using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Enumeration
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
