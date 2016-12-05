using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Utils.Services.Language
{
    public class LanguageMap
    {
        private readonly Dictionary<string, LanguageWord> _dicWords;
        public IList<LanguageWord> Words { get; }
        public LanguageMap(IList<LanguageWord> words)
        {
            Words = words;
            _dicWords = new Dictionary<string, LanguageWord>();
            InitDic();
        }

        private void InitDic()
        {
            foreach (var languageWord in Words)
            {
                _dicWords.Add(languageWord.Key, languageWord);
            }
        }

        public string Get(string key)
        {
            if (!_dicWords.ContainsKey(key))
                return string.Empty;
            return _dicWords[key].Value;
        }
    }
}
