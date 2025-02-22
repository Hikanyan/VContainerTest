using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace HikanyanLaboratory.UISystem
{
    public class ScenarioScenePresenter : PresenterBase<ScenarioSceneView, ScenarioSceneModel>
    {
        public override UniTask InitializeAsync(CancellationToken ct)
        {
            // Presenterの初期化処理
            return default;
        }
        
    }
}