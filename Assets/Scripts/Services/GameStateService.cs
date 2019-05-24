using System;
using Managers;
using UnityEngine;
using Utils;

namespace Services
{
    public class GameStateService : IInitializeble, IUnInitializeble
    {
        public Action<GameState> CurrentGameStateChanged = delegate { };

        public GameState CurrentGameState
        {
            get
            {
                return _currentGameState;
            }
            set
            {
                if (_currentGameState == value)
                {
                    return;
                }

                Debug.Log(string.Format("Current game state changed from {0} to {1}", _currentGameState, value));

                _currentGameState = value;

                CurrentGameStateChanged.Invoke(_currentGameState);
                // игрок проигрывает,
                if (_currentGameState == GameState.Finished)
                {
                    Time.timeScale = 0;
                }
                // re-initializing the game
                if (_currentGameState == GameState.NotStarted)
                {
                    Time.timeScale = 1;

                    GameManager.Instance.ReInitialize();
                }
            }
        }

        private GameState _currentGameState;

        public void Initialize()
        {
            CurrentGameState = GameState.NotStarted;

            GameManager.Instance.ClickService.ClickHandled += ClickServiceClickHandled;
        }

        public void UnInitialize()
        {
            GameManager.Instance.ClickService.ClickHandled -= ClickServiceClickHandled;
        }

        private void ClickServiceClickHandled()
        {
            // в таком случае игра начинает заново по клику в любой части экрана.
            if (CurrentGameState == GameState.Finished)
            {
                CurrentGameState = GameState.NotStarted;

                return;
            }

            if (CurrentGameState != GameState.Started)
            {
                CurrentGameState = GameState.Started;
            }
        }
    }

    public enum GameState
    {
        NotStarted,
        Started,
        Finished,
    }
}
