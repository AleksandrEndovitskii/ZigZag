using Entities;
using UnityEngine;
using Utils;

namespace Managers
{
    public class GameObjectsManager : MonoBehaviour, IInitializeble, IUnInitializeble
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

        public void UnInitialize()
        {
            Destroy(BallViewInstance.gameObject);
            BallViewInstance = null;
            Destroy(_fieldViewInstance.gameObject);
            _fieldViewInstance = null;
            Destroy(_cameraInstance.gameObject);
            _cameraInstance = null;
            Destroy(_directionalLightInstance.gameObject);
            _directionalLightInstance = null;
        }
    }
}
