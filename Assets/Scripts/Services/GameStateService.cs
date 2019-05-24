using System;
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
            CurrentGameState = GameState.None;
        }
    }

    public enum GameState
    {
        None,
        InProgress,
        Finished,
    }
}
