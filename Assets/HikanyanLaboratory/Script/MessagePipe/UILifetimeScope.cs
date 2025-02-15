using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace HikanyanLaboratory.Script.MessagePipe
{
    public sealed class UILifetimeScope : LifetimeScope
    {
        [SerializeField] private UIView _uiView;
    
        protected override void Configure(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe();
        
            builder.Register<UIPresenter>(Lifetime.Singleton);
            builder.Register<UIModel>(Lifetime.Singleton);
            builder.RegisterEntryPoint<UIPresenter>(Lifetime.Singleton);
            builder.RegisterEntryPoint<UIModel>(Lifetime.Singleton);

            builder.RegisterComponent(_uiView);
        }
    }

}