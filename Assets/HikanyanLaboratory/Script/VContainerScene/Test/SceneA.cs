using MessagePipe;
using UnityEngine;
using VContainer;

namespace HikanyanLaboratory.Script.VContainerScene
{
    public class SceneA : MonoBehaviour
    {
        [SerializeField] private string _message = "Scene A says Hello!";
        private IPublisher<string> _publisher;

        [Inject]
        public void Construct(GameMessageHandler gameMessageHandler)
        {
            _publisher = gameMessageHandler.MessagePublisher;
        }

        void Start()
        {
            if (_publisher == null)
            {
                Debug.LogError("SceneA: _publisher is null. Ensure dependency injection is working.");
                return;
            }

            _publisher.Publish(_message);
            Debug.Log($"SceneA published: {_message}");
        }
    }
}