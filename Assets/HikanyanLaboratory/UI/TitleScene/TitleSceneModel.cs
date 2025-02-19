using UnityEngine;

namespace HikanyanLaboratory.UI.TitleScene
{
    public class TitleSceneModel
    {
        public string SceneName { get; } = "Title Scene";

        public void StartGame()
        {
            Debug.Log("Game Starting...");
            // ここでシーン遷移などの処理を行う
        }

        public void ExitGame()
        {
            Debug.Log("Game Exiting...");
            Application.Quit();
        }
    }
}