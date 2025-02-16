using System.Collections.Generic;
using UnityEngine;

namespace HikanyanLaboratory.UISystemTest
{
    public interface IUINode
    {
        int Id { get; }
        UINodeBase Parent { get; }
        List<IUINode> Children { get; }
        bool IsActive { get; }

        void AddChild(IUINode child);
        void RemoveChild(IUINode child);
        void SetActiveChild(IUINode child);

        void OnInitialize();
        void OnOpenIn();
        void OnCloseIn();
        void OnOpenOut();
        void OnCloseOut();
    }
}