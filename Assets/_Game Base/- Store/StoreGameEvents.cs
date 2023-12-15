using System;

namespace GAME
{
    [Serializable]
    public class StoreGameEvents
    {
        public Action StoreDataLoad;
        public Action StoreDataSave;
        public Action<object, string, Action<object>> LoadDataByType;
        public Action<object, string, Action> SaveDataByType;

        public Action StoreDataLoaded;
        public Action StoreDataSaved;
    }
}