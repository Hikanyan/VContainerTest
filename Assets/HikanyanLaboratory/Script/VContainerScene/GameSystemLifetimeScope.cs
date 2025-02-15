using UnityEngine;
using VContainer;
using VContainer.Unity;
using MessagePipe;

namespace HikanyanLaboratory.Script.MessagePipe
{
    public class GameSystemLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // MessagePipe の設定
            var options = builder.RegisterMessagePipe();
        
            // グローバルに使うメッセージブローカー（スコア通知）
            builder.RegisterMessageBroker<int>(options)
                .AsImplementedInterfaces()
                .WithLifetime(Lifetime.Singleton);

            // その他のシングルトン管理
            builder.Register<GameManager>(Lifetime.Singleton);
        }
    }
}