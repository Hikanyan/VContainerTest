using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using System;

namespace HikanyanLaboratory.Script.VContainerScene
{
    public class GameMessageHandler
    {
        public GameMessageHandler(IPublisher<string> messagePublisher, ISubscriber<string> subscriber)
        {
            MessagePublisher = messagePublisher;
            Subscriber = subscriber;
        }

        public IPublisher<string> MessagePublisher { get; }
        public readonly ISubscriber<string> Subscriber;
    }
}