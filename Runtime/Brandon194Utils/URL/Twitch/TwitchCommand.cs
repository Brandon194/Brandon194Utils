using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Brandon194Utils.TwitchChat
{
    [System.Serializable]
    public class TwitchCommand
    {
        public string name;
        [SerializeField] UnityEvent uEvent;

        public void Invoke()
        {
            uEvent.Invoke();
        }
    }
}
