using HikanyanLaboratory.Script.VContainerTest.System;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace HikanyanLaboratory.Script.VContainerScene
{
    public class SceneA : MonoBehaviour
    {
        [SerializeField] private string _message = "Scene A says Hello!";
        private IPublisher<string> _publisher;

        void Start()
        {
            // `LifetimeScope` から `Container` を取得
            var container = this.GetComponentInParent<LifetimeScope>().Container;
            _publisher = container.Resolve<IPublisher<string>>();

            // メッセージを発行
            _publisher.Publish(_message);
            Debug.Log($"SceneA published: {_message}");
        }
    }
}