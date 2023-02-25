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
            this.button6 = new System.Windows.Forms.Button();
            this.workplaceInput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saveRepo = new System.Windows.Forms.Button();
            this.commandList = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.newCommand = new System.Windows.Forms.Button();
            this.deleteCommand = new System.Windows.Forms.Button();
            this.repoNameInput = new System.Windows.Forms.TextBox();
            this.authorInput = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.websiteInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scriptsTab = new System.Windows.Forms.TabPage();
            this.terminal = new System.Windows.Forms.TabPage();
            this.repositories = new System.Windows.Forms.TabPage();
            this.repoAddress = new System.Windows.Forms.TextBox();
            this.newRepoButton = new System.Windows.Forms.Button();
            this.deleteRepo = new System.Windows.Forms.Button();
            this.addRemote = new System.Windows.Forms.Button();
            this.addLocal = new System.Windows.Forms.Button();
            this.repositoryList = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.launcher.SuspendLayout();
            this.launcherTabs.SuspendLayout();
            this.commandsTab.SuspendLayout();
            this.repositories.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.launcher);
            this.tabControl1.Controls.Add(this.repositories);
            this.tabControl1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(6, 5);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(534, 563);
            this.tabControl1.TabIndex = 0;
            // 
            // launcher
            // 
            this.launcher.Controls.Add(this.launcherTabs);
            this.launcher.Location = new System.Drawing.Point(28, 4);
            this.launcher.Name = "launcher";
            this.launcher.Size = new System.Drawing.Size(502, 555);
            this.launcher.TabIndex = 0;
            this.launcher.Text = "Launcher";
            this.launcher.UseVisualStyleBackColor = true;
            // 
            // launcherTabs
            // 
            this.launcherTabs.Controls.Add(this.commandsTab);
            this.launcherTabs.Controls.Add(this.scriptsTab);
            this.launcherTabs.Controls.Add(this.terminal);
            this.launcherTabs.Location = new System.Drawing.Point(3, 3);
            this.launcherTabs.Multiline = true;
            this.launcherTabs.Name = "launcherTabs";
            this.launcherTabs.SelectedIndex = 0;
            this.launcherTabs.Size = new System.Drawing.Size(496, 549);
            this.launcherTabs.TabIndex = 15;
            // 
            // commandsTab
            // 
            this.commandsTab.Controls.Add(this.button6);
            this.commandsTab.Controls.Add(this.workplaceInput);
            this.commandsTab.Controls.Add(this.label4);
            this.commandsTab.Controls.Add(this.saveRepo);
            this.commandsTab.Controls.Add(this.commandList);
            this.commandsTab.Controls.Add(this.checkBox1);
            this.commandsTab.Controls.Add(this.newCommand);
            this.commandsTab.Controls.Add(this.deleteCommand);
            this.commandsTab.Controls.Add(this.repoNameInput);
            this.commandsTab.Controls.Add(this.authorInput);
            this.commandsTab.Controls.Add(this.button3);
            this.commandsTab.Controls.Add(this.websiteInput);
            this.commandsTab.Controls.Add(this.label3);
            this.commandsTab.Controls.Add(this.label1);
            this.commandsTab.Controls.Add(this.label2);
            this.commandsTab.Location = new System.Drawing.Point(4, 27);
            this.commandsTab.Name = "commandsTab";
            this.commandsTab.Padding = new System.Windows.Forms.Padding(3);
            this.commandsTab.Size = new System.Drawing.Size(488, 518);
            this.commandsTab.TabIndex = 0;
            this.commandsTab.Text = "Commands";
            this.commandsTab.UseVisualStyleBackColor = true;
            this.commandsTab.Click += new System.EventHandler(this.commandsTab_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(351, 376);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(130, 27);
            this.button6.TabIndex = 18;
            this.button6.Text = "Select Folder";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // workplaceInput
            // 
            this.workplaceInput.Location = new System.Drawing.Point(351, 344);
            this.workplaceInput.Name = "workplaceInput";
            this.workplaceInput.Size = new System.Drawing.Size(129, 26);
            this.workplaceInput.TabIndex = 17;
            this.workplaceInput.Text = "C:/Project/A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(351, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "Workspace";
            // 
            // saveRepo
            // 
            this.saveRepo.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveRepo.Location = new System.Drawing.Point(351, 182);
            this.saveRepo.Name = "saveRepo";
            this.saveRepo.Size = new System.Drawing.Size(130, 27);
            this.saveRepo.TabIndex = 15;
            this.saveRepo.Text = "Save Repository";
            this.saveRepo.UseVisualStyleBackColor = true;
            this.saveRepo.Click += new System.EventHandler(this.saveRepo_Click);
            // 
            // commandList
            // 
            this.commandList.BackColor = System.Drawing.SystemColors.Window;
            this.commandList.ColumnWidth = 20;
            this.commandList.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandList.ForeColor = System.Drawing.SystemColors.InfoText;
            this.commandList.FormattingEnabled = true;
            this.commandList.ItemHeight = 45;
            this.commandList.Items.AddRange(new object[] {
            "Clone Repository",
            "Initialize Repository",
            "Add (All Files)",
            "Commit",
            "Add + Commit",
            "Push to Remote",
            "Pull from Remote",
            "Show Status"});
            this.commandList.Location = new System.Drawing.Point(6, 6);
            this.commandList.Name = "commandList";
            this.commandList.Size = new System.Drawing.Size(339, 499);
            this.commandList.TabIndex = 10;
            this.commandList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(354, 452);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(122, 20);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Launch On Click";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // newCommand
            // 
            this.newCommand.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCommand.Location = new System.Drawing.Point(351, 227);
            this.newCommand.Name = "newCommand";
            this.newCommand.Size = new System.Drawing.Size(130, 27);
            this.newCommand.TabIndex = 12;
            this.newCommand.Text = "New Command";
            this.newCommand.UseVisualStyleBackColor = true;
            this.newCommand.Click += new System.EventHandler(this.newCommand_Click);
            // 
            // deleteCommand
            // 
            this.deleteCommand.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteCommand.Location = new System.Drawing.Point(351, 260);
            this.deleteCommand.Name = "deleteCommand";
            this.deleteCommand.Size = new System.Drawing.Size(130, 27);
            this.deleteCommand.TabIndex = 13;
            this.deleteCommand.Text = "Delete Selected";
            this.deleteCommand.UseVisualStyleBackColor = true;
            this.deleteCommand.Click += new System.EventHandler(this.deleteCommand_Click);
            // 
            // repoNameInput
            // 
            this.repoNameInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repoNameInput.Location = new System.Drawing.Point(351, 27);
            this.repoNameInput.Name = "repoNameInput";
            this.repoNameInput.Size = new System.Drawing.Size(130, 26);
            this.repoNameInput.TabIndex = 1;
            this.repoNameInput.Text = "Test Repo";
            // 
            // authorInput
            // 
            this.authorInput.Location = new System.Drawing.Point(351, 86);
            this.authorInput.Name = "authorInput";
            this.authorInput.Size = new System.Drawing.Size(130, 26);
            this.authorInput.TabIndex = 2;
            this.authorInput.Text = "farukcan";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(354, 478);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(127, 27);
            this.button3.TabIndex = 11;
            this.button3.Text = "Launch";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // websiteInput
            // 
            this.websiteInput.Location = new System.Drawing.Point(351, 150);
            this.websiteInput.Name = "websiteInput";
            this.websiteInput.Size = new System.Drawing.Size(130, 26);
            this.websiteInput.TabIndex = 3;
            this.websiteInput.Text = "https:/farukcan.net";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Website";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Repository";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Author";
            // 
            // scriptsTab
            // 
            this.scriptsTab.Location = new System.Drawing.Point(4, 27);
            this.scriptsTab.Name = "scriptsTab";
            this.scriptsTab.Padding = new System.Windows.Forms.Padding(3);
            this.scriptsTab.Size = new System.Drawing.Size(488, 518);
            this.scriptsTab.TabIndex = 1;
            this.scriptsTab.Text = "Scripts";
            this.scriptsTab.UseVisualStyleBackColor = true;
            // 
            // terminal
            // 
            this.terminal.Location = new System.Drawing.Point(4, 27);
            this.terminal.Name = "terminal";
            this.terminal.Size = new System.Drawing.Size(488, 518);
            this.terminal.TabIndex = 2;
            this.terminal.Text = "Terminal";
            this.terminal.UseVisualStyleBackColor = true;
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
            this.repositories.Name = "repositories";
            this.repositories.Size = new System.Drawing.Size(502, 555);
            this.repositories.TabIndex = 1;
            this.repositories.Text = "Repositories";
            this.repositories.UseVisualStyleBackColor = true;
            // 
            // repoAddress
            // 
            this.repoAddress.Location = new System.Drawing.Point(16, 481);
            this.repoAddress.Name = "repoAddress";
            this.repoAddress.ReadOnly = true;
            this.repoAddress.Size = new System.Drawing.Size(474, 26);
            this.repoAddress.TabIndex = 5;
            // 
            // newRepoButton
            // 
            this.newRepoButton.Location = new System.Drawing.Point(16, 513);
            this.newRepoButton.Name = "newRepoButton";
            this.newRepoButton.Size = new System.Drawing.Size(114, 30);
            this.newRepoButton.TabIndex = 4;
            this.newRepoButton.Text = "New";
            this.newRepoButton.UseVisualStyleBackColor = true;
            this.newRepoButton.Click += new System.EventHandler(this.newRepoButton_Click);
            // 
            // deleteRepo
            // 
            this.deleteRepo.Location = new System.Drawing.Point(136, 513);
            this.deleteRepo.Name = "deleteRepo";
            this.deleteRepo.Size = new System.Drawing.Size(114, 30);
            this.deleteRepo.TabIndex = 3;
            this.deleteRepo.Text = "Delete";
            this.deleteRepo.UseVisualStyleBackColor = true;
            this.deleteRepo.Click += new System.EventHandler(this.deleteRepo_Click);
            // 
            // addRemote
            // 
            this.addRemote.Location = new System.Drawing.Point(376, 513);
            this.addRemote.Name = "addRemote";
            this.addRemote.Size = new System.Drawing.Size(114, 30);
            this.addRemote.TabIndex = 2;
            this.addRemote.Text = "Add Remote";
            this.addRemote.UseVisualStyleBackColor = true;
            this.addRemote.Click += new System.EventHandler(this.addRemote_Click);
            // 
            // addLocal
            // 
            this.addLocal.Location = new System.Drawing.Point(256, 513);
            this.addLocal.Name = "addLocal";
            this.addLocal.Size = new System.Drawing.Size(114, 30);
            this.addLocal.TabIndex = 1;
            this.addLocal.Text = "Add Local";
            this.addLocal.UseVisualStyleBackColor = true;
            this.addLocal.Click += new System.EventHandler(this.addLocal_Click);
            // 
            // repositoryList
            // 
            this.repositoryList.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryList.FormattingEnabled = true;
            this.repositoryList.ItemHeight = 27;
            this.repositoryList.Items.AddRange(new object[] {
            "Files (by farukcan)",
            "Git (by farukcan)"});
            this.repositoryList.Location = new System.Drawing.Point(16, 12);
            this.repositoryList.Name = "repositoryList";
            this.repositoryList.Size = new System.Drawing.Size(474, 463);
            this.repositoryList.TabIndex = 0;
            this.repositoryList.SelectedIndexChanged += new System.EventHandler(this.OnRepositorySelect);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 570);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Visual PowerShell";
            this.Load += new System.EventHandler(this.Form_Load);
            this.tabControl1.ResumeLayout(false);
            this.launcher.ResumeLayout(false);
            this.launcherTabs.ResumeLayout(false);
            this.commandsTab.ResumeLayout(false);
            this.commandsTab.PerformLayout();
            this.repositories.ResumeLayout(false);
            this.repositories.PerformLayout();
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox commandList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox websiteInput;
        private System.Windows.Forms.TextBox authorInput;
        private System.Windows.Forms.TextBox repoNameInput;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabControl launcherTabs;
        private System.Windows.Forms.TabPage commandsTab;
        private System.Windows.Forms.TabPage scriptsTab;
        private System.Windows.Forms.Button newRepoButton;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox workplaceInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveRepo;
        private System.Windows.Forms.TabPage terminal;
        private System.Windows.Forms.TextBox repoAddress;
    }
}

