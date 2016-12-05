using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Commons.Utils.Extensions
{
   public static class UserNameExtension
    {
       public static bool IsNameValid(this string input)
       {
           if (String.IsNullOrEmpty(input))
               return false;
            var regex = new Regex(@"^(?:[aA-zZ]+[\s\.]?[aA-zZ]+)+$");
           return regex.IsMatch(input);
       }
    }
}
