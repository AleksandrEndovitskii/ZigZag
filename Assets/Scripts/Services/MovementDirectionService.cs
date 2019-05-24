using Managers;
using UnityEngine;
using Utils;

namespace Services
{
    public class MovementDirectionService : IInitializeble, IUnInitializeble
    {
        public Vector3 CurrentMovementDirection;

        public void Initialize()
        {
            // Шарик может двигаться либо прямо, либо вправо.
            CurrentMovementDirection = Vector3.forward;

            GameManager.Instance.ClickService.ClickHandled += ClickServiceClickHandled;
        }

        public void UnInitialize()
        {
            GameManager.Instance.ClickService.ClickHandled -= ClickServiceClickHandled;
        }

        private void ClickServiceClickHandled()
        {
            // Изменение направления движения шарика происходит по клику в любую часть игрового поля.
            ChangeMovementDirection();
        }

        public void ChangeMovementDirection()
        {
            // Если шарик двигается прямо, то после клика, он начнет двигаться вправо
            if (CurrentMovementDirection == Vector3.forward)
            {
                CurrentMovementDirection = Vector3.right;

                return;
            }
            // после следующего клика шарик начнет двигаться прямо.
            if (CurrentMovementDirection == Vector3.right)
            {
                CurrentMovementDirection = Vector3.forward;

                return;
            }
        }
    }
}
