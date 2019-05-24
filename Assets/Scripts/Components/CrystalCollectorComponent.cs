using Entities;
using Managers;
using UnityEngine;

namespace Components
{
    public class CrystalCollectorComponent : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            // Если шарик наезжает на кристалл, то кристалл исчезает с тайла и считается, что игрок подобрал этот кристалл.
            var crystalView = collision.gameObject.GetComponent<CrystalView>();
            if (crystalView != null)
            {
                Destroy(crystalView.gameObject);

                GameManager.Instance.CollectedCrystalsCountingService.CollectedCrystalsCount++;
            }
        }
    }
}
