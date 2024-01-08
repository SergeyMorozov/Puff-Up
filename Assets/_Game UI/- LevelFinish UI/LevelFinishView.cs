using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GAME
{
    public class LevelFinishView : MonoBehaviour
    {
        public GameObject PanelComplete;
        public Animator AnimatorComplete;
        
        public TextMeshProUGUI TextLevel;
        public List<GameObject> Stars;
        public Button ButtonNext;
        public Button ButtonRestart;
    }
}

