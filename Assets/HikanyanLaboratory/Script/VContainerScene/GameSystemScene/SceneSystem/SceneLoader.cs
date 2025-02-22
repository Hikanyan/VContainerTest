using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace HikanyanLaboratory.SceneSystem
{
    public class SceneLoader
    {
        /// <summary>
        /// シーンを非同期で読み込む
        /// </summary>
        public static async UniTask LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Additive)
        {
            // シーンが読み込まれていない場合は読み込む
            if (!IsSceneLoaded(sceneName))
            {
                var loadSceneOperation =
                    UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
                while (loadSceneOperation is { isDone: false })
                {
                    await UniTask.Yield();
                }
            }
        }

        /// <summary>
        /// シーンを非同期でアンロードする
        /// </summary>
        public static async UniTask UnloadSceneAsync(string sceneName)
        {
            if (IsSceneLoaded(sceneName))
            {
                var unloadSceneOperation = UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
                while (unloadSceneOperation is { isDone: false })
                {
                    await UniTask.Yield();
                }
            }
        }

        /// <summary>
        /// シーンが読み込まれているかどうか
        /// </summary>
        public static bool IsSceneLoaded(string sceneName)
        {
            for (int i = 0; i < UnityEngine.SceneManagement.SceneManager.sceneCount; i++)
            {
                Scene scene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i);
                if (scene.name == sceneName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}