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
            if(CupSystem.Data.Index >= CupSystem.Data.Cups.Count) return;
            CupSystem.Data.CurrentCup = CupSystem.Data.Cups[CupSystem.Data.Index];
            ChainSystem.Data.CurrentChain = CupSystem.Data.CurrentCup.GetComponentInChildren<ChainObject>();

            CameraObject cam = FindObjectOfType<CameraObject>();

            for (int i = 0; i < 3; i++)
            {
                cam.Cams[i].SetActive(i == CupSystem.Data.Index);
            }
            
            LevelSystem.Events.CupLoaded?.Invoke();
        }
    }
}

