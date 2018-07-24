using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace storage_blobs_dotnet_quickstart.StorageEx
{
    public class CloudBlobContainerEx
    {
        private readonly CloudBlobClientEx cloudBlobClient;
        private readonly IFailoverExecutor<CloudBlobContainer> failoverExecutor;

        public CloudBlobContainerEx(CloudBlobClientEx cloudBlobClient, FailoverToken failoverToken, params CloudBlobContainer[] cloudBlobContainers)
            : this(cloudBlobClient, new FailoverContainer<CloudBlobContainer>(failoverToken, cloudBlobContainers))
        {
        }

        protected CloudBlobContainerEx(CloudBlobClientEx cloudBlobClient, IFailoverExecutor<CloudBlobContainer> failoverExecutor)
        {
            if (failoverExecutor == null)
                throw new ArgumentNullException(nameof(failoverExecutor));


            this.cloudBlobClient = cloudBlobClient;
            this.failoverExecutor = failoverExecutor;
        }

        public CloudBlobClientEx ServiceClient
        {
            get { return this.cloudBlobClient; }
        }

        public string Name
        {
            get
            {
                string name = this.failoverExecutor.Execute(x => x.Name);
                return name;
            }
        }






        [DoesServiceRequest]
        public virtual Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId = null)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.AcquireLeaseAsync(leaseTime, proposedLeaseId = null));
        }

        [DoesServiceRequest]
        public virtual Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.AcquireLeaseAsync(leaseTime, proposedLeaseId, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.AcquireLeaseAsync(leaseTime, proposedLeaseId, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.BreakLeaseAsync(breakPeriod, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.BreakLeaseAsync(breakPeriod));
        }

        [DoesServiceRequest]
        public virtual Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.BreakLeaseAsync(breakPeriod, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ChangeLeaseAsync(proposedLeaseId, accessCondition));
        }

        [DoesServiceRequest]
        public virtual Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ChangeLeaseAsync(proposedLeaseId, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ChangeLeaseAsync(proposedLeaseId, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task CreateAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateAsync());
        }

        [DoesServiceRequest]
        public virtual Task CreateAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateAsync(options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task CreateAsync(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateAsync(accessType, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task CreateAsync(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateAsync(accessType, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<bool> CreateIfNotExistsAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateIfNotExistsAsync(options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<bool> CreateIfNotExistsAsync(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateIfNotExistsAsync(accessType, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<bool> CreateIfNotExistsAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateIfNotExistsAsync());
        }

        [DoesServiceRequest]
        public virtual Task<bool> CreateIfNotExistsAsync(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateIfNotExistsAsync(accessType, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task DeleteAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DeleteAsync());
        }

        [DoesServiceRequest]
        public virtual Task DeleteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DeleteAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task DeleteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DeleteAsync(accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<bool> DeleteIfExistsAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DeleteIfExistsAsync());
        }

        [DoesServiceRequest]
        public virtual Task<bool> DeleteIfExistsAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DeleteIfExistsAsync(accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<bool> DeleteIfExistsAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DeleteIfExistsAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ExistsAsync(options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ExistsAsync(options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<bool> ExistsAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ExistsAsync());
        }

        [DoesServiceRequest]
        public virtual Task FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.FetchAttributesAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task FetchAttributesAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.FetchAttributesAsync());
        }

        [DoesServiceRequest]
        public virtual Task FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.FetchAttributesAsync(accessCondition, options, operationContext, cancellationToken));
        }

        public virtual CloudAppendBlobEx GetAppendBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            if (blobName == null)
                throw new ArgumentNullException(nameof(blobName));


            CloudAppendBlob[] cloudAppendBlobArray = new CloudAppendBlob[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobContainer container = this.failoverExecutor.AllElements[i];
                CloudAppendBlob cloudAppendBlob = container.GetAppendBlobReference(blobName, snapshotTime);
                cloudAppendBlobArray[i] = cloudAppendBlob;
            }

            CloudAppendBlobEx cloudAppendBlobEx = new CloudAppendBlobEx(this, this.failoverExecutor.FailoverToken, cloudAppendBlobArray);
            return cloudAppendBlobEx;
        }

        public virtual CloudAppendBlobEx GetAppendBlobReference(string blobName)
        {
            if (blobName == null)
                throw new ArgumentNullException(nameof(blobName));


            CloudAppendBlob[] cloudAppendBlobArray = new CloudAppendBlob[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobContainer container = this.failoverExecutor.AllElements[i];
                CloudAppendBlob cloudAppendBlob = container.GetAppendBlobReference(blobName);
                cloudAppendBlobArray[i] = cloudAppendBlob;
            }

            CloudAppendBlobEx cloudAppendBlobEx = new CloudAppendBlobEx(this, this.failoverExecutor.FailoverToken, cloudAppendBlobArray);
            return cloudAppendBlobEx;
        }

        public virtual CloudBlobEx GetBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            if (blobName == null)
                throw new ArgumentNullException(nameof(blobName));


            CloudBlob[] cloudBlobArray = new CloudBlob[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobContainer container = this.failoverExecutor.AllElements[i];
                CloudBlob cloudBlob = container.GetBlobReference(blobName, snapshotTime);
                cloudBlobArray[i] = cloudBlob;
            }

            CloudBlobEx cloudBlobEx = new CloudBlobEx(this, this.failoverExecutor.FailoverToken, cloudBlobArray);
            return cloudBlobEx;
        }

        public virtual CloudBlobEx GetBlobReference(string blobName)
        {
            if (blobName == null)
                throw new ArgumentNullException(nameof(blobName));


            CloudBlob[] cloudBlobArray = new CloudBlob[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobContainer container = this.failoverExecutor.AllElements[i];
                CloudBlob cloudBlob = container.GetBlobReference(blobName);
                cloudBlobArray[i] = cloudBlob;
            }

            CloudBlobEx cloudBlobEx = new CloudBlobEx(this, this.failoverExecutor.FailoverToken, cloudBlobArray);
            return cloudBlobEx;
        }

        [DoesServiceRequest]
        public virtual Task<ICloudBlob> GetBlobReferenceFromServerAsync(string blobName)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.GetBlobReferenceFromServerAsync(blobName));
        }

        [DoesServiceRequest]
        public virtual Task<ICloudBlob> GetBlobReferenceFromServerAsync(string blobName, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.GetBlobReferenceFromServerAsync(blobName, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<ICloudBlob> GetBlobReferenceFromServerAsync(string blobName, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.GetBlobReferenceFromServerAsync(blobName, accessCondition, options, operationContext));
        }

        public virtual CloudBlockBlobEx GetBlockBlobReference(string blobName)
        {
            if (blobName == null)
                throw new ArgumentNullException(nameof(blobName));


            CloudBlockBlob[] cloudBlockBlobArray = new CloudBlockBlob[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobContainer container = this.failoverExecutor.AllElements[i];
                CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(blobName);
                cloudBlockBlobArray[i] = cloudBlockBlob;
            }

            CloudBlockBlobEx cloudBlockBlobEx = new CloudBlockBlobEx(this, this.failoverExecutor.FailoverToken, cloudBlockBlobArray);
            return cloudBlockBlobEx;
        }

        public virtual CloudBlockBlobEx GetBlockBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            if (blobName == null)
                throw new ArgumentNullException(nameof(blobName));


            CloudBlockBlob[] cloudBlockBlobArray = new CloudBlockBlob[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobContainer container = this.failoverExecutor.AllElements[i];
                CloudBlockBlob cloudBlockBlob = container.GetBlockBlobReference(blobName, snapshotTime);
                cloudBlockBlobArray[i] = cloudBlockBlob;
            }

            CloudBlockBlobEx cloudBlockBlobEx = new CloudBlockBlobEx(this, this.failoverExecutor.FailoverToken, cloudBlockBlobArray);
            return cloudBlockBlobEx;
        }

        public virtual CloudBlobDirectoryEx GetDirectoryReference(string relativeAddress)
        {
            if (relativeAddress == null)
                throw new ArgumentNullException(nameof(relativeAddress));


            CloudBlobDirectory[] cloudBlobDirectoryArray = new CloudBlobDirectory[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobContainer container = this.failoverExecutor.AllElements[i];
                CloudBlobDirectory cloudBlobDirectory = container.GetDirectoryReference(relativeAddress);
                cloudBlobDirectoryArray[i] = cloudBlobDirectory;
            }

            CloudBlobDirectoryEx cloudBlobDirectoryEx = new CloudBlobDirectoryEx(this, this.failoverExecutor.FailoverToken, cloudBlobDirectoryArray);
            return cloudBlobDirectoryEx;
        }

        public virtual CloudPageBlobEx GetPageBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            if (blobName == null)
                throw new ArgumentNullException(nameof(blobName));


            CloudPageBlob[] cloudPageBlobArray = new CloudPageBlob[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobContainer container = this.failoverExecutor.AllElements[i];
                CloudPageBlob cloudPageBlob = container.GetPageBlobReference(blobName, snapshotTime);
                cloudPageBlobArray[i] = cloudPageBlob;
            }

            CloudPageBlobEx cloudPageBlobEx = new CloudPageBlobEx(this, this.failoverExecutor.FailoverToken, cloudPageBlobArray);
            return cloudPageBlobEx;
        }

        public virtual CloudPageBlobEx GetPageBlobReference(string blobName)
        {
            if (blobName == null)
                throw new ArgumentNullException(nameof(blobName));


            CloudPageBlob[] cloudPageBlobArray = new CloudPageBlob[this.failoverExecutor.AllElements.Length];
            for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
            {
                CloudBlobContainer container = this.failoverExecutor.AllElements[i];
                CloudPageBlob cloudPageBlob = container.GetPageBlobReference(blobName);
                cloudPageBlobArray[i] = cloudPageBlob;
            }

            CloudPageBlobEx cloudPageBlobEx = new CloudPageBlobEx(this, this.failoverExecutor.FailoverToken, cloudPageBlobArray);
            return cloudPageBlobEx;
        }

        [DoesServiceRequest]
        public virtual Task<BlobContainerPermissions> GetPermissionsAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.GetPermissionsAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<BlobContainerPermissions> GetPermissionsAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.GetPermissionsAsync(accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<BlobContainerPermissions> GetPermissionsAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.GetPermissionsAsync());
        }

        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy)
        {
            return this.failoverExecutor.Execute(x => x.GetSharedAccessSignature(policy));
        }

        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy, string groupPolicyIdentifier)
        {
            return this.failoverExecutor.Execute(x => x.GetSharedAccessSignature(policy, groupPolicyIdentifier));
        }

        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy, string groupPolicyIdentifier, SharedAccessProtocol? protocols, IPAddressOrRange ipAddressOrRange)
        {
            return this.failoverExecutor.Execute(x => x.GetSharedAccessSignature(policy, groupPolicyIdentifier, protocols, ipAddressOrRange));
        }

        [DoesServiceRequest]
        public virtual Task<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ListBlobsSegmentedAsync(prefix, useFlatBlobListing, blobListingDetails, maxResults, currentToken, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<BlobResultSegment> ListBlobsSegmentedAsync(BlobContinuationToken currentToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ListBlobsSegmentedAsync(currentToken));
        }

        [DoesServiceRequest]
        public virtual Task<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, BlobContinuationToken currentToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ListBlobsSegmentedAsync(prefix, currentToken));
        }

        [DoesServiceRequest]
        public virtual Task<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ListBlobsSegmentedAsync(prefix, useFlatBlobListing, blobListingDetails, maxResults, currentToken, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ReleaseLeaseAsync(accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ReleaseLeaseAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task ReleaseLeaseAsync(AccessCondition accessCondition)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ReleaseLeaseAsync(accessCondition));
        }

        [DoesServiceRequest]
        public virtual Task RenewLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.RenewLeaseAsync(accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task RenewLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.RenewLeaseAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task RenewLeaseAsync(AccessCondition accessCondition)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.RenewLeaseAsync(accessCondition));
        }

        [DoesServiceRequest]
        public virtual Task SetMetadataAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetMetadataAsync());
        }

        [DoesServiceRequest]
        public virtual Task SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetMetadataAsync(accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetMetadataAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task SetPermissionsAsync(BlobContainerPermissions permissions)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetPermissionsAsync(permissions));
        }

        [DoesServiceRequest]
        public virtual Task SetPermissionsAsync(BlobContainerPermissions permissions, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetPermissionsAsync(permissions, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task SetPermissionsAsync(BlobContainerPermissions permissions, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetPermissionsAsync(permissions, accessCondition, options, operationContext, cancellationToken));
        }
    }
}
