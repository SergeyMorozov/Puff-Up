using UnityEngine;

namespace GAME
{
    public class CupSystem : MonoBehaviour
    {
        private static CupSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindObjectOfType<CupSystem>();
        }

        public static CupSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new CupSystemSettings());
            }
        }

        public static CupSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new CupSystemData());
            }
        }

        public static CupSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new CupSystemEvents());
            }
        }

        [SerializeField] private CupSystemSettings settings;
        [SerializeField] private CupSystemData data;
        private CupSystemEvents events;

    }
}

