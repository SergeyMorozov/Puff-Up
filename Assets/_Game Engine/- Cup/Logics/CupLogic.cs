using UnityEngine;

namespace  GAME
{
    public class CupLogic : MonoBehaviour
    {
        private void Awake()
        {
            LevelSystem.Events.NextCup += NextCup;
        }

        private void NextCup()
        {
            CupSystem.Data.Index++;
            CupSystem.Data.CurrentCup = CupSystem.Data.Cups[CupSystem.Data.Index];
            ChainSystem.Data.CurrentChain = CupSystem.Data.CurrentCup.GetComponentInChildren<ChainObject>();

            CameraSystem.Events.SetCameraPoint?.Invoke(CupSystem.Data.CurrentCup.Ref.CameraPoint.position, true);
            LevelSystem.Events.CupLoaded?.Invoke();
        }
    }
}

