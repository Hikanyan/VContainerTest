using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace HikanyanLaboratory.Script.VContainerScene
{
    public class GameSystemLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // MessagePipeの設定
            var options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<GameEvent>(options);

            // シングルトンで管理するもの
            builder.Register<GameManager>(Lifetime.Singleton);
            builder.Register<AudioManager>(Lifetime.Singleton);
            builder.Register<UIManager>(Lifetime.Singleton);
        }
    }
}