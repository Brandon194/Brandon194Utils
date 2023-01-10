using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using UnityEngine;
using Brandon194;

namespace Brandon194Utils.TwitchChat
{
    public class TwitchChatIntegration : MonoBehaviour
    {
        public static TwitchChatIntegration instance;
        private void Awake()
        {
            if (instance == null) instance = this;
            else
            {
                BemLogger.Log(logSettings, "There is already a twitch instance: " + instance.name, this);
            }
        }
        public static string tokenURL = "https://twitchapps.com/tmi";

        TcpClient twitchClient;
        StreamReader reader;
        StreamWriter writer;
        Save save;

        [SerializeField] string commandPrefix;
        [SerializeField] LogSettings _logSettings;
        public LogSettings logSettings
        {
            get
            {
                if (_logSettings == null)
                {
                    _logSettings = (LogSettings)ScriptableObject.CreateInstance(typeof(LogSettings));
                    _logSettings.name = "<b>Twitch</b>";
                    _logSettings.prefixColor = new Color(0.6627451f, 0.4392157f, 1f, 1f);

                    _logSettings.showLogs = true;
                }

                return _logSettings;
            }
        }


        [Header("Lists")]

        [SerializeField] List<TwitchChatMessage> messages = new List<TwitchChatMessage>();
        [SerializeField] List<string> console = new List<string>();
        [SerializeField] TwitchCommand[] commands;

        [Header("Connection Info")]
        // Get the password from https://twitchapps.com/tmi
        [field: SerializeField] public string username;
        [field: SerializeField] public string password;
        [field: SerializeField] public string channelName;
        [field: SerializeField] public string _status { get; private set; }
        bool shouldBeConnected = false;

        void Start()
        {
            try
            {
                Load();
            }
            catch (System.Exception e)
            {
                Debug.LogWarning("Save not found for TwitchChatIntegration.Start()\n" + e.ToString());
            }
        }

        void Update()
        {
            if (shouldBeConnected)
            {
                if (!twitchClient.Connected)
                {
                    Connect(username, password, channelName);
                }

                ReadChat();
            }

        }

        private void OnDestroy()
        {
            if (shouldBeConnected)
            {
                Disconnect();
            }
        }

        public void Connect(string username, string password, string channelName)
        {
            this.username = username;
            this.password = password;
            this.channelName = channelName;

            twitchClient = new TcpClient("irc.chat.twitch.tv", 6667);
            reader = new StreamReader(twitchClient.GetStream());
            writer = new StreamWriter(twitchClient.GetStream());

            writer.WriteLine("PASS " + password);
            writer.WriteLine("NICK " + username);
            writer.WriteLine("USER " + username + " 8 * :" + username);
            writer.WriteLine("JOIN #" + channelName);
            writer.Flush();

            shouldBeConnected = true;
            if (twitchClient.Connected)
            {

                _status = "Connected";
                WriteChat("Connecting via " + commandPrefix);
                writer.Flush();

                Save();
            }
        }

        public void Disconnect()
        {
            if (shouldBeConnected == true)
            {
                shouldBeConnected = false;
            }

            WriteChat("Disconnecting via " + commandPrefix);
            writer.WriteLine("PART " + channelName);
            writer.Flush();
            twitchClient.Close();
            _status = "Disconnected";
        }

        public void ReadChat()
        {
            if (twitchClient.Available > 0)
            {
                string incoming = reader.ReadLine();

                TwitchChatMessage newMessage;

                if (CheckCommand(incoming, out newMessage))
                {
                    messages.Add(newMessage);
                }
                else
                {

                    console.Add(incoming);

                    if (incoming.Equals("PING :tmi.twitch.tv"))
                    {
                        console.Add("PONG :tmi.twitch.tv");
                        writer.WriteLine("PONG :tmi.twitch.tv");
                    }
                }
            }
        }

        public void WriteChat(string message)
        {
            message = ":" + username + "!" + username + "@" + username + ".tmi.twitch.tv PRIVMSG #" + channelName + " :" + message;

            TwitchChatMessage tcMessage;
            if (CheckCommand(message, out tcMessage))
            {
                BemLogger.Log(logSettings, tcMessage.message);
            }
            else
            {
                writer.WriteLine(message);
                writer.Flush();
            }

        }

        public TwitchChatMessage[] GetChat()
        {
            TwitchChatMessage[] msg = messages.ToArray();
            messages.Clear();
            return msg;
        }

        public bool CheckCommand(string newMessage, out TwitchChatMessage tcMessage)
        {
            tcMessage = TwitchChatMessage.NewMessage(newMessage);

            if (tcMessage == null) { return false; }

            if (tcMessage.message.Contains("!" + commandPrefix + " "))
            {
                string currentCommand = tcMessage.message.Replace("!" + commandPrefix + " ", "");

                foreach (TwitchCommand command in commands)
                {
                    if (currentCommand.Contains(command.name))
                    {
                        command.Invoke();
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public string[] GetConsole()
        {
            string[] cons = console.ToArray();
            console.Clear();
            return cons;
        }

        public void OpenTokenSite()
        {
            Application.OpenURL(tokenURL);
        }

        public void Save()
        {
            BemLogger.Log(logSettings, "Saving credentials!");

            Save save = new Save(Application.persistentDataPath + "\\Twitch.bem");
            save.SaveFile(new TwitchSave(username, password));
        }

        public void Load()
        {
            save = new Save(Application.persistentDataPath + "\\Twitch.bem");
            TwitchSave saveFile = (TwitchSave)save.LoadFile();

            username = saveFile.username;
            password = saveFile.password;
        }
    }
}