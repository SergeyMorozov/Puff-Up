using System.Linq;
using UnityEngine;

namespace  GAME
{
    public class ChainLogicInit : MonoBehaviour
    {
        private void Awake()
        {
            ChainSystem.Data.Chains = FindObjectsOfType<ChainObject>().ToList();
            // ChainSystem.Data.CurrentChain = ChainSystem.Data.Chains[0];
        }
    }
}

