using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace HikanyanLaboratory.Script.VContainerScene
{
    public class VContainerTests : IInitializable
    {
        public void Initialize()
        {
            GameManager_IsSingleton();
        }

        public void GameManager_IsSingleton()
        {
            var builder = new ContainerBuilder();
            builder.Register<GameManager>(Lifetime.Singleton);
            var container = builder.Build();

            var instance1 = container.Resolve<GameManager>();
            var instance2 = container.Resolve<GameManager>();

            Debug.Log($"GameManager {instance1} {instance2}");
        }
    }
}