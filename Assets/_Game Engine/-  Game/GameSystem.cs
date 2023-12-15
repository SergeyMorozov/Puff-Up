using UnityEngine;

namespace GAME
{
    public class GameSystem : MonoBehaviour
    {
        private static GameSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindObjectOfType<GameSystem>();
        }
        
        public static GameSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new GameSystemSettings());
            }
        }
        
        public static GameSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new GameSystemData());
            }
        }

        public static GameSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new GameSystemEvents());
            }
        }
        
        [SerializeField] private GameSystemSettings settings;
        [SerializeField] private GameSystemData data;
        private GameSystemEvents events;
    }
}
