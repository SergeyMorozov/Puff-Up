using UnityEngine;

namespace GAME
{
    public class ChainSystem : MonoBehaviour
    {
        private static ChainSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindObjectOfType<ChainSystem>();
        }

        public static ChainSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new ChainSystemSettings());
            }
        }

        public static ChainSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new ChainSystemData());
            }
        }

        public static ChainSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new ChainSystemEvents());
            }
        }

        [SerializeField] private ChainSystemSettings settings;
        [SerializeField] private ChainSystemData data;
        private ChainSystemEvents events;

    }
}

