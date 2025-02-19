using HikanyanLaboratory.UISystemTest;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace HikanyanLaboratory.UI.TitleScene
{
    public class TitleSceneView : UIViewBase
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _titleMenuButton;
        
        public Button StartButton => _startButton;
        public Button TitleMenuButton => _titleMenuButton;
    }
}