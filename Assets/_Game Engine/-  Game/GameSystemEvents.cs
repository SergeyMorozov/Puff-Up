using System;

namespace GAME
{
    [Serializable]
    public class GameSystemEvents
    {
        public Action<Action, Action> GameActionWithFade;
        
        public Action GameStart;
        public Action GameInit;
        public Action GameReady;
        public Action<GameStateData> StateSet;
        public Action<GameStateData> StateSetWithFade;
        public Action<GameStateData> StateEnter;
        public Action<GameStateData> StateEnterComplete;
        public Action<GameStateData> StateExit;
        public Action<GameStateData> StateExitComplete;
    }
}