using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    // поле по которому двигается шарик
    // Поле представляет собой набор квадратных тайлов, расположенных друг рядом с другом, по которым может катиться шарик.
    // Поле представляет собой дорожку толщиной в 1 тайл, направление которой может идти только прямо или право.

    //      генерация дорожки шириной в 1 тайл начинается только после этой площадки.
    // Поле генерируется случайным образом бесконечно, таким образом, чтобы по нему мог пройти шарик (не должно быть непроходимых участков).
    public class FieldView : MonoBehaviour
    {
        [SerializeField]
        private CellView _cellViewPrefab;

        private List<CellView> _cellViewInstance = new List<CellView>();

        private int _startWidth = 3;
        private int _startHeight = 3;

        private void Awake()
        {
            // В самом начале игры поле всегда представляет собой квадратную площадку тайлов размером 3*3,
            for (var x = 0; x < _startWidth; x++)
            {
                for (var y = 0; y < _startHeight; y++)
                {
                    var cellViewInstance = Instantiate(_cellViewPrefab);
                    cellViewInstance.gameObject.transform.position = new Vector3(
                        cellViewInstance.gameObject.transform.position.x + x,
                        cellViewInstance.gameObject.transform.position.y + y,
                        cellViewInstance.gameObject.transform.position.z);
                    cellViewInstance.transform.SetParent(this.gameObject.transform);
                    _cellViewInstance.Add(cellViewInstance);
                }
            }
        }
    }
}
