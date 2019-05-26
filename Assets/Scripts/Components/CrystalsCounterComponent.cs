using Managers;
using TMPro;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CrystalsCounterComponent : MonoBehaviour
    {
        private const string DEFAULT_TEXT = "Collected crystals count: ";

        private void Awake()
        {
            CollectedCrystalsCountingServiceCollectedCrystalsCountChanged(GameManager.Instance.CollectedCrystalsCountingService.CollectedCrystalsCount);

            GameManager.Instance.CollectedCrystalsCountingService.CollectedCrystalsCountChanged += CollectedCrystalsCountingServiceCollectedCrystalsCountChanged;
        }

        private void CollectedCrystalsCountingServiceCollectedCrystalsCountChanged(int collectedCrystalsCount)
        {
            this.gameObject.GetComponent<TextMeshProUGUI>().text = DEFAULT_TEXT + collectedCrystalsCount;
        }
    }
}
