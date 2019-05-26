using System;
using UnityEngine;
using Utils;

namespace Services
{
    // реализовать систему подсчета очков
    public class CollectedCrystalsCountingService : IInitializeble, IUnInitializeble
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

        public void Initialize()
        {
            CollectedCrystalsCount = 0;
        }

        public void UnInitialize()
        {

        }
    }
}
