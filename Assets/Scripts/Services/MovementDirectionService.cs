using Managers;

namespace Services
{
    public class MovementDirectionService
    {
        public MovementDirection CurrentMovementDirection;

        public MovementDirectionService()
        {
            CurrentMovementDirection = MovementDirection.Forward;

            GameManager.Instance.ClickService.ClickHandled += ClickServiceClickHandled;
        }

        private void ClickServiceClickHandled()
        {
            // Изменение направления движения шарика происходит по клику в любую часть игрового поля.
            ChangeMovementDirection();
        }

        // Если шарик двигается прямо, то после клика, он начнет двигаться вправо, после следующего клика шарик начнет двигаться прямо.
        public void ChangeMovementDirection()
        {
            if (CurrentMovementDirection == MovementDirection.Forward)
            {
                CurrentMovementDirection = MovementDirection.Right;

                return;
            }

            if (CurrentMovementDirection == MovementDirection.Right)
            {
                CurrentMovementDirection = MovementDirection.Forward;

                return;
            }
        }
    }

    // Шарик может двигаться либо прямо, либо вправо.
    public enum MovementDirection
    {
        Forward,
        Right,
    }
}
