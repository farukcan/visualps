using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual_PowerShell.Helpers;
using Visual_PowerShell.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void commandsTab_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public List<Repository> commandRepositories = new List<Repository>();
        private void Form_Load(object sender, EventArgs e)
        {
            commandRepositories.Add(new Repository()
            {
                Name = "Files",
                Author = "Faruk Can",
                Website = "htts://farukcan.net",
                Commands = new List<Command>()
                {
                    new Command()
                    {
                        Name = "List files in the folder",
                        Scripts = new List<string>()
                        {
                            "ls"
                        }
                    }
                }
            });
            UpdateRepositoryList();
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
            await LoadFromURL(prompValue);
        }
        private async Task LoadFromURL(string url)
        {
            if (url.StartsWith("https://gist.github.com/"))
            {
                url = url.Replace("https://gist.github.com/", "https://gist.githubusercontent.com/");
                if (!url.Contains("/raw"))
                {
                    url = url + (url.EndsWith("/") ? "raw" : "/raw");
                }
            }
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();
                    Repository repository = JsonConvert.DeserializeObject<Repository>(json);
                    repository.Address = url;
                    commandRepositories.Insert(0, repository);
                    UpdateRepositoryList();
                    SetRepositoryIndex(0);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, url);
            }
            // done
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
    }
}
