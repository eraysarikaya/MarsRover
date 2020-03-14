using System.ComponentModel;

namespace MarsRover.Core.Enumeration
{
    public enum MovementCommandsEnum
    {
        [Description("Left")]
        L = 0,
        [Description("Right")]
        R = 1,
        [Description("Move")]
        M = 2
    }
}
