using System.Collections.Generic;

namespace MarsRover.Core.Models
{
    public class RoversModel
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int Direction { get; set; }
        public List<char> RoverMovementCommands { get; set; }

        public void TurnLeft()
        {
            Direction = (Direction + 1) % 4;
        }
        public void TurnRight()
        {
            Direction = (Direction + 3) % 4;
        }
        public void Move()
        {
            switch (Direction)
            {
                case 0: YCoordinate += 1; break;
                case 1: XCoordinate -= 1; break;
                case 2: YCoordinate -= 1; break;
                case 3: XCoordinate += 1; break;
            }
        }
    }
}
