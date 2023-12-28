using UnityEngine;
using UnityEngine.Serialization;

namespace GAME
{
    public class GameSystemSettings : ScriptableObject
    {
        public string StoreName = "game_data";
        public float FadeSpeed = 0.5f;
    }
}