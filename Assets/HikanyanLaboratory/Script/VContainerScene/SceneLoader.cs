using System.Collections;
using VContainer;
using VContainer.Unity;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using MessagePipe;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HikanyanLaboratory.Script.VContainerScene
{
    class SceneLoader
    {
        private readonly LifetimeScope _parent;

        public SceneLoader(LifetimeScope lifetimeScope)
        {
            _parent = lifetimeScope;
        }
        

        async UniTask LoadSceneAsync()
        {
            using (LifetimeScope.EnqueueParent(_parent))
            {
                await SceneManager.LoadSceneAsync("...", LoadSceneMode.Additive);
            }
        }
    }
}