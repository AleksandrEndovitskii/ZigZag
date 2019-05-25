using Components;
using Managers;
using UnityEngine;

namespace Entities
{
    // поле по которому двигается шарик
    // Поле представляет собой набор квадратных тайлов, расположенных друг рядом с другом, по которым может катиться шарик.
    // Поле представляет собой дорожку толщиной в 1 тайл, направление которой может идти только прямо или право.
    public class FieldView : MonoBehaviour
    {
        private int _startWidth = 3;
        private int _startHeight = 3;

        private CellView _lastSpawnedCellViewInstance = null;

        private void Awake()
        {
            // В самом начале игры поле всегда представляет собой квадратную площадку тайлов размером 3*3,
            // генерация дорожки шириной в 1 тайл начинается только после этой площадки.
            for (var x = 0; x < _startWidth; x++)
            {
                for (var z = 0; z < _startHeight; z++)
                {
                    var cellViewInstance = GameManager.Instance.GameObjectsManager.InstantiateCell();
                    cellViewInstance.gameObject.transform.position = new Vector3(
                        cellViewInstance.gameObject.transform.position.x + x,
                        cellViewInstance.gameObject.transform.position.y,
                        cellViewInstance.gameObject.transform.position.z + z);
                    cellViewInstance.transform.SetParent(this.gameObject.transform);

                    _lastSpawnedCellViewInstance = cellViewInstance;
                }
            }

            _lastSpawnedCellViewInstance.gameObject.AddComponent<CellSpawnerComponent>();
        }
    }
}
