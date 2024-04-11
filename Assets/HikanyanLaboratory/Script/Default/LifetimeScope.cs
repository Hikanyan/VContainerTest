using VContainer;
using VContainer.Unity;

namespace HikanyanLaboratory.Script.Default
{
    public class LifetimeScope : VContainer.Unity.LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IMessageService, ConsoleMessageService>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<GameController>();
        }
    }
}