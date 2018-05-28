namespace RoverMotionControl.Models
{
    public class State
    {
        public State(CoOrdinates points, Movement movement)
        {
            Points = points;
            Movement = movement;
        }

        public CoOrdinates Points { get; }
        public Movement Movement { get; }

        public override string ToString()
        {
            return $"({Points.X}, {Points.Y},{GetCurrentDirection()} )";
        }

        public string GetCurrentDirection()
        {
            switch (Movement.CurrentDirection)
            {
                case Direction.North:
                    return "N";
                case Direction.South:
                    return "S";
                case Direction.East:
                    return "E";
                case Direction.West:
                    return "W";
            }
            return "N";
        }
    }
}