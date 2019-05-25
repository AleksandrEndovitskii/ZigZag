using Managers;
using UnityEngine;

namespace Components
{
    public class XZAxisObjectFollowingComponent : MonoBehaviour
    {
        private const float HEIGHT_CORRECTION = 3f;

        // Камера при этом двигается за шариком таким образом, чтобы он всегда находился в центре экрана по вертикали.
        private void Update()
        {
            var targetObject = GameManager.Instance.GameObjectsManager.BallViewInstance;

            if (targetObject == null)
            {
                return;
            }

            this.gameObject.transform.position = new Vector3(
                (targetObject.gameObject.transform.position.x + targetObject.gameObject.transform.position.z) / 2 - HEIGHT_CORRECTION,
                this.gameObject.transform.position.y,
                (targetObject.gameObject.transform.position.x + targetObject.gameObject.transform.position.z) / 2 - HEIGHT_CORRECTION);
        }
    }
}
