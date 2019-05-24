using System;
using UnityEngine;

namespace Services
{
    public class CollectedCrystalsCountingService
    {
        public Action<int> CollectedCrystalsCountChanged = delegate { };

        public int CollectedCrystalsCount
        {
            get
            {
                return _collectedCrystalsCount;
            }
            set
            {
                if (_collectedCrystalsCount == value)
                {
                    return;
                }

                Debug.Log(string.Format("Collected crystals count changed from {0} to {1}", _collectedCrystalsCount, value));

                _collectedCrystalsCount = value;

                CollectedCrystalsCountChanged.Invoke(_collectedCrystalsCount);
            }
        }

        private int _collectedCrystalsCount;

        public CollectedCrystalsCountingService()
        {
            CollectedCrystalsCount = 0;
        }
    }
}
