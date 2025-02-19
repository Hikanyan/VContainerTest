using UnityEngine;

namespace HikanyanLaboratory.UIToolSystem
{
    [CreateAssetMenu(fileName = "PresenterGeneratorSettings", menuName = "Tools/Presenter Generator Settings")]
    public class PresenterGeneratorSettings : ScriptableObject
    {
        public string outputDirectory = "Assets/Scripts/Generated/";
    }
}