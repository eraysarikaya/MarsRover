using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Helpers
{
    public static class EnumHelper
    {
        public static T GetEnumByName<T>(string enumName)
        {
            return (T)Enum.Parse(typeof(T), enumName);
        }

        public static List<string> GetItems(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type must be an enum type.");
            }

            string[] items = Enum.GetNames(enumType);
            List<string> output = new List<string>();
            foreach (string val in items)
            {
                output.Add(val);
            }
            return output;
        }
    }
}
