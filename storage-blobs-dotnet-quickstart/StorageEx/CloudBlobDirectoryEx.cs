using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace storage_blobs_dotnet_quickstart.StorageEx
{
    public class CloudBlobDirectoryEx : IListBlobItemEx, IListBlobItem
    {
        private readonly CloudBlobContainerEx cloudBlobContainer;
        private readonly IFailoverExecutor<CloudBlobDirectory> failoverExecutor;

        public CloudBlobDirectoryEx(CloudBlobContainerEx cloudBlobContainer, FailoverToken failoverToken, params CloudBlobDirectory[] cloudBlobs)
            : this(cloudBlobContainer, new FailoverContainer<CloudBlobDirectory>(failoverToken, cloudBlobs))
        {
        }

        protected CloudBlobDirectoryEx(CloudBlobContainerEx cloudBlobContainer, IFailoverExecutor<CloudBlobDirectory> failoverExecutor)
        {
            if (cloudBlobContainer == null)
                throw new ArgumentNullException(nameof(cloudBlobContainer));

            if (failoverExecutor == null)
                throw new ArgumentNullException(nameof(failoverExecutor));


            this.cloudBlobContainer = cloudBlobContainer;
            this.failoverExecutor = failoverExecutor;
        }

        public string Prefix
        {
            get { return this.failoverExecutor.Execute(x => x.Prefix); }
        }

        public CloudBlobContainerEx Container
        {
            get { return this.cloudBlobContainer; }
        }

        CloudBlobContainer IListBlobItem.Container
        {
            get { throw new NotSupportedException(); }
        }


        public CloudBlobDirectoryEx Parent
        {
            get
            {
                CloudBlobDirectory[] cloudBlobDirectoryArray = new CloudBlobDirectory[this.failoverExecutor.AllElements.Length];
                for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
                {
                    CloudBlobDirectory directory = this.failoverExecutor.AllElements[i];
                    CloudBlobDirectory parent = directory.Parent;
                    cloudBlobDirectoryArray[i] = parent;
                }

                CloudBlobDirectoryEx cloudBlobDirectoryEx = new CloudBlobDirectoryEx(this.cloudBlobContainer, this.failoverExecutor.FailoverToken, cloudBlobDirectoryArray);
                return cloudBlobDirectoryEx;
            }
        }

        CloudBlobDirectory IListBlobItem.Parent
        {
            get { throw new NotSupportedException(); }
        }

        public StorageUri StorageUri
        {
            get { return this.failoverExecutor.Execute(x => x.StorageUri); }
        }

        public Uri Uri
        {
            get { return this.failoverExecutor.Execute(x => x.Uri); }
        }

        public CloudBlobClientEx ServiceClient
        {
            get { return this.cloudBlobContainer.ServiceClient; }
        }

        public virtual CloudAppendBlobEx GetAppendBlobReference(string blobName)
        {
            if (blobName == null)
                throw new ArgumentNullException(nameof(blobName));


            CloudAppendBlob[] cloudAppendBlobArray = new CloudAppendBlob[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobDirectory directory = this.failoverExecutor.AllElements[i];
                CloudAppendBlob cloudAppendBlob = directory.GetAppendBlobReference(blobName);
                cloudAppendBlobArray[i] = cloudAppendBlob;
            }

            CloudAppendBlobEx cloudAppendBlobEx = new CloudAppendBlobEx(this.Container, this.failoverExecutor.FailoverToken, cloudAppendBlobArray);
            return cloudAppendBlobEx;
        }

        public virtual CloudAppendBlobEx GetAppendBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            if (blobName == null)
                throw new ArgumentNullException(nameof(blobName));


            CloudAppendBlob[] cloudAppendBlobArray = new CloudAppendBlob[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobDirectory directory = this.failoverExecutor.AllElements[i];
                CloudAppendBlob cloudAppendBlob = directory.GetAppendBlobReference(blobName, snapshotTime);
                cloudAppendBlobArray[i] = cloudAppendBlob;
            }

            CloudAppendBlobEx cloudAppendBlobEx = new CloudAppendBlobEx(this.Container, this.failoverExecutor.FailoverToken, cloudAppendBlobArray);
            return cloudAppendBlobEx;
        }

        public virtual CloudBlobEx GetBlobReference(string blobName)
        {
            if (blobName == null)
                throw new ArgumentNullException(nameof(blobName));


            CloudBlob[] cloudBlobArray = new CloudBlob[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobDirectory directory = this.failoverExecutor.AllElements[i];
                CloudBlob cloudBlob = directory.GetBlobReference(blobName);
                cloudBlobArray[i] = cloudBlob;
            }

            CloudBlobEx cloudBlobEx = new CloudBlobEx(this.Container, this.failoverExecutor.FailoverToken, cloudBlobArray);
            return cloudBlobEx;
        }

        public virtual CloudBlobEx GetBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            if (blobName == null)
                throw new ArgumentNullException(nameof(blobName));


            CloudBlob[] cloudBlobArray = new CloudBlob[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobDirectory directory = this.failoverExecutor.AllElements[i];
                CloudBlob cloudBlob = directory.GetBlobReference(blobName);
                cloudBlobArray[i] = cloudBlob;
            }

            CloudBlobEx cloudBlobEx = new CloudBlobEx(this.Container, this.failoverExecutor.FailoverToken, cloudBlobArray);
            return cloudBlobEx;
        }

        public virtual CloudBlockBlobEx GetBlockBlobReference(string blobName)
        {
            if (blobName == null)
                throw new ArgumentNullException(nameof(blobName));


            CloudBlockBlob[] cloudBlockBlobArray = new CloudBlockBlob[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobDirectory directory = this.failoverExecutor.AllElements[i];
                CloudBlockBlob cloudBlockBlob = directory.GetBlockBlobReference(blobName);
                cloudBlockBlobArray[i] = cloudBlockBlob;
            }

            CloudBlockBlobEx cloudBlockBlobEx = new CloudBlockBlobEx(this.Container, this.failoverExecutor.FailoverToken, cloudBlockBlobArray);
            return cloudBlockBlobEx;
        }

        public virtual CloudBlockBlobEx GetBlockBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            if (blobName == null)
                throw new ArgumentNullException(nameof(blobName));


            CloudBlockBlob[] cloudBlockBlobArray = new CloudBlockBlob[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobDirectory directory = this.failoverExecutor.AllElements[i];
                CloudBlockBlob cloudBlockBlob = directory.GetBlockBlobReference(blobName, snapshotTime);
                cloudBlockBlobArray[i] = cloudBlockBlob;
            }

            CloudBlockBlobEx cloudBlockBlobEx = new CloudBlockBlobEx(this.Container, this.failoverExecutor.FailoverToken, cloudBlockBlobArray);
            return cloudBlockBlobEx;
        }

        public virtual CloudBlobDirectoryEx GetDirectoryReference(string itemName)
        {
            if (itemName == null)
                throw new ArgumentNullException(nameof(itemName));


            CloudBlobDirectory[] cloudBlobDirectoryArray = new CloudBlobDirectory[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobDirectory directory = this.failoverExecutor.AllElements[i];
                CloudBlobDirectory dir = directory.GetDirectoryReference(itemName);
                cloudBlobDirectoryArray[i] = dir;
            }

            CloudBlobDirectoryEx cloudBlobDirectoryEx = new CloudBlobDirectoryEx(this.Container, this.failoverExecutor.FailoverToken, cloudBlobDirectoryArray);
            return cloudBlobDirectoryEx;
        }

        public virtual CloudPageBlobEx GetPageBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            if (blobName == null)
                throw new ArgumentNullException(nameof(blobName));


            CloudPageBlob[] cloudPageBlobArray = new CloudPageBlob[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobDirectory directory = this.failoverExecutor.AllElements[i];
                CloudPageBlob cloudPageBlob = directory.GetPageBlobReference(blobName, snapshotTime);
                cloudPageBlobArray[i] = cloudPageBlob;
            }

            CloudPageBlobEx cloudPageBlobEx = new CloudPageBlobEx(this.Container, this.failoverExecutor.FailoverToken, cloudPageBlobArray);
            return cloudPageBlobEx;
        }

        public virtual CloudPageBlobEx GetPageBlobReference(string blobName)
        {
            if (blobName == null)
                throw new ArgumentNullException(nameof(blobName));


            CloudPageBlob[] cloudPageBlobArray = new CloudPageBlob[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobDirectory directory = this.failoverExecutor.AllElements[i];
                CloudPageBlob cloudPageBlob = directory.GetPageBlobReference(blobName);
                cloudPageBlobArray[i] = cloudPageBlob;
            }

            CloudPageBlobEx cloudPageBlobEx = new CloudPageBlobEx(this.Container, this.failoverExecutor.FailoverToken, cloudPageBlobArray);
            return cloudPageBlobEx;
        }


        [DoesServiceRequest]
        public virtual Task<BlobResultSegment> ListBlobsSegmentedAsync(bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ListBlobsSegmentedAsync(useFlatBlobListing, blobListingDetails, maxResults, currentToken, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<BlobResultSegment> ListBlobsSegmentedAsync(BlobContinuationToken currentToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ListBlobsSegmentedAsync(currentToken));
        }

        [DoesServiceRequest]
        public virtual Task<BlobResultSegment> ListBlobsSegmentedAsync(bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ListBlobsSegmentedAsync(useFlatBlobListing, blobListingDetails, maxResults, currentToken, options, operationContext, cancellationToken));
        }

    }
}
