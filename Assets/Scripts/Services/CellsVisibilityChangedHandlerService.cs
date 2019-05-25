using Components;
using Entities;
using Managers;
using UnityEngine;
using Utils;

namespace Services
{
    public class CellsVisibilityChangedHandlerService : IInitializeble, IUnInitializeble
    {
        public void Initialize()
        {

        }

        public void UnInitialize()
        {

        }

        public void WatchForBecameVisible(CellView cellView)
        {
            cellView.gameObject.GetComponent<VisibilityDetectionComponent>().IsVisibleChanged += LastSpawnedCellViewInstanceIsVisibleChanged;
        }

        private void LastSpawnedCellViewInstanceIsVisibleChanged(MonoBehaviour monoBehaviour)
        {
            if (!monoBehaviour.gameObject.GetComponent<Renderer>().isVisible)
            {
                return;
            }

            monoBehaviour.gameObject.GetComponent<VisibilityDetectionComponent>().IsVisibleChanged -= LastSpawnedCellViewInstanceIsVisibleChanged;

            // Поле генерируется случайным образом бесконечно, таким образом, чтобы по нему мог пройти шарик (не должно быть непроходимых участков).
            var cellView = GameManager.Instance.RandomFiledGenerationService.AddCellToCell(monoBehaviour.GetComponent<CellView>());
            cellView.gameObject.GetComponent<VisibilityDetectionComponent>().IsVisibleChanged += LastSpawnedCellViewInstanceIsVisibleChanged;
        }
    }
}
