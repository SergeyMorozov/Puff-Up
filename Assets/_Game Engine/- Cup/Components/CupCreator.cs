using System;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class CupCreator : MonoBehaviour
    {
        public CupObject Cup;

        public CupRef CupRef;
        public ChainObject Chain;

        [Header("Shapes")]
        public List<ShapeData> BorderLeft;
        public List<ShapeData> BorderRight;
        public List<ShapeData> BorderBottom;
        public List<ShapeData2D> Inside;
    }

    [Serializable]
    public class ShapeData
    {
        public ShapeObject Shape;
        [Range(0f, 1f)] public float Position = 0.5f;
    }
    
    [Serializable]
    public class ShapeData2D
    {
        public ShapeObject Shape;
        [Range(0f, 1f)] public float PositionX = 0.5f;
        [Range(0f, 1f)] public float PositionY = 0.5f;
    }

}

