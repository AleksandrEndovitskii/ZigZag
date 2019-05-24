using Entities;
using UnityEngine;

namespace Managers
{
    public class GameObjectsManager : MonoBehaviour
    {
        [SerializeField]
        private Light _directionalLightPrefab;
        [SerializeField]
        private Camera _cameraPrefab;

        [SerializeField]
        private FieldView _fieldViewPrefab;
        [SerializeField]
        private BallView _ballViewPrefab;

        private Light _directionalLightInstance;
        private Camera _cameraInstance;

        private FieldView _fieldViewInstance;
        public BallView BallViewInstance;

        public void Initialize()
        {
            _directionalLightInstance = Instantiate(_directionalLightPrefab);
            _cameraInstance = Instantiate(_cameraPrefab);

            _fieldViewInstance = Instantiate(_fieldViewPrefab);
            BallViewInstance = Instantiate(_ballViewPrefab);
            BallViewInstance.transform.position = new Vector3(
                BallViewInstance.gameObject.transform.position.x,
                BallViewInstance.gameObject.transform.position.y + 1,
                BallViewInstance.gameObject.transform.position.z);
        }
    }
}
