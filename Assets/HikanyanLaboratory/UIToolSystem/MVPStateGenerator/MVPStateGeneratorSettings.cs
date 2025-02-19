using UnityEngine;
using UnityEngine.Serialization;

namespace HikanyanLaboratory.UIToolSystem
{
    [CreateAssetMenu(fileName = "MVPStateGeneratorSettings", menuName = "HikanyanTools/MVPStateGeneratorSettings")]
    public class MVPStateGeneratorSettings : ScriptableObject
    {
        public string OutputDirectory = "Assets/HikanyanLaboratory/UIToolSystem/MVPStateGenerator/Generated/";
    }
}