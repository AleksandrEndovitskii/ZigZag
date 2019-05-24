using Entities;
using UnityEngine;

namespace Managers
{
    public class GameObjectsManager : MonoBehaviour
    {
        [SerializeField]
        private Light _directionalLightPrefab;

        [SerializeField]
        private FieldView _fieldViewPrefab;

        private Light _directionalLightInstance;

        private FieldView _fieldViewInstance;

        public void Initialize()
        {
            _directionalLightInstance = Instantiate(_directionalLightPrefab);

            _fieldViewInstance = Instantiate(_fieldViewPrefab);
        }
    }
}
