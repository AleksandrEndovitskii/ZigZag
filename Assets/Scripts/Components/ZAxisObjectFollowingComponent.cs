using Managers;
using UnityEngine;

namespace Components
{
    public class ZAxisObjectFollowingComponent : MonoBehaviour
    {
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
                this.gameObject.transform.position.y,
                targetObject.transform.position.z);
        }
    }
}
