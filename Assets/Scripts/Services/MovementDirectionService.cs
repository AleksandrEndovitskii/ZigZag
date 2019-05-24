namespace Services
{
    public class MovementDirectionService
    {
        public MovementDirection CurrentMovementDirection;

        public MovementDirectionService()
        {
            CurrentMovementDirection = MovementDirection.Forward;
        }
    }

    // Шарик может двигаться либо прямо, либо вправо.
    public enum MovementDirection
    {
        Forward,
        Right,
    }
}
