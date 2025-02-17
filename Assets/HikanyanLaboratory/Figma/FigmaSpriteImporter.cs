using UnityEditor;

namespace HikanyanLaboratory.Figma
{
    public class FigmaSpriteImporter : AssetPostprocessor
    {
        void OnPreprocessTexture()
        {
            TextureImporter importer = (TextureImporter)assetImporter;

            // Figma からの画像かどうかを判定（パスに "Figma" が含まれている場合）
            if (importer.assetPath.Contains("Figma"))
            {
                importer.textureType = TextureImporterType.Sprite; // Sprite に設定
                importer.spriteImportMode = SpriteImportMode.Single; // Single に設定
                importer.SaveAndReimport();
            }
        }
    }
}