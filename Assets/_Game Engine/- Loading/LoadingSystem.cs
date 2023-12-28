using UnityEngine;

namespace GAME
{
    public class LoadingSystem : MonoBehaviour
    {
        private static LoadingSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindObjectOfType<LoadingSystem>();
        }

        public static LoadingSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new LoadingSystemSettings());
            }
        }

        public static LoadingSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new LoadingSystemData());
            }
        }

        public static LoadingSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new LoadingSystemEvents());
            }
        }

        [SerializeField] private LoadingSystemSettings settings;
        [SerializeField] private LoadingSystemData data;
        private LoadingSystemEvents events;

    }
}

