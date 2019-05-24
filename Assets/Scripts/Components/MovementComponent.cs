using Managers;
using Services;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(ObjectMovementComponent))]
    public class MovementComponent : MonoBehaviour
    {
        private void Awake()
        {
            this.gameObject.GetComponent<ObjectMovementComponent>().enabled = false;

            GameManager.Instance.GameStateService.CurrentGameStateChanged += GameStateServiceCurrentGameStateChanged;
        }

        private void GameStateServiceCurrentGameStateChanged(GameState gameState)
        {
            if (gameState == GameState.Started)
            {
                StartMovement();
            }
        }

        // При начале игры шарик не двигается до тех пор, пока пользователь не кликнет в любой части экрана.
        private void StartMovement()
        {
            this.gameObject.GetComponent<ObjectMovementComponent>().enabled = true;
        }
    }
}
