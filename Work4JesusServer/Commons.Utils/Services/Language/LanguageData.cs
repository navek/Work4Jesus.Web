using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Utils.Services.Language
{
    public class LanguageData
    {
        /// <summary>
        /// Language Key
        /// </summary>
        public  string Key { get; set; }

        public string FilePath { get; set; }


        public LanguageData(string key, string filePath)
        {
            Key = key;
            FilePath = filePath;
        }

        public LanguageData()
        {
            
        }
    }
}
