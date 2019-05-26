using DG.Tweening;
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
                // to prevent body blocking
                crystalView.gameObject.GetComponent<Collider>().enabled = false;
                // добавить анимацию с использованием системы частиц исчезновения кристалла при подборе его с тайла
                crystalView.gameObject.GetComponent<DOTweenAnimation>().DORestartById("ScaleDown");
                // за подбор одного кристалла начисляется 1 очко
                GameManager.Instance.CollectedCrystalsCountingService.CollectedCrystalsCount++;
            }
        }
    }
}
