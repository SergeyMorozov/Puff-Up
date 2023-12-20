using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace  GAME
{
    [ExecuteInEditMode]
    public class CupLogicEdit : MonoBehaviour
    {
        private static CupObject _cup;
        private static CupRef _cupRef;
        private static ChainObject _chain;
        private static List<ShapeData> _borderLeft;
        private static List<ShapeData> _borderRight;
        private static List<ShapeData> _borderBottom;

        public static void CupView(CupObject cup)
        {
            if(!cup.gameObject.scene.IsValid()) return;

            if (_cup != cup)
            {
                Tools.RemoveObjects(cup.transform, true);

                if (_cupRef != null) DestroyImmediate(_cupRef.gameObject);
                if (_chain != null) DestroyImmediate(_chain.gameObject);

                if (_borderLeft != null)
                    foreach (ShapeData shapeData in _borderLeft)
                    {
                        if (shapeData.Shape != null) DestroyImmediate(shapeData.Shape.gameObject);
                    }

                if (_borderRight != null)
                    foreach (ShapeData shapeData in _borderRight)
                    {
                        if (shapeData.Shape != null) DestroyImmediate(shapeData.Shape.gameObject);
                    }

                if (_borderBottom != null)
                    foreach (ShapeData shapeData in _borderBottom)
                    {
                        if (shapeData.Shape != null) DestroyImmediate(shapeData.Shape.gameObject);
                    }

                if (_cup != null)
                {
                    DestroyImmediate(_cup.gameObject);
                }
            }

            _cup = cup;
            
            CupRef();
            Chain();
            
            if (_borderLeft == null) _borderLeft = new List<ShapeData>();
            if (_borderRight == null) _borderRight = new List<ShapeData>();
            if (_borderBottom == null) _borderBottom = new List<ShapeData>();

            BorderShapes(_borderLeft, _cup.BorderLeft, 0);
            BorderShapes(_borderRight, _cup.BorderRight, 1);
            BorderShapes(_borderBottom, _cup.BorderBottom, 2);
        }

        private static void CupRef()
        {
            if (_cupRef == null && _cup.Ref != null)
            {
                _cupRef = Tools.AddObject<CupRef>(_cup.Ref, _cup.transform);
                _cupRef.name = _cup.Ref.name;
            }
            
            if (_cupRef != null && _cup.Ref == null)
            {
                DestroyImmediate(_cupRef.gameObject);
                _cupRef = null;
            }
        }
        
        private static void Chain()
        {
            if (_chain == null && _cup.Chain != null)
            {
                _chain = Tools.AddObject<ChainObject>(_cup.Chain, _cup.transform);
                _chain.name = _cup.Chain.name;

                if (_cupRef != null)
                {
                    _chain.transform.position = _cupRef.ChainPoint.position;
                }
            }
            
            if (_chain != null && _cup.Chain == null)
            {
                DestroyImmediate(_chain.gameObject);
                _chain = null;
            }
        }

        private static void BorderShapes(List<ShapeData> list, List<ShapeData> listCup, int indexBorder)
        {
            for (var i = 0; i < listCup.Count; i++)
            {
                if (i >= list.Count)
                {
                    list.Add(new ShapeData());
                }

                var borderData = list[i];
                var shapeData = listCup[i];
                if (shapeData == null || shapeData.Shape == null)
                {
                    if (borderData != null && borderData.Shape != null)
                        DestroyImmediate(borderData.Shape.gameObject);
                }
                else
                {
                    if (borderData.Shape == null)
                    {
                        ShapeObject shape = Tools.AddObject<ShapeObject>(shapeData.Shape, _cup.transform);
                        shape.name = shapeData.Shape.name;
                        borderData.Shape = shape;
                    }
                }

                if (borderData.Shape != null)
                {
                    switch (indexBorder)
                    {
                        case 0:
                            borderData.Shape.transform.position = _cup.Ref.Shapes[0].transform.position +
                                                                  new Vector3(0, shapeData.Position * 9, 0);
                            break;

                        case 1:
                            borderData.Shape.transform.position = _cup.Ref.Shapes[1].transform.position +
                                                                  new Vector3(0, shapeData.Position * 9, 0);
                            borderData.Shape.transform.localRotation = Quaternion.Euler(0, 180, 0);
                            break;
                        
                        case 2:
                            borderData.Shape.transform.position = _cup.Ref.Shapes[2].transform.position +
                                                                  new Vector3((shapeData.Position - 0.5f) * 8, 0, 0);
                            break;

                    }
                    
                }
            }

            for (int i = listCup.Count; i < list.Count; i++)
            {
                DestroyImmediate(list[i].Shape.gameObject);
                list.RemoveAt(i);
                i--;
            }
        }

        /*
        private void Update()
        {
            if(Application.isPlaying) return;

            if (_cup == null && _cupRef != null)
            {
                if(_cupRef != null) DestroyImmediate(_cupRef.gameObject);
                if(_chain != null) DestroyImmediate(_chain.gameObject);

                foreach (ShapeData shapeData in _borderLeft)
                {
                    if(shapeData.Shape != null) DestroyImmediate(shapeData.Shape.gameObject);
                }

                foreach (ShapeData shapeData in _borderRight)
                {
                    if(shapeData.Shape != null) DestroyImmediate(shapeData.Shape.gameObject);
                }

                foreach (ShapeData shapeData in _borderBottom)
                {
                    if(shapeData.Shape != null) DestroyImmediate(shapeData.Shape.gameObject);
                }

                _borderLeft.Clear();
                _borderRight.Clear();
                _borderBottom.Clear();

                _cup = null;
            }
        }
    */
    }
}

