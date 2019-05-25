using Entities;
using Managers;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Renderer))]
    [RequireComponent(typeof(CellView))]
    public class CellSpawnerComponent : MonoBehaviour
    {
        private void OnBecameVisible()
        {
            Destroy(this);

            // Поле генерируется случайным образом бесконечно, таким образом, чтобы по нему мог пройти шарик (не должно быть непроходимых участков).
            var cellView = GameManager.Instance.RandomFiledGenerationService.AddCellToCell(this.gameObject.GetComponent<CellView>());

            cellView.gameObject.AddComponent<CellSpawnerComponent>();
        }
    }
}
