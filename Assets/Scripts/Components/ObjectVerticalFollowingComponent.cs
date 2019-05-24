using Managers;
using UnityEngine;

namespace Components
{
    public class ObjectVerticalFollowingComponent : MonoBehaviour
    {
        // Камера при этом двигается за шариком таким образом, чтобы он всегда находился в центре экрана по вертикали.
        private void Update()
        {
            var targetObject = GameManager.Instance.GameObjectsManager.BallViewInstance;

            this.gameObject.transform.position = new Vector3(
                this.gameObject.transform.position.x,
                this.gameObject.transform.position.y,
                targetObject.transform.position.z);
        }
    }
}
