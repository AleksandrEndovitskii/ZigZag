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
        [SerializeField]
        private BallView _ballViewPrefab;

        private Light _directionalLightInstance;

        private FieldView _fieldViewInstance;
        private BallView _ballViewInstance;

        public void Initialize()
        {
            _directionalLightInstance = Instantiate(_directionalLightPrefab);

            _fieldViewInstance = Instantiate(_fieldViewPrefab);
            _ballViewInstance = Instantiate(_ballViewPrefab);
            _ballViewInstance.transform.position = new Vector3(
                _ballViewInstance.gameObject.transform.position.x,
                _ballViewInstance.gameObject.transform.position.y + 1,
                _ballViewInstance.gameObject.transform.position.z);
        }
    }
}
