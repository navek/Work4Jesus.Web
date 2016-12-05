using System;

namespace Commons.Utils.Services.Storage
{
    public interface IExternalStorage
    {

        void SaveFile(FileStorageInfo fileStorageInfo, Action<string> onSuccess,Action<string> onError);
        void GetFile(string key, Action<byte[]> onResult, Action<string> onError);
        bool IsFileExist(string key);
    }
}
