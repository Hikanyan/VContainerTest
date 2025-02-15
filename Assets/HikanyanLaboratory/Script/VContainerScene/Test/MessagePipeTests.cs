using MessagePipe;
using NUnit.Framework;
using VContainer;
using Assert = UnityEngine.Assertions.Assert;

namespace HikanyanLaboratory.Script.VContainerScene
{
    public class MessagePipeTests
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

        [Test]
        public void MessagePipe_PublishesAndReceivesMessage()
        {
            var publisher = container.Resolve<IPublisher<string>>();
            var subscriber = container.Resolve<ISubscriber<string>>();

            string receivedMessage = null;
            subscriber.Subscribe(msg => receivedMessage = msg);

            publisher.Publish("Hello World");

            Assert.AreEqual("Hello World", receivedMessage);
        }
    }
}