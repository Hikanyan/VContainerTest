using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HikanyanLaboratory.UI
{
    public class PrefabBinder : EditorWindow
    {
        private string resourcePath = "Resources";

        [MenuItem("HikanyanTools/Prefab Binder")]
        public static void ShowWindow()
        {
            GetWindow<PrefabBinder>("Prefab Binder");
        }

        private void OnGUI()
        {
            GUILayout.Label("Prefab Binder", EditorStyles.boldLabel);
            resourcePath = EditorGUILayout.TextField("Resource Path", resourcePath);

            if (GUILayout.Button("Bind Prefabs"))
            {
                PrefabLoader.Initialize();
            }
        }
    }
}