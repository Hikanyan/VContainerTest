using HikanyanLaboratory.Script.GameManager.UI;
using VContainer;
using VContainer.Unity;

namespace HikanyanLaboratory.Script.GameManager.System
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<GameStateMachine>(Lifetime.Singleton);
            builder.Register<TitleState>(Lifetime.Singleton);
            builder.Register<PlayState>(Lifetime.Singleton);

            builder.Register<System.GameManager>(Lifetime.Singleton);


            builder.RegisterComponentInHierarchy<GameView>();
            builder.Register<GamePresenter>(Lifetime.Singleton).AsSelf();
        }

        private void Start()
        {
            var gameManager = Container.Resolve<System.GameManager>();
            var gamePresenter = Container.Resolve<GamePresenter>();
        }
    }
}