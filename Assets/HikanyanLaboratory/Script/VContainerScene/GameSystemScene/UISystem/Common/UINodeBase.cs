using System;
using System.Collections.Generic;
using UnityEngine;

namespace HikanyanLaboratory.UISystem
{
    public abstract class UINodeBase : MonoBehaviour, IUINode
    {
        public int Id { get; private set; }
        public UINodeBase Parent { get; private set; }
        public List<IUINode> Children { get; private set; } = new();
        public bool IsActive { get; protected set; }
        private UIManager _uiManager;

        public void Awake()
        {
            _uiManager = UIManager.Instance;
            if (Parent == null)
            {
                Parent = transform.parent?.GetComponent<UINodeBase>();
            }

            _uiManager.RegisterNode(this);
        }

        public void Start()
        {
            Id = gameObject.GetInstanceID();// Awakeで取得すると、インスタンスが生成される前に取得されてしまうため、Startで取得する
        }

        public void OnDestroy()
        {
            _uiManager.UnregisterNode(this);
        }


        public virtual void Initialize(int id, UINodeBase parent = null)
        {
            Id = id;
            Parent = parent;
            if (parent != null)
            {
                parent.AddChild(this);
            }
        }

        public void AddChild(IUINode child)
        {
            if (Children.Contains(child)) return;
            Children.Add(child);
            SetActiveChild(child);
        }

        public void RemoveChild(IUINode child)
        {
            if (!Children.Contains(child)) return;
            Children.Remove(child);
            if (Children.Count > 0)
            {
                SetActiveChild(Children[^1]); // 最後の要素をアクティブにする
            }
        }

        public void SetActiveChild(IUINode child)
        {
            foreach (var c in Children)
            {
                ((UINodeBase)c).IsActive = false;
            }

            ((UINodeBase)child).IsActive = true;
        }

        public virtual void OnInitialize()
        {
        }

        public virtual void OnOpenIn()
        {
        }

        public virtual void OnCloseIn()
        {
        }

        public virtual void OnOpenOut()
        {
        }

        public virtual void OnCloseOut()
        {
        }
    }
}