using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace HikanyanLaboratory.UISystem
{
    public class TitleScenePresenter : PresenterBase<TitleSceneView, TitleSceneModel>
    {
        public override UniTask InitializeAsync(CancellationToken ct)
        {
            View.StartButton.onClick.AddListener(() => { Model.StartGame(); });

            View.TitleMenuButton.onClick.AddListener(() => { Model.OpenTitleMenu(); });
            return default;
        }
    }
}