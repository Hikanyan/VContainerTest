using UnityEditor;

namespace HikanyanLaboratory.UI
{
    [InitializeOnLoad]
    public class PrefabBinderInitializer
    {
        static PrefabBinderInitializer()
        {
            PrefabLoader.Initialize();
        }
    }
}