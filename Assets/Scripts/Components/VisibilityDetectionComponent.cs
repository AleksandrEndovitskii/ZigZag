using System;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Renderer))]
    public class VisibilityDetectionComponent : MonoBehaviour
    {
        public Action<MonoBehaviour> IsVisibleChanged = delegate { };

        private void OnBecameInvisible()
        {
            IsVisibleChanged.Invoke(this);
        }

        private void OnBecameVisible()
        {
            IsVisibleChanged.Invoke(this);
        }
    }
}
