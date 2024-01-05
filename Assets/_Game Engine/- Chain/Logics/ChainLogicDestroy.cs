using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace  GAME
{
    public class ChainLogicDestroy : MonoBehaviour
    {
        private void Awake()
        {
            ChainSystem.Events.ChainDestroy += ChainDestroy;
        }

        private void ChainDestroy(ChainObject chain)
        {
            chain.IsActive = false;
            // chain.gameObject.SetActive(false);

            Rigidbody2D[] rbs = chain.GetComponentsInChildren<Rigidbody2D>();
            foreach (Rigidbody2D rb in rbs)
            {
                if(rb.gameObject == chain.Ref.HingeLock.gameObject) continue;
                
                rb.gravityScale = -1;
                rb.mass = 0.1f;
            }
            
            MeshRenderer[] mrs = chain.Ref.Sprite1.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mr in mrs)
            {
                mr.enabled = false;
            }
            mrs = chain.Ref.Sprite2.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mr in mrs)
            {
                mr.enabled = false;
            }
            

            chain.Ref.HingeDestroy.enabled = false;
            chain.Ref.HingeLock.enabled = false;
            chain.Ref.HingeLock.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-4, 4) * 300);
            chain.Ref.LockTop.SetActive(false);
            
            chain.Ref.FX_Destroy.SetActive(true);

            StartCoroutine(RemoveChain(chain));
        }

        IEnumerator RemoveChain(ChainObject chain)
        {
            float _alpha = 1;

            while (_alpha > 0)
            {
                _alpha -= Time.deltaTime / 2;
                Color color = chain.Ref.Sprite1.color;
                color.a = _alpha;
                chain.Ref.Sprite1.color = color;
                chain.Ref.Sprite2.color = color;
                
                yield return null;
            }
            
            Destroy(chain.gameObject);
        }
        
    }
}

