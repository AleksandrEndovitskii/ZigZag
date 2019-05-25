using UnityEngine;

namespace Components
{
    public class LowerScreenPartObjectDestroyerComponent : MonoBehaviour
    {
        private const int SCREEN_PART_DESTROY_TRIGGER = 4; // 1/4 of screen will trigger destruction

        private void Update()
        {
            var screenPosition = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
            if (screenPosition.y < Screen.height / SCREEN_PART_DESTROY_TRIGGER)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
