using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Brandon194.Statics
{
    public class Delegates
    {
        public delegate void OnPauseGame();
        public static OnPauseGame onPauseGame;

        public delegate void OnStartGame();
        public static OnStartGame onStartGame;

        public delegate void OnEndGame();
        public static OnEndGame onEndGame;

        public delegate void OnRefresh();
        public static OnRefresh onRefresh;

        public delegate void TextureHandlerFinished();
        public static TextureHandlerFinished textureHandlerFinished;
    }
    public enum GameState
    {
        Null, Playing, Paused, Ended
    }

    public enum status
    {
        Null, Enabled, Disabled, Running
    }

    public interface BemDelegates
    {
        void OnStartGame();
        void OnPauseGame();
        void OnEndGame();
        void OnRefresh();
        void OnSave();
        void OnLoad();
    }
}