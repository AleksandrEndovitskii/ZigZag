using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entities
{
    // поле по которому двигается шарик
    // Поле представляет собой набор квадратных тайлов, расположенных друг рядом с другом, по которым может катиться шарик.
    // Поле представляет собой дорожку толщиной в 1 тайл, направление которой может идти только прямо или право.
    public class FieldView : MonoBehaviour
    {
        [SerializeField]
        private CellView _cellViewPrefab;

        private List<CellView> _cellViewInstance = new List<CellView>();

        private int _startWidth = 3;
        private int _startHeight = 3;

        private static System.Random _random = new System.Random();

        private void Awake()
        {
            // В самом начале игры поле всегда представляет собой квадратную площадку тайлов размером 3*3,
            // генерация дорожки шириной в 1 тайл начинается только после этой площадки.
            for (var x = 0; x < _startWidth; x++)
            {
                for (var z = 0; z < _startHeight; z++)
                {
                    var cellViewInstance = Instantiate(_cellViewPrefab);
                    cellViewInstance.gameObject.transform.position = new Vector3(
                        cellViewInstance.gameObject.transform.position.x + x,
                        cellViewInstance.gameObject.transform.position.y,
                        cellViewInstance.gameObject.transform.position.z + z);
                    cellViewInstance.transform.SetParent(this.gameObject.transform);
                    _cellViewInstance.Add(cellViewInstance);
                }
            }

            // Поле генерируется случайным образом бесконечно, таким образом, чтобы по нему мог пройти шарик (не должно быть непроходимых участков).
            for (var i = 0; i < 100; i++)
            {
                if (!_cellViewInstance.Any())
                {
                    return;
                }

                var connectedCell = _cellViewInstance.Last();
                AddCell(connectedCell);
            }
        }

        private void AddCell(CellView connectedCell)
        {
            // add random Cell
            var randomNumber = _random.Next(0, 2);
            var positionCorrectionX = 0f;
            var positionCorrectionZ = 0f;
            if (randomNumber > 0)
            {
                positionCorrectionX++; // forward
            }
            else
            {
                positionCorrectionZ++; // right
            }

            var instance = Instantiate(_cellViewPrefab, this.gameObject.transform);
            instance.transform.position = new Vector3(
                connectedCell.gameObject.transform.position.x + positionCorrectionX,
                connectedCell.gameObject.transform.position.y,
                connectedCell.gameObject.transform.position.z + positionCorrectionZ);
            _cellViewInstance.Add(instance);
        }
    }
}
