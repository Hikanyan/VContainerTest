using MessagePipe;
using VContainer;
using VContainer.Unity;

namespace HikanyanLaboratory.Script.MessagePipe
{
    public class InGameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // ここではScopedだが、MessageBrokerはSingletonのものを使う
            var options = builder.RegisterMessagePipe();
        
            // InGame専用の依存関係
            builder.Register<NoteJudge>(Lifetime.Scoped);
            builder.Register<ScoreManager>(Lifetime.Scoped);
        }
    }
}