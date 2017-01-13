using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryClock.Converter
{
    public static class IntegerToBooleanArrayConverter
    {
        public static bool[] ConvertToBools(int value, int length)
        {
            var list = new List<bool>();

            for (int i = 0; i < length; ++i)
            {
                var result = ((value >> i) & 1) == 1;
                list.Insert(0, result);
            }

            return list.ToArray();
        }
    }
}
