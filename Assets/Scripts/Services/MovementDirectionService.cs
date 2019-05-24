using Managers;
using UnityEngine;

namespace Services
{
    public class MovementDirectionService
    {
        public Vector3 CurrentMovementDirection;

        public MovementDirectionService()
        {
            // Шарик может двигаться либо прямо, либо вправо.
            // Vector3.up // forward
            // Vector3.right

            CurrentMovementDirection = Vector3.up;

            GameManager.Instance.ClickService.ClickHandled += ClickServiceClickHandled;
        }

        private void ClickServiceClickHandled()
        {
            // Изменение направления движения шарика происходит по клику в любую часть игрового поля.
            ChangeMovementDirection();
        }

        public void ChangeMovementDirection()
        {
            // Если шарик двигается прямо, то после клика, он начнет двигаться вправо
            if (CurrentMovementDirection == Vector3.up)
            {
                CurrentMovementDirection = Vector3.right;

                return;
            }
            // после следующего клика шарик начнет двигаться прямо.
            if (CurrentMovementDirection == Vector3.right)
            {
                CurrentMovementDirection = Vector3.up;

                return;
            }
        }
    }
}
