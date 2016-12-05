namespace Commons.Utils.Services.Storage
{
    public class ConnectionBlob
    {
        public string AccountName { get; private set; }
        public string Key { get; private set; }
        public  string ContainerName { get; private set; }
        public string ConnectionString => $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Key}";

        public ConnectionBlob(string accountName, 
            string key,
            string containerName)
        {
            AccountName = accountName;
            Key = key;
            ContainerName = containerName;
        }


    }
}
