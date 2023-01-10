using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Brandon194;

namespace Brandon194Utils.TwitchChat
{
    [System.Serializable]
    public class TwitchSave : Save.SaveObject
    {
        public string username, password;

        public TwitchSave(string _username, string _password)
        {
            username = _username;
            password = _password;
        }
    }
}
