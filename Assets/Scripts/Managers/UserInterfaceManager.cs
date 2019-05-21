using UnityEngine;
using UnityEngine.EventSystems;

namespace Managers
{
    public class UserInterfaceManager : MonoBehaviour
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
    }
}
