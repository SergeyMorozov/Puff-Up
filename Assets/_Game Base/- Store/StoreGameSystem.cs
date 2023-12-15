using UnityEngine;

namespace GAME
{
    public class StoreGameSystem : MonoBehaviour
    {
        private static StoreGameSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindObjectOfType<StoreGameSystem>();
        }
        
        public static StoreGameSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance._settings ?? (Instance._settings = new StoreGameSettings());
            }
        }
        
        public static StoreGameData Data
        {
            get
            {
                CheckInstance();
                return Instance._data ?? (Instance._data = new StoreGameData());
            }
        }

        public static StoreGameEvents Events
        {
            get
            {
                CheckInstance();
                return Instance._events ?? (Instance._events = new StoreGameEvents());
            }
        }
        
        [SerializeField] private StoreGameSettings _settings;
        [SerializeField] private StoreGameData _data;
        private StoreGameEvents _events;
    }

}
