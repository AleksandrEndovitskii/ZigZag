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
