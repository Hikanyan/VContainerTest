using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace HikanyanLaboratory.Script.VContainerScene
{
    public class InGameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<GameEvent>(options);
            builder.RegisterMessageBroker<string>(options);

            builder.Register<InGameManager>(Lifetime.Scoped);
            builder.RegisterEntryPoint<InGameController>();

            builder.RegisterEntryPoint<VContainerTests>();
            builder.RegisterEntryPoint<AddressablesLoader>();

            
            
        }
    }
}