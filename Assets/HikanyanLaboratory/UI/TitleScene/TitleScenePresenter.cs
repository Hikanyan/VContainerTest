using System.Threading;
using Cysharp.Threading.Tasks;
using HikanyanLaboratory.UISystemTest;
using UnityEngine;

namespace HikanyanLaboratory.UI.TitleScene
{
    public class TitleScenePresenter : PresenterBase<TitleSceneView, TitleSceneModel>
    {
        public override async UniTask InitializeAsync(CancellationToken ct)
        {
            Debug.Log($"Initializing {Model.SceneName}");

            // ボタンイベントの登録
            View.StartButton.onClick.AddListener(() => Model.StartGame());
            View.TitleMenuButton.onClick.AddListener(() => Model.ExitGame());

            await UniTask.CompletedTask;
        }
    }
}