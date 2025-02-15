using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace HikanyanLaboratory.Script.VContainerScene
{
    public class AddressablesLoader : IInitializable
    {
        public async UniTask<GameObject> LoadPrefabAsync(string key)
        {
            try
            {
                Debug.Log($"Loading prefab: {key}");

                var handle = Addressables.LoadAssetAsync<GameObject>(key);
                var prefab = await handle.Task;

                if (prefab == null)
                {
                    Debug.LogError($"Failed to load prefab: {key}");
                    return null;
                }

                Debug.Log($"Prefab loaded successfully: {prefab.name}");
                return prefab;
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception occurred while loading prefab {key}: {ex.Message}");
                return null;
            }
        }

        public async void Initialize()
        {
            string testPrefabKey = "TestPrefab"; // Addressables に登録されているキーを指定

            var prefab = await LoadPrefabAsync(testPrefabKey);
            if (prefab != null)
            {
                Object.Instantiate(prefab); // プレハブをシーンに生成
            }
        }
    }
}