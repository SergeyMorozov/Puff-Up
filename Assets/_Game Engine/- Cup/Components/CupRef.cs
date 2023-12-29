using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GAME
{
    public class CupRef : MonoBehaviour
    {
        public Collider Collider;
        public Transform CameraPoint;
        public Transform ChainPoint;
        public Transform NextCupPoint;
        public Transform BorderBottom;
        public List<MeshRenderer> MeshBorder;
        public MeshRenderer MeshBack;
        public TextMeshPro TextLevel;
        public List<Transform> Shapes;
        
    }
}

