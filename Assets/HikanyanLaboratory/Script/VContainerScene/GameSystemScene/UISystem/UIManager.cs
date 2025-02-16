using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace HikanyanLaboratory.UISystemTest
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        private readonly Dictionary<int, IUINode> _activeUiNodes = new();
        private readonly List<IUINode> _uiStack = new();
        [SerializeField] private Canvas _rootCanvas;
        private bool _inputOrderFixEnabled = true;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// UI ノードを `UIManager` に登録
        /// </summary>
        public void RegisterNode(UINodeBase node)
        {
            if (node == null) return;
            _activeUiNodes.TryAdd(node.Id, node);
            // 画面を開く（Push）
            PushNode(node);
        }

        /// <summary>
        /// UI ノードを `UIManager` から削除
        /// </summary>
        public void UnregisterNode(UINodeBase node)
        {
            if (node == null) return;

            _activeUiNodes.Remove(node.Id);
            PopNode(node);
            Destroy(node.gameObject);
        }

        /// <summary>
        /// UIを開く（既存のものがあれば最前面に移動）
        /// </summary>
        public T Open<T>(string prefabKey, UINodeBase parent = null)
            where T : UINodeBase
        {
            // すでに開いているものがあれば最前面に移動
            foreach (var uiNode in _activeUiNodes.Values)
            {
                if (uiNode is not T existingNode) continue;
                BringToFront(existingNode);
                return existingNode;
            }

            // UINodeFactory でインスタンスを作成
            var node = UINodeFactory.Create<T>(prefabKey, parent);
            if (node == null) return null;
            // UI ノードを rootCanvas の下に配置
            if (parent == null)
            {
                node.transform.SetParent(_rootCanvas.transform, false);
            }

            // アクティブな UI に追加
            RegisterNode(node);
            return node;
        }


        /// <summary>
        /// UIを閉じる（UINodeBaseのID指定で閉じる）
        /// </summary>
        public void Close<T>() where T : UINodeBase
        {
            // `T` 型の UI を `_activeUiNodes` から検索し、対応する `Id` を取得
            var entry = _activeUiNodes.FirstOrDefault(x => x.Value is T);
            int id = entry.Key;
            // 該当する UI が見つからなければ終了
            if (!_activeUiNodes.TryGetValue(id, out var node) || node is not T typedNode) return;
            UnregisterNode(typedNode);
        }


        /// <summary>
        /// 画面を開く（Push）
        /// </summary>
        private void PushNode(IUINode uiNode)
        {
            uiNode.OnInitialize();
            uiNode.OnOpenIn();
            uiNode.OnOpenOut();
            _uiStack.Insert(0, uiNode);
            FixInputOrder();
        }

        /// <summary>
        /// 画面を閉じる（Pop）
        /// </summary>
        private void PopNode(IUINode uiNode)
        {
            if (!_uiStack.Contains(uiNode)) return;
            uiNode.OnCloseIn();
            uiNode.OnCloseOut();
            _uiStack.Remove(uiNode);
        }

        /// <summary>
        /// 画面を最前面に移動
        /// </summary>
        private void BringToFront(IUINode node)
        {
            if (!_uiStack.Contains(node)) return;

            _uiStack.Remove(node);
            _uiStack.Insert(0, node);
            FixInputOrder();
        }

        /// <summary>
        /// Unity UI の入力順序修正
        /// </summary>
        private void FixInputOrder()
        {
            if (!_inputOrderFixEnabled) return;

            int order = 0;
            foreach (Transform child in _rootCanvas.transform)
            {
                var canvas = child.GetComponent<Canvas>();
                if (canvas == null) continue;
                canvas.overrideSorting = true;
                canvas.sortingOrder = order++;
            }
        }
    }
}