using UnityEngine;

namespace GAME
{
    public class BallSystem : MonoBehaviour
    {
        private static BallSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindObjectOfType<BallSystem>();
        }

        public static BallSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new BallSystemSettings());
            }
        }

        public static BallSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new BallSystemData());
            }
        }

        public static BallSystemEvents Events
        {
            get
            {
                CheckInstance();
                if (Instance == null) return null;
                return Instance.events ?? (Instance.events = new BallSystemEvents());
            }
        }

        [SerializeField] private BallSystemSettings settings;
        [SerializeField] private BallSystemData data;
        private BallSystemEvents events;

    }
}

