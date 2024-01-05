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
            chain.ValueDist = 0;
            if (chain.Value > 0) return;

            chain.Value = 0;
            
            BallSystem.Events.BallCreateEnabled?.Invoke(false);
        }

        private void Update()
        {
            foreach (ChainObject chain in ChainSystem.Data.Chains)
            {
                if (chain.ValueLast > chain.Value)
                {
                    chain.ValueDist += Time.deltaTime / 2;
                    chain.ValueLast = Mathf.Lerp(chain.ValueLast, chain.Value, chain.ValueDist);
                    if (chain.ValueLast - 1 <= chain.Value) chain.ValueLast = chain.Value;
                }
                
                chain.Ref.TextValue.text = ((int)chain.ValueLast).ToString();
                
                if (chain.IsActive && chain.ValueLast <= 0)
                {
                    chain.IsActive = false;
                    ChainSystem.Events.ChainDestroy?.Invoke(chain);
                }
            }
        }
    }
}

