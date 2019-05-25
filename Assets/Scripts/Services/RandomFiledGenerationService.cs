using System;
using System.Linq;
using Entities;
using Managers;
using UnityEngine;
using Utils;

namespace Services
{
    public class RandomFiledGenerationService : IInitializeble, IUnInitializeble
    {
        public Action<int> CurrentStepsToLeftCountChanged = delegate { };

        private static System.Random _random = new System.Random();

        private const int MAX_STEPS_RIGHT_COUNT = 7;
        private const int MIN_STEPS_LEFT_COUNT = 1;

        private int CurrentStepsCount
        {
            get
            {
                return _currentStepsCount;
            }
            set
            {
                if (_currentStepsCount == value)
                {
                    return;
                }

                Debug.Log(string.Format("Current steps left count changed from {0} to {1}", _currentStepsCount, value));

                _currentStepsCount = value;

                CurrentStepsToLeftCountChanged.Invoke(_currentStepsCount);
            }
        }
        // its count of steps from left border 
        // 1-7 steps - calculated experimentally
        // TODO: re-implement as dynamic calculation depend from screen wight and Cell size
        private int _currentStepsCount;

        private bool CanGoLeft
        {
            get
            {
                return MIN_STEPS_LEFT_COUNT < CurrentStepsCount;
            }
        }

        private bool CanGoRight
        {
            get
            {
                return CurrentStepsCount < MAX_STEPS_RIGHT_COUNT;
            }
        }

        public void Initialize()
        {
            _currentStepsCount = 4;
        }

        public void UnInitialize()
        {

        }

        public CellView AddCellToCell(CellView connectedCell)
        {
            // add random Cell
            var randomNumber = _random.Next(0, 2);
            var positionCorrection = new Vector3();
            if (randomNumber > 0)
            {
                positionCorrection = TryToModifyPositionCorrectionToGoLeft(positionCorrection);
            }
            else
            {
                positionCorrection = TryToModifyPositionCorrectionToGoRight(positionCorrection);
            }

            var instance = GameManager.Instance.GameObjectsManager.InstantiateCell();
            instance.transform.position = new Vector3(
                connectedCell.gameObject.transform.position.x + positionCorrection.x,
                connectedCell.gameObject.transform.position.y + positionCorrection.y,
                connectedCell.gameObject.transform.position.z + positionCorrection.z);

            return instance;
        }

        private Vector3 TryToModifyPositionCorrectionToGoLeft(Vector3 positionCorrection)
        {
            if (CanGoLeft)
            {
                positionCorrection.z++; // go left

                CurrentStepsCount--;
            }
            else
            {
                positionCorrection = TryToModifyPositionCorrectionToGoRight(positionCorrection);
            }

            return positionCorrection;
        }

        private Vector3 TryToModifyPositionCorrectionToGoRight(Vector3 positionCorrection)
        {
            if (CanGoRight)
            {
                positionCorrection.x++; // go right

                CurrentStepsCount++;
            }
            else
            {
                positionCorrection = TryToModifyPositionCorrectionToGoLeft(positionCorrection);
            }

            return positionCorrection;
        }
    }
}
