using System.Collections.Generic;

namespace MarsRover.Core.Helpers
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
