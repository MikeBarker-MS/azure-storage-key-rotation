using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;

namespace storage_blobs_dotnet_quickstart.StorageEx
{
    sealed class CloudStorageAccountEx
    {
        private readonly FailoverContainer<CloudStorageAccount> failoverContainer;

        public CloudStorageAccountEx(params CloudStorageAccount[] accounts)
        {
            if (accounts == null)
                throw new ArgumentNullException(nameof(accounts));

            if (accounts.Length == 0)
                throw new ArgumentException(nameof(accounts));


            FailoverToken failoverToken = new FailoverToken(accounts.Length);
            this.failoverContainer = new FailoverContainer<CloudStorageAccount>(failoverToken, accounts);
        }

        public static CloudStorageAccountEx Parse(params string[] connectionStrings)
        {
            if (connectionStrings == null)
                throw new ArgumentNullException(nameof(connectionStrings));

            if (connectionStrings.Length == 0)
                throw new ArgumentException(nameof(connectionStrings));


            CloudStorageAccount[] accounts = new CloudStorageAccount[connectionStrings.Length];
            for (int i = 0; i < connectionStrings.Length; i++)
            {
                CloudStorageAccount account;
                account = CloudStorageAccount.Parse(connectionStrings[i]);

                accounts[i] = account;
            }

            CloudStorageAccountEx accountEx = new CloudStorageAccountEx(accounts);
            return accountEx;
        }

        public static bool TryParse(out CloudStorageAccountEx accountEx, params string[] connectionStrings)
        {
            if (connectionStrings == null)
                throw new ArgumentNullException(nameof(connectionStrings));

            if (connectionStrings.Length == 0)
                throw new ArgumentException(nameof(connectionStrings));


            bool result = true;

            CloudStorageAccount[] accounts = new CloudStorageAccount[connectionStrings.Length];
            for (int i = 0; i < connectionStrings.Length; i++)
            {
                CloudStorageAccount account;
                result &= CloudStorageAccount.TryParse(connectionStrings[i], out account);

                accounts[i] = account;
            }

            accountEx = (result)
                ? new CloudStorageAccountEx(accounts)
                : null;
            return result;
        }

        public CloudBlobClientEx CreateCloudBlobClient()
        {
            CloudBlobClient[] cloudBlobClientArray = new CloudBlobClient[this.failoverContainer.AllElements.Length];
            for (int i = 0; i < this.failoverContainer.AllElements.Length; i++)
            {
                CloudStorageAccount account = this.failoverContainer.AllElements[i];
                CloudBlobClient cloudBlobClient = account.CreateCloudBlobClient();
                cloudBlobClientArray[i] = cloudBlobClient;
            }

            CloudBlobClientEx cloudBlobClientEx = new CloudBlobClientEx(this.failoverContainer.FailoverToken, cloudBlobClientArray);
            return cloudBlobClientEx;
        }
    }
}
