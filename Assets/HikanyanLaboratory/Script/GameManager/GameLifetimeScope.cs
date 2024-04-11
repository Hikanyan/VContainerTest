using VContainer;
using VContainer.Unity;

namespace HikanyanLaboratory.Script.GameManager
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameStateMachine>(Lifetime.Singleton);
            builder.Register<TitleState>(Lifetime.Singleton);
            builder.Register<PlayState>(Lifetime.Singleton);

            builder.Register<GameManager>(Lifetime.Singleton).AsSelf()
                .WithParameter("stateMachine", new GameStateMachine()); //ここでGameStateMachineを生成して渡している
        }
    }
}