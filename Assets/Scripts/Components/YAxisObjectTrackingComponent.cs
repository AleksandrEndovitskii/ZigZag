using Managers;
using Services;
using UnityEngine;

namespace Components
{
    public class YAxisObjectTrackingComponent : MonoBehaviour
    {
        // Если шарик выходит за рамки тайла в пустое пространство (туда, где нет тайла), то  шарик падает за поле
        private void Update()
        {
            if (this.gameObject.transform.position.y < 0)
            {
                GameManager.Instance.GameStateService.CurrentGameState = GameState.Finished;
            }
        }
    }
}
