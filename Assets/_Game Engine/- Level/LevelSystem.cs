using UnityEngine;

namespace GAME
{
    public class LevelSystem : MonoBehaviour
    {
        private static LevelSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindObjectOfType<LevelSystem>();
        }

        public static LevelSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new LevelSystemSettings());
            }
        }

        public static LevelSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new LevelSystemData());
            }
        }

        public static LevelSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new LevelSystemEvents());
            }
        }

        [SerializeField] private LevelSystemSettings settings;
        [SerializeField] private LevelSystemData data;
        private LevelSystemEvents events;

    }
}

