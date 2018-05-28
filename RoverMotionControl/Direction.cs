using System;

namespace RoverMotionControl.Models
{
    public  enum Direction

    {
        North,
        South,
        East,
        West

    }

    public abstract class Movement
    {
        public abstract Direction CurrentDirection { get;  }
        public abstract Direction CorrespondingLeft { get;  }
        public abstract Direction CorrespondingRight { get;  }

       
        public abstract CoOrdinates UpdateBy(CoOrdinates points, uint delta);
       
    }

    public class NorthMovement : Movement
    {
        public override Direction CurrentDirection => Direction.North;
        public override Direction CorrespondingLeft => Direction.West;
        public override Direction CorrespondingRight => Direction.East;

        public override CoOrdinates UpdateBy(CoOrdinates points, uint delta)
        {
            return new CoOrdinates(points.X, points.Y + Convert.ToInt16(delta));
        }
    }
    
    public class SouthMovement : Movement
    {
        public override Direction CurrentDirection => Direction.South;
        public override Direction CorrespondingLeft => Direction.East;
        public override Direction CorrespondingRight => Direction.West;

        public override CoOrdinates UpdateBy(CoOrdinates points, uint delta)
        {
            return new CoOrdinates(points.X, points.Y - Convert.ToInt16(delta));
        }
    }
    public class EastMovement : Movement
    {
        public override Direction CurrentDirection => Direction.East;
        public override Direction CorrespondingLeft => Direction.North;
        public override Direction CorrespondingRight => Direction.South;
       
         public override CoOrdinates UpdateBy(CoOrdinates points, uint delta)
        {
            return new CoOrdinates(points.X + Convert.ToInt16(delta), points.Y );
        }
    }
    public class WestMovement : Movement
    {
        public override Direction CurrentDirection => Direction.West;
        public override Direction CorrespondingLeft => Direction.South;
        public override Direction CorrespondingRight => Direction.North;
        public override CoOrdinates UpdateBy(CoOrdinates points, uint delta)
        {
            return new CoOrdinates(points.X - Convert.ToInt16(delta), points.Y);
        }
    }
}