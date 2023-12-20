using UnityEngine;

namespace GAME
{
    public class ShapeSystem : MonoBehaviour
    {
        private static ShapeSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindObjectOfType<ShapeSystem>();
        }

        public static ShapeSystemSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new ShapeSystemSettings());
            }
        }

        public static ShapeSystemData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new ShapeSystemData());
            }
        }

        public static ShapeSystemEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new ShapeSystemEvents());
            }
        }

        [SerializeField] private ShapeSystemSettings settings;
        [SerializeField] private ShapeSystemData data;
        private ShapeSystemEvents events;

    }
}

