using System.IO;
using UnityEditor;
using UnityEngine;

namespace HikanyanLaboratory.UIToolSystem
{
    public class PresenterGeneratorWindow : EditorWindow
    {
        private GameObject selectedPrefab;
        private MVPStateGeneratorSettings settings;

        [MenuItem("Tools/Presenter Generator")]
        public static void ShowWindow()
        {
            GetWindow<PresenterGeneratorWindow>("Presenter Generator");
        }

        private void OnEnable()
        {
            settings = Resources.Load<MVPStateGeneratorSettings>("PresenterGeneratorSettings");

            if (settings == null)
            {
                Debug.LogWarning("PresenterGeneratorSettings.asset が Resources フォルダにありません。作成してください。");
            }
        }

        private void OnGUI()
        {
            GUILayout.Label("Presenter Generator", EditorStyles.boldLabel);
            selectedPrefab = (GameObject)EditorGUILayout.ObjectField("Prefab", selectedPrefab, typeof(GameObject), false);

            if (settings != null)
            {
                settings._outputDirectory = EditorGUILayout.TextField("Output Directory", settings._outputDirectory);
            }

            if (GUILayout.Button("Generate MVP Classes"))
            {
                GenerateMVPClasses();
            }
        }

        private void GenerateMVPClasses()
        {
            if (selectedPrefab == null)
            {
                Debug.LogError("Prefabが選択されていません。");
                return;
            }

            if (settings == null || string.IsNullOrEmpty(settings._outputDirectory))
            {
                Debug.LogError("設定ファイルが正しくロードされていません。");
                return;
            }

            string prefabName = selectedPrefab.name;
            string outputPath = Path.Combine(settings._outputDirectory, prefabName);

            // フォルダ作成
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            GeneratePresenterClass(prefabName, outputPath);
            GenerateViewClass(prefabName, outputPath);
            GenerateModelClass(prefabName, outputPath);

            AssetDatabase.Refresh();
            Debug.Log($"MVPクラスを {outputPath} に生成しました。");
        }

        private void GeneratePresenterClass(string prefabName, string outputPath)
        {
            string className = $"{prefabName}Presenter";
            string filePath = Path.Combine(outputPath, $"{className}.cs");

            string scriptContent = $@"using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace HikanyanLaboratory.UISystemTest
{{
    public class {className} : PresenterBase<{prefabName}View, {prefabName}Model>
    {{
        public override UniTask InitializeAsync(CancellationToken ct)
        {{
            // Initialize Presenter Logic
            return default;
        }}
    }}
}}";

            File.WriteAllText(filePath, scriptContent);
        }

        private void GenerateViewClass(string prefabName, string outputPath)
        {
            string className = $"{prefabName}View";
            string filePath = Path.Combine(outputPath, $"{className}.cs");

            string scriptContent = $@"using UnityEngine;

namespace HikanyanLaboratory.UISystemTest
{{
    public class {className} : UIViewBase
    {{
        // Define UI Elements and Logic Here
    }}
}}";

            File.WriteAllText(filePath, scriptContent);
        }

        private void GenerateModelClass(string prefabName, string outputPath)
        {
            string className = $"{prefabName}Model";
            string filePath = Path.Combine(outputPath, $"{className}.cs");

            string scriptContent = $@"namespace HikanyanLaboratory.UISystemTest
{{
    public class {className}
    {{
        // Define Model Data Here
    }}
}}";

            File.WriteAllText(filePath, scriptContent);
        }
    }
}
