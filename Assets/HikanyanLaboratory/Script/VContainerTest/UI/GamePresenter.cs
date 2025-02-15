using HikanyanLaboratory.Script.VContainerTest.System;
using UnityEngine;

namespace HikanyanLaboratory.Script.VContainerTest.UI
{
    public class GamePresenter
    {
        private readonly VContainerTest.System.GameManager _gameManager;
        private readonly GameView _gameView;

        public GamePresenter(VContainerTest.System.GameManager gameManager, GameView gameView)
        {
            _gameManager = gameManager;
            _gameView = gameView;
            Debug.Log("GameView Awake");
            _gameView.OnChangeStateButtonClicked += OnChangeStateButtonClicked;
        }

        public void OnChangeStateButtonClicked()
        {
            _gameManager.ChangeState(new PlayState());
        }
    }
}