using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Brandon194Utils.TwitchChat
{
    [System.Serializable]
    public class TwitchChatMessage
    {
        public static TwitchChatMessage NewMessage(string message)
        {
            if (message.Contains("PRIVMSG"))
            {
                int splitpoint = message.IndexOf("!", 1);
                string chatName = message.Substring(0, splitpoint);
                chatName = chatName.Substring(1);


                splitpoint = message.IndexOf(":", 1);
                message = message.Substring(splitpoint + 1);

                return new TwitchChatMessage(chatName, message);
            }

            return null;
        }

        public string chatName;
        public string message;

        public TwitchChatMessage(string _chatName, string _message)
        {
            chatName = _chatName;
            message = _message;
        }

        public override string ToString()
        {
            return chatName + ": " + message;
        }
    }
}
