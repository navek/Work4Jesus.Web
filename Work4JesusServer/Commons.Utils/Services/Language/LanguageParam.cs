using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Utils.Services.Language
{
  public  class LanguageParam
    {
        public string Key { get; private set; }
        public string FilePath { get; private set; }
        public bool IsDefault { get; private set; }

      public LanguageParam(string key, bool isDefault, string filePath)
      {
          Key = key;
          IsDefault = isDefault;
          FilePath = filePath;
      }
    }
}
