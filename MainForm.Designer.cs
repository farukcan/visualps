namespace Visual_PowerShell
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.launcher = new System.Windows.Forms.TabPage();
            this.launcherTabs = new System.Windows.Forms.TabControl();
            this.commandsTab = new System.Windows.Forms.TabPage();
            this.selectFolder = new System.Windows.Forms.Button();
            this.workplaceInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saveRepo = new System.Windows.Forms.Button();
            this.commandList = new System.Windows.Forms.ListBox();
            this.launchOnClickCheck = new System.Windows.Forms.CheckBox();
            this.newCommand = new System.Windows.Forms.Button();
            this.deleteCommand = new System.Windows.Forms.Button();
            this.repoNameInput = new System.Windows.Forms.TextBox();
            this.authorInput = new System.Windows.Forms.TextBox();
            this.launchButton = new System.Windows.Forms.Button();
            this.websiteInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scriptsTab = new System.Windows.Forms.TabPage();
            this.newScript = new System.Windows.Forms.Button();
            this.deleteScript = new System.Windows.Forms.Button();
            this.scriptList = new System.Windows.Forms.ListBox();
            this.terminal = new System.Windows.Forms.TabPage();
            this.cancelButtons = new System.Windows.Forms.Button();
            this.terminalArea = new System.Windows.Forms.TextBox();
            this.repositories = new System.Windows.Forms.TabPage();
            this.repoAddress = new System.Windows.Forms.TextBox();
            this.newRepoButton = new System.Windows.Forms.Button();
            this.deleteRepo = new System.Windows.Forms.Button();
            this.addRemote = new System.Windows.Forms.Button();
            this.addLocal = new System.Windows.Forms.Button();
            this.repositoryList = new System.Windows.Forms.ListBox();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.trayEnabled = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.packageList = new System.Windows.Forms.TextBox();
            this.about = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.launcher.SuspendLayout();
            this.launcherTabs.SuspendLayout();
            this.commandsTab.SuspendLayout();
            this.scriptsTab.SuspendLayout();
            this.terminal.SuspendLayout();
            this.repositories.SuspendLayout();
            this.settingsTab.SuspendLayout();
            this.about.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.launcher);
            this.tabControl1.Controls.Add(this.repositories);
            this.tabControl1.Controls.Add(this.settingsTab);
            this.tabControl1.Controls.Add(this.about);
            this.tabControl1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(7, 6);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(623, 650);
            this.tabControl1.TabIndex = 0;
            // 
            // launcher
            // 
            this.launcher.Controls.Add(this.launcherTabs);
            this.launcher.Location = new System.Drawing.Point(28, 4);
            this.launcher.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.launcher.Name = "launcher";
            this.launcher.Size = new System.Drawing.Size(591, 642);
            this.launcher.TabIndex = 0;
            this.launcher.Text = "Launcher";
            this.launcher.UseVisualStyleBackColor = true;
            // 
            // launcherTabs
            // 
            this.launcherTabs.Controls.Add(this.commandsTab);
            this.launcherTabs.Controls.Add(this.scriptsTab);
            this.launcherTabs.Controls.Add(this.terminal);
            this.launcherTabs.Location = new System.Drawing.Point(4, 3);
            this.launcherTabs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.launcherTabs.Multiline = true;
            this.launcherTabs.Name = "launcherTabs";
            this.launcherTabs.SelectedIndex = 0;
            this.launcherTabs.Size = new System.Drawing.Size(579, 633);
            this.launcherTabs.TabIndex = 15;
            // 
            // commandsTab
            // 
            this.commandsTab.Controls.Add(this.selectFolder);
            this.commandsTab.Controls.Add(this.workplaceInput);
            this.commandsTab.Controls.Add(this.label4);
            this.commandsTab.Controls.Add(this.saveRepo);
            this.commandsTab.Controls.Add(this.commandList);
            this.commandsTab.Controls.Add(this.launchOnClickCheck);
            this.commandsTab.Controls.Add(this.newCommand);
            this.commandsTab.Controls.Add(this.deleteCommand);
            this.commandsTab.Controls.Add(this.repoNameInput);
            this.commandsTab.Controls.Add(this.authorInput);
            this.commandsTab.Controls.Add(this.launchButton);
            this.commandsTab.Controls.Add(this.websiteInput);
            this.commandsTab.Controls.Add(this.label3);
            this.commandsTab.Controls.Add(this.label1);
            this.commandsTab.Controls.Add(this.label2);
            this.commandsTab.Location = new System.Drawing.Point(4, 27);
            this.commandsTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.commandsTab.Name = "commandsTab";
            this.commandsTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.commandsTab.Size = new System.Drawing.Size(571, 602);
            this.commandsTab.TabIndex = 0;
            this.commandsTab.Text = "Commands";
            this.commandsTab.UseVisualStyleBackColor = true;
            this.commandsTab.Click += new System.EventHandler(this.commandsTab_Click);
            // 
            // selectFolder
            // 
            this.selectFolder.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectFolder.Location = new System.Drawing.Point(410, 434);
            this.selectFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.selectFolder.Name = "selectFolder";
            this.selectFolder.Size = new System.Drawing.Size(152, 31);
            this.selectFolder.TabIndex = 18;
            this.selectFolder.Text = "Select Folder";
            this.selectFolder.UseVisualStyleBackColor = true;
            this.selectFolder.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // workplaceInput
            // 
            this.workplaceInput.Location = new System.Drawing.Point(410, 397);
            this.workplaceInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.workplaceInput.Name = "workplaceInput";
            this.workplaceInput.Size = new System.Drawing.Size(150, 26);
            this.workplaceInput.TabIndex = 17;
            this.workplaceInput.TextChanged += new System.EventHandler(this.workplaceInput_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 373);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "Workspace";
            // 
            // saveRepo
            // 
            this.saveRepo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveRepo.Location = new System.Drawing.Point(410, 210);
            this.saveRepo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.saveRepo.Name = "saveRepo";
            this.saveRepo.Size = new System.Drawing.Size(152, 31);
            this.saveRepo.TabIndex = 15;
            this.saveRepo.Text = "Save Repository";
            this.saveRepo.UseVisualStyleBackColor = true;
            this.saveRepo.Click += new System.EventHandler(this.saveRepo_Click);
            // 
            // commandList
            // 
            this.commandList.BackColor = System.Drawing.SystemColors.Window;
            this.commandList.ColumnWidth = 20;
            this.commandList.Font = new System.Drawing.Font("Bahnschrift SemiBold Condensed", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.commandList.ForeColor = System.Drawing.SystemColors.InfoText;
            this.commandList.FormattingEnabled = true;
            this.commandList.ItemHeight = 39;
            this.commandList.Items.AddRange(new object[] {
            "Clone Repository",
            "Initialize Repository",
            "Add (All Files)",
            "Commit",
            "Add + Commit",
            "Push to Remote",
            "Pull from Remote",
            "Show Status"});
            this.commandList.Location = new System.Drawing.Point(7, 7);
            this.commandList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.commandList.Name = "commandList";
            this.commandList.Size = new System.Drawing.Size(395, 589);
            this.commandList.TabIndex = 10;
            this.commandList.Click += new System.EventHandler(this.launchOnClick);
            this.commandList.SelectedIndexChanged += new System.EventHandler(this.commandList_SelectedIndexChanged);
            this.commandList.DoubleClick += new System.EventHandler(this.launchOnDoubleClick);
            // 
            // launchOnClickCheck
            // 
            this.launchOnClickCheck.AutoSize = true;
            this.launchOnClickCheck.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.launchOnClickCheck.Location = new System.Drawing.Point(413, 522);
            this.launchOnClickCheck.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.launchOnClickCheck.Name = "launchOnClickCheck";
            this.launchOnClickCheck.Size = new System.Drawing.Size(122, 20);
            this.launchOnClickCheck.TabIndex = 14;
            this.launchOnClickCheck.Text = "Launch On Click";
            this.launchOnClickCheck.UseVisualStyleBackColor = true;
            this.launchOnClickCheck.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // newCommand
            // 
            this.newCommand.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newCommand.Location = new System.Drawing.Point(410, 262);
            this.newCommand.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.newCommand.Name = "newCommand";
            this.newCommand.Size = new System.Drawing.Size(152, 31);
            this.newCommand.TabIndex = 12;
            this.newCommand.Text = "New Command";
            this.newCommand.UseVisualStyleBackColor = true;
            this.newCommand.Click += new System.EventHandler(this.newCommand_Click);
            // 
            // deleteCommand
            // 
            this.deleteCommand.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteCommand.Location = new System.Drawing.Point(410, 300);
            this.deleteCommand.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.deleteCommand.Name = "deleteCommand";
            this.deleteCommand.Size = new System.Drawing.Size(152, 31);
            this.deleteCommand.TabIndex = 13;
            this.deleteCommand.Text = "Delete Selected";
            this.deleteCommand.UseVisualStyleBackColor = true;
            this.deleteCommand.Click += new System.EventHandler(this.deleteCommand_Click);
            // 
            // repoNameInput
            // 
            this.repoNameInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.repoNameInput.Location = new System.Drawing.Point(410, 31);
            this.repoNameInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.repoNameInput.Name = "repoNameInput";
            this.repoNameInput.Size = new System.Drawing.Size(151, 26);
            this.repoNameInput.TabIndex = 1;
            this.repoNameInput.Text = "Test Repo";
            // 
            // authorInput
            // 
            this.authorInput.Location = new System.Drawing.Point(410, 99);
            this.authorInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.authorInput.Name = "authorInput";
            this.authorInput.Size = new System.Drawing.Size(151, 26);
            this.authorInput.TabIndex = 2;
            this.authorInput.Text = "farukcan";
            // 
            // launchButton
            // 
            this.launchButton.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.launchButton.Location = new System.Drawing.Point(413, 552);
            this.launchButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(148, 31);
            this.launchButton.TabIndex = 11;
            this.launchButton.Text = "Launch";
            this.launchButton.UseVisualStyleBackColor = true;
            this.launchButton.Click += new System.EventHandler(this.launchButton_Click);
            // 
            // websiteInput
            // 
            this.websiteInput.Location = new System.Drawing.Point(410, 173);
            this.websiteInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.websiteInput.Name = "websiteInput";
            this.websiteInput.Size = new System.Drawing.Size(151, 26);
            this.websiteInput.TabIndex = 3;
            this.websiteInput.Text = "https:/farukcan.net";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Website";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(410, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Repository";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Author";
            // 
            // scriptsTab
            // 
            this.scriptsTab.Controls.Add(this.newScript);
            this.scriptsTab.Controls.Add(this.deleteScript);
            this.scriptsTab.Controls.Add(this.scriptList);
            this.scriptsTab.Location = new System.Drawing.Point(4, 24);
            this.scriptsTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.scriptsTab.Name = "scriptsTab";
            this.scriptsTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.scriptsTab.Size = new System.Drawing.Size(571, 605);
            this.scriptsTab.TabIndex = 1;
            this.scriptsTab.Text = "Scripts";
            this.scriptsTab.UseVisualStyleBackColor = true;
            // 
            // newScript
            // 
            this.newScript.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newScript.Location = new System.Drawing.Point(414, 552);
            this.newScript.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.newScript.Name = "newScript";
            this.newScript.Size = new System.Drawing.Size(152, 31);
            this.newScript.TabIndex = 14;
            this.newScript.Text = "New Script";
            this.newScript.UseVisualStyleBackColor = true;
            this.newScript.Click += new System.EventHandler(this.newScript_Click);
            // 
            // deleteScript
            // 
            this.deleteScript.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteScript.Location = new System.Drawing.Point(7, 552);
            this.deleteScript.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.deleteScript.Name = "deleteScript";
            this.deleteScript.Size = new System.Drawing.Size(152, 31);
            this.deleteScript.TabIndex = 15;
            this.deleteScript.Text = "Delete Selected";
            this.deleteScript.UseVisualStyleBackColor = true;
            this.deleteScript.Click += new System.EventHandler(this.deleteScript_Click);
            // 
            // scriptList
            // 
            this.scriptList.BackColor = System.Drawing.SystemColors.Window;
            this.scriptList.ColumnWidth = 20;
            this.scriptList.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scriptList.ForeColor = System.Drawing.SystemColors.InfoText;
            this.scriptList.FormattingEnabled = true;
            this.scriptList.ItemHeight = 21;
            this.scriptList.Items.AddRange(new object[] {
            "git clone {text:Address}",
            "git status"});
            this.scriptList.Location = new System.Drawing.Point(7, 7);
            this.scriptList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.scriptList.Name = "scriptList";
            this.scriptList.Size = new System.Drawing.Size(555, 529);
            this.scriptList.TabIndex = 11;
            // 
            // terminal
            // 
            this.terminal.Controls.Add(this.cancelButtons);
            this.terminal.Controls.Add(this.terminalArea);
            this.terminal.Location = new System.Drawing.Point(4, 24);
            this.terminal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.terminal.Name = "terminal";
            this.terminal.Size = new System.Drawing.Size(571, 605);
            this.terminal.TabIndex = 2;
            this.terminal.Text = "Terminal";
            this.terminal.UseVisualStyleBackColor = true;
            // 
            // cancelButtons
            // 
            this.cancelButtons.Enabled = false;
            this.cancelButtons.Location = new System.Drawing.Point(493, 576);
            this.cancelButtons.Name = "cancelButtons";
            this.cancelButtons.Size = new System.Drawing.Size(75, 23);
            this.cancelButtons.TabIndex = 1;
            this.cancelButtons.Text = "Cancel";
            this.cancelButtons.UseVisualStyleBackColor = true;
            this.cancelButtons.Click += new System.EventHandler(this.cancelButtons_Click);
            // 
            // terminalArea
            // 
            this.terminalArea.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.terminalArea.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.terminalArea.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.terminalArea.Location = new System.Drawing.Point(0, 3);
            this.terminalArea.Multiline = true;
            this.terminalArea.Name = "terminalArea";
            this.terminalArea.ReadOnly = true;
            this.terminalArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.terminalArea.Size = new System.Drawing.Size(568, 571);
            this.terminalArea.TabIndex = 0;
            this.terminalArea.Text = "\r\n   Welcome to the Visual PowerShell\r\n\r\n   Run a command to see console messages" +
    ".\r\n";
            // 
            // repositories
            // 
            this.repositories.Controls.Add(this.repoAddress);
            this.repositories.Controls.Add(this.newRepoButton);
            this.repositories.Controls.Add(this.deleteRepo);
            this.repositories.Controls.Add(this.addRemote);
            this.repositories.Controls.Add(this.addLocal);
            this.repositories.Controls.Add(this.repositoryList);
            this.repositories.Location = new System.Drawing.Point(28, 4);
            this.repositories.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.repositories.Name = "repositories";
            this.repositories.Size = new System.Drawing.Size(591, 642);
            this.repositories.TabIndex = 1;
            this.repositories.Text = "Repositories";
            this.repositories.UseVisualStyleBackColor = true;
            // 
            // repoAddress
            // 
            this.repoAddress.Location = new System.Drawing.Point(19, 555);
            this.repoAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.repoAddress.Name = "repoAddress";
            this.repoAddress.ReadOnly = true;
            this.repoAddress.Size = new System.Drawing.Size(552, 26);
            this.repoAddress.TabIndex = 5;
            // 
            // newRepoButton
            // 
            this.newRepoButton.Location = new System.Drawing.Point(19, 592);
            this.newRepoButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.newRepoButton.Name = "newRepoButton";
            this.newRepoButton.Size = new System.Drawing.Size(133, 35);
            this.newRepoButton.TabIndex = 4;
            this.newRepoButton.Text = "New";
            this.newRepoButton.UseVisualStyleBackColor = true;
            this.newRepoButton.Click += new System.EventHandler(this.newRepoButton_Click);
            // 
            // deleteRepo
            // 
            this.deleteRepo.Location = new System.Drawing.Point(159, 592);
            this.deleteRepo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.deleteRepo.Name = "deleteRepo";
            this.deleteRepo.Size = new System.Drawing.Size(133, 35);
            this.deleteRepo.TabIndex = 3;
            this.deleteRepo.Text = "Delete";
            this.deleteRepo.UseVisualStyleBackColor = true;
            this.deleteRepo.Click += new System.EventHandler(this.deleteRepo_Click);
            // 
            // addRemote
            // 
            this.addRemote.Location = new System.Drawing.Point(439, 592);
            this.addRemote.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addRemote.Name = "addRemote";
            this.addRemote.Size = new System.Drawing.Size(133, 35);
            this.addRemote.TabIndex = 2;
            this.addRemote.Text = "Add Remote";
            this.addRemote.UseVisualStyleBackColor = true;
            this.addRemote.Click += new System.EventHandler(this.addRemote_Click);
            // 
            // addLocal
            // 
            this.addLocal.Location = new System.Drawing.Point(299, 592);
            this.addLocal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addLocal.Name = "addLocal";
            this.addLocal.Size = new System.Drawing.Size(133, 35);
            this.addLocal.TabIndex = 1;
            this.addLocal.Text = "Add Local";
            this.addLocal.UseVisualStyleBackColor = true;
            this.addLocal.Click += new System.EventHandler(this.addLocal_Click);
            // 
            // repositoryList
            // 
            this.repositoryList.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.repositoryList.FormattingEnabled = true;
            this.repositoryList.ItemHeight = 27;
            this.repositoryList.Items.AddRange(new object[] {
            "Files (by farukcan)",
            "Git (by farukcan)"});
            this.repositoryList.Location = new System.Drawing.Point(19, 14);
            this.repositoryList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.repositoryList.Name = "repositoryList";
            this.repositoryList.Size = new System.Drawing.Size(552, 517);
            this.repositoryList.TabIndex = 0;
            this.repositoryList.SelectedIndexChanged += new System.EventHandler(this.OnRepositorySelect);
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.trayEnabled);
            this.settingsTab.Controls.Add(this.label5);
            this.settingsTab.Controls.Add(this.packageList);
            this.settingsTab.Location = new System.Drawing.Point(28, 4);
            this.settingsTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Size = new System.Drawing.Size(591, 642);
            this.settingsTab.TabIndex = 2;
            this.settingsTab.Text = "Settings";
            this.settingsTab.UseVisualStyleBackColor = true;
            this.settingsTab.Click += new System.EventHandler(this.settingsTab_Click);
            // 
            // trayEnabled
            // 
            this.trayEnabled.AutoSize = true;
            this.trayEnabled.Location = new System.Drawing.Point(416, 493);
            this.trayEnabled.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.trayEnabled.Name = "trayEnabled";
            this.trayEnabled.Size = new System.Drawing.Size(142, 22);
            this.trayEnabled.TabIndex = 2;
            this.trayEnabled.Text = "Hide to Tray Icon";
            this.trayEnabled.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 14);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Repository Packages (Add Line)";
            // 
            // packageList
            // 
            this.packageList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.packageList.Location = new System.Drawing.Point(4, 38);
            this.packageList.Margin = new System.Windows.Forms.Padding(6);
            this.packageList.Multiline = true;
            this.packageList.Name = "packageList";
            this.packageList.Size = new System.Drawing.Size(578, 445);
            this.packageList.TabIndex = 0;
            this.packageList.Text = "https://gist.github.com/farukcan/487b5577aa672a0b3ad183f87f74a2c9";
            // 
            // about
            // 
            this.about.Controls.Add(this.label6);
            this.about.Location = new System.Drawing.Point(28, 4);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(591, 642);
            this.about.TabIndex = 3;
            this.about.Text = "About / Help";
            this.about.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(289, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Double click to the command to launch it.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 658);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "Visual PowerShell";
            this.Load += new System.EventHandler(this.Form_Load);
            this.tabControl1.ResumeLayout(false);
            this.launcher.ResumeLayout(false);
            this.launcherTabs.ResumeLayout(false);
            this.commandsTab.ResumeLayout(false);
            this.commandsTab.PerformLayout();
            this.scriptsTab.ResumeLayout(false);
            this.terminal.ResumeLayout(false);
            this.terminal.PerformLayout();
            this.repositories.ResumeLayout(false);
            this.repositories.PerformLayout();
            this.settingsTab.ResumeLayout(false);
            this.settingsTab.PerformLayout();
            this.about.ResumeLayout(false);
            this.about.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage launcher;
        private System.Windows.Forms.TabPage repositories;
        private System.Windows.Forms.ListBox repositoryList;
        private System.Windows.Forms.Button addRemote;
        private System.Windows.Forms.Button addLocal;
        private System.Windows.Forms.Button deleteRepo;
        private System.Windows.Forms.Button deleteCommand;
        private System.Windows.Forms.Button newCommand;
        private System.Windows.Forms.Button launchButton;
        private System.Windows.Forms.ListBox commandList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox websiteInput;
        private System.Windows.Forms.TextBox authorInput;
        private System.Windows.Forms.TextBox repoNameInput;
        private System.Windows.Forms.CheckBox launchOnClickCheck;
        private System.Windows.Forms.TabControl launcherTabs;
        private System.Windows.Forms.TabPage commandsTab;
        private System.Windows.Forms.TabPage scriptsTab;
        private System.Windows.Forms.Button newRepoButton;
        private System.Windows.Forms.Button selectFolder;
        private System.Windows.Forms.TextBox workplaceInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveRepo;
        private System.Windows.Forms.TabPage terminal;
        private System.Windows.Forms.TextBox repoAddress;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox packageList;
        private System.Windows.Forms.ListBox scriptList;
        private System.Windows.Forms.Button newScript;
        private System.Windows.Forms.Button deleteScript;
        private System.Windows.Forms.CheckBox trayEnabled;
        private System.Windows.Forms.TextBox terminalArea;
        private System.Windows.Forms.Button cancelButtons;
        private System.Windows.Forms.TabPage about;
        private System.Windows.Forms.Label label6;
    }
}

