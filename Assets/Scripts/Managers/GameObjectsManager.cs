using Entities;
using UnityEngine;

namespace Managers
{
    public class GameObjectsManager : MonoBehaviour
    {
        [SerializeField]
        private FieldView _fieldViewPrefab;

        private FieldView _fieldViewInstance;

        public void Initialize()
        {
            _fieldViewInstance = Instantiate(_fieldViewPrefab);
        }
    }
}
