using System.Collections.Generic;

namespace PingPong
{

    public class BallDirection
    {

        public enum Direction
        {
            Negative = -1,
            Positive = 1
        }

        private static readonly List<Direction> values = new List<Direction>()
        {
            Direction.Negative,
            Direction.Positive
        };
        private static readonly int size = values.Count;

        public static Direction RandomDirection()
        {
            return values[Util.GetRandomNumber(0, size - 1)];
        }

        public static Direction SwitchDirection(Direction direction)
        {
            if (direction.Equals(BallDirection.Direction.Positive))
            {
                return BallDirection.Direction.Negative;
            }
            else
            {
                return BallDirection.Direction.Positive;
            }
        }
    }
}