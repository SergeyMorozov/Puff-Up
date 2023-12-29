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
                if (nextPoint != null)
                {
                    cupLevel.transform.position = nextPoint.position;
                    SetShapesList(cupLevel);
                }
                nextPoint = cupLevel.Ref.NextCupPoint;
                
                ChainObject chain = cupLevel.GetComponentInChildren<ChainObject>();
                chain.Value = 60;
                ChainSystem.Data.Chains.Add(chain);
                if (i == 0) ChainSystem.Data.CurrentChain = chain;
                
                Destroy(cupLevel.GetComponent<CupCreator>());
            }
        }

        private void SetShapesList(CupObject cup)
        {
            cup.Ref.BorderBottom.localScale = new Vector3(1, 0, 1);
            cup.Ref.BorderBottom.gameObject.SetActive(false);
            
            cup.Shapes = cup.GetComponentsInChildren<ShapeObject>().ToList();

            foreach (ShapeObject shape in cup.Shapes)
            {
                shape.gameObject.SetActive(false);
                shape.transform.localScale = Vector3.zero;
            }
        }
    }
}

