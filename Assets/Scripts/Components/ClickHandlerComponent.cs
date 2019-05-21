using UnityEngine;
using UnityEngine.UI;

namespace Components
{
    [RequireComponent(typeof(Button))]
    public class ClickHandlerComponent : MonoBehaviour
    {
        private void Awake()
        {
            this.gameObject.GetComponent<Button>().onClick.AddListener(ButtonOnClick);
        }
        private void OnDestroy()
        {
            this.gameObject.GetComponent<Button>().onClick.RemoveListener(ButtonOnClick);
        }

        private void ButtonOnClick()
        {
            Debug.Log("Click was handled.");
        }
    }
}
