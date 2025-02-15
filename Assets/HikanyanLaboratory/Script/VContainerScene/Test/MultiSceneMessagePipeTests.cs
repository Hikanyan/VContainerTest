using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using MessagePipe;
using System.Collections;
using UnityEngine.Assertions;
using Assert = UnityEngine.Assertions.Assert;

namespace HikanyanLaboratory.Script.VContainerScene
{
    public class MultiSceneMessagePipeTests
    {
        private IContainerBuilder builder;
        private IObjectResolver container;

        [SetUp]
        public void SetUp()
        {
            var containerBuilder = new ContainerBuilder();

            var options = containerBuilder.RegisterMessagePipe();
            containerBuilder.RegisterMessageBroker<string>(options);
            container = containerBuilder.Build();
        }

        public IEnumerator MessagePipe_CommunicatesAcrossScenes()
        {
            SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
            yield return null;

            var publisher = container.Resolve<IPublisher<string>>();
            var subscriber = container.Resolve<ISubscriber<string>>();

            string receivedMessage = null;
            subscriber.Subscribe(msg => receivedMessage = msg);

            publisher.Publish("SceneChange");

            yield return new WaitForSeconds(0.1f);

            Assert.AreEqual("SceneChange", receivedMessage, "MessagePipe should communicate across scenes.");
        }
    }
}