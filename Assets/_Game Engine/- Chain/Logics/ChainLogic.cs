using System;
using UnityEngine;

namespace  GAME
{
    public class ChainLogic : MonoBehaviour
    {
        private void Awake()
        {
            BallSystem.Events.BallConnected += BallConnected;
        }

        private void BallConnected(BallObject ball)
        {
            ChainSystem.Data.CurrentChain.Value -= ball.Value;
        }

        private void Update()
        {
            ChainSystem.Data.CurrentChain.Ref.TextValue.text = ((int)ChainSystem.Data.CurrentChain.Value).ToString();
        }
    }
}

