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
            // MessagePipeの受信登録
            var resolver = Parent.Container;
            var subscriber = resolver.Resolve<ISubscriber<GameEvent>>();

            builder.Register<InGameManager>(Lifetime.Scoped);
            builder.RegisterEntryPoint<InGameController>();

            // 受信処理の例
            subscriber.Subscribe(e => Debug.Log($"Received event: {e.Type}"));
            builder.RegisterEntryPoint<VContainerTests>();
            builder.RegisterEntryPoint<AddressablesLoader>();
        }
    }
}