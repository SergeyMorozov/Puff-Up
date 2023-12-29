using UnityEditor;

namespace  GAME
{
    [CustomEditor(typeof(CupCreator)), CanEditMultipleObjects]
    class CupCreatorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            CupCreator cupCreator = (CupCreator)target;
            if(cupCreator == null) return;
            
            CupLogicCreator.CupView(cupCreator);
        }
    }

}

