using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityFigmaBridge.Editor;
using UnityFigmaBridge.Editor.Settings;

namespace HikanyanLaboratory.Figma
{
    [CustomEditor(typeof(CustomUnityFigmaBridgeSettings))]
    public sealed class CustomUnityFigmaBridgeSettingsEditor : Editor
    {
        UnityFigmaBridgeSettingsEditor _unityFigmaBridgeSettingsEditor;

        void OnEnable()
        {
            var unityBridgeSettingsAsset = UnityFigmaBridgeSettingsProvider.FindUnityBridgeSettingsAsset();
            unityBridgeSettingsAsset.BuildPrototypeFlow = false;
            unityBridgeSettingsAsset.RunTimeAssetsScenePath = "Assets/HikanyanLaboratory/Figma/Figma.unity";
            unityBridgeSettingsAsset.ScreenBindingNamespace = string.Empty;
            unityBridgeSettingsAsset.ServerRenderImageScale = 3;
            unityBridgeSettingsAsset.EnableGoogleFontsDownloads = true;
            unityBridgeSettingsAsset.CreateScreenNameCSharpFile = false;
            unityBridgeSettingsAsset.GenerateNodesMarkedForExport = true;
            unityBridgeSettingsAsset.OnlyImportSelectedPages = true;
            _unityFigmaBridgeSettingsEditor =
                CreateEditor(unityBridgeSettingsAsset, typeof(UnityFigmaBridgeSettingsEditor)) as
                    UnityFigmaBridgeSettingsEditor;
        }

        static string FigmaAccessTokenKey()
        {
            var unityFigmaBridgeImporterType = typeof(UnityFigmaBridgeImporter);
            var field = unityFigmaBridgeImporterType.GetField("FIGMA_PERSONAL_ACCESS_TOKEN_PREF_KEY",
                BindingFlags.NonPublic | BindingFlags.Static);
            if (field != null) return field.GetValue(null) as string;
            return "";
        }

        static CustomUnityFigmaBridgeSettings FindUnityBridgeSettingsAsset()
        {
            var assets = AssetDatabase.FindAssets($"t:{nameof(CustomUnityFigmaBridgeSettings)}");
            return AssetDatabase.LoadAssetAtPath<CustomUnityFigmaBridgeSettings>(
                AssetDatabase.GUIDToAssetPath(assets[0]));
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            _unityFigmaBridgeSettingsEditor.OnInspectorGUI();

            GUILayout.Space(15);
            if (GUILayout.Button("Sync"))
            {
                var savedAccessToken = PlayerPrefs.GetString(FigmaAccessTokenKey());

                var customUnityFigmaBridgeSettings = FindUnityBridgeSettingsAsset();
                if (customUnityFigmaBridgeSettings.AccessToken != savedAccessToken)
                {
                    PlayerPrefs.SetString(FigmaAccessTokenKey(), customUnityFigmaBridgeSettings.AccessToken);
                    PlayerPrefs.Save();
                }

                typeof(UnityFigmaBridgeImporter).GetMethod("Sync", BindingFlags.Static | BindingFlags.NonPublic)
                    ?.Invoke(null, null);
            }
        }
        
        // Figma Bridgeのメニュー隠蔽
        
        [MenuItem("Figma Bridge/Sync Document", true)]
        static bool SyncDocumentOff()
        {
            return false;
        }

        [MenuItem("Figma Bridge/Select Settings File", true)]
        static bool SelectSettingsFileOff()
        {
            return false;
        }

        [MenuItem("Figma Bridge/Set Personal Access Token", true)]
        static bool SetPersonalAccessToken()
        {
            return false;
        }

        [MenuItem("Figma Bridge/Settings File")]
        static void SelectSettings()
        {
            var bridgeSettings = FindUnityBridgeSettingsAsset();
            bridgeSettings.AccessToken = PlayerPrefs.GetString(FigmaAccessTokenKey());
            Selection.activeObject = bridgeSettings;
        }
    }
}