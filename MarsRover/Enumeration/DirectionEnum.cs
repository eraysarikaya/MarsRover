using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Enumeration
{
    public enum DirectionEnum
    {
        [Description("North")]
        N = 0,
        [Description("West")]
        W = 1,
        [Description("South")]
        S = 2,
        [Description("East")]
        E = 3
    }
}
