using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;

namespace storage_blobs_dotnet_quickstart.StorageEx2
{
    public sealed class CloudBlobClientEx : IFailoverContainerContainerProvider<CloudBlobClient>
    {
        private readonly CloudStorageAccountEx cloudStorageAccount;
        private readonly FailoverContainer<CloudBlobClient> failoverContainer;

        internal CloudBlobClientEx(CloudStorageAccountEx cloudStorageAccount, Func<CloudStorageAccount, CloudBlobClient> ctorFunc)
        {
            if (cloudStorageAccount == null)
                throw new ArgumentNullException(nameof(cloudStorageAccount));

            if (ctorFunc == null)
                throw new ArgumentNullException(nameof(ctorFunc));


            this.cloudStorageAccount = cloudStorageAccount;
            this.failoverContainer = ((IFailoverContainerContainerProvider<CloudStorageAccount>)cloudStorageAccount)
                .FailoverContainer.CreateChildContainer(ctorFunc);
        }

        FailoverContainer<CloudBlobClient> IFailoverContainerContainerProvider<CloudBlobClient>.FailoverContainer
        {
            get { return this.failoverContainer; }
        }

        public CloudBlobContainerEx GetContainerReference(string containerName)
        {
            CloudBlobContainerEx cloudBlobContainerEx = new CloudBlobContainerEx(this, account => account.GetContainerReference(containerName));
            return cloudBlobContainerEx;
        }
    }
}
