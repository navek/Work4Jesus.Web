using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Commons.Utils.Services.Language
{
   public class LanguageService : ILanguageService
   {
       private string _defaultKey;
       private readonly Dictionary<string, LanguageMap> _languageMap;
       public LanguageService(LanguageParams param)
       {
            _languageMap =  new Dictionary<string, LanguageMap>();
           InitParameters(param.GetParameters());
       }

       private void InitParameters(IList<LanguageParam> parameters)
       {
           foreach (var parameter in parameters)
           {
                LoadLangage(parameter.Key, parameter.FilePath, parameter.IsDefault);
           }
       }

       public void AddLanguage(string key, string filePath, bool isdefault)
       {
           LoadLangage(key, filePath, isdefault);
       }


       private void LoadLangage(string key, string filePath, bool isDefault)
       {
            if(!File.Exists(filePath))   
                return;
           string datajson = "";
           using (var fileStream = File.OpenText(filePath))
           {
                datajson =fileStream.ReadToEnd();
           }
         if (string.IsNullOrEmpty(datajson))
                return;
          var  languages =JsonConvert.DeserializeObject<List<LanguageWord>>(datajson);
            if(languages == null)
                return;
           if (isDefault)
               _defaultKey = key;
            _languageMap.Add(key, new LanguageMap(languages));
       }

       public void SetDefaultLanguage(string key)
       {
           _defaultKey = key;
       }

       public IList<string> GetAllLanguageKey()
       {
           return _languageMap.Keys.ToList();
       }

       public string Get(string languageKey, string wordKey)
       {
           try
           {
               languageKey = languageKey.ToLower();
                if (!_languageMap.ContainsKey(languageKey))
                    return _languageMap[_defaultKey].Get(wordKey);
                return _languageMap[languageKey].Get(wordKey);
            }
           catch (Exception e)
           {
                Debug.WriteLine("Cannot find the specified key\n" + e.Message);
               return string.Empty;
           }

       }
    }
}
