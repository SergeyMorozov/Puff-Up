using TMPro;
using UnityEngine;

namespace GAME
{
    public class LevelView : MonoBehaviour
    {
        public Animator AnimatorMoney;
        public Animator AnimatorMoneyText;
        public Animator AnimatorMoves;
        public Animator AnimatorMovesText;
        public Animator AnimatorSound;
        public Animator AnimatorMovePopup;

        public RectTransform IconMoney;
        public TextMeshProUGUI TextMoney;
        public TextMeshProUGUI TextMoves;

        public CanvasGroup MovesGroup;
        public TextMeshProUGUI MovesText;
    }
}

