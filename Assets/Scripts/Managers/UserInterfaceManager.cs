using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

namespace Managers
{
    public class UserInterfaceManager : MonoBehaviour, IInitializeble, IUnInitializeble
    {
        [SerializeField]
        private Canvas _windowsCanvasPrefab;
        [SerializeField]
        private EventSystem _eventSystemPrefab;

        private Canvas _windowsCanvasInstance;
        private EventSystem _eventSystemInstance;

        public void Initialize()
        {
            _windowsCanvasInstance = Instantiate(_windowsCanvasPrefab);
            _eventSystemInstance = Instantiate(_eventSystemPrefab);
        }

        public void UnInitialize()
        {
            Destroy(_eventSystemInstance.gameObject);
            _eventSystemInstance = null;
            Destroy(_windowsCanvasInstance.gameObject);
            _windowsCanvasInstance = null;
        }
    }
}
