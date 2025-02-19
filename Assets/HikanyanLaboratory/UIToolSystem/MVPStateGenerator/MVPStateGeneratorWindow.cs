using System.IO;
using UnityEditor;
using UnityEngine;

namespace HikanyanLaboratory.UIToolSystem
{
    public class MVPStateGeneratorWindow : EditorWindow
    {
        private GameObject selectedPrefab;
        private MVPStateGeneratorSettings settings;

        // 設定ファイルの保存パス（Editor専用フォルダ内）
        private static readonly string settingsDirectory = "Assets/HikanyanLaboratory/UIToolSystem/MVPStateGenerator";
        private static readonly string settingsPath = settingsDirectory + "MVPStateGeneratorSettings.asset";

        [MenuItem("HikanyanTools/MVP State Generator")]
        public static void ShowWindow()
        {
            GetWindow<MVPStateGeneratorWindow>("MVP State Generator");
        }

        private void OnEnable()
        {
            LoadOrCreateSettings();
        }

        /// <summary>
        /// 設定ファイルをロード、存在しない場合は新規作成
        /// </summary>
        private void LoadOrCreateSettings()
        {
            settings = AssetDatabase.LoadAssetAtPath<MVPStateGeneratorSettings>(settingsPath);

            if (settings == null)
            {
                Debug.LogWarning("設定ファイルが見つかりません。新規作成します。");
                settings = CreateInstance<MVPStateGeneratorSettings>();
                settings.OutputDirectory = settingsDirectory;

                // 設定フォルダの作成（Editorフォルダ内）
                if (!Directory.Exists(settingsDirectory))
                {
                    Directory.CreateDirectory(settingsDirectory);
                }

                // 設定ファイルを作成
                AssetDatabase.CreateAsset(settings, settingsPath);
                AssetDatabase.SaveAssets();
                Debug.Log($"新しい設定ファイルを作成しました: {settingsPath}");
            }
        }

        private void OnGUI()
        {
            GUILayout.Label("MVP State Generator", EditorStyles.boldLabel);
            selectedPrefab =
                (GameObject)EditorGUILayout.ObjectField("Prefab", selectedPrefab, typeof(GameObject), false);

            if (settings != null)
            {
                settings.OutputDirectory = EditorGUILayout.TextField("Output Directory", settings.OutputDirectory);
            }

            if (GUILayout.Button("Generate MVP Classes"))
            {
                GenerateMVPClasses();
            }
        }

        /// <summary>
        /// MVPのプレゼンター、ビュー、モデルを生成
        /// </summary>
        private void GenerateMVPClasses()
        {
            if (selectedPrefab == null)
            {
                Debug.LogError("Prefabが選択されていません。");
                return;
            }

            if (settings == null || string.IsNullOrEmpty(settings.OutputDirectory))
            {
                Debug.LogError("設定ファイルが正しくロードされていません。");
                return;
            }

            string prefabName = selectedPrefab.name;
            string outputPath = Path.Combine(settings.OutputDirectory, prefabName);

            // フォルダ作成（存在しない場合のみ）
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            GeneratePresenterClass(prefabName, outputPath);
            GenerateViewClass(prefabName, outputPath);
            GenerateModelClass(prefabName, outputPath);

            // プレハブを更新
            AttachScriptsToPrefab(prefabName);

            AssetDatabase.Refresh();
            Debug.Log($"MVPクラスを {outputPath} に生成し、Prefabにアタッチしました。");
        }

        /// <summary>
        /// Presenterクラスの生成
        /// </summary>
        private void GeneratePresenterClass(string prefabName, string outputPath)
        {
            string className = $"{prefabName}Presenter";
            string filePath = Path.Combine(outputPath, $"{className}.cs");

            string scriptContent = $@"using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace HikanyanLaboratory.UISystem
{{
    public class {className} : PresenterBase<{prefabName}View, {prefabName}Model>
    {{
        public override UniTask InitializeAsync(CancellationToken ct)
        {{
            // Presenterの初期化処理
            return default;
        }}
    }}
}}";

            File.WriteAllText(filePath, scriptContent);
        }

        /// <summary>
        /// Viewクラスの生成
        /// </summary>
        private void GenerateViewClass(string prefabName, string outputPath)
        {
            string className = $"{prefabName}View";
            string filePath = Path.Combine(outputPath, $"{className}.cs");

            string scriptContent = $@"using UnityEngine;

namespace HikanyanLaboratory.UISystem
{{
    public class {className} : UIViewBase
    {{
        // UIのロジックをここに記述
    }}
}}";

            File.WriteAllText(filePath, scriptContent);
        }

        /// <summary>
        /// Modelクラスの生成
        /// </summary>
        private void GenerateModelClass(string prefabName, string outputPath)
        {
            string className = $"{prefabName}Model";
            string filePath = Path.Combine(outputPath, $"{className}.cs");

            string scriptContent = $@"namespace HikanyanLaboratory.UISystem
{{
    public class {className}
    {{
        // データモデルの定義
    }}
}}";

            File.WriteAllText(filePath, scriptContent);
        }

        /// <summary>
        /// プレゼンターとビューをPrefabにアタッチ
        /// </summary>
        private void AttachScriptsToPrefab(string prefabName)
        {
            string prefabPath = AssetDatabase.GetAssetPath(selectedPrefab);

            if (string.IsNullOrEmpty(prefabPath))
            {
                Debug.LogError("選択されたオブジェクトがPrefabではありません。");
                return;
            }

            GameObject prefabInstance = PrefabUtility.LoadPrefabContents(prefabPath);

            if (prefabInstance == null)
            {
                Debug.LogError("Prefabのロードに失敗しました。");
                return;
            }

            // スクリプトのタイプを取得
            System.Type presenterType = System.Type.GetType($"HikanyanLaboratory.UISystem.{prefabName}Presenter");
            System.Type viewType = System.Type.GetType($"HikanyanLaboratory.UISystem.{prefabName}View");

            if (presenterType == null || viewType == null)
            {
                Debug.LogError("スクリプトのコンパイルが完了していないか、名前空間が間違っています。");
                PrefabUtility.UnloadPrefabContents(prefabInstance);
                return;
            }

            // Viewコンポーネントをアタッチ
            Component viewComponent = prefabInstance.GetComponent(viewType);
            if (viewComponent == null)
            {
                prefabInstance.AddComponent(viewType);
                Debug.Log($"{prefabName}View をPrefabに追加しました。");
            }

            // Presenterコンポーネントをアタッチ
            Component presenterComponent = prefabInstance.GetComponent(presenterType);
            if (presenterComponent == null)
            {
                prefabInstance.AddComponent(presenterType);
                Debug.Log($"{prefabName}Presenter をPrefabに追加しました。");
            }

            // プレハブの保存
            PrefabUtility.SaveAsPrefabAsset(prefabInstance, prefabPath);
            PrefabUtility.UnloadPrefabContents(prefabInstance);
        }
    }
}