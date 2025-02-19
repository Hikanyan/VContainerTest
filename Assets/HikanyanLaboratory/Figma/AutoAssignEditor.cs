using UnityEditor;
using UnityEngine;
using HikanyanLaboratory.UISystem;

namespace HikanyanLaboratory.Figma
{
    [CustomEditor(typeof(UINodeBase), true)]
    public sealed class UINodeBaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (!GUILayout.Button("Auto Assign")) return;

            foreach (var obj in serializedObject.targetObjects)
            {
                if (obj is UINodeBase view)
                {
                    EditorUtil.AutoAssignForView<UINodeBase>(view.gameObject);
                    EditorUtility.SetDirty(view.gameObject);
                }
            }
        }
    }

    [CustomEditor(typeof(UIViewBase), true)]
    public sealed class UIViewBaseEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (!GUILayout.Button("Auto Assign")) return;

            foreach (var obj in serializedObject.targetObjects)
            {
                if (obj is UIViewBase view)
                {
                    EditorUtil.AutoAssignForView<UIViewBase>(view.gameObject);
                    EditorUtility.SetDirty(view.gameObject);
                }
            }
        }
    }
}