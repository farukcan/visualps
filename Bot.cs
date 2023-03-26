using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Visual_PowerShell.Models;
using Message = Telegram.Bot.Types.Message;

namespace Visual_PowerShell
{
    // Telegram.Bot
    public class Bot
    {
        // singleton
        private static Bot instance;
        private Bot() { }
        public static Bot Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Bot();
                }
                return instance;
            }
        }
        // Telegram.Bot
        public TelegramBotClient client;
        public long? chatId = null;
        public Update lastUpdate;
        public enum State
        {
            Idle,
            Waiting,
            Command,
            Repository,
            Input,
            Launching,
            FolderInput
        };
        public State state;
        public User user;
        public async Task<User> GetMe()
        {
            return user = await client.GetMeAsync();
        }

        public void SetToken(string token)
        {
            client = new TelegramBotClient(token);
            using CancellationTokenSource cts = new();
            state = State.Waiting;
            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
            };
            client.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );
        }

        private async Task HandlePollingErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken ct)
        {
            MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            await Task.Yield();
        }

        private async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken ct)
        {
            lastUpdate = update;
            await handler(update);
        }
        public async Task SendRepositoryAsync(Repository repository)
        {
            if (chatId is null) return;
            var list = new List<InlineKeyboardButton[]>();
            List<Tuple<string, string>> pairs = new();
            for (int i = 0; i < repository.Commands.Count; i += 2)
            {
                if (i + 1 < repository.Commands.Count)
                {
                    pairs.Add(new Tuple<string, string>(repository.Commands[i].Name, repository.Commands[i + 1].Name));
                }
                else
                {
                    pairs.Add(new Tuple<string, string>(repository.Commands[i].Name, ""));
                }
            }
            foreach (var (a, b) in pairs)
            {
                if (string.IsNullOrEmpty(b))
                {
                    list.Add(new InlineKeyboardButton[] { a });
                    continue;
                }
                list.Add(new InlineKeyboardButton[] { a, b });
            }

            list.Add(new InlineKeyboardButton[] { "[Switch Repository]" });
            await client.SendTextMessageAsync(
                chatId: chatId,
                text: "Select command : ",
                parseMode: ParseMode.Markdown,
                replyMarkup: new InlineKeyboardMarkup(list)
                );
            state = State.Command;
        }

        public async Task SendRepositoriesAsync(List<Repository> commandRepositories)
        {
            if (chatId is null) return;
            var list = new List<InlineKeyboardButton[]>();
            List<Tuple<string, string>> pairs = new();
            for (int i = 0; i < commandRepositories.Count; i += 2)
            {
                if (i + 1 < commandRepositories.Count)
                {
                    pairs.Add(new Tuple<string, string>(commandRepositories[i].Name, commandRepositories[i + 1].Name));
                }
                else
                {
                    pairs.Add(new Tuple<string, string>(commandRepositories[i].Name, ""));
                }
            }
            foreach (var (a, b) in pairs)
            {
                if (string.IsNullOrEmpty(b))
                {
                    list.Add(new InlineKeyboardButton[] { a });
                    continue;
                }
                list.Add(new InlineKeyboardButton[] { a, b });
            }
            list.Add(new InlineKeyboardButton[] { "[Back]" });
            await client.SendTextMessageAsync(
                        chatId: chatId,
                        text: "Select repository : ",
                        parseMode: ParseMode.Markdown,
                        replyMarkup: new InlineKeyboardMarkup(list)
                        );
            state = State.Repository;
        }
        public string lastValue = string.Empty;

        public async Task Prompt(string text, string caption)
        {
            if (chatId is null) return;
            await client.SendTextMessageAsync(
                        chatId: chatId,
                        text: $"*{text}* \n\r{caption}",
                        parseMode: ParseMode.Markdown
                        );
            state = State.Input;
        }
        Message lastTextMessage = null;
        DateTime lastTextMessageTime = DateTime.Now;
        public string lastText = "";
        BackgroundWorker textMessageWorker;
        bool textChanged = false;
        public async Task SendText(string text)
        {
            if (chatId is null) return;
            InlineKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                new InlineKeyboardButton[] { "[Done]" },
            });
            if ((DateTime.Now - lastTextMessageTime).TotalMilliseconds < 2000)
            {
                lock (lastText)
                {
                    lastText += $"\n\r{text}";
                }
                lastTextMessageTime = DateTime.Now;
                textChanged = true;
                if (textMessageWorker is null)
                {
                    textMessageWorker = new BackgroundWorker();
                    textMessageWorker.DoWork += async (a, b) =>
                    {
                        const int MaxLength = 4000;
                        while (true)
                        {
                            if (textChanged && lastTextMessage != null)
                            {
                                bool failed = false;
                                try
                                {
                                    await client.EditMessageTextAsync(
                                        chatId: chatId,
                                        messageId: lastTextMessage.MessageId,
                                        text: lastText.Substring(0, Math.Min(MaxLength, lastText.Length)),
                                        replyMarkup: replyKeyboardMarkup
                                    );
                                }
                                catch (System.Exception e)
                                {
                                    if(!e.Message.Contains("message is not modified")){
                                        lock (lastText)
                                        {
                                            lastText += $"\n\r{e.Message}";
                                        }
                                        failed = true;
                                    }
                                }

                                if (lastText.Length < MaxLength && !failed)
                                {
                                    textChanged = false;
                                }
                                else if (failed)
                                {
                                    lastTextMessage = await client.SendTextMessageAsync(
                                        chatId: chatId,
                                        text: lastText,
                                        replyMarkup: replyKeyboardMarkup
                                        );
                                    Thread.Sleep(500);
                                }
                                else
                                {
                                    lastText = lastText.Substring(MaxLength);
                                    lastTextMessage = await client.SendTextMessageAsync(
                                        chatId: chatId,
                                        text: lastText.Substring(0, Math.Min(MaxLength, lastText.Length)),
                                        replyMarkup: replyKeyboardMarkup
                                        );
                                }
                            }
                            Thread.Sleep(200);
                        }
                    };
                    textMessageWorker.RunWorkerAsync();
                }
            }
            else
            {
                lastText = $"{text}";
                lastTextMessageTime = DateTime.Now;
                lastTextMessage = await client.SendTextMessageAsync(
                     chatId: chatId,
                     text: lastText,
                     replyMarkup: replyKeyboardMarkup
                     );
            }
        }

        public async Task StartConversation()
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {
                new KeyboardButton[] { "🛠️ Commands", "📚 Repositories" },
                new KeyboardButton[] { "📁 Set Workspace" },
            })
            {
                ResizeKeyboard = true
            };

            Message sentMessage = await client.SendTextMessageAsync(
                chatId: chatId,
                text: "Welcome to Visual PowerShell!",
                replyMarkup: replyKeyboardMarkup);
        }
        public string currentPath;
        public bool dialogFileSelectParam, dialogFolderSelectParam;
        public async Task FolderDialog(string path, bool fileSelect = false, bool folderSelect = true, string text = "")
        {
            if (chatId is null) return;
            dialogFileSelectParam = fileSelect;
            dialogFolderSelectParam = folderSelect;
            currentPath = path;
            var list = new List<InlineKeyboardButton[]>();
            List<Tuple<string, string>> pairs = new();
            var directories = Directory.GetDirectories(path);
            // parent folder
            if (folderSelect)
            {
                pairs.Add(new Tuple<string, string>("✅ Select Folder", "🔼 Parent Folder"));
            }
            else
            {
                pairs.Add(new Tuple<string, string>("🔼 Parent Folder", ""));
            }
            for (int i = 0; i < directories.Length; i += 2)
            {
                if (i + 1 < directories.Length)
                {
                    pairs.Add(new Tuple<string, string>(
                        "📁" + Path.GetFileName(directories[i]),
                        "📁" + Path.GetFileName(directories[i + 1])));
                }
                else
                {
                    pairs.Add(new Tuple<string, string>("📁" + Path.GetFileName(directories[i]), ""));
                }
            }
            if (fileSelect)
            {
                var files = Directory.GetFiles(path);
                for (int i = 0; i < files.Length; i += 2)
                {
                    if (i + 1 < files.Length)
                    {
                        pairs.Add(new Tuple<string, string>(
                            "📄" + Path.GetFileName(files[i]),
                            "📄" + Path.GetFileName(files[i + 1])));
                    }
                    else
                    {
                        pairs.Add(new Tuple<string, string>("📄" + Path.GetFileName(files[i]), ""));
                    }
                }
            }
            foreach (var (a, b) in pairs)
            {
                if (string.IsNullOrEmpty(b))
                {
                    list.Add(new InlineKeyboardButton[] { a });
                    continue;
                }
                list.Add(new InlineKeyboardButton[] { a, b });
            }
            var caption = "*Select folder*";
            if (fileSelect && folderSelect)
            {
                caption = "*Select file or folder*";
            }
            else
            {
                if (fileSelect)
                {
                    caption = "*Select file*";
                }
            }
            caption = text + "\n\r" + caption;
            await client.SendTextMessageAsync(
                        chatId: chatId,
                        text: $"{caption} - {path}",
                        parseMode: ParseMode.Markdown,
                        replyMarkup: new InlineKeyboardMarkup(list)
                        );
            state = State.FolderInput;
        }

        public delegate Task UpdateHandler(Update update);
        // event
        public UpdateHandler handler;
    }
}
