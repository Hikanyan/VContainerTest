using HikanyanLaboratory.UISystemTest;
using UnityEditor;
using UnityEngine;
using UINodeBase = HikanyanLaboratory.UISystemTest.UINodeBase;

namespace HikanyanLaboratory.Figma
{
    [CustomEditor(typeof(UINodeBase), true)]
    public sealed class ViewEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Auto Assign"))
            {
                var view = target as UINodeBase;
                if (view == null) return;
                EditorUtil.AutoAssignForView(view.gameObject);
                EditorUtility.SetDirty(view.gameObject);
            }
        }
    }
}