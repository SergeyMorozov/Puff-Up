using UnityEngine;

namespace GAME
{
    public class StateSystem : MonoBehaviour
    {
        private static StateSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindObjectOfType<StateSystem>();
        }

        public static StateSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new StateSystemSettings());
            }
        }

        public static StateSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new StateSystemData());
            }
        }

        public static StateSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new StateSystemEvents());
            }
        }

        [SerializeField] private StateSystemSettings settings;
        [SerializeField] private StateSystemData data;
        private StateSystemEvents events;

    }
}

