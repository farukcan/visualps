using System;
using System.IO;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Visual_PowerShell.Helpers;

namespace Visual_PowerShell
{
    public partial class MainForm
    {
        bool launchedFromBot = false;
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