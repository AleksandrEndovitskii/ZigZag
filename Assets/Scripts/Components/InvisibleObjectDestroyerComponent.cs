using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Renderer))]
    public class InvisibleObjectDestroyerComponent : MonoBehaviour
    {
        private void OnBecameInvisible()
        {
            Destroy(this.gameObject);
        }
    }
}
