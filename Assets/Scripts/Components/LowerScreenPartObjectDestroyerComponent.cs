using Managers;
using UnityEngine;

namespace Components
{
    public class LowerScreenPartObjectDestroyerComponent : MonoBehaviour
    {
        private readonly Vector3 ANIMATION_DIRECTION = Vector3.down;
        private const float ANIMATION_SPEED = 1;

        private void Update()
        {
            // добавить анимации пропадания тайлов, находящихся позади шарика (те, которые уже были пройдены)
            if (this.gameObject.transform.position.x < GameManager.Instance.GameObjectsManager.BallViewInstance.gameObject.transform.position.x - 1 &&
                this.gameObject.transform.position.z < GameManager.Instance.GameObjectsManager.BallViewInstance.gameObject.transform.position.z - 1)
            {
                this.gameObject.transform.Translate(ANIMATION_DIRECTION * ANIMATION_SPEED * Time.deltaTime,
                    Space.World);

                if (this.gameObject.GetComponent<InvisibleObjectDestroyerComponent>() == null)
                {
                    this.gameObject.AddComponent<InvisibleObjectDestroyerComponent>();
                }
            }
        }
    }
}
