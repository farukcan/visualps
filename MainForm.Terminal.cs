using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual_PowerShell.Helpers;

namespace Visual_PowerShell
{
    public partial class MainForm
    {
        PowerShell _ps;
        List<string> scripts = new List<string>();
        int runningScriptIndex = 0;
        private async Task LaunchAsync()
        {
            if (repositoryList.SelectedItem is null) return;
            if (commandList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            var command = repo.Commands[commandList.SelectedIndex];
            if (command.Scripts.Count == 0)
            {
                MessageBox.Show("Please add scripts to the commands.");
                return;
            }
            await LaunchingMode();
            scripts.Clear();
            runningScriptIndex = 0;
            TerminalLog($"\r\n     -----------");
            TerminalLog($"\r\n     Directory: {workplaceInput.Text}");
            int i = 0;
            foreach (var script in command.Scripts)
            {
                i++;
                TerminalLog($"\r\n     {i})   " + script);
                scripts.Add(script);
            }
            TerminalLog($"\r\n     ----------- \r\n");
            ScrollTerminalArea();
            await RunScripts();
        }

        private async Task RunScripts()
        {
            PowerShell ps = PowerShell.Create();
            var regex = new Regex(@"\{.*?:.*?\}");
            var matches = regex.Matches(scripts[runningScriptIndex]).Distinct(new RegexMatchComparer());
            if (matches.Count<Match>() > 0 && launchedFromBot && Bot.Instance.chatId is not null)
            {
                await Bot.Instance.EndLog();
            }
            foreach (Match match in matches)
            {
                var type = match.Value.Split(':')[0].TrimStart('{').ToLower();
                var key = match.Value.Split(':')[1].TrimEnd('}');
                string value = string.Empty;
                switch (type)
                {
                    case "text":
                        if (launchedFromBot && Bot.Instance.chatId is not null)
                        {
                            await Bot.Instance.Prompt("Enter Text", key);
                            SetBotState(Bot.Instance.state);
                            // wait while state is not lauching
                            while (Bot.Instance.state == Bot.State.Input)
                            {
                                await Task.Delay(250);
                            }
                            value = Bot.Instance.lastValue;
                        }
                        else
                        {
                            (bool haveValue, value) = Prompt.ShowDialog(key, "Enter text", "Enter");
                            if (!haveValue)
                            {
                                await Cancel();
                                return;
                            }
                        }
                        break;
                    case "file":
                        if (launchedFromBot && Bot.Instance.chatId is not null)
                        {
                            await Bot.Instance.FolderDialog(workplaceInput.Text, true, false, key);
                            SetBotState(Bot.Instance.state);
                            // wait while state is not lauching
                            while (Bot.Instance.state == Bot.State.FolderInput)
                            {
                                await Task.Delay(250);
                            }
                            value = Bot.Instance.currentPath;
                        }
                        else
                        {
                            var fileDialog = new OpenFileDialog();
                            fileDialog.Title = $"Open {key}";
                            fileDialog.DefaultExt = "file";
                            fileDialog.ShowDialog();
                            value = fileDialog.FileName;
                        }
                        break;
                    case "save":
                        if (launchedFromBot && Bot.Instance.chatId is not null)
                        {
                            await Bot.Instance.FolderDialog(workplaceInput.Text, false, true, "(1/2) Folder for " + key);
                            SetBotState(Bot.Instance.state);
                            // wait while state is not lauching
                            while (Bot.Instance.state == Bot.State.FolderInput)
                            {
                                await Task.Delay(250);
                            }
                            var folder = Bot.Instance.currentPath;
                            await Bot.Instance.Prompt("Enter Filename (ex: test.txt)", "(2/2) Filename for " + key);
                            SetBotState(Bot.Instance.state);
                            // wait while state is not lauching
                            while (Bot.Instance.state == Bot.State.Input)
                            {
                                await Task.Delay(250);
                            }
                            value = Path.Combine(folder, Bot.Instance.lastValue);
                        }
                        else
                        {
                            var saveDialog = new SaveFileDialog();
                            saveDialog.Title = $"Save {key}";
                            saveDialog.DefaultExt = "file";
                            saveDialog.Filter = "All files (*.*)|*.*";
                            saveDialog.ShowDialog();
                            value = saveDialog.FileName;
                        }
                        break;
                    case "folder":
                        if (launchedFromBot && Bot.Instance.chatId is not null)
                        {
                            await Bot.Instance.FolderDialog(workplaceInput.Text, false, true, key);
                            SetBotState(Bot.Instance.state);
                            // wait while state is not lauching
                            while (Bot.Instance.state == Bot.State.FolderInput)
                            {
                                await Task.Delay(250);
                            }
                            value = Bot.Instance.currentPath;
                        }
                        else
                        {
                            var folderDialog = new FolderBrowserDialog();
                            folderDialog.Description = $"Select Folder '{key}'";
                            folderDialog.ShowDialog();
                            value = folderDialog.SelectedPath;
                        }
                        break;
                    default:
                        MessageBox.Show("Unknown Prompt Type : " + type);
                        break;
                }
                for (int i = runningScriptIndex; i < scripts.Count; i++)
                {
                    scripts[i] = scripts[i].Replace(match.Value, value).TrimEnd();
                }
            }
            if (matches.Count<Match>() > 0 && launchedFromBot && Bot.Instance.chatId is not null)
            {
                await Bot.Instance.StartLog();
            }
            var script = scripts[runningScriptIndex];
            runningScriptIndex++;
            ps.AddScript($"Set-Location -Path '{workplaceInput.Text}'");
            ps.AddScript(script);
            _ps = ps;
            ps.AddCommand("Out-String").AddParameter("Stream", true);

            var output = new PSDataCollection<string>();
            output.DataAdded += new EventHandler<DataAddedEventArgs>(ProcessOutput);
            cancelButtons.Enabled = true;

            var asyncToken = ps.BeginInvoke<object, string>(null, output);

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += async (obj, args) =>
            {
                while (!(asyncToken.IsCompleted || ps.HadErrors))
                {
                    Thread.Sleep(100);
                }
                foreach (var warningRecord in ps.Streams.Warning)
                {
                    TerminalLog("\r\n" + warningRecord.ToString());
                }
                if (ps.HadErrors)
                {
                    foreach (var errorRecord in ps.Streams.Error)
                    {
                        TerminalLog("\r\n" + errorRecord.ToString());
                    }
                    TerminalLog($"\r\n     ---\r\n  ({runningScriptIndex}/{scripts.Count} Failed: {script})");
                }
                else
                {
                    TerminalLog($"\r\n     ---\r\n ({runningScriptIndex}/{scripts.Count} Success: {script})");
                }
                ScrollTerminalArea();
                if (runningScriptIndex < scripts.Count && !ps.HadErrors)
                {
                    await RunScripts();
                }
                else
                {
                    if (backToCommands.Checked && !ps.HadErrors)
                    {
                        launcherTabs.InvokeIfRequired(() =>
                        {
                            launcherTabs.SelectedTab = commandsTab;
                        });
                    }
                    await LaunchFreeMode();
                }
            };
            worker.RunWorkerAsync();
        }

        public void TerminalLog(string text)
        {
            terminalArea.InvokeIfRequired(() =>
            {
                terminalArea.Text += text;
                if (launchedFromBot && Bot.Instance.chatId is not null && text.Trim().Length != 0)
                {
                    Bot.Instance.SendLog(text.Trim());
                }
            });
        }

        void ScrollTerminalArea()
        {
            terminalArea.InvokeIfRequired(() =>
            {
                terminalArea.SelectionStart = terminalArea.TextLength;
                terminalArea.ScrollToCaret();
            });
        }

        void ProcessOutput(object? sender, DataAddedEventArgs eventArgs)
        {
            var collection = sender as PSDataCollection<string>;
            if (null != collection)
            {
                var outputItem = collection[eventArgs.Index];
                terminalArea.InvokeIfRequired(() =>
                {
                    TerminalLog("\r\n" + outputItem.ToString());
                    ScrollTerminalArea();
                });
            }
        }
        async Task Cancel()
        {
            TerminalLog($"\r\n  (Cancelled Manually)");
            if (_ps is not null)
            {
                _ps.Stop();
                _ps = null;
            }
            await LaunchFreeMode();
        }

        async Task LaunchingMode()
        {
            mainTabControl.InvokeIfRequired(() =>
            {
                launcherTabs.SelectedTab = terminal;
                ((Control)commandsTab).Enabled = false;
                ((Control)scriptsTab).Enabled = false;
            });
            if (launchedFromBot && Bot.Instance.chatId is not null)
            {
                await Bot.Instance.StartLog();
            }
        }

        async Task LaunchFreeMode()
        {
            if (launchedFromBot && Bot.Instance.chatId is not null)
            {
                await Bot.Instance.EndLog();
            }
            mainTabControl.InvokeIfRequired(() =>
            {
                SetBotState(Bot.State.Command);
                cancelButtons.Enabled = false;
                ((Control)scriptsTab).Enabled = true;
                ((Control)commandsTab).Enabled = true;
                launchedFromBot = false;
            });
        }
    }
}