using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GAME
{
    public class LevelFinishView : MonoBehaviour
    {
        [Header("Complete")]
        public GameObject PanelComplete;
        public Animator AnimatorComplete;
        public TextMeshProUGUI TextLevel;
        public List<GameObject> Stars;
        public Button ButtonNext;
        public Button ButtonReplay;
        
        [Header("Fail")]
        public GameObject PanelFail;
        public Button ButtonContinue;
        public Button ButtonRestart;

    }
}

