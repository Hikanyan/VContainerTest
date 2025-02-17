using UnityEngine;

namespace HikanyanLaboratory.Figma
{
    [CreateAssetMenu(fileName = "CustomUnityFigmaBridgeSettings", menuName = "New Figma Bridge Settings")]
    public sealed class CustomUnityFigmaBridgeSettings : ScriptableObject
    {
        [SerializeField] string _accessToken;
        public string AccessToken {
            get => _accessToken;
            set => _accessToken = value;
        }
    }
}