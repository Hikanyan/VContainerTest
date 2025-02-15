using MessagePipe;
using R3;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace HikanyanLaboratory.Script.MessagePipe
{
    public class UIView : MonoBehaviour
    {
        [SerializeField] 
        private Button _button;

        [SerializeField] 
        private Text _text;
    
        [Inject]
        private readonly IPublisher<Unit> _publisher;

        private void Start()
        {
            var onPush = _button.onClick.AsObservable();

            onPush.Subscribe(_publisher.Publish);
        }

        public void ChangeText(int num)
        {
            _text.text = num.ToString();
        }
    }

}