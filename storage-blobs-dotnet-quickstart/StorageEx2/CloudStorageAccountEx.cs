using Microsoft.WindowsAzure.Storage;
using System;

namespace storage_blobs_dotnet_quickstart.StorageEx2
{
    sealed class CloudStorageAccountEx : IFailoverContainerContainerProvider<CloudStorageAccount>
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

        FailoverContainer<CloudStorageAccount> IFailoverContainerContainerProvider<CloudStorageAccount>.FailoverContainer
        {
            get { return this.failoverContainer; }
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
            CloudBlobClientEx cloudBlobClientEx = new CloudBlobClientEx(this, account => account.CreateCloudBlobClient());
            return cloudBlobClientEx;
        }
    }
}
