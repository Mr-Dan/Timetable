using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Models;

namespace Timetable.Controller
{
    internal class ConvertCustom
    {
        public static int ConvertToInt(string value) {
            int b = 0;
            if (int.TryParse(value, out b))
            {
               return b;
            }
            return 0;

        }
        public static bool TryConvertToInt(string value)
        {
            int b = 0;
            if (int.TryParse(value, out b))
            {
                return true;
            }
            return false;

        }
    }
}
