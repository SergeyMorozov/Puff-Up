using System;
using System.Collections.Generic;

namespace GAME
{
    [Serializable]
    public class StateSystemData
    {
        public StateDataFade StateDataFade = new ();
        public StateDataAppLoading StateDataAppLoading = new ();
        public StateDataMainMenu StateDataMainMenu = new ();
        public StateDataInventory StateDataInventory = new ();
        public StateDataMap StateDataMap = new ();
        public StateDataSkills StateDataSkills = new ();
        public StateDataZone StateDataZone = new();
        public StateDataLevel StateDataLevel = new ();
        public StateDataLevelComplete StateDataLevelComplete = new ();
        public StateDataLevelFail StateDataLevelFail = new ();
    }

    public class StateData
    {
        public bool IsActive;
        public bool IsShow;
    }

    [Serializable]
    public class StateDataFade : StateData
    {
        public bool IsFade;
        public float Value;
        public StateData DataIn;
        public StateData DataOut;
    }

    [Serializable]
    public class StateDataAppLoading : StateData
    {
        public float Value;
        public Action CallBackExit;
    }
    
    [Serializable]
    public class StateDataMainMenu : StateData
    {
    }

    [Serializable]
    public class StateDataInventory : StateData
    {
    }

    [Serializable]
    public class StateDataSkills : StateData
    {
    }

    [Serializable]
    public class StateDataMap : StateData
    {
    }

    [Serializable]
    public class StateDataZone : StateData
    {
    }
    
    [Serializable]
    public class StateDataLevel : StateData
    {
        public LevelObject Level;
        public LevelState LevelState;
    }

    [Serializable]
    public class StateDataLevelComplete : StateData
    {
        public int Movies;
        // public List<ItemData> Rewards;
    }

    [Serializable]
    public class StateDataLevelFail : StateData
    {
        public int Movies;
    }

    
    
    public enum LevelState
    {
        None = 0,
        Loading = 1,
        Init = 2,
        Spawn = 3,
        Play = 4,
        Finish = 5,
        Complete = 6,
        Fail = 7,
        Continue = 8,
        Exit = 9
    } 

}
