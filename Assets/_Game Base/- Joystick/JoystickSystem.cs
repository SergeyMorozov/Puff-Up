using UnityEngine;

namespace GAME
{
    public class JoystickSystem : MonoBehaviour
    {
        private static JoystickSystem Instance;

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindObjectOfType<JoystickSystem>();
        }
        
        public static JoystickSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new JoystickSettings());
            }
        }
        
        public static JoystickData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new JoystickData());
            }
        }

        public static JoystickEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new JoystickEvents());
            }
        }
        
        [SerializeField] private JoystickSettings settings;
        [SerializeField] private JoystickData data;
        private JoystickEvents events;
    }
}
