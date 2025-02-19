using System.Collections.Generic;
public static class PrefabKeys
{
    private static readonly Dictionary<string, string> PrefabPathDictionary = new Dictionary<string, string>()
    {
        { MainScene, "Assets/HikanyanLaboratory/Script/VContainerScene/GameSystemScene/UISystem/Resources/MainScene.prefab" },
        { MainWindow, "Assets/HikanyanLaboratory/Script/VContainerScene/GameSystemScene/UISystem/Resources/MainWindow.prefab" },
        { Screen1, "Assets/HikanyanLaboratory/Script/VContainerScene/GameSystemScene/UISystem/Resources/Screen1.prefab" },
        { Screen2, "Assets/HikanyanLaboratory/Script/VContainerScene/GameSystemScene/UISystem/Resources/Screen2.prefab" },
        { TitleScene, "Assets/HikanyanLaboratory/UI/TitleScene/Resources/TitleScene.prefab" },
    };

    public const string MainScene = "MainScene";
    public const string MainWindow = "MainWindow";
    public const string Screen1 = "Screen1";
    public const string Screen2 = "Screen2";
    public const string TitleScene = "TitleScene";
    public static IEnumerable<string> GetAllKeys()
    {
        return PrefabPathDictionary.Keys;
    }
    public static string GetPrefabPath(string key)
    {
        return PrefabPathDictionary.TryGetValue(key, out var path) ? path : null;
    }
}