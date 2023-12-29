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
            ChainObject chain = ChainSystem.Data.CurrentChain;
            if(chain.Value <= 0) return;
            
            chain.Value -= ball.Value;
            if (chain.Value > 0) return;

            chain.Value = 0;
            ChainSystem.Events.ChainDestroy?.Invoke(chain);
        }

        private void Update()
        {
            foreach (ChainObject chain in ChainSystem.Data.Chains)
            {
                chain.Ref.TextValue.text = ((int)chain.Value).ToString();
            }
        }
    }
}

