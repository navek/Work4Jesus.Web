using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Utils.Services.Language
{
    public interface ILanguageService
    {
        void AddLanguage(string key, string filePath, bool isDefaultKey = false);
        void SetDefaultLanguage(string key);
        IList<string> GetAllLanguageKey();
        /// <summary>
        /// return a 
        /// </summary>
        /// <param name="languageKey"></param>
        /// <param name="wordKey"></param>
        /// <returns></returns>
        string Get(string languageKey, string wordKey);

    }
}
