using UnityEngine;

namespace Components
{
    public class RandomItemSpawnerComponent : MonoBehaviour
    {
        [SerializeField]
        private GameObject _Prefab;

        private GameObject _instance;

        private static System.Random _random = new System.Random();

        private void Awake()
        {
            var randomNumber = _random.Next(0, 2);
            // На каждом тайле может быть 1 кристалл или ни одного, это определяется случайным образом.
            if (randomNumber > 0)
            {
                _instance = Instantiate(_Prefab, this.gameObject.transform);
            }
        }
    }
}
