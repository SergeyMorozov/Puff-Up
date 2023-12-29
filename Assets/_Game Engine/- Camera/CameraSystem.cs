using UnityEngine;

namespace GAME
{
    public class CameraSystem : MonoBehaviour
    {
        private static CameraSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindObjectOfType<CameraSystem>();
        }

        public static CameraSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new CameraSystemSettings());
            }
        }

        public static CameraSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new CameraSystemData());
            }
        }

        public static CameraSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new CameraSystemEvents());
            }
        }

        [SerializeField] private CameraSystemSettings settings;
        [SerializeField] private CameraSystemData data;
        private CameraSystemEvents events;

    }
}

