using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HikanyanLaboratory.SceneSystem
{
    public class SceneManager
    {
        private bool _isManagerSceneLoaded = false;
        private const string ManagerSceneName = "ManagerScene";

        /// <summary>
        /// ManagerSceneをロードするメソッド
        /// </summary>
        private async UniTask LoadManagerSceneAsync()
        {
            if (!SceneLoader.IsSceneLoaded(ManagerSceneName))
            {
                await SceneLoader.LoadSceneAsync(ManagerSceneName);
                _isManagerSceneLoaded = true;
                Debug.Log("ManagerScene loaded.");
            }
        }

        /// <summary>
        /// シーンをロードするメソッド
        /// </summary>
        public async UniTask LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Additive)
        {
            // ManagerSceneがロードされていない場合、最初にロード
            if (!_isManagerSceneLoaded)
            {
                await LoadManagerSceneAsync();
            }

            // 新しいシーンのロード
            if (!SceneLoader.IsSceneLoaded(sceneName))
            {
                await SceneLoader.LoadSceneAsync(sceneName, loadSceneMode);
                Debug.Log($"Scene {sceneName} loaded.");
            }
        }

        /// <summary>
        /// ManagerSceneはアンロードできないように制御
        /// </summary>
        public async UniTask UnloadSceneAsync(string sceneName)
        {
            if (sceneName == ManagerSceneName)
            {
                Debug.LogWarning("ManagerScene cannot be unloaded.");
                return;
            }

            if (SceneLoader.IsSceneLoaded(sceneName))
            {
                await SceneLoader.UnloadSceneAsync(sceneName);
                Debug.Log($"Scene {sceneName} unloaded.");
            }
        }
    }
}