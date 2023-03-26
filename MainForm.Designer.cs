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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.launcher = new System.Windows.Forms.TabPage();
            this.launcherTabs = new System.Windows.Forms.TabControl();
            this.commandsTab = new System.Windows.Forms.TabPage();
            this.commandDown = new System.Windows.Forms.Button();
            this.commandUp = new System.Windows.Forms.Button();
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
            this.scriptDown = new System.Windows.Forms.Button();
            this.scriptUp = new System.Windows.Forms.Button();
            this.newScript = new System.Windows.Forms.Button();
            this.deleteScript = new System.Windows.Forms.Button();
            this.scriptList = new System.Windows.Forms.ListBox();
            this.terminal = new System.Windows.Forms.TabPage();
            this.colorPicker = new System.Windows.Forms.Label();
            this.backToCommands = new System.Windows.Forms.CheckBox();
            this.cancelButtons = new System.Windows.Forms.Button();
            this.terminalArea = new System.Windows.Forms.TextBox();
            this.repositories = new System.Windows.Forms.TabPage();
            this.repoDown = new System.Windows.Forms.Button();
            this.repoUp = new System.Windows.Forms.Button();
            this.repoAddress = new System.Windows.Forms.TextBox();
            this.newRepoButton = new System.Windows.Forms.Button();
            this.deleteRepo = new System.Windows.Forms.Button();
            this.addRemote = new System.Windows.Forms.Button();
            this.addLocal = new System.Windows.Forms.Button();
            this.repositoryList = new System.Windows.Forms.ListBox();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.runBot = new System.Windows.Forms.Button();
            this.botToken = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.defaultAuthor = new System.Windows.Forms.TextBox();
            this.defaultWebsite = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.trayEnabled = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.packageList = new System.Windows.Forms.TextBox();
            this.about = new System.Windows.Forms.TabPage();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.launchBotOnStart = new System.Windows.Forms.CheckBox();
            this.mainTabControl.SuspendLayout();
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
            // mainTabControl
            // 
            this.mainTabControl.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.mainTabControl.Controls.Add(this.launcher);
            this.mainTabControl.Controls.Add(this.repositories);
            this.mainTabControl.Controls.Add(this.settingsTab);
            this.mainTabControl.Controls.Add(this.about);
            this.mainTabControl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mainTabControl.Location = new System.Drawing.Point(7, 6);
            this.mainTabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mainTabControl.Multiline = true;
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(623, 650);
            this.mainTabControl.TabIndex = 0;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // launcher
            // 
            this.launcher.Controls.Add(this.launcherTabs);
            this.launcher.Location = new System.Drawing.Point(28, 4);
            this.launcher.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.launcher.Name = "launcher";
            this.launcher.Size = new System.Drawing.Size(591, 642);
            this.launcher.TabIndex = 0;
            this.launcher.Text = "🚀 Launcher";
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
            this.launcherTabs.SelectedIndexChanged += new System.EventHandler(this.launcherTabs_SelectedIndexChanged);
            // 
            // commandsTab
            // 
            this.commandsTab.Controls.Add(this.commandDown);
            this.commandsTab.Controls.Add(this.commandUp);
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
            this.commandsTab.Text = "🛠️ Commands";
            this.commandsTab.UseVisualStyleBackColor = true;
            this.commandsTab.Click += new System.EventHandler(this.commandsTab_Click);
            // 
            // commandDown
            // 
            this.commandDown.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.commandDown.Location = new System.Drawing.Point(529, 335);
            this.commandDown.Name = "commandDown";
            this.commandDown.Size = new System.Drawing.Size(34, 31);
            this.commandDown.TabIndex = 20;
            this.commandDown.Text = "🔽";
            this.commandDown.UseVisualStyleBackColor = true;
            this.commandDown.Click += new System.EventHandler(this.commandDown_Click);
            // 
            // commandUp
            // 
            this.commandUp.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.commandUp.Location = new System.Drawing.Point(529, 298);
            this.commandUp.Name = "commandUp";
            this.commandUp.Size = new System.Drawing.Size(34, 31);
            this.commandUp.TabIndex = 19;
            this.commandUp.Text = "🔼";
            this.commandUp.UseVisualStyleBackColor = true;
            this.commandUp.Click += new System.EventHandler(this.commandUp_Click);
            // 
            // selectFolder
            // 
            this.selectFolder.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectFolder.Location = new System.Drawing.Point(409, 475);
            this.selectFolder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.selectFolder.Name = "selectFolder";
            this.selectFolder.Size = new System.Drawing.Size(152, 31);
            this.selectFolder.TabIndex = 18;
            this.selectFolder.Text = "📁 Select Folder";
            this.selectFolder.UseVisualStyleBackColor = true;
            this.selectFolder.Click += new System.EventHandler(this.selectFolder_Click);
            // 
            // workplaceInput
            // 
            this.workplaceInput.Location = new System.Drawing.Point(409, 438);
            this.workplaceInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.workplaceInput.Name = "workplaceInput";
            this.workplaceInput.Size = new System.Drawing.Size(150, 26);
            this.workplaceInput.TabIndex = 17;
            this.workplaceInput.TextChanged += new System.EventHandler(this.workplaceInput_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(409, 414);
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
            this.saveRepo.Text = "💾 Save Repository";
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
            "Loading"});
            this.commandList.Location = new System.Drawing.Point(7, 7);
            this.commandList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.commandList.Name = "commandList";
            this.commandList.Size = new System.Drawing.Size(395, 589);
            this.commandList.TabIndex = 10;
            this.commandList.Click += new System.EventHandler(this.launchOnClick);
            this.commandList.SelectedIndexChanged += new System.EventHandler(this.commandList_SelectedIndexChanged);
            this.commandList.DoubleClick += new System.EventHandler(this.launchOnDoubleClick);
            this.commandList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandList_KeyDown);
            // 
            // launchOnClickCheck
            // 
            this.launchOnClickCheck.AutoSize = true;
            this.launchOnClickCheck.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.launchOnClickCheck.Location = new System.Drawing.Point(413, 539);
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
            this.newCommand.Location = new System.Drawing.Point(409, 297);
            this.newCommand.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.newCommand.Name = "newCommand";
            this.newCommand.Size = new System.Drawing.Size(116, 31);
            this.newCommand.TabIndex = 12;
            this.newCommand.Text = "➕ New Command";
            this.newCommand.UseVisualStyleBackColor = true;
            this.newCommand.Click += new System.EventHandler(this.newCommand_Click);
            // 
            // deleteCommand
            // 
            this.deleteCommand.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteCommand.Location = new System.Drawing.Point(409, 335);
            this.deleteCommand.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.deleteCommand.Name = "deleteCommand";
            this.deleteCommand.Size = new System.Drawing.Size(116, 31);
            this.deleteCommand.TabIndex = 13;
            this.deleteCommand.Text = "🗑️ Delete Selected";
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
            this.repoNameInput.Text = "Loading";
            // 
            // authorInput
            // 
            this.authorInput.Location = new System.Drawing.Point(410, 99);
            this.authorInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.authorInput.Name = "authorInput";
            this.authorInput.Size = new System.Drawing.Size(151, 26);
            this.authorInput.TabIndex = 2;
            this.authorInput.Text = "Loading";
            // 
            // launchButton
            // 
            this.launchButton.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.launchButton.Location = new System.Drawing.Point(413, 565);
            this.launchButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.launchButton.Name = "launchButton";
            this.launchButton.Size = new System.Drawing.Size(148, 31);
            this.launchButton.TabIndex = 11;
            this.launchButton.Text = "🚀 Launch";
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
            this.websiteInput.Text = "Visual PS";
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
            this.scriptsTab.Controls.Add(this.scriptDown);
            this.scriptsTab.Controls.Add(this.scriptUp);
            this.scriptsTab.Controls.Add(this.newScript);
            this.scriptsTab.Controls.Add(this.deleteScript);
            this.scriptsTab.Controls.Add(this.scriptList);
            this.scriptsTab.Location = new System.Drawing.Point(4, 24);
            this.scriptsTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.scriptsTab.Name = "scriptsTab";
            this.scriptsTab.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.scriptsTab.Size = new System.Drawing.Size(571, 605);
            this.scriptsTab.TabIndex = 1;
            this.scriptsTab.Text = "🔨 Scripts";
            this.scriptsTab.UseVisualStyleBackColor = true;
            // 
            // scriptDown
            // 
            this.scriptDown.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scriptDown.Location = new System.Drawing.Point(374, 565);
            this.scriptDown.Name = "scriptDown";
            this.scriptDown.Size = new System.Drawing.Size(34, 31);
            this.scriptDown.TabIndex = 22;
            this.scriptDown.Text = "🔽";
            this.scriptDown.UseVisualStyleBackColor = true;
            this.scriptDown.Click += new System.EventHandler(this.scriptDown_Click);
            // 
            // scriptUp
            // 
            this.scriptUp.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scriptUp.Location = new System.Drawing.Point(334, 565);
            this.scriptUp.Name = "scriptUp";
            this.scriptUp.Size = new System.Drawing.Size(34, 31);
            this.scriptUp.TabIndex = 21;
            this.scriptUp.Text = "🔼";
            this.scriptUp.UseVisualStyleBackColor = true;
            this.scriptUp.Click += new System.EventHandler(this.scriptUp_Click);
            // 
            // newScript
            // 
            this.newScript.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.newScript.Location = new System.Drawing.Point(415, 565);
            this.newScript.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.newScript.Name = "newScript";
            this.newScript.Size = new System.Drawing.Size(152, 31);
            this.newScript.TabIndex = 14;
            this.newScript.Text = "➕ New Script";
            this.newScript.UseVisualStyleBackColor = true;
            this.newScript.Click += new System.EventHandler(this.newScript_Click);
            // 
            // deleteScript
            // 
            this.deleteScript.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.deleteScript.Location = new System.Drawing.Point(7, 565);
            this.deleteScript.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.deleteScript.Name = "deleteScript";
            this.deleteScript.Size = new System.Drawing.Size(152, 31);
            this.deleteScript.TabIndex = 15;
            this.deleteScript.Text = "🗑️ Delete Selected";
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
            "Loading"});
            this.scriptList.Location = new System.Drawing.Point(7, 7);
            this.scriptList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.scriptList.Name = "scriptList";
            this.scriptList.Size = new System.Drawing.Size(555, 550);
            this.scriptList.TabIndex = 11;
            this.scriptList.DoubleClick += new System.EventHandler(this.scriptList_DoubleClick);
            this.scriptList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.scriptList_KeyDown);
            // 
            // terminal
            // 
            this.terminal.Controls.Add(this.colorPicker);
            this.terminal.Controls.Add(this.backToCommands);
            this.terminal.Controls.Add(this.cancelButtons);
            this.terminal.Controls.Add(this.terminalArea);
            this.terminal.Location = new System.Drawing.Point(4, 24);
            this.terminal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.terminal.Name = "terminal";
            this.terminal.Size = new System.Drawing.Size(571, 605);
            this.terminal.TabIndex = 2;
            this.terminal.Text = "🖥️ Terminal";
            this.terminal.UseVisualStyleBackColor = true;
            // 
            // colorPicker
            // 
            this.colorPicker.AutoSize = true;
            this.colorPicker.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.colorPicker.Font = new System.Drawing.Font("Lucida Console", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colorPicker.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.colorPicker.Location = new System.Drawing.Point(3, 568);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Padding = new System.Windows.Forms.Padding(5, 5, 6, 6);
            this.colorPicker.Size = new System.Drawing.Size(75, 30);
            this.colorPicker.TabIndex = 16;
            this.colorPicker.Text = "Style";
            this.colorPicker.Click += new System.EventHandler(this.colorPicker_Click);
            // 
            // backToCommands
            // 
            this.backToCommands.AutoSize = true;
            this.backToCommands.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.backToCommands.Location = new System.Drawing.Point(84, 573);
            this.backToCommands.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.backToCommands.Name = "backToCommands";
            this.backToCommands.Size = new System.Drawing.Size(204, 20);
            this.backToCommands.TabIndex = 15;
            this.backToCommands.Text = "Back to Commands after finish";
            this.backToCommands.UseVisualStyleBackColor = true;
            // 
            // cancelButtons
            // 
            this.cancelButtons.Enabled = false;
            this.cancelButtons.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cancelButtons.Location = new System.Drawing.Point(420, 568);
            this.cancelButtons.Name = "cancelButtons";
            this.cancelButtons.Size = new System.Drawing.Size(148, 31);
            this.cancelButtons.TabIndex = 1;
            this.cancelButtons.Text = "🟥 Cancel";
            this.cancelButtons.UseVisualStyleBackColor = true;
            this.cancelButtons.Click += new System.EventHandler(this.cancelButtons_Click);
            // 
            // terminalArea
            // 
            this.terminalArea.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.terminalArea.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.terminalArea.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.terminalArea.Location = new System.Drawing.Point(0, 3);
            this.terminalArea.MaxLength = 2100000;
            this.terminalArea.Multiline = true;
            this.terminalArea.Name = "terminalArea";
            this.terminalArea.ReadOnly = true;
            this.terminalArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.terminalArea.Size = new System.Drawing.Size(568, 559);
            this.terminalArea.TabIndex = 0;
            this.terminalArea.Text = "\r\n   Welcome to the Visual PowerShell\r\n\r\n   Run a command to see console messages" +
    ".\r\n";
            this.terminalArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.terminalArea_KeyDown);
            // 
            // repositories
            // 
            this.repositories.Controls.Add(this.repoDown);
            this.repositories.Controls.Add(this.repoUp);
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
            this.repositories.Text = "📚 Repositories";
            this.repositories.UseVisualStyleBackColor = true;
            // 
            // repoDown
            // 
            this.repoDown.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.repoDown.Location = new System.Drawing.Point(19, 605);
            this.repoDown.Name = "repoDown";
            this.repoDown.Size = new System.Drawing.Size(34, 31);
            this.repoDown.TabIndex = 22;
            this.repoDown.Text = "🔽";
            this.repoDown.UseVisualStyleBackColor = true;
            this.repoDown.Click += new System.EventHandler(this.repoDown_Click);
            // 
            // repoUp
            // 
            this.repoUp.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.repoUp.Location = new System.Drawing.Point(19, 568);
            this.repoUp.Name = "repoUp";
            this.repoUp.Size = new System.Drawing.Size(34, 31);
            this.repoUp.TabIndex = 21;
            this.repoUp.Text = "🔼";
            this.repoUp.UseVisualStyleBackColor = true;
            this.repoUp.Click += new System.EventHandler(this.repoUp_Click);
            // 
            // repoAddress
            // 
            this.repoAddress.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.repoAddress.Location = new System.Drawing.Point(60, 569);
            this.repoAddress.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.repoAddress.Name = "repoAddress";
            this.repoAddress.ReadOnly = true;
            this.repoAddress.Size = new System.Drawing.Size(511, 26);
            this.repoAddress.TabIndex = 5;
            // 
            // newRepoButton
            // 
            this.newRepoButton.Location = new System.Drawing.Point(60, 601);
            this.newRepoButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.newRepoButton.Name = "newRepoButton";
            this.newRepoButton.Size = new System.Drawing.Size(102, 35);
            this.newRepoButton.TabIndex = 4;
            this.newRepoButton.Text = "➕ New";
            this.newRepoButton.UseVisualStyleBackColor = true;
            this.newRepoButton.Click += new System.EventHandler(this.newRepoButton_Click);
            // 
            // deleteRepo
            // 
            this.deleteRepo.Location = new System.Drawing.Point(170, 601);
            this.deleteRepo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.deleteRepo.Name = "deleteRepo";
            this.deleteRepo.Size = new System.Drawing.Size(102, 35);
            this.deleteRepo.TabIndex = 3;
            this.deleteRepo.Text = "🗑️ Remove";
            this.deleteRepo.UseVisualStyleBackColor = true;
            this.deleteRepo.Click += new System.EventHandler(this.deleteRepo_Click);
            // 
            // addRemote
            // 
            this.addRemote.Location = new System.Drawing.Point(438, 601);
            this.addRemote.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addRemote.Name = "addRemote";
            this.addRemote.Size = new System.Drawing.Size(133, 35);
            this.addRemote.TabIndex = 2;
            this.addRemote.Text = "🌐 Add Remote";
            this.addRemote.UseVisualStyleBackColor = true;
            this.addRemote.Click += new System.EventHandler(this.addRemote_Click);
            // 
            // addLocal
            // 
            this.addLocal.Location = new System.Drawing.Point(298, 601);
            this.addLocal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addLocal.Name = "addLocal";
            this.addLocal.Size = new System.Drawing.Size(133, 35);
            this.addLocal.TabIndex = 1;
            this.addLocal.Text = "📁 Add Local";
            this.addLocal.UseVisualStyleBackColor = true;
            this.addLocal.Click += new System.EventHandler(this.addLocal_Click);
            // 
            // repositoryList
            // 
            this.repositoryList.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.repositoryList.FormattingEnabled = true;
            this.repositoryList.ItemHeight = 27;
            this.repositoryList.Items.AddRange(new object[] {
            "Loading"});
            this.repositoryList.Location = new System.Drawing.Point(19, 14);
            this.repositoryList.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.repositoryList.Name = "repositoryList";
            this.repositoryList.Size = new System.Drawing.Size(552, 544);
            this.repositoryList.TabIndex = 0;
            this.repositoryList.SelectedIndexChanged += new System.EventHandler(this.OnRepositorySelect);
            this.repositoryList.DoubleClick += new System.EventHandler(this.repositoryList_DoubleClick);
            this.repositoryList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.repositoryList_KeyDown);
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.launchBotOnStart);
            this.settingsTab.Controls.Add(this.runBot);
            this.settingsTab.Controls.Add(this.botToken);
            this.settingsTab.Controls.Add(this.label25);
            this.settingsTab.Controls.Add(this.defaultAuthor);
            this.settingsTab.Controls.Add(this.defaultWebsite);
            this.settingsTab.Controls.Add(this.label12);
            this.settingsTab.Controls.Add(this.label13);
            this.settingsTab.Controls.Add(this.trayEnabled);
            this.settingsTab.Controls.Add(this.label5);
            this.settingsTab.Controls.Add(this.packageList);
            this.settingsTab.Location = new System.Drawing.Point(28, 4);
            this.settingsTab.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.Size = new System.Drawing.Size(591, 642);
            this.settingsTab.TabIndex = 2;
            this.settingsTab.Text = "⚙️ Settings";
            this.settingsTab.UseVisualStyleBackColor = true;
            this.settingsTab.Click += new System.EventHandler(this.settingsTab_Click);
            // 
            // runBot
            // 
            this.runBot.Location = new System.Drawing.Point(3, 319);
            this.runBot.Name = "runBot";
            this.runBot.Size = new System.Drawing.Size(578, 26);
            this.runBot.TabIndex = 13;
            this.runBot.Text = "Run Bot";
            this.runBot.UseVisualStyleBackColor = true;
            this.runBot.Click += new System.EventHandler(this.runBot_Click);
            // 
            // botToken
            // 
            this.botToken.Location = new System.Drawing.Point(4, 259);
            this.botToken.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.botToken.Name = "botToken";
            this.botToken.Size = new System.Drawing.Size(578, 26);
            this.botToken.TabIndex = 12;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(4, 238);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(145, 18);
            this.label25.TabIndex = 11;
            this.label25.Text = "Telegram Bot Token";
            // 
            // defaultAuthor
            // 
            this.defaultAuthor.Location = new System.Drawing.Point(19, 518);
            this.defaultAuthor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.defaultAuthor.Name = "defaultAuthor";
            this.defaultAuthor.Size = new System.Drawing.Size(178, 26);
            this.defaultAuthor.TabIndex = 7;
            this.defaultAuthor.Text = "Your name";
            // 
            // defaultWebsite
            // 
            this.defaultWebsite.Location = new System.Drawing.Point(19, 592);
            this.defaultWebsite.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.defaultWebsite.Name = "defaultWebsite";
            this.defaultWebsite.Size = new System.Drawing.Size(178, 26);
            this.defaultWebsite.TabIndex = 8;
            this.defaultWebsite.Text = "Visual PS";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 568);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 18);
            this.label12.TabIndex = 10;
            this.label12.Text = "Default Website";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 494);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 18);
            this.label13.TabIndex = 9;
            this.label13.Text = "Default Author";
            // 
            // trayEnabled
            // 
            this.trayEnabled.AutoSize = true;
            this.trayEnabled.Checked = true;
            this.trayEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.trayEnabled.Location = new System.Drawing.Point(440, 596);
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
            this.packageList.Size = new System.Drawing.Size(578, 194);
            this.packageList.TabIndex = 0;
            this.packageList.Text = "Loading";
            // 
            // about
            // 
            this.about.Controls.Add(this.label24);
            this.about.Controls.Add(this.label23);
            this.about.Controls.Add(this.label22);
            this.about.Controls.Add(this.label21);
            this.about.Controls.Add(this.label20);
            this.about.Controls.Add(this.label19);
            this.about.Controls.Add(this.label18);
            this.about.Controls.Add(this.label17);
            this.about.Controls.Add(this.label16);
            this.about.Controls.Add(this.label15);
            this.about.Controls.Add(this.label14);
            this.about.Controls.Add(this.label11);
            this.about.Controls.Add(this.label10);
            this.about.Controls.Add(this.linkLabel2);
            this.about.Controls.Add(this.label9);
            this.about.Controls.Add(this.linkLabel1);
            this.about.Controls.Add(this.label8);
            this.about.Controls.Add(this.label7);
            this.about.Controls.Add(this.label6);
            this.about.Location = new System.Drawing.Point(28, 4);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(591, 642);
            this.about.TabIndex = 3;
            this.about.Text = "ℹ️ About / Help";
            this.about.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(19, 579);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(278, 18);
            this.label24.TabIndex = 18;
            this.label24.Text = "Press R to rename selected command.";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(19, 552);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(413, 18);
            this.label23.TabIndex = 17;
            this.label23.Text = "Press Backspace or Delete or - key to clear Terminal Area.";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(19, 525);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(356, 18);
            this.label22.TabIndex = 16;
            this.label22.Text = "Press - or delete key to remove something in a list.";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(19, 497);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(271, 18);
            this.label21.TabIndex = 15;
            this.label21.Text = "Press + key to add something to a list.";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(19, 469);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(401, 18);
            this.label20.TabIndex = 14;
            this.label20.Text = "Press E or D for next tab. Press Q and A for previous tab.";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(19, 440);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(412, 18);
            this.label19.TabIndex = 13;
            this.label19.Text = "Press Space key to back Command List on Terminal Area.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(19, 412);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(369, 18);
            this.label18.TabIndex = 12;
            this.label18.Text = "Press ESC key to Cancel process on Terminal Area.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(19, 384);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(512, 18);
            this.label17.TabIndex = 11;
            this.label17.Text = "Use W and S or Up and Down key to switch command on Command List.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 356);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(523, 18);
            this.label16.TabIndex = 10;
            this.label16.Text = "Press to Space/Enter key to Launch selected command on Command List.";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 328);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(399, 18);
            this.label15.TabIndex = 9;
            this.label15.Text = "Use 1, 2 ... 9 keys to switch command on Command List.";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 299);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(393, 18);
            this.label14.TabIndex = 8;
            this.label14.Text = "Use F1, F2 ... F9 to switch repository on Command List.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(19, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 22);
            this.label11.TabIndex = 7;
            this.label11.Text = "Best practices";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 270);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(373, 18);
            this.label10.TabIndex = 6;
            this.label10.Text = "Double click to the repository to open its Gist or URL.";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(477, 606);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(87, 18);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Bug Report";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(279, 18);
            this.label9.TabIndex = 4;
            this.label9.Text = "Open Source Powershell Executer GUI.";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(38, 130);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(252, 18);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/farukcan/visualps";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Malgun Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(19, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(329, 50);
            this.label8.TabIndex = 2;
            this.label8.Text = "Visual Powershell";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(240, 18);
            this.label7.TabIndex = 1;
            this.label7.Text = "Double click to the script to edit it.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(289, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "Double click to the command to launch it.";
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Visual Powershell";
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_MouseClick);
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // launchBotOnStart
            // 
            this.launchBotOnStart.AutoSize = true;
            this.launchBotOnStart.Location = new System.Drawing.Point(4, 291);
            this.launchBotOnStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.launchBotOnStart.Name = "launchBotOnStart";
            this.launchBotOnStart.Size = new System.Drawing.Size(166, 22);
            this.launchBotOnStart.TabIndex = 14;
            this.launchBotOnStart.Text = "Launch Bot On Start";
            this.launchBotOnStart.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(644, 664);
            this.Controls.Add(this.mainTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Visual PowerShell";
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.mainTabControl.ResumeLayout(false);
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

        private System.Windows.Forms.TabControl mainTabControl;
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
        private System.Windows.Forms.Button commandDown;
        private System.Windows.Forms.Button commandUp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button scriptDown;
        private System.Windows.Forms.Button scriptUp;
        private System.Windows.Forms.Button repoDown;
        private System.Windows.Forms.Button repoUp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox backToCommands;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox defaultAuthor;
        private System.Windows.Forms.TextBox defaultWebsite;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label colorPicker;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button runBot;
        private System.Windows.Forms.TextBox botToken;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.CheckBox launchBotOnStart;
    }
}

