using System;

namespace Commons.Utils.Services.Storage
{
    public class FileStorageInfo
    {
        public byte[] DataBytes { get; private set; }

        public string FileExtension { get; }


        public FileStorageInfo(byte[] fileBytes, string fileExtension = "")
        {
            FileExtension = fileExtension;
            DataBytes = fileBytes;
        }

        public string GenerateKey()
        {
            var guid = Guid.NewGuid();
            return $"{guid}{FileExtension}";
        }
    }
}
