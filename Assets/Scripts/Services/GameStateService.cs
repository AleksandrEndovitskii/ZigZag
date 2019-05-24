using System;
using Managers;
using UnityEngine;

namespace Services
{
    public class GameStateService
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

        public GameStateService()
        {
            CurrentGameState = GameState.NotStarted;

            GameManager.Instance.ClickService.ClickHandled += ClickServiceClickHandled;
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
