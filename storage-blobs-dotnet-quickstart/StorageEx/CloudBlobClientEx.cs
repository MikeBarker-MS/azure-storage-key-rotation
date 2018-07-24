using Microsoft.WindowsAzure.Storage.Blob;
using System;

namespace storage_blobs_dotnet_quickstart.StorageEx
{
    public sealed class CloudBlobClientEx
    {
        private readonly FailoverContainer<CloudBlobClient> failoverContainer;

        public CloudBlobClientEx(FailoverToken failoverToken, params CloudBlobClient[] cloudBlobClients)
        {
            if (failoverToken == null)
                throw new ArgumentNullException(nameof(failoverToken));

            if (cloudBlobClients == null)
                throw new ArgumentNullException(nameof(cloudBlobClients));

            if (cloudBlobClients.Length == 0)
                throw new ArgumentException(nameof(cloudBlobClients));

            if (failoverToken.FailoverCount != cloudBlobClients.Length)
                throw new ArgumentException();


            this.failoverContainer = new FailoverContainer<CloudBlobClient>(failoverToken, cloudBlobClients);
        }

        public CloudBlobContainerEx GetContainerReference(string containerName)
        {
            if (containerName == null)
                throw new ArgumentNullException(nameof(containerName));


            CloudBlobContainer[] cloudBlobContainerArray = new CloudBlobContainer[this.failoverContainer.AllElements.Length];
            for (int i = 0; i < this.failoverContainer.AllElements.Length; i++)
            {
                CloudBlobClient client = this.failoverContainer.AllElements[i];
                CloudBlobContainer cloudBlobContainer = client.GetContainerReference(containerName);
                cloudBlobContainerArray[i] = cloudBlobContainer;
            }

            CloudBlobContainerEx cloudBlobClientEx = new CloudBlobContainerEx(this, this.failoverContainer.FailoverToken, cloudBlobContainerArray);
            return cloudBlobClientEx;
        }
    }
}
