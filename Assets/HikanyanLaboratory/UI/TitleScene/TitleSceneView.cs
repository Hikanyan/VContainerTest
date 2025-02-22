using HikanyanLaboratory.Figma;
using UnityEngine;
using UnityEngine.UI;

namespace HikanyanLaboratory.UISystem
{
    public class TitleSceneView : UIViewBase
    {
        [SerializeField, AutoAssignByName("StartButton")]
        private Button _startButton;

        [SerializeField, AutoAssignByName("TitleMenuButton")]
        private Button _titleMenuButton;

        public Button StartButton => _startButton;
        public Button TitleMenuButton => _titleMenuButton;
    }
}