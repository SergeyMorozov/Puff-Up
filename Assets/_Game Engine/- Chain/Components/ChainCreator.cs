using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class ChainCreator : MonoBehaviour
    {
        public ChainObject Chain;
        public Rigidbody2D Point1;
        public Rigidbody2D Point2;
        public Transform RootLinks;

        public void UpdateChain()
        {
            if (Application.isPlaying) return;

            float length = Vector3.Distance(Point1.transform.position, Point2.transform.position);
            int count = RootLinks.childCount;

            if (count <= 0) return;
            float step = length / count;

            Rigidbody2D rb = null;
            int index = 0;
            foreach (Transform link in RootLinks)
            {
                link.localPosition = new Vector3(0, index * -step - step / 2, 0);

                HingeJoint2D hj = link.GetComponent<HingeJoint2D>();
                if (hj == null)
                {
                    hj = link.gameObject.AddComponent<HingeJoint2D>();
                }

                if (index == 0)
                {
                    hj.connectedBody = Point1;
                    hj.anchor = new Vector2(0, step / 2);
                    hj.connectedAnchor = new Vector2(0, 0);
                }
                else
                {
                    hj.connectedBody = rb;
                    hj.anchor = new Vector2(0, step / 2);
                    hj.connectedAnchor = new Vector2(0, -step / 2);
                }

                hj.autoConfigureConnectedAnchor = false;

                rb = link.GetComponent<Rigidbody2D>();
                if (rb == null)
                {
                    rb = link.gameObject.AddComponent<Rigidbody2D>();
                }

                index++;
            }

            HingeJoint2D hjp2 = Point2.GetComponent<HingeJoint2D>();
            if (hjp2 == null)
            {
                hjp2 = Point2.gameObject.AddComponent<HingeJoint2D>();
            }

            hjp2.connectedBody = rb;
            hjp2.anchor = new Vector2(0, 0);
            hjp2.connectedAnchor = new Vector2(0, -step / 2);
            hjp2.autoConfigureConnectedAnchor = false;
        }

    }
    
}

