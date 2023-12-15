using UnityEngine;

namespace GAME
{
    public class VibrationSystem : MonoBehaviour
    {
        private static VibrationSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindObjectOfType<VibrationSystem>();
        }
        
        public static VibrationSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new VibrationSettings());
            }
        }
        
        public static VibrationData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new VibrationData());
            }
        }

        public static VibrationEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new VibrationEvents());
            }
        }
        
        [SerializeField] private VibrationSettings settings;
        [SerializeField] private VibrationData data;
        private VibrationEvents events;
    }

}
