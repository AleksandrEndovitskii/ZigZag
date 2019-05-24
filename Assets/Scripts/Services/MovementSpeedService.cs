using Utils;

namespace Services
{
    public class MovementSpeedService : IInitializeble, IUnInitializeble
    {
        // Шарик постоянно движется по полю с одинаковой скоростью.
        public int CurrentMovementSpeed;

        public void Initialize()
        {
            CurrentMovementSpeed = 1;
        }

        public void UnInitialize()
        {
            CurrentMovementSpeed = 0;
        }
    }
}
