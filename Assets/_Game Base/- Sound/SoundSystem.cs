using UnityEngine;

namespace GAME
{
    public class SoundSystem : MonoBehaviour
    {
        private static SoundSystem Instance;

        public static Transform Transform
        {
            get
            {
                CheckInstance();
                return Instance.transform;
            }
        }

        private static void CheckInstance()
        {
            if (Instance == null)
                Instance = FindObjectOfType<SoundSystem>();
        }
        
        public static SoundSettings Settings
        {
            get
            {
                CheckInstance();
                return Instance.settings ?? (Instance.settings = new SoundSettings());
            }
        }
        
        public static SoundData Data
        {
            get
            {
                CheckInstance();
                return Instance.data ?? (Instance.data = new SoundData());
            }
        }

        public static SoundEvents Events
        {
            get
            {
                CheckInstance();
                return Instance.events ?? (Instance.events = new SoundEvents());
            }
        }
        
        [SerializeField] private SoundSettings settings;
        [SerializeField] private SoundData data;
        private SoundEvents events;
    }

}
