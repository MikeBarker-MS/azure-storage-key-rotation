using Microsoft.WindowsAzure.Storage.File;
using System;

namespace storage_blobs_dotnet_quickstart.StorageEx
{
    public sealed class CloudFileClientEx
    {
        private readonly FailoverContainer<CloudFileClient> failoverContainer;

        public CloudFileClientEx(FailoverToken failoverToken, params CloudFileClient[] cloudFileClients)
        {
            if (failoverToken == null)
                throw new ArgumentNullException(nameof(failoverToken));

            if (cloudFileClients == null)
                throw new ArgumentNullException(nameof(cloudFileClients));

            if (cloudFileClients.Length == 0)
                throw new ArgumentException(nameof(cloudFileClients));

            if (failoverToken.FailoverCount != cloudFileClients.Length)
                throw new ArgumentException();


            this.failoverContainer = new FailoverContainer<CloudFileClient>(failoverToken, cloudFileClients);
        }

/*
        public CloudFileShareEx GetShareReference(string shareName)
        {
            if (shareName == null)
                throw new ArgumentNullException(nameof(shareName));


            CloudFileShare[] cloudFileContainerArray = new CloudFileShare[this.failoverContainer.AllElements.Length];
            for (int i = 0; i < this.failoverContainer.AllElements.Length; i++)
            {
                CloudFileClient client = this.failoverContainer.AllElements[i];
                CloudFileShare cloudFileContainer = client.GetShareReference(shareName);
                cloudFileContainerArray[i] = cloudFileContainer;
            }

            CloudFileShareEx cloudFileClientEx = new CloudFileShareEx(this.failoverContainer.FailoverToken, cloudFileContainerArray);
            return cloudFileClientEx;
        }

        public CloudFileShareEx GetShareReference(string shareName, DateTimeOffset? snapshotTime)
        {
            if (shareName == null)
                throw new ArgumentNullException(nameof(shareName));


            CloudFileShare[] cloudFileContainerArray = new CloudFileShare[this.failoverContainer.AllElements.Length];
            for (int i = 0; i < this.failoverContainer.AllElements.Length; i++)
            {
                CloudFileClient client = this.failoverContainer.AllElements[i];
                CloudFileShare cloudFileContainer = client.GetShareReference(shareName, snapshotTime);
                cloudFileContainerArray[i] = cloudFileContainer;
            }

            CloudFileShareEx cloudFileClientEx = new CloudFileShareEx(this.failoverContainer.FailoverToken, cloudFileContainerArray);
            return cloudFileClientEx;
        }
*/
    }
}
