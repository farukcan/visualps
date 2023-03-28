using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual_PowerShell.Models;
using Command = Visual_PowerShell.Models.Command;
using Prompt = Visual_PowerShell.Helpers.Prompt;

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
            if (!string.IsNullOrEmpty(Properties.Settings.Default.Workspace))
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
            foreach (var address in addresses)
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
            (bool haveValue, string promptValue) = Prompt.ShowDialog("Repository Name", "New Repository", "Create");
            if (!haveValue || string.IsNullOrEmpty(promptValue)) return;
            commandRepositories.Insert(0, new Repository()
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

        private async void addRemote_Click(object sender, EventArgs e)
        {
            (bool haveValue, string promptValue) = Prompt.ShowDialog("JSON URL (Gist, API, CDN)", "Download Remote JSON", "Download");
            if (!haveValue || string.IsNullOrEmpty(promptValue)) return;

            await LoadFromURL(promptValue, true);
        }

        private void newCommand_Click(object sender, EventArgs e)
        {
            if (repositoryList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            (bool haveValue, string promptText) = Prompt.ShowDialog("Enter command name", "New command", "Create");
            if (!haveValue || string.IsNullOrEmpty(promptText)) return;

            repo.Commands.Add(new Command()
            {
                Name = promptText,
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
            (bool haveValue, string promptText) = Prompt.ShowDialog("Enter script ; {text:YourTextInput} , {file:YourFileInput} , {save:YourFileInput}", "New script", "Create");
            if (!haveValue || string.IsNullOrEmpty(promptText)) return;
            command.Scripts.Add(promptText);
            UpdateScripts();
            scriptList.SelectedIndex = command.Scripts.Count - 1;
        }
        private async void launchButton_Click(object sender, EventArgs e)
        {
            await LaunchAsync();
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
            if (index < 1) return;
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
            if (repo.Address.StartsWith("http"))
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
                    if (((Control)scriptsTab).Enabled)
                    {
                        launcherTabs.SelectedTab = scriptsTab;
                    }
                    else
                    {
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
            switch (e.KeyCode)
            {
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
                    if (((Control)scriptsTab).Enabled)
                    {
                        launcherTabs.SelectedTab = scriptsTab;
                    }
                    else
                    {
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

        void FocusLists()
        {
            if (launcherTabs.SelectedTab == commandsTab)
            {
                commandList.Focus();
            }
            else if (launcherTabs.SelectedTab == terminal)
            {
                terminalArea.Focus();
            }
            else if (launcherTabs.SelectedTab == scriptsTab)
            {
                scriptList.Focus();
            }
        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainTabControl.SelectedTab == launcher)
            {
                FocusLists();
            }
            else if (mainTabControl.SelectedTab == repositories)
            {
                repositoryList.Focus();
            }
        }

        void SetScriptIndex(int index)
        {
            if (index >= 0 && index < scriptList.Items.Count)
            {
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
                case Keys.Escape:
                    mainTabControl.SelectedTab = launcher;
                    launcherTabs.SelectedTab = commandsTab;
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
        private async void runBot_Click(object sender, EventArgs e)
        {
            await BotRunner();
        }

        private void botfatherLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenURL("https://telegram.me/botfather");
        }
    }
}
