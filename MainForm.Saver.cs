using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Visual_PowerShell
{
    public partial class MainForm
    {
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
    }
}