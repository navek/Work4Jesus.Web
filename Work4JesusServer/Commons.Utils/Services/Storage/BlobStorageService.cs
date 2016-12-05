using System;
using System.IO;
using Commons.Utils.Extensions;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
// Namespace for CloudStorageAccount
// Namespace for Blob storage types

namespace Commons.Utils.Services.Storage
{

    public class BlobStorageService : IExternalStorageService
    {
        private readonly CloudBlobClient _cloudBlobClient;
        private readonly string _containerName;

        public BlobStorageService(ConnectionBlob connection)
        {
            var connectionBlob = connection;
            var credentials = new StorageCredentials(connectionBlob.AccountName, connectionBlob.Key);
            var cloudStorageAccount = new CloudStorageAccount(credentials, true);

            _cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            _containerName = connection.ContainerName;
            InitContainer(_cloudBlobClient, _containerName);
        }

        private void InitContainer(CloudBlobClient blobClient,
            string containerName,
            bool isPublic = false)
        {
            var container = blobClient.GetContainerReference(containerName);

            container.CreateIfNotExists();
            if (isPublic)
                container.SetPermissions(new BlobContainerPermissions {PublicAccess = BlobContainerPublicAccessType.Blob});

            container.CreateIfNotExists();
        }


        public void GetFile(string key, Action<byte[]> onResult, Action<string> onError)
        {
            try
            {
                if (IsFileExist(key))
                {
                    var block = GetBlobContainer().GetBlockBlobReference(key);
                    using (var stream = new MemoryStream())
                    {
                        block.DownloadToStream(stream);
                        onResult.Invoke(stream.ConvertToBytes());
                    }
                }
                else
                {
                    onResult(null);
                }
            }
            catch (Exception  exception)
            {
                onError.Invoke($"Error occured when try to get the file. Message: " +
                               $"{exception.Message}\nStackTrace : {exception.StackTrace}");
            }
        }

        public bool IsFileExist(string key) 
        {
            var container = GetBlobContainer();
            // Loop over items within the container and output the length and URI.
            foreach (IListBlobItem item in container.ListBlobs(null, false))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob) item;

                    if (blob.Uri.ToString().Contains(key))
                        return true;

                }
                else if (item.GetType() == typeof(CloudPageBlob))
                {
                    CloudPageBlob pageBlob = (CloudPageBlob) item;

                    Console.WriteLine("Page blob of length {0}: {1}", pageBlob.Properties.Length, pageBlob.Uri);

                }
                else if (item.GetType() == typeof(CloudBlobDirectory))
                {
                    CloudBlobDirectory directory = (CloudBlobDirectory) item;

                    Console.WriteLine("Directory: {0}", directory.Uri);
                }
            }
            return false;
        }

        private CloudBlobContainer GetBlobContainer()
        {
            return _cloudBlobClient.GetContainerReference(_containerName);
        }

        public void SaveFile(FileStorageInfo infoStorage, Action<string> onResult, Action<string> onError)
        {
            var guid = infoStorage.GenerateKey();
            //We create a new 
            while (IsFileExist(guid))
            {
                guid = infoStorage.GenerateKey();
            }
            var container = GetBlobContainer();
            var blockBlob = container.GetBlockBlobReference(guid);
            blockBlob.UploadFromByteArray(infoStorage.DataBytes, 0, infoStorage.DataBytes.Length);
            onResult.Invoke(guid);
        }
    }
}
