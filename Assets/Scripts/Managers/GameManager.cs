using Services;
using UnityEngine;
using Utils;

/*
Требования к реализации:
1) Игра должна быть реализована с использованием Unity3D + C#
2) Для реализации можно использовать Unity3D любой удобной вам версии
3) Реализация должна быть сделана с уклоном на расширяемость игры.
4) В реализации тестового задания разрешается использовать готовые ассеты. 
5) Необязательным, но огромным плюсом в реализации проекта будет использование практик Внедрения Зависимостей и любого DI контейнера.
 */

namespace Managers
{
    public class GameManager : MonoBehaviour, IInitializeble, IUnInitializeble, IReInitializeble
    {
        // static instance of GameManager which allows it to be accessed by any other script 
        public static GameManager Instance;

        public UserInterfaceManager UserInterfaceManager
        {
            get { return this.gameObject.GetComponent<UserInterfaceManager>(); }
        }

        public GameObjectsManager GameObjectsManager
        {
            get { return this.gameObject.GetComponent<GameObjectsManager>(); }
        }

        public ClickService ClickService;

        public MovementDirectionService MovementDirectionService;

        public GameStateService GameStateService;

        public CollectedCrystalsCountingService CollectedCrystalsCountingService;

        public MovementSpeedService MovementSpeedService;

        public RandomFiledGenerationService RandomFiledGenerationService;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                DontDestroyOnLoad(gameObject); // sets this to not be destroyed when reloading scene 
            }
            else
            {
                if (Instance != this)
                {
                    // this enforces our singleton pattern, meaning there can only ever be one instance of a GameManager 
                    Destroy(gameObject);
                }
            }

            Initialize();
        }

        public void Initialize()
        {
            ClickService = new ClickService();
            ClickService.Initialize();
            MovementDirectionService = new MovementDirectionService();
            MovementDirectionService.Initialize();
            GameStateService = new GameStateService();
            GameStateService.Initialize();
            CollectedCrystalsCountingService = new CollectedCrystalsCountingService();
            CollectedCrystalsCountingService.Initialize();
            // UserInterfaceManager needs CollectedCrystalsCountingService
            UserInterfaceManager.Initialize();
            MovementSpeedService = new MovementSpeedService();
            MovementSpeedService.Initialize();
            // GameObjectsManager needs GameStateService
            RandomFiledGenerationService = new RandomFiledGenerationService();
            RandomFiledGenerationService.Initialize();
            // GameObjectsManager needs RandomFiledGenerationService
            GameObjectsManager.Initialize();
        }

        public void UnInitialize()
        {
            GameObjectsManager.UnInitialize();
            RandomFiledGenerationService.UnInitialize();
            MovementSpeedService.UnInitialize();
            CollectedCrystalsCountingService.UnInitialize();
            GameStateService.UnInitialize();
            MovementDirectionService.UnInitialize();
            ClickService.UnInitialize();
            UserInterfaceManager.UnInitialize();
        }

        public void ReInitialize()
        {
            UnInitialize();
            Initialize();
        }
    }
}
