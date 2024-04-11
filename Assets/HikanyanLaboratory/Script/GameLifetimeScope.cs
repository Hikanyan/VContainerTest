using VContainer;
using VContainer.Unity;

namespace HikanyanLaboratory.Script
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IMessageService, ConsoleMessageService>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<GameController>();
        }
    }
}