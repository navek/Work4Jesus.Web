using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Utils.Services.Language
{
   public class LanguageParams
   {
       private List<LanguageParam> _params;

       public LanguageParams()
       {
           _params = new List<LanguageParam>();
       }

       public void Add(LanguageParam param)
       {
           _params.Add(param);
       }

       public IList<LanguageParam> GetParameters()
       {
           return _params;
       }
   }
}
