using HikanyanLaboratory.Script.VContainerTest.System;
using MessagePipe;
using TMPro;
using UnityEngine;
using VContainer;
using System;
using VContainer.Unity;

namespace HikanyanLaboratory.Script.VContainerScene
{
    public class SceneB : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private ISubscriber<string> _subscriber;
        private IDisposable _subscription;

        [Inject]
        public void Construct(GameMessageHandler gameMessageHandler)
        {
            _subscriber = gameMessageHandler.Subscriber;
        }

        void OnEnable()
        {
            _subscription = _subscriber.Subscribe(message =>
            {
                Debug.Log($"SceneB received: {message}");
                if (_text != null)
                {
                    _text.text = message;
                }
                else
                {
                    Debug.LogError("TMP_Text component is not assigned.");
                }
            });
        }

        void OnDisable()
        {
            _subscription?.Dispose();
        }
    }
}

