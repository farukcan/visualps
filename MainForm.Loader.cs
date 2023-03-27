using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Visual_PowerShell.Models;

namespace Visual_PowerShell
{
    public partial class MainForm
    {
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
    }
}