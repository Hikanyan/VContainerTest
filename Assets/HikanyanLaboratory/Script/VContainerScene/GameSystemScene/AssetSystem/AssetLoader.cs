using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace HikanyanLaboratory.Script.VContainerScene
{
    public class AssetLoader
    {
        public static async UniTask<GameObject> LoadPrefabAsync(string key)
        {
            return await Addressables.InstantiateAsync(key);
        }
    }
}