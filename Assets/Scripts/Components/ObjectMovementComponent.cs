using Managers;
using UnityEngine;

namespace Components
{
    public class ObjectMovementComponent : MonoBehaviour
    {
        private void Update()
        {
            // Move the object forward along its z axis 1 unit/second.
            this.gameObject.transform.Translate(
                GameManager.Instance.MovementDirectionService.CurrentMovementDirection *
                GameManager.Instance.MovementSpeedService.CurrentMovementSpeed * Time.deltaTime,
                Space.World);
        }
    }
}
