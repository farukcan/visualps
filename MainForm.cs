using System.Threading;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net.Http;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual_PowerShell.Helpers;
using Visual_PowerShell.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Command = Visual_PowerShell.Models.Command;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Speech.Synthesis;
using Prompt = Visual_PowerShell.Helpers.Prompt;
using System.Drawing.Printing;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;

namespace Visual_PowerShell
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnRepositorySelect(object sender, EventArgs e)
        {
            if (repositoryList.SelectedItem is null) return;
            // get string
            OnLoadRepository();
        }
        private void OnLoadRepository()
        {
            if (repositoryList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            repoAddress.Text = repo.Address;
            repoNameInput.Text = repo.Name;
            websiteInput.Text = repo.Website;
            authorInput.Text = repo.Author;
            UpdateCommandList();
        }
        private void UpdateCommandList()
        {
            if (repositoryList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            int index = commandList.SelectedIndex;
            commandList.Items.Clear();
            foreach (Command command in repo.Commands)
            {
                commandList.Items.Add(command.Name);
            }
            SetCommandIndex(index);
        }
        private int commandIndex;
        private void SetCommandIndex(int index)
        {
            if (index >= 0 && index < commandList.Items.Count)
            {
                commandList.SelectedIndex = index;
                commandIndex = index;
            }
            else
            {
                ((Control)scriptsTab).Enabled = false;
                scriptList.Items.Clear();
                scriptList.Items.Add("Select a command to edit its scripts");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void commandsTab_Click(object sender, EventArgs e)
        {

        }

        private void commandList_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateScripts();
        }

        private void UpdateScripts()
        {
            if (repositoryList.SelectedItem is null) return;
            if (commandList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            var command = repo.Commands[commandList.SelectedIndex];
            scriptList.Items.Clear();
            foreach (string script in command.Scripts)
            {
                scriptList.Items.Add(script);
            }
            ((Control)scriptsTab).Enabled = true;
        }

        public List<Repository> commandRepositories = new List<Repository>();
        private async void Form_Load(object sender, EventArgs e)
        {
            SyncStyleLabel();
            workplaceInput.Text = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if( !string.IsNullOrEmpty(Properties.Settings.Default.Workspace))
            {
                workplaceInput.Text = Properties.Settings.Default.Workspace;
            }
            packageList.Text = Properties.Settings.Default.RepositoryPackages;
            backToCommands.Checked = Properties.Settings.Default.BackToCommands;
            defaultAuthor.Text = Properties.Settings.Default.DefaultAuthor;
            defaultWebsite.Text = Properties.Settings.Default.DefaultWebsite;
            botToken.Text = Properties.Settings.Default.BotToken;
            launchBotOnStart.Checked = Properties.Settings.Default.LaunchBotOnStart;
            mainTabControl.SelectedTab = repositories;
            mainTabControl.Enabled = false;
            await LoadRepositoriesFromSettings();
            await RetreivePackages();
            mainTabControl.Enabled = true;
            mainTabControl.SelectedTab = launcher;

            SetRepositoryIndex(Properties.Settings.Default.RepositoryIndex);
            commandList.Focus();
            if (launchBotOnStart.Checked)
            {
                mainTabControl.SelectedTab = settingsTab;
                runBot.PerformClick();
            }
        }
        async Task LoadRepositoriesFromSettings()
        {
            // split do lines
            var addresses = Properties.Settings.Default.CommandRepositories.Split(
                new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );
            foreach ( var address in addresses )
            {
                if (address.StartsWith("http"))
                {
                    await LoadFromURL(address);
                }
                else
                {
                    if (File.Exists(address))
                    {
                        LoadFile(address);
                    }
                }
            }
        }
        void SaveSettings()
        {
            StringBuilder repoAdresses = new StringBuilder();
            foreach(Repository repository in commandRepositories )
            {
                if (repository.Address.StartsWith("http") || File.Exists(repository.Address))
                {
                    repoAdresses.AppendLine(repository.Address);
                }
            }
            Properties.Settings.Default.CommandRepositories = repoAdresses.ToString();
            Properties.Settings.Default.RepositoryPackages = packageList.Text;
            Properties.Settings.Default.Workspace = workplaceInput.Text;
            Properties.Settings.Default.RepositoryIndex = repositoryList.SelectedIndex;
            Properties.Settings.Default.BackToCommands = backToCommands.Checked;
            Properties.Settings.Default.DefaultAuthor = defaultAuthor.Text;
            Properties.Settings.Default.DefaultWebsite = defaultWebsite.Text;
            Properties.Settings.Default.BotToken = botToken.Text;
            Properties.Settings.Default.LaunchBotOnStart = launchBotOnStart.Checked;
            Properties.Settings.Default.Save();
        }
        private void UpdateRepositoryList()
        {
            int index = repositoryList.SelectedIndex;
            repositoryList.Items.Clear();
            foreach (Repository repository in commandRepositories)
            {
                repositoryList.Items.Add($"{repository.Name} (by {repository.Author})");
            }
            SetRepositoryIndex(index);
            if (repositoryList.SelectedItem is null) SetRepositoryIndex(0);
        }
        private int repositoryIndex;
        private void SetRepositoryIndex(int index)
        {
            if (index >= 0 && index < repositoryList.Items.Count)
            {
                repositoryIndex = index;
                repositoryList.SelectedIndex = index;
            }
        }

        private void newRepoButton_Click(object sender, EventArgs e)
        {
            (bool haveValue, string promptValue) = Prompt.ShowDialog("Repository Name", "New Repository","Create");
            if (!haveValue || string.IsNullOrEmpty(promptValue)) return;
            commandRepositories.Insert(0,new Repository()
            {
                Name = promptValue,
                Author = defaultAuthor.Text,
                Website = defaultWebsite.Text,
                Address = "Do not forget to save!"
            });
            UpdateRepositoryList();
            SetRepositoryIndex(0); 
        }

        private void deleteRepo_Click(object sender, EventArgs e)
        {
            if (repositoryList.SelectedItem is null) return;
            commandRepositories.RemoveAt(repositoryList.SelectedIndex);
            UpdateRepositoryList();
            SetRepositoryIndex(0);
        }

        private void addLocal_Click(object sender, EventArgs e)
        {
            OpenFile();
        }
        void OpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Title = "Load Local JSON";
            dialog.DefaultExt = "json";
            dialog.Filter = "JSON files (*.json)|*.json";
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.ShowDialog();
            try
            {
                foreach (var fileName in dialog.FileNames)
                {
                    LoadFile(fileName);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        void LoadFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string json = reader.ReadToEnd();
                Repository repository = JsonConvert.DeserializeObject<Repository>(json);
                repository.Address = fileName;
                int updateRepositoryIndex = commandRepositories.FindLastIndex((r)=>r.Address==repository.Address);
                if(updateRepositoryIndex!= -1)
                {
                    commandRepositories[updateRepositoryIndex] = repository;
                }
                else
                {
                    commandRepositories.Add(repository);
                }
                UpdateRepositoryList();
                SetRepositoryIndex(commandRepositories.Count-1);
            }
        }

        private async void addRemote_Click(object sender, EventArgs e)
        {
            (bool haveValue, string promptValue) = Prompt.ShowDialog("JSON URL (Gist, API, CDN)", "Download Remote JSON","Download");
            if (!haveValue || string.IsNullOrEmpty(promptValue)) return;

            await LoadFromURL(promptValue,true);
        }
        private async Task LoadFromURL(string url,bool setRepoIndex=false)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(ParseGistURL(url));
                    var json = await response.Content.ReadAsStringAsync();
                    Repository repository = JsonConvert.DeserializeObject<Repository>(json);
                    repository.Address = url;
                    int updateRepositoryIndex = commandRepositories.FindLastIndex((r) => r.Address == repository.Address);
                    if (updateRepositoryIndex != -1)
                    {
                        commandRepositories[updateRepositoryIndex] = repository;
                    }
                    else
                    {
                        commandRepositories.Add(repository);
                    }
                    UpdateRepositoryList();
                    if(setRepoIndex) SetRepositoryIndex(commandRepositories.Count-1);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, url);
            }
            // done
        }

        private string ParseGistURL(string url)
        {
            if (url.StartsWith("https://gist.github.com/"))
            {
                url = url.Replace("https://gist.github.com/", "https://gist.githubusercontent.com/");
                if (!url.Contains("/raw"))
                {
                    url = url + (url.EndsWith("/") ? "raw?update=" : "/raw?update=") +DateTime.Now.ToFileTime();
                }
            }
            return url;
        }

        private async Task RetreivePackages()
        {
            // split to lines
            var packages = packageList.Text.Split(
                new string[] { "\r\n", "\r", "\n" },
                StringSplitOptions.None
            );
            // foreach package
            foreach ( var package in packages )
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        var response = await client.GetAsync(ParseGistURL(package));
                        var json = await response.Content.ReadAsStringAsync();
                        var list = JsonConvert.DeserializeObject<List<string>>(json);
                        foreach (var url in list)
                        {
                            await LoadFromURL(url);
                        }
                    }
                }
                catch(Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            UpdateRepositoryList();
        }

        private void newCommand_Click(object sender, EventArgs e)
        {
            if (repositoryList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            (bool haveValue, string promptText) = Prompt.ShowDialog("Enter command name", "New command", "Create");
            if (!haveValue ||string.IsNullOrEmpty(promptText)) return;

            repo.Commands.Add(new Command()
            {
                Name= promptText,
                Scripts = new List<string> { }
            });
            UpdateCommandList();
            SetCommandIndex(repo.Commands.Count - 1);
        }

        private void deleteCommand_Click(object sender, EventArgs e)
        {
            if (repositoryList.SelectedItem is null) return;
            if (commandList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            int index = commandList.SelectedIndex;
            repo.Commands.RemoveAt(index);
            UpdateCommandList();
        }

        private void saveRepo_Click(object sender, EventArgs e)
        {
            SaveRepository();
        }
        void SaveRepository()
        {
            if (repositoryList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save Repository as JSON File";
            dialog.DefaultExt = "json";
            dialog.Filter = "JSON files (*.json)|*.json";
            if (!repo.Address.StartsWith("http") && File.Exists(repo.Address))
            {
                dialog.InitialDirectory = Path.GetDirectoryName(repo.Address);
                dialog.FileName = Path.GetFileName(repo.Address);
            }
            dialog.CheckPathExists = true;
            dialog.ShowDialog(this);
            if (string.IsNullOrEmpty(dialog.FileName)) return;
            repo.Address = dialog.FileName;
            repo.Author = authorInput.Text;
            repo.Name = repoNameInput.Text;
            repo.Website = websiteInput.Text;
            // Write
            TextWriter txt = new StreamWriter(dialog.FileName);
            var json = JsonConvert.SerializeObject(repo, Formatting.Indented);
            txt.Write(json);
            txt.Close();
            UpdateRepositoryList();
        }

        private void settingsTab_Click(object sender, EventArgs e)
        {

        }

        private void deleteScript_Click(object sender, EventArgs e)
        {
            if (scriptList.SelectedItem is null) return;
            if (repositoryList.SelectedItem is null) return;
            if (commandList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            var command = repo.Commands[commandList.SelectedIndex];
            command.Scripts.RemoveAt(scriptList.SelectedIndex);
            UpdateScripts();
        }

        private void newScript_Click(object sender, EventArgs e)
        {
            if (repositoryList.SelectedItem is null) return;
            if (commandList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            var command = repo.Commands[commandList.SelectedIndex];
            (bool haveValue,string promptText) = Prompt.ShowDialog("Enter script ; {text:YourTextInput} , {file:YourFileInput} , {save:YourFileInput}", "New script", "Create");
            if (!haveValue || string.IsNullOrEmpty(promptText)) return;
            command.Scripts.Add(promptText);
            UpdateScripts();
            scriptList.SelectedIndex = command.Scripts.Count - 1;
        }
        bool launchedFromBot = false;
        private async void launchButton_Click(object sender, EventArgs e)
        {
            await LaunchAsync();
        }
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
            LaunchingMode();
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
            foreach (Match match in matches)
            {
                var type = match.Value.Split(':')[0].TrimStart('{').ToLower();
                var key = match.Value.Split(':')[1].TrimEnd('}');
                string value = string.Empty;
                switch (type)
                {
                    case "text":
                        if(launchedFromBot && Bot.Instance.chatId is not null)
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
                        if(launchedFromBot && Bot.Instance.chatId is not null){
                            await Bot.Instance.FolderDialog(workplaceInput.Text, true, false,key);
                            SetBotState(Bot.Instance.state);
                            // wait while state is not lauching
                            while (Bot.Instance.state == Bot.State.FolderInput)
                            {
                                await Task.Delay(250);
                            }
                            value = Bot.Instance.currentPath;
                        }else{
                            var fileDialog = new OpenFileDialog();
                            fileDialog.Title = $"Open {key}";
                            fileDialog.DefaultExt= "file" ;
                            fileDialog.ShowDialog();
                            value = fileDialog.FileName;
                        }
                        break;
                    case "save":
                        if(launchedFromBot && Bot.Instance.chatId is not null){
                            await Bot.Instance.FolderDialog(workplaceInput.Text, false, true,"(1/2) Folder for "+key);
                            SetBotState(Bot.Instance.state);
                            // wait while state is not lauching
                            while (Bot.Instance.state == Bot.State.FolderInput)
                            {
                                await Task.Delay(250);
                            }
                            var folder = Bot.Instance.currentPath;
                            await Bot.Instance.Prompt("Enter Filename (ex: test.txt)", "(2/2) Filename for "+key);
                            SetBotState(Bot.Instance.state);
                            // wait while state is not lauching
                            while (Bot.Instance.state == Bot.State.Input)
                            {
                                await Task.Delay(250);
                            }
                            value = Path.Combine(folder,Bot.Instance.lastValue);
                        }else{
                            var saveDialog = new SaveFileDialog();
                            saveDialog.Title = $"Save {key}";
                            saveDialog.DefaultExt = "file";
                            saveDialog.Filter = "All files (*.*)|*.*";
                            saveDialog.ShowDialog();
                            value = saveDialog.FileName;
                        }
                        break;
                    case "folder":
                        if(launchedFromBot && Bot.Instance.chatId is not null){
                            await Bot.Instance.FolderDialog(workplaceInput.Text, false, true,key);
                            SetBotState(Bot.Instance.state);
                            // wait while state is not lauching
                            while (Bot.Instance.state == Bot.State.FolderInput)
                            {
                                await Task.Delay(250);
                            }
                            value = Bot.Instance.currentPath;
                        }else{
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
                for(int i=runningScriptIndex; i < scripts.Count; i++)
                {
                    scripts[i] = scripts[i].Replace(match.Value, value).TrimEnd();
                }
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
                if (runningScriptIndex< scripts.Count && !ps.HadErrors)
                {
                    await RunScripts();
                }
                else
                {
                    LaunchFreeMode();
                    if (backToCommands.Checked && !ps.HadErrors)
                    {
                        launcherTabs.InvokeIfRequired(() =>
                        {
                            launcherTabs.SelectedTab = commandsTab;
                        });
                    }
                }
            };
            worker.RunWorkerAsync();
        }

        public void TerminalLog(string text)
        {
            terminalArea.InvokeIfRequired(async() =>
            {
                terminalArea.Text += text;
                if (launchedFromBot && Bot.Instance.chatId is not null && text.Trim().Length != 0)
                {
                    await Bot.Instance.SendText(text.Trim());
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
                terminalArea.InvokeIfRequired(async () =>
                {
                    TerminalLog("\r\n" + outputItem.ToString());
                    ScrollTerminalArea();
                });
            }
        }

        private void workplaceInput_TextChanged(object sender, EventArgs e)
        {
            this.Text = "Visual PowerShell - " + workplaceInput.Text;
        }

        private void selectFolder_Click(object sender, EventArgs e)
        {
            // Select Folder
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = true;
            folderDialog.InitialDirectory = workplaceInput.Text;
            DialogResult result = folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                workplaceInput.Text = folderDialog.SelectedPath;
            }
        }

        private async void cancelButtons_Click(object sender, EventArgs e)
        {
            await Cancel();
        }
        async Task Cancel()
        {
            TerminalLog($"\r\n  (Cancelled Manually)");
            LaunchFreeMode();
            if (_ps is not null)
            {
                _ps.Stop();
                _ps = null;
            }
        }

        void LaunchingMode()
        {
            launcherTabs.SelectedTab = terminal;
            ((Control)commandsTab).Enabled = false;
            ((Control)scriptsTab).Enabled = false;
        }

        void LaunchFreeMode()
        {
            SetBotState(Bot.State.Command);
            cancelButtons.InvokeIfRequired(() =>
            {
                cancelButtons.Enabled = false;
                ((Control)scriptsTab).Enabled = true;
                ((Control)commandsTab).Enabled = true;
            });
            launchedFromBot = false;
        }

        private async void launchOnClick(object sender, EventArgs e)
        {
            if (launchOnClickCheck.Checked)
            {
                await LaunchAsync();
            }
        }

        private async void launchOnDoubleClick(object sender, EventArgs e)
        {
            await LaunchAsync();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void scriptList_DoubleClick(object sender, EventArgs e)
        {
            EditScript();
        }

        void EditScript()
        {
            if (repositoryList.SelectedItem is null) return;
            if (commandList.SelectedItem is null) return;
            if (scriptList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            var command = repo.Commands[commandList.SelectedIndex];
            var script = command.Scripts[scriptList.SelectedIndex];
            (bool haveValue, string newValue) = Prompt.ShowDialog("Enter scripts", "Edit script", "Edit", script);
            if (!haveValue || string.IsNullOrEmpty(newValue)) return;
            command.Scripts[scriptList.SelectedIndex] = newValue;
            UpdateScripts();
        }

        private void commandUp_Click(object sender, EventArgs e)
        {
            if (repositoryList.SelectedItem is null) return;
            if (commandList.SelectedItem is null) return;
            if (commandList.SelectedIndex < 1) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            int index = commandList.SelectedIndex;
            var swap = repo.Commands[index];
            repo.Commands[index] = repo.Commands[index - 1];
            repo.Commands[index - 1] = swap;
            UpdateCommandList();
            SetCommandIndex(index - 1);
        }

        private void commandDown_Click(object sender, EventArgs e)
        {
            if (repositoryList.SelectedItem is null) return;
            if (commandList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            int index = commandList.SelectedIndex;
            if (index >= (repo.Commands.Count - 1)) return;
            var swap = repo.Commands[index];
            repo.Commands[index] = repo.Commands[index + 1];
            repo.Commands[index + 1] = swap;
            UpdateCommandList();
            SetCommandIndex(index + 1);
        }

        private void scriptUp_Click(object sender, EventArgs e)
        {
            if (repositoryList.SelectedItem is null) return;
            if (commandList.SelectedItem is null) return;
            if (scriptList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            var command = repo.Commands[commandList.SelectedIndex];
            int index = scriptList.SelectedIndex;
            if(index<1) return;
            var swap = command.Scripts[index];
            command.Scripts[index] = command.Scripts[index - 1];
            command.Scripts[index - 1] = swap;
            UpdateScripts();
            scriptList.SelectedIndex = index - 1;
        }

        private void scriptDown_Click(object sender, EventArgs e)
        {
            if (repositoryList.SelectedItem is null) return;
            if (commandList.SelectedItem is null) return;
            if (scriptList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            var command = repo.Commands[commandList.SelectedIndex];
            int index = scriptList.SelectedIndex;
            if (index >= (command.Scripts.Count - 1)) return;
            var swap = command.Scripts[index];
            command.Scripts[index] = command.Scripts[index + 1];
            command.Scripts[index + 1] = swap;
            UpdateScripts();
            scriptList.SelectedIndex = index + 1;
        }

        private void repoUp_Click(object sender, EventArgs e)
        {
            if (repositoryList.SelectedItem is null) return;
            int index = repositoryList.SelectedIndex;
            if (index < 1) return;
            var swap = commandRepositories[index];
            commandRepositories[index] = commandRepositories[index - 1];
            commandRepositories[index - 1] = swap;
            UpdateRepositoryList();
            SetRepositoryIndex(index - 1);
        }

        private void repoDown_Click(object sender, EventArgs e)
        {
            if (repositoryList.SelectedItem is null) return;
            int index = repositoryList.SelectedIndex;
            if (index >= (commandRepositories.Count - 1)) return;
            var swap = commandRepositories[index];
            commandRepositories[index] = commandRepositories[index + 1];
            commandRepositories[index + 1] = swap;
            UpdateRepositoryList();
            SetRepositoryIndex(index + 1);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/farukcan/visualps");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://github.com/farukcan/visualps/issues");
        }

        void OpenURL(string url)
        {
            Process.Start(new ProcessStartInfo(url)
            {
                UseShellExecute = true
            });
        }

        private void repositoryList_DoubleClick(object sender, EventArgs e)
        {
            // open repo address URL
            if (repositoryList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            // if starts with http
            if(repo.Address.StartsWith("http"))
            {
                OpenURL(repo.Address);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && trayEnabled.Checked)
            {
                SaveSettings();
                Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(3000, "I'm here!", "Visual Powershell minimized.", ToolTipIcon.Info);
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            TrayIconClick();
        }

        private void notifyIcon_MouseClick(object sender, EventArgs e)
        {
            TrayIconClick();
        }
        void TrayIconClick()
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            TrayIconClick();
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private async void commandList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    SetRepositoryIndex(0);
                    break;
                case Keys.F2:
                    SetRepositoryIndex(1);
                    break;
                case Keys.F3:
                    SetRepositoryIndex(2);
                    break;
                case Keys.F4:
                    SetRepositoryIndex(3);
                    break;
                case Keys.F5:
                    SetRepositoryIndex(4);
                    break;
                case Keys.F6:
                    SetRepositoryIndex(5);
                    break;
                case Keys.F7:
                    SetRepositoryIndex(6);
                    break;
                case Keys.F8:
                    SetRepositoryIndex(7);
                    break;
                case Keys.F9:
                    SetRepositoryIndex(8);
                    break;
                case Keys.D1:
                    SetCommandIndex(0);
                    break;
                case Keys.D2:
                    SetCommandIndex(1);
                    break;
                case Keys.D3:
                    SetCommandIndex(2);
                    break;
                case Keys.D4:
                    SetCommandIndex(3);
                    break;
                case Keys.D5:
                    SetCommandIndex(4);
                    break;
                case Keys.D6:
                    SetCommandIndex(5);
                    break;
                case Keys.D7:
                    SetCommandIndex(6);
                    break;
                case Keys.D8:
                    SetCommandIndex(7);
                    break;
                case Keys.D9:
                    SetCommandIndex(8);
                    break;
                case Keys.Enter:
                case Keys.Space:
                    await LaunchAsync();
                    break;
                case Keys.W:
                    SetCommandIndex(commandList.SelectedIndex - 1);
                    break;
                case Keys.S:
                    SetCommandIndex(commandList.SelectedIndex + 1);
                    break;
                case Keys.Q:
                case Keys.A:
                    launcherTabs.SelectedTab = terminal;
                    break;
                case Keys.E:
                case Keys.D:
                    if(((Control)scriptsTab).Enabled){
                        launcherTabs.SelectedTab = scriptsTab;
                    }else{
                        launcherTabs.SelectedTab = terminal;
                    }
                    break;
                case Keys.Subtract:
                case Keys.Delete:
                    deleteCommand.PerformClick();
                    break;
                case Keys.Add:
                    newCommand.PerformClick();
                    break;
                case Keys.R:
                    // rename command
                    if (commandList.SelectedItem is null) return;
                    var command = commandRepositories[repositoryList.SelectedIndex].Commands[commandList.SelectedIndex];
                    (bool haveValue, string promptValue) = Prompt.ShowDialog("Enter commands name", "Rename " + command.Name, "Rename", command.Name);
                    if (haveValue)
                    {
                        command.Name = promptValue;
                        UpdateCommandList();
                    }
                    break;
                default:
                    break;
            }
        }

        private async void terminalArea_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode){
                case Keys.Subtract:
                case Keys.Back:
                case Keys.Delete:
                    terminalArea.Text = string.Empty;
                    break;
                case Keys.Escape:
                    await Cancel();
                    commandList.Focus();
                    break;
                case Keys.Enter:
                case Keys.E:
                case Keys.D:
                case Keys.Space:
                    launcherTabs.SelectedTab = commandsTab;
                    commandList.Focus();
                    break;
                case Keys.Q:
                case Keys.A:
                    if(((Control)scriptsTab).Enabled){
                        launcherTabs.SelectedTab = scriptsTab;
                    }else{
                        launcherTabs.SelectedTab = commandsTab;
                    }
                    break;
                default:
                    break;
            }
        }

        private void launcherTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            FocusLists();
        }

        void FocusLists(){
            if(launcherTabs.SelectedTab == commandsTab)
            {
                commandList.Focus();
            }else if(launcherTabs.SelectedTab == terminal)
            {
                terminalArea.Focus();
            }else if(launcherTabs.SelectedTab == scriptsTab)
            {
                scriptList.Focus();
            }
        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainTabControl.SelectedTab == launcher)
            { 
                FocusLists();
            }else if(mainTabControl.SelectedTab == repositories)
            {
                repositoryList.Focus();
            }
        }

        void SetScriptIndex(int index){
            if (index >= 0 && index < scriptList.Items.Count){
                scriptList.SelectedIndex = index;
            }
        }

        private void scriptList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                case Keys.Space:
                    EditScript();
                    break;
                case Keys.Subtract:
                case Keys.Delete:
                    deleteScript.PerformClick();
                    break;
                case Keys.Add:
                    newScript.PerformClick();
                    break;
                case Keys.W:
                    SetScriptIndex(scriptList.SelectedIndex - 1);
                    break;
                case Keys.S:
                    SetScriptIndex(scriptList.SelectedIndex + 1);
                    break;
                case Keys.Q:
                case Keys.A:
                    launcherTabs.SelectedTab = commandsTab;
                    break;
                case Keys.E:
                case Keys.D:
                    launcherTabs.SelectedTab = terminal;
                    break;
            }
        }

        private void repositoryList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Subtract:
                case Keys.Delete:
                    deleteRepo.PerformClick();
                    break;
                case Keys.Add:
                    newRepoButton.PerformClick();
                    break;
                case Keys.W:
                    SetRepositoryIndex(repositoryList.SelectedIndex - 1);
                    break;
                case Keys.S:
                    SetRepositoryIndex(repositoryList.SelectedIndex + 1);
                    break;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    SaveRepository();
                    break;
                case Keys.Control | Keys.O:
                    OpenFile();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
            {
                saveRepo.PerformClick();
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            }
        }

        private void colorPicker_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialogForBackground = new();
            colorDialogForBackground.Color = terminalArea.BackColor;
            colorDialogForBackground.ShowDialog();
            Properties.Settings.Default.TerminalBackgroundColor = colorDialogForBackground.Color;
            SyncStyleLabel();
            ColorDialog colorDialogForText = new();
            colorDialogForText.Color = terminalArea.ForeColor;
            colorDialogForText.ShowDialog();
            Properties.Settings.Default.TerminalTextColor = colorDialogForText.Color;
            SyncStyleLabel();
        }
        void SyncStyleLabel()
        {
            terminalArea.BackColor = Properties.Settings.Default.TerminalBackgroundColor;
            terminalArea.ForeColor = Properties.Settings.Default.TerminalTextColor;
            colorPicker.ForeColor = terminalArea.ForeColor;
            colorPicker.BackColor = terminalArea.BackColor;
        }
        bool botWorkspaceSelectMode = false;
        private async void runBot_Click(object sender, EventArgs e)
        {
            if(Bot.Instance.client is null)
            {
                Bot.Instance.SetToken(botToken.Text);
                Bot.Instance.handler = async (update) =>
                {
                    if(update.Type == UpdateType.Message || update.Type == UpdateType.CallbackQuery)
                    {
                        if(update.Type == UpdateType.CallbackQuery){
                            Bot.Instance.chatId = update.CallbackQuery.Message.Chat.Id;
                        }else{
                            Bot.Instance.chatId = update.Message.Chat.Id;
                        }
                        runBot.InvokeIfRequired(() =>
                        {
                            runBot.Text = "Stop Listening";
                        });
                       
                        Bot.Instance.handler = async (update) =>
                        {
                            string text;
                            if (update.Type == UpdateType.Message)
                            {
                                text = update.Message.Text;
                                if(text == "🛠️ Commands"){
                                    await Bot.Instance.SendRepositoryAsync(commandRepositories[repositoryIndex]);
                                    SetBotState(Bot.State.Command);
                                    return;
                                }else if(text == "📚 Repositories"){
                                    await Bot.Instance.SendRepositoriesAsync(commandRepositories);
                                    SetBotState(Bot.State.Repository);
                                    return;
                                }else if(text == "📁 Set Workspace"){
                                    await Bot.Instance.FolderDialog(workplaceInput.Text);
                                    SetBotState(Bot.State.FolderInput);
                                    botWorkspaceSelectMode = true;
                                    return;
                                }
                            }else if(update.Type == UpdateType.CallbackQuery){
                                text = update.CallbackQuery.Data;
                                await Bot.Instance.client.DeleteMessageAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId);
                            }else{
                                MessageBox.Show(update.Type.ToString());
                                return;
                            }
                            switch (Bot.Instance.state)
                            {
                                case Bot.State.Command:
                                    if ( text == "[Switch Repository]")
                                    {
                                        await Bot.Instance.SendRepositoriesAsync(commandRepositories);
                                        SetBotState(Bot.Instance.state);
                                        break;
                                    }
                                    // search for command
                                    var repo = commandRepositories[repositoryIndex];
                                    for (int i=0; i < repo.Commands.Count; i++)
                                    {
                                        if (repo.Commands[i].Name == text)
                                        {
                                            mainTabControl.InvokeIfRequired(() =>
                                            {
                                                TrayIconClick();
                                                SetCommandIndex(i);
                                                SetBotState(Bot.State.Launching);
                                                launchedFromBot = true;
                                                mainTabControl.SelectedTab = launcher;
                                                launcherTabs.SelectedTab = commandsTab;
                                                launchButton.PerformClick();
                                            });
                                            return;
                                        }
                                    }
                                    //await Bot.Instance.SendText("Command Not Found");
                                    //await Bot.Instance.SendRepositoryAsync(commandRepositories[repositoryIndex]);
                                    SetBotState(Bot.Instance.state);
                                    break;
                                case Bot.State.Repository:
                                    if (text == "[Back]")
                                    {
                                        await Bot.Instance.SendRepositoryAsync(commandRepositories[repositoryIndex]);
                                        SetBotState(Bot.Instance.state);
                                        break;
                                    }
                                    // search for repository
                                    for(int i=0; i< commandRepositories.Count; i++)
                                    {
                                        if (commandRepositories[i].Name == text)
                                        {
                                            mainTabControl.InvokeIfRequired(() => {
                                                SetRepositoryIndex(i);
                                            });
                                            await Bot.Instance.SendRepositoryAsync(commandRepositories[i]);
                                            return;
                                        }
                                    }
                                    //await Bot.Instance.SendText("Repository Not Found");
                                    //await Bot.Instance.SendRepositoriesAsync(commandRepositories);
                                    SetBotState(Bot.Instance.state);
                                    break;
                                case Bot.State.Launching:
                                    if (text == "[Done]"){
                                        await Cancel();
                                    }
                                    break;
                                case Bot.State.Input:
                                    if (update.Type == UpdateType.Message){
                                        Bot.Instance.lastValue = text;
                                        SetBotState(Bot.State.Launching);
                                    }
                                    break;
                                case Bot.State.FolderInput:
                                    if(botWorkspaceSelectMode){
                                        if(text == "🔼 Parent Folder"){
                                            await Bot.Instance.FolderDialog(Path.GetDirectoryName(Bot.Instance.currentPath));
                                        }else if(text == "✅ Select Folder"){
                                            workplaceInput.InvokeIfRequired(() =>{
                                                workplaceInput.Text = Bot.Instance.currentPath;
                                            });
                                            await Bot.Instance.SendRepositoryAsync(commandRepositories[repositoryIndex]);
                                            SetBotState(Bot.State.Command);
                                            botWorkspaceSelectMode = false;
                                        }else{
                                            await Bot.Instance.FolderDialog(Path.Combine(Bot.Instance.currentPath, text.Replace("📁","")));
                                        }
                                    }else{
                                        if(text == "🔼 Parent Folder"){
                                            await Bot.Instance.FolderDialog(
                                                Path.GetDirectoryName(Bot.Instance.currentPath),
                                                Bot.Instance.dialogFileSelectParam,
                                                Bot.Instance.dialogFolderSelectParam
                                            );
                                        }else if(text == "✅ Select Folder"){
                                            SetBotState(Bot.State.Launching);
                                        }else{
                                            if(text.Contains("📁")){
                                                await Bot.Instance.FolderDialog(
                                                    Path.Combine(Bot.Instance.currentPath, text.Replace("📁","")),
                                                    Bot.Instance.dialogFileSelectParam,
                                                    Bot.Instance.dialogFolderSelectParam
                                                );
                                            }else{
                                                SetBotState(Bot.State.Launching);
                                                Bot.Instance.currentPath = Path.Combine(Bot.Instance.currentPath, text.Replace("📄",""));
                                            }
                                        }
                                    }
                                    break;
                            }
                        }; // handler end
                         await Bot.Instance.StartConversation();
                    }
                };
            }
            if(Bot.Instance.chatId is null && Bot.Instance.user is null)
            {
                await Bot.Instance.GetMe();
                SetBotState(Bot.State.Waiting);
            }
            else
            {
                var client = Bot.Instance.client;
                Bot.Instance.client = null;
                Bot.Instance.chatId = null;
                SetBotState(Bot.State.Idle);
            }
        }
        void SetBotState(Bot.State state)
        {
            Bot.Instance.state = state;
            runBot.InvokeIfRequired(() =>
            {
                switch (state)
                {
                    case Bot.State.Idle:
                        runBot.Text = "Run Bot";
                        break;
                    case Bot.State.Waiting:
                        runBot.Text = "Waiting for first message to : " + Bot.Instance.user.Username;
                        break;
                    case Bot.State.Launching:
                        runBot.Text = "Active - Launching Command";
                        break;
                    case Bot.State.Command:
                        runBot.Text = "Active - Command Selector";
                        break;
                    case Bot.State.Repository:
                        runBot.Text = "Active - Repository Selector";
                        break;
                    case Bot.State.Input:
                        runBot.Text = "Active - Waiting for input";
                        break;
                }
            });
        }
    }
}
