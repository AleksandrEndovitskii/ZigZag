using Services;
using UnityEngine;

/*
Описание:
В игре, которую предстоит реализовать есть 3 игровых сущности - 
    шарик, которым управляет игрок, 
    поле по которому двигается шарик и 
    кристаллы, расположенные на поле.
Поле представляет собой набор набор квадратных тайлов, расположенных друг рядом с другом, по которым может катиться шарик.
Если шарик выходит за рамки тайла в пустое пространство (туда, где нет тайла), то  шарик падает за поле и игрок проигрывает, в таком случае игра начинает заново по клику в любой части экрана.
Поле представляет собой дорожку толщиной в 1 тайл, направление которой может идти только прямо или право.
Поле генерируется случайным образом бесконечно, таким образом, чтобы по нему мог пройти шарик (не должно быть непроходимых участков).
В самом начале игры поле всегда представляет собой квадратную площадку тайлов размером 3*3, генерация дорожки шириной в 1 тайл начинается только после этой площадки.

Если шарик наезжает на кристалл, то кристалл исчезает с тайла и считается, что игрок подобрал этот кристалл.
Шарик постоянно движется по полю с одинаковой скоростью.

Камера при этом двигается за шариком таким образом, чтобы он всегда находился в центре экрана по вертикали.

Дополнительно:
1) реализовать систему подсчета очков и 
    выводить результат на экран, при условии, что
    за подбор одного кристалла начисляется 1 очко.
    Для реализации этого пункта можно использовать любой UI фреймворк.
2) добавить анимации пропадания тайлов, находящихся позади шарика (те, которые уже были пройдены)
3) добавить анимацию с использованием системы частиц исчезновения кристалла при подборе его с тайла.

Требования к реализации:
1) Игра должна быть реализована с использованием Unity3D + C#
2) Для реализации можно использовать Unity3D любой удобной вам версии
3) Реализация должна быть сделана с уклоном на расширяемость игры.
4) В реализации тестового задания разрешается использовать готовые ассеты. 
5) Необязательным, но огромным плюсом в реализации проекта будет использование практик Внедрения Зависимостей и любого DI контейнера.
 */

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        // static instance of GameManager which allows it to be accessed by any other script 
        public static GameManager Instance;

        public UserInterfaceManager UserInterfaceManager
        {
            get { return this.gameObject.GetComponent<UserInterfaceManager>(); }
        }

        public ClickService ClickService;

        public MovementDirectionService MovementDirectionService;

        public GameStateService GameStateService;

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
            UserInterfaceManager.Initialize();
            ClickService = new ClickService();
            MovementDirectionService = new MovementDirectionService();
            GameStateService = new GameStateService();
        }
    }
}
