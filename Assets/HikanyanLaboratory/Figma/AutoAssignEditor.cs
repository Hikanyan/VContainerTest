using HikanyanLaboratory.UISystemTest;
using UnityEditor;
using UnityEngine;
using UINodeBase = HikanyanLaboratory.UISystemTest.UINodeBase;

namespace HikanyanLaboratory.Figma
{
    [CustomEditor(typeof(UINodeBase), true)]
    public sealed class UINodeBaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (!GUILayout.Button("Auto Assign")) return;
            var view = target as UINodeBase;
            if (view == null) return;
            EditorUtil.AutoAssignForView<UINodeBase>(view.gameObject);
            EditorUtility.SetDirty(view.gameObject);
        }
    }
    [CustomEditor(typeof(UIViewBase), true)]
    public sealed class UIViewBaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (!GUILayout.Button("Auto Assign")) return;
            var view = target as UIViewBase;
            if (view == null) return;
            EditorUtil.AutoAssignForView<UIViewBase>(view.gameObject);
            EditorUtility.SetDirty(view.gameObject);
        }
    }
}