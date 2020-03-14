using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Helpers
{
    public static class StringHelper
    {
        public static string[] CustomSplit(this string data, char splitChar)
        {
            List<string> result = new List<string>();
            foreach (string splitData in data.Split(splitChar))
            {
                result.Add(splitData.ToUpper());
            }
            return result.ToArray();
        }
    }
}
