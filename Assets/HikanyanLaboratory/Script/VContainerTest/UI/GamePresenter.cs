using HikanyanLaboratory.Script.GameManager.System;
using UnityEngine;

namespace HikanyanLaboratory.Script.GameManager.UI
{
    public class GamePresenter
    {
        private readonly System.GameManager _gameManager;
        private readonly GameView _gameView;

        public GamePresenter(System.GameManager gameManager, GameView gameView)
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