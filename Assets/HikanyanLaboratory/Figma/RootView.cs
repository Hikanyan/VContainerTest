using HikanyanLaboratory.UISystemTest;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HikanyanLaboratory.Figma
{
    public class RootView : UINodeBase
    {
        [SerializeField, AutoAssignByName("TextButton")]
        Button _buttonA;

        [SerializeField, AutoAssignByName("ButtonA/Label")]
        TextMeshProUGUI _buttonALabel;

        [SerializeField, AutoAssignByName("ButtonB")]
        Button _buttonB;

        [SerializeField, AutoAssignByName("ButtonB/Label")]
        TextMeshProUGUI _buttonBLabel;
    
        [SerializeField, AutoAssignByName("ImageA")]
        Image _image;
    }
}