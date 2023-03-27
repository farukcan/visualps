using System.IO;
using System.Text;
using Visual_PowerShell.Models;

namespace Visual_PowerShell
{
    public partial class MainForm
    {
        void SaveSettings()
        {
            StringBuilder repoAdresses = new StringBuilder();
            foreach (Repository repository in commandRepositories)
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
    }
}