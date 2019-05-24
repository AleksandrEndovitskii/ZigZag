﻿using UnityEngine;

namespace Components
{
    public class RandomCrystalSpawnerComponent : MonoBehaviour
    {
        [SerializeField]
        private CrystalComponent _crystalComponentPrefab;

        private CrystalComponent _crystalComponentInstance;

        private static System.Random _random = new System.Random();

        private void Awake()
        {
            var randomNumber = _random.Next(0, 2);
            // На каждом тайле может быть 1 кристалл или ни одного, это определяется случайным образом.
            if (randomNumber > 0)
            {
                _crystalComponentInstance = Instantiate(_crystalComponentPrefab, this.gameObject.transform);
            }
        }
    }
}