using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace HikanyanLaboratory.UI
{
    public static class PrefabLoader
    {
        private static readonly Dictionary<string, GameObject> PrefabDictionary = new Dictionary<string, GameObject>();
        private static readonly Dictionary<string, string> PrefabPathDictionary = new Dictionary<string, string>();

        /// <summary>
        /// 指定されたディレクトリからプレハブを読み込み、プレハブの変数名とパスをディクショナリに追加します。
        /// </summary>
        /// <param name="searchPath"></param>
        public static void Initialize(string searchPath = "Assets")
        {
            PrefabDictionary.Clear();
            PrefabPathDictionary.Clear();

            List<string> resourcePaths = new List<string>();
            FindResourceDirectories(searchPath, resourcePaths);

            foreach (string path in resourcePaths)
            {
                string[] prefabGuids = AssetDatabase.FindAssets("t:Prefab", new[] { path });

                foreach (string guid in prefabGuids)
                {
                    string prefabPath = AssetDatabase.GUIDToAssetPath(guid);
                    GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
                    string variableName = GenerateVariableName(prefab.name);

                    if (PrefabDictionary.TryAdd(variableName, prefab))
                    {
                        PrefabPathDictionary.Add(variableName, prefabPath);
                    }
                    else
                    {
                        Debug.LogWarning($"Duplicate prefab name detected: {variableName}");
                    }
                }
            }

            GeneratePrefabKeysClass();
        }

        /// <summary>
        /// 指定されたディレクトリからリソースディレクトリを見つけ、リソースディレクトリのパスをリストに追加します。
        /// </summary>
        /// <param name="path"></param>
        /// <param name="resourcePaths"></param>
        private static void FindResourceDirectories(string path, List<string> resourcePaths)
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                if (Path.GetFileName(directory) == "Resources")
                {
                    resourcePaths.Add(directory);
                }

                FindResourceDirectories(directory, resourcePaths);
            }
        }

        /// <summary>
        /// プレハブの変数名とパスを使って、PrefabKeysクラスを生成します。
        /// </summary>
        private static void GeneratePrefabKeysClass()
        {
            string classContent = "using System.Collections.Generic;\n";
            classContent += "public static class PrefabKeys\n{\n";
            classContent +=
                "    private static readonly Dictionary<string, string> PrefabPathDictionary = new Dictionary<string, string>()\n    {\n";

            foreach (var entry in PrefabPathDictionary)
            {
                classContent += $"        {{ {entry.Key}, \"{entry.Value}\" }},\n";
            }

            classContent += "    };\n\n";

            foreach (var entry in PrefabDictionary)
            {
                classContent += $"    public const string {entry.Key} = \"{entry.Key}\";\n";
            }

            classContent +=
                "    public static IEnumerable<string> GetAllKeys()\n    {\n        return PrefabPathDictionary.Keys;\n    }\n";
            classContent +=
                "    public static string GetPrefabPath(string key)\n    {\n        return PrefabPathDictionary.TryGetValue(key, out var path) ? path : null;\n    }";
            classContent += "\n}";

            File.WriteAllText("Assets/HikanyanLaboratory/UIToolSystem/PrefabProperty/PrefabKeys.cs", classContent);
            AssetDatabase.Refresh();
        }

        /// <summary>
        /// 指定されたキーに対応するプレハブを取得します。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static GameObject GetPrefab(string key)
        {
            if (PrefabDictionary.TryGetValue(key, out GameObject prefab))
            {
                return prefab;
            }

            Debug.LogError($"Prefab with key '{key}' not found.");
            return null;
        }

        /// <summary>
        /// プレハブ名から変数名を生成します。
        /// </summary>
        /// <param name="prefabName"></param>
        /// <returns></returns>
        private static string GenerateVariableName(string prefabName)
        {
            return prefabName.Replace(" ", "_").Replace("-", "_");
        }
    }
}