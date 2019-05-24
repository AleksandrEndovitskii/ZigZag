using Managers;
using UnityEngine;

namespace Components
{
    public class ObjectMovementComponent : MonoBehaviour
    {
        private void Update()
        {
            this.gameObject.transform.Translate(
                GameManager.Instance.MovementDirectionService.CurrentMovementDirection *
                GameManager.Instance.MovementSpeedService.CurrentMovementSpeed * Time.deltaTime,
                Space.World);
        }
    }
}
