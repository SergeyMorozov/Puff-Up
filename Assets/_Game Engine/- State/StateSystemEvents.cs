using System;

namespace GAME
{
    [Serializable]
    public class StateSystemEvents
    {
        public Action<StateData> StateEnter;
        public Action<StateData, StateData> StateEnterWithFade;
        
        public Action StateMainMenu;
        public Action StateSkills;
        public Action StateSkillsBack;
        public Action StateInventory;
        public Action StateInventoryBack;
        public Action StateMap;
        public Action StateMapBack;
        public Action<int> StateZone;
        public Action StateZoneBack;
        public Action StateLevel;
        public Action StateLevelToBase;
        public Action StateLevelRestart;
        public Action StateLevelToZone;
    }
}
