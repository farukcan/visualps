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

//using System.Management.Automation;
//using System.Collections.Objectmodel;

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
        private void SetCommandIndex(int index)
        {
            if (index >= 0 && index < commandList.Items.Count)
            {
                commandList.SelectedIndex = index;
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
            await RetreivePackages();
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
        private void SetRepositoryIndex(int index)
        {
            if (index >= 0 && index < repositoryList.Items.Count)
            {
                repositoryList.SelectedIndex = index;
            }
        }

        private void newRepoButton_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Repository Name", "New Repository","Create");
            commandRepositories.Insert(0,new Repository()
            {
                Name = promptValue,
                Author = "Your Name",
                Website = "https://yoursite.com",
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
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Load Local JSON";
            dialog.DefaultExt = "json";
            dialog.Filter = "JSON files (*.json)|*.json";
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.ShowDialog();
            try
            {
                using (StreamReader reader = new StreamReader(dialog.FileName))
                {
                    string json = reader.ReadToEnd();
                    Repository repository = JsonConvert.DeserializeObject<Repository>(json);
                    repository.Address = dialog.FileName;
                    commandRepositories.Insert(0, repository);
                    UpdateRepositoryList();
                    SetRepositoryIndex(0);
                }
            }catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private async void addRemote_Click(object sender, EventArgs e)
        {
            string prompValue = Prompt.ShowDialog("JSON URL (Gist, API, CDN)", "Download Remote JSON","Download");
            await LoadFromURL(prompValue,true);
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
                    commandRepositories.Insert(0, repository);
                    UpdateRepositoryList();
                    if(setRepoIndex) SetRepositoryIndex(0);
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
                    url = url + (url.EndsWith("/") ? "raw?update" : "/raw?update");
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
                    // Do nothing
                }
            }
            UpdateRepositoryList();
        }

        private void newCommand_Click(object sender, EventArgs e)
        {
            if (repositoryList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            string promptText = Prompt.ShowDialog("Enter command name", "New command", "Create");
            repo.Commands.Add(new Command()
            {
                Name= promptText,
                Scripts = new List<string> { }
            });
            UpdateCommandList();
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
            if (repositoryList.SelectedItem is null) return;
            var repo = commandRepositories[repositoryList.SelectedIndex];
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save Repository as JSON File";
            dialog.DefaultExt = "json";
            dialog.Filter = "JSON files (*.json)|*.json";
            dialog.CheckPathExists= true;
            dialog.ShowDialog(this);
            repo.Address= dialog.FileName;
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
            string promptText = Prompt.ShowDialog("Enter script ; {text:YourTextInput} , {file:YourFileInput} , {save:YourFileInput}", "New script", "Create");
            command.Scripts.Add(promptText);
            UpdateScripts();
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            Launch();
        }
        private void Launch()
        {
            terminal.Focus();
            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.
                PowerShellInstance.AddScript($"cd {workplaceInput.Text}");

                // use "AddParameter" to add a single parameter to the last command/script on the pipeline.
                //PowerShellInstance.AddParameter("param1", "parameter 1 value!");
                // invoke execution on the pipeline (collecting output)
                Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                // loop through each output object item
                foreach (PSObject outputItem in PSOutput)
                {
                    if (outputItem != null)
                    {
                        MessageBox.Show(outputItem.BaseObject.ToString());
                    }
                }
            }
        }
    }
}
