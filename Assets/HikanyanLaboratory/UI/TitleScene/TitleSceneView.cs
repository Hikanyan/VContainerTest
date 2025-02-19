using HikanyanLaboratory.Figma;
using HikanyanLaboratory.UISystem;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace HikanyanLaboratory.UI.TitleScene
{
    public class TitleSceneView : UIViewBase
    {
        [SerializeField,AutoAssignByName("StartButton")] private Button _startButton;
        [SerializeField,AutoAssignByName("TitleMenuButton")] private Button _titleMenuButton;
        
        public Button StartButton => _startButton;
        public Button TitleMenuButton => _titleMenuButton;
    }
}