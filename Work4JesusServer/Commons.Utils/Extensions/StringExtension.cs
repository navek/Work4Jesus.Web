using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Utils.Extensions
{
    public static class StringExtension
    {
        public static bool HasNumber(this string input)
        {
            return input.Where(x => Char.IsDigit(x)).Any();
        }

    }
}
