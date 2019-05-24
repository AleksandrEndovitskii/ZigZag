using Managers;
using UnityEngine;

namespace Components
{
    public class ZAxisObjectFollowingComponent : MonoBehaviour
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
                this.gameObject.transform.position.x,
                targetObject.transform.position.x * 0.5f + targetObject.transform.position.z * 0.5f + HEIGHT_CORRECTION,
                this.gameObject.transform.position.z);
        }
    }
}
