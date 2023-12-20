using UnityEditor;

namespace  GAME
{
    [CustomEditor(typeof(CupObject)), CanEditMultipleObjects]
    class CupObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            CupObject cup = (CupObject)target;
            if(cup == null) return;
            
            CupLogicEdit.CupView(cup);
        }
    }

}

