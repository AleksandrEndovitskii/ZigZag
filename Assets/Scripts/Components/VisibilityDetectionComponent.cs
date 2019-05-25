using System;
using UnityEngine;

namespace Components
{
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
