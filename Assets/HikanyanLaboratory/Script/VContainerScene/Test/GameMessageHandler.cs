using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using System;

namespace HikanyanLaboratory.Script.VContainerScene
{
    public class GameMessageHandler : IStartable, IDisposable
    {
        private readonly ISubscriber<string> _subscriber;
        private readonly IPublisher<string> _publisher;
        private IDisposable _subscription;

        [Inject]
        public GameMessageHandler(ISubscriber<string> subscriber, IPublisher<string> publisher)
        {
            _subscriber = subscriber;
            _publisher = publisher;
        }

        public void Start()
        {
            // メッセージを受信
            _subscription = _subscriber.Subscribe(message => Debug.Log($"GameMessageHandler received: {message}"));

            // メッセージを発行
            _publisher.Publish("Game Started!");
        }

        public void Dispose()
        {
            _subscription?.Dispose();
        }
    }
}