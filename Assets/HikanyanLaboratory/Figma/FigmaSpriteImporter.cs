using UnityEngine;
using UnityEditor;
using UnityFigmaBridge.Editor.Settings;


namespace HikanyanLaboratory.Figma
{
    public class FixFigmaSprites
    {
        [MenuItem("Tools/Fix Figma Sprites")]
        static void FixSprites()
        {
            string[] guids = AssetDatabase.FindAssets("t:Texture2D", new[] { "Assets/HikanyanLaboratory/Figma" });

            foreach (string guid in guids)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;

                if (importer != null && importer.textureType == TextureImporterType.Sprite &&
                    importer.spriteImportMode == SpriteImportMode.Multiple)
                {
                    importer.spriteImportMode = SpriteImportMode.Single;
                    importer.SaveAndReimport();
                    Debug.Log($"Changed {path} to SpriteMode Single");
                }
            }
        }
    }
}