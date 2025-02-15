using System;
using UnityEngine;
using UnityEngine.UI;

namespace HikanyanLaboratory.Script.VContainerTest.UI
{
    public class GameView : MonoBehaviour
    {
        [SerializeField] Button _changeStateButton;

        public event Action OnChangeStateButtonClicked;

        void Awake()
        {
            _changeStateButton.onClick.AddListener(() =>
                OnChangeStateButtonClicked?.Invoke());
        }
    }
}