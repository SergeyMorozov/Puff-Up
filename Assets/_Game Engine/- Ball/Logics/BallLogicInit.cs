using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class BallLogicInit : MonoBehaviour
    {
        private void Awake()
        {
            BallSystem.Data.Balls = new List<BallObject>();
        }
    }
}

