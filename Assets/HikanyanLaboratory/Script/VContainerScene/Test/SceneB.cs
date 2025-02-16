using HikanyanLaboratory.Script.VContainerTest.System;
using MessagePipe;
using TMPro;
using UnityEngine;
using VContainer;
using System;
using VContainer.Unity;

namespace HikanyanLaboratory.Script.VContainerScene
{
    public class SceneB : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private ISubscriber<string> _subscriber;
        private IDisposable _subscription;

        void Start()
        {
            // `LifetimeScope` から `Container` を取得
            var container = this.GetComponentInParent<LifetimeScope>().Container;
            _subscriber = container.Resolve<ISubscriber<string>>();

            // メッセージを受信
            _subscription = _subscriber.Subscribe(message =>
            {
                Debug.Log($"SceneB received: {message}");
                if (_text != null)
                {
                    _text.text = message; // 受信メッセージを UI に表示
                }
                else
                {
                    Debug.LogError("TMP_Text component is not assigned.");
                }
            });
        }

        void OnDestroy()
        {
            _subscription?.Dispose(); // メモリリーク防止
        }
    }
}