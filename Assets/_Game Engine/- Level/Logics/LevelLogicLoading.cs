using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace  GAME
{
    public class LevelLogicLoading : MonoBehaviour
    {
        private void Awake()
        {
            LevelSystem.Events.LevelLoad += LevelLoad;
        }

        private void LevelLoad()
        {
            LevelSystem.Data.IsWin = false;
            
            int index = LevelSystem.Data.LevelNumber - 1;
            LevelPreset levelPreset = LevelSystem.Settings.Levels[index]; 
            LevelObject level = Tools.AddObject<LevelObject>(null);
            level.Preset = levelPreset;
            level.name = levelPreset.name;

            SetCups(level);
            
            LevelSystem.Data.CurrentLevel = level;
            LevelSystem.Events.LevelLoaded?.Invoke();
        }

        private void SetCups(LevelObject level)
        {
            Transform nextPoint = null;
            
            for (var i = 0; i < level.Preset.Cups.Count; i++)
            {
                CupObject cupPrefab = level.Preset.Cups[i];
                CupObject cupLevel = Tools.AddObject<CupObject>(cupPrefab, level.transform);
                cupLevel.Ref = cupLevel.GetComponentInChildren<CupRef>();
                cupLevel.Ref.TextLevel.text = (i + 1).ToString();
                cupLevel.Shapes = cupLevel.GetComponentsInChildren<ShapeObject>().ToList();
                
                if (nextPoint != null)
                {
                    SetShapesSizeZero(cupLevel);
                    cupLevel.Ref.BorderBottom.localScale = new Vector3(1, 0, 1);
                    cupLevel.Ref.BorderBottom.gameObject.SetActive(false);
                    cupLevel.transform.position = nextPoint.position;
                }
                nextPoint = cupLevel.Ref.NextCupPoint;
                
                CupSystem.Data.Cups.Add(cupLevel);
                
                ChainObject chain = cupLevel.GetComponentInChildren<ChainObject>();
                chain.Value = 40;
                ChainSystem.Data.Chains.Add(chain);
                if (i == 0) ChainSystem.Data.CurrentChain = chain;
                
                Destroy(cupLevel.GetComponent<CupCreator>());
            }

            CupSystem.Data.Index = 0;
            CupSystem.Data.CurrentCup = CupSystem.Data.Cups[0];
        }

        private void SetShapesSizeZero(CupObject cup)
        {
            foreach (ShapeObject shape in cup.Shapes)
            {
                shape.gameObject.SetActive(false);
                shape.transform.localScale = Vector3.zero;
            }
        }
    }
}

