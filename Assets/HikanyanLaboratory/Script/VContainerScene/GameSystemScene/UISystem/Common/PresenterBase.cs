using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HikanyanLaboratory.UISystemTest
{
    public abstract class PresenterBase<TView, TModel> : UINodeBase
        where TView : UIViewBase
        where TModel : class, new()
    {
        protected TView View;
        protected TModel Model;

        public override void OnInitialize()
        {
            Model = new TModel();
            View = GetComponent<TView>();
            if (View == null)
            {
                Debug.LogError($"View component of type {typeof(TView).Name} not found on {gameObject.name}.");
            }

            InitializeAsync(CancellationToken.None).Forget();
        }

        public virtual UniTask InitializeAsync(CancellationToken ct)
        {
            return default;
        }
    }
}