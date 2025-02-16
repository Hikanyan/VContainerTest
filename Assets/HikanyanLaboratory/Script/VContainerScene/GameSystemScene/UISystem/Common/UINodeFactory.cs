using HikanyanLaboratory.UI;
using UnityEngine;

namespace HikanyanLaboratory.UISystemTest
{
    public static class UINodeFactory
    {
        public static T Create<T>(string prefabKey, UINodeBase parent = null) where T : UINodeBase
        {
            GameObject prefab = PrefabLoader.GetPrefab(prefabKey);
            if (prefab == null)
            {
                Debug.LogError($"Prefab for {typeof(T).Name} is null!");
                return null;
            }

            GameObject instance = Object.Instantiate(prefab, parent?.transform);

            var node = instance.GetComponent<T>();

            if (node == null)
            {
                Debug.LogError($"<Color=red> {typeof(T).Name} is not found in prefab {prefabKey} </Color>");
                return null;
            }

            node.Initialize(instance.GetInstanceID(), parent);
            return node;
        }
    }
}