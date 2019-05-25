using System.Collections.Generic;
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
        private CellView _cellViewPrefab;
        [SerializeField]
        private BallView _ballViewPrefab;

        public BallView BallViewInstance;
        public List<CellView> CellViewInstances = new List<CellView>();

        private Light _directionalLightInstance;
        private Camera _cameraInstance;

        private FieldView _fieldViewInstance;

        public void Initialize()
        {
            _directionalLightInstance = Instantiate(_directionalLightPrefab);
            _cameraInstance = Instantiate(_cameraPrefab);

            _fieldViewInstance = Instantiate(_fieldViewPrefab);
            CellViewInstances = new List<CellView>();
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
            foreach (var cellViewInstance in CellViewInstances)
            {
                Destroy(cellViewInstance.gameObject);
            }
            CellViewInstances = null;
            Destroy(_fieldViewInstance.gameObject);
            _fieldViewInstance = null;
            Destroy(_cameraInstance.gameObject);
            _cameraInstance = null;
            Destroy(_directionalLightInstance.gameObject);
            _directionalLightInstance = null;
        }

        public CellView InstantiateCell()
        {
            var instance = Instantiate(_cellViewPrefab, this.gameObject.transform);

            CellViewInstances.Add(instance);

            return instance;
        }
    }
}
