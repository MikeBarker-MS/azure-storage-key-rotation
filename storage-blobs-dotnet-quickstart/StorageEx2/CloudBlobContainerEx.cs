using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace storage_blobs_dotnet_quickstart.StorageEx2
{
    public class CloudBlobContainerEx : IFailoverContainerContainerProvider<CloudBlobContainer>
    {
        private readonly CloudBlobClientEx cloudBlobClient;
        private readonly FailoverContainer<CloudBlobContainer> failoverContainer;

        public CloudBlobContainerEx(CloudBlobClientEx cloudBlobClient, Func<CloudBlobClient, CloudBlobContainer> ctorFunc)
        {
            if (cloudBlobClient == null)
                throw new ArgumentNullException(nameof(cloudBlobClient));

            if (ctorFunc == null)
                throw new ArgumentNullException(nameof(ctorFunc));


            this.cloudBlobClient = cloudBlobClient;
            this.failoverContainer = ((IFailoverContainerContainerProvider<CloudBlobClient>)cloudBlobClient)
                .FailoverContainer.CreateChildContainer(ctorFunc);
        }

        FailoverContainer<CloudBlobContainer> IFailoverContainerContainerProvider<CloudBlobContainer>.FailoverContainer
        {
            get { return this.failoverContainer; }
        }

        public CloudBlobClientEx ServiceClient
        {
            get { return this.cloudBlobClient; }
        }

        public string Name
        {
            get
            {
                string name = this.failoverContainer.Execute(x => x.Name);
                return name;
            }
        }






        [DoesServiceRequest]
        public virtual Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId = null)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AcquireLeaseAsync(leaseTime, proposedLeaseId = null));
        }

        [DoesServiceRequest]
        public virtual Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AcquireLeaseAsync(leaseTime, proposedLeaseId, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AcquireLeaseAsync(leaseTime, proposedLeaseId, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.BreakLeaseAsync(breakPeriod, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod)
        {
            return this.failoverContainer.ExecuteAsync(x => x.BreakLeaseAsync(breakPeriod));
        }

        [DoesServiceRequest]
        public virtual Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.BreakLeaseAsync(breakPeriod, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition)
        {
            return this.failoverContainer.ExecuteAsync(x => x.ChangeLeaseAsync(proposedLeaseId, accessCondition));
        }

        [DoesServiceRequest]
        public virtual Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.ChangeLeaseAsync(proposedLeaseId, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.ChangeLeaseAsync(proposedLeaseId, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task CreateAsync()
        {
            return this.failoverContainer.ExecuteAsync(x => x.CreateAsync());
        }

        [DoesServiceRequest]
        public virtual Task CreateAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.CreateAsync(options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task CreateAsync(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.CreateAsync(accessType, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task CreateAsync(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.CreateAsync(accessType, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<bool> CreateIfNotExistsAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.CreateIfNotExistsAsync(options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<bool> CreateIfNotExistsAsync(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.CreateIfNotExistsAsync(accessType, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<bool> CreateIfNotExistsAsync()
        {
            return this.failoverContainer.ExecuteAsync(x => x.CreateIfNotExistsAsync());
        }

        [DoesServiceRequest]
        public virtual Task<bool> CreateIfNotExistsAsync(BlobContainerPublicAccessType accessType, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.CreateIfNotExistsAsync(accessType, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task DeleteAsync()
        {
            return this.failoverContainer.ExecuteAsync(x => x.DeleteAsync());
        }

        [DoesServiceRequest]
        public virtual Task DeleteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.DeleteAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task DeleteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.DeleteAsync(accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<bool> DeleteIfExistsAsync()
        {
            return this.failoverContainer.ExecuteAsync(x => x.DeleteIfExistsAsync());
        }

        [DoesServiceRequest]
        public virtual Task<bool> DeleteIfExistsAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.DeleteIfExistsAsync(accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<bool> DeleteIfExistsAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.DeleteIfExistsAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.ExistsAsync(options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.ExistsAsync(options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<bool> ExistsAsync()
        {
            return this.failoverContainer.ExecuteAsync(x => x.ExistsAsync());
        }

        [DoesServiceRequest]
        public virtual Task FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.FetchAttributesAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task FetchAttributesAsync()
        {
            return this.failoverContainer.ExecuteAsync(x => x.FetchAttributesAsync());
        }

        [DoesServiceRequest]
        public virtual Task FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.FetchAttributesAsync(accessCondition, options, operationContext, cancellationToken));
        }

        public virtual CloudAppendBlobEx GetAppendBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            CloudAppendBlobEx cloudAppendBlobEx = new CloudAppendBlobEx(this, account => account.GetAppendBlobReference(blobName, snapshotTime));
            return cloudAppendBlobEx;
        }

        public virtual CloudAppendBlobEx GetAppendBlobReference(string blobName)
        {
            CloudAppendBlobEx cloudAppendBlobEx = new CloudAppendBlobEx(this, account => account.GetAppendBlobReference(blobName));
            return cloudAppendBlobEx;
        }

        public virtual CloudBlobEx GetBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            CloudBlobEx cloudBlobEx = new CloudBlobEx(this, account => account.GetBlobReference(blobName, snapshotTime));
            return cloudBlobEx;
        }

        public virtual CloudBlobEx GetBlobReference(string blobName)
        {
            CloudBlobEx cloudBlobEx = new CloudBlobEx(this, account => account.GetBlobReference(blobName));
            return cloudBlobEx;
        }

        [DoesServiceRequest]
        public virtual Task<ICloudBlob> GetBlobReferenceFromServerAsync(string blobName)
        {
            return this.failoverContainer.ExecuteAsync(x => x.GetBlobReferenceFromServerAsync(blobName));
        }

        [DoesServiceRequest]
        public virtual Task<ICloudBlob> GetBlobReferenceFromServerAsync(string blobName, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.GetBlobReferenceFromServerAsync(blobName, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<ICloudBlob> GetBlobReferenceFromServerAsync(string blobName, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.GetBlobReferenceFromServerAsync(blobName, accessCondition, options, operationContext));
        }

        public virtual CloudBlockBlobEx GetBlockBlobReference(string blobName)
        {
            CloudBlockBlobEx cloudBlockBlobEx = new CloudBlockBlobEx(this, account => account.GetBlockBlobReference(blobName));
            return cloudBlockBlobEx;
        }

        public virtual CloudBlockBlobEx GetBlockBlobReference(string blobName, DateTimeOffset? snapshotTime)
        {
            CloudBlockBlobEx cloudBlockBlobEx = new CloudBlockBlobEx(this, account => account.GetBlockBlobReference(blobName, snapshotTime));
            return cloudBlockBlobEx;
        }
        /*
                public virtual CloudBlobDirectoryEx GetDirectoryReference(string relativeAddress)
                {
                    if (relativeAddress == null)
                        throw new ArgumentNullException(nameof(relativeAddress));


                    CloudBlobDirectory[] cloudBlobDirectoryArray = new CloudBlobDirectory[this.failoverContainer.AllElements.Length];
                    for (int i = 0; i < this.failoverContainer.AllElements.Length; i++)
                    {
                        CloudBlobContainer container = this.failoverContainer.AllElements[i];
                        CloudBlobDirectory cloudBlobDirectory = container.GetDirectoryReference(relativeAddress);
                        cloudBlobDirectoryArray[i] = cloudBlobDirectory;
                    }

                    CloudBlobDirectoryEx cloudBlobDirectoryEx = new CloudBlobDirectoryEx(this, this.failoverContainer.FailoverToken, cloudBlobDirectoryArray);
                    return cloudBlobDirectoryEx;
                }

                public virtual CloudPageBlobEx GetPageBlobReference(string blobName, DateTimeOffset? snapshotTime)
                {
                    if (blobName == null)
                        throw new ArgumentNullException(nameof(blobName));


                    CloudPageBlob[] cloudPageBlobArray = new CloudPageBlob[this.failoverContainer.AllElements.Length];
                    for (int i = 0; i < this.failoverContainer.AllElements.Length; i++)
                    {
                        CloudBlobContainer container = this.failoverContainer.AllElements[i];
                        CloudPageBlob cloudPageBlob = container.GetPageBlobReference(blobName, snapshotTime);
                        cloudPageBlobArray[i] = cloudPageBlob;
                    }

                    CloudPageBlobEx cloudPageBlobEx = new CloudPageBlobEx(this, this.failoverContainer.FailoverToken, cloudPageBlobArray);
                    return cloudPageBlobEx;
                }

                public virtual CloudPageBlobEx GetPageBlobReference(string blobName)
                {
                    if (blobName == null)
                        throw new ArgumentNullException(nameof(blobName));


                    CloudPageBlob[] cloudPageBlobArray = new CloudPageBlob[this.failoverContainer.AllElements.Length];
                    for (int i = 0; i < this.failoverContainer.AllElements.Length; i++)
                    {
                        CloudBlobContainer container = this.failoverContainer.AllElements[i];
                        CloudPageBlob cloudPageBlob = container.GetPageBlobReference(blobName);
                        cloudPageBlobArray[i] = cloudPageBlob;
                    }

                    CloudPageBlobEx cloudPageBlobEx = new CloudPageBlobEx(this, this.failoverContainer.FailoverToken, cloudPageBlobArray);
                    return cloudPageBlobEx;
                }
        */
        [DoesServiceRequest]
        public virtual Task<BlobContainerPermissions> GetPermissionsAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.GetPermissionsAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<BlobContainerPermissions> GetPermissionsAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.GetPermissionsAsync(accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<BlobContainerPermissions> GetPermissionsAsync()
        {
            return this.failoverContainer.ExecuteAsync(x => x.GetPermissionsAsync());
        }

        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy)
        {
            return this.failoverContainer.Execute(x => x.GetSharedAccessSignature(policy));
        }

        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy, string groupPolicyIdentifier)
        {
            return this.failoverContainer.Execute(x => x.GetSharedAccessSignature(policy, groupPolicyIdentifier));
        }

        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy, string groupPolicyIdentifier, SharedAccessProtocol? protocols, IPAddressOrRange ipAddressOrRange)
        {
            return this.failoverContainer.Execute(x => x.GetSharedAccessSignature(policy, groupPolicyIdentifier, protocols, ipAddressOrRange));
        }

        [DoesServiceRequest]
        public virtual Task<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.ListBlobsSegmentedAsync(prefix, useFlatBlobListing, blobListingDetails, maxResults, currentToken, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<BlobResultSegment> ListBlobsSegmentedAsync(BlobContinuationToken currentToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.ListBlobsSegmentedAsync(currentToken));
        }

        [DoesServiceRequest]
        public virtual Task<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, BlobContinuationToken currentToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.ListBlobsSegmentedAsync(prefix, currentToken));
        }

        [DoesServiceRequest]
        public virtual Task<BlobResultSegment> ListBlobsSegmentedAsync(string prefix, bool useFlatBlobListing, BlobListingDetails blobListingDetails, int? maxResults, BlobContinuationToken currentToken, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.ListBlobsSegmentedAsync(prefix, useFlatBlobListing, blobListingDetails, maxResults, currentToken, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.ReleaseLeaseAsync(accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.ReleaseLeaseAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task ReleaseLeaseAsync(AccessCondition accessCondition)
        {
            return this.failoverContainer.ExecuteAsync(x => x.ReleaseLeaseAsync(accessCondition));
        }

        [DoesServiceRequest]
        public virtual Task RenewLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.RenewLeaseAsync(accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task RenewLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.RenewLeaseAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task RenewLeaseAsync(AccessCondition accessCondition)
        {
            return this.failoverContainer.ExecuteAsync(x => x.RenewLeaseAsync(accessCondition));
        }

        [DoesServiceRequest]
        public virtual Task SetMetadataAsync()
        {
            return this.failoverContainer.ExecuteAsync(x => x.SetMetadataAsync());
        }

        [DoesServiceRequest]
        public virtual Task SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.SetMetadataAsync(accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.SetMetadataAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task SetPermissionsAsync(BlobContainerPermissions permissions)
        {
            return this.failoverContainer.ExecuteAsync(x => x.SetPermissionsAsync(permissions));
        }

        [DoesServiceRequest]
        public virtual Task SetPermissionsAsync(BlobContainerPermissions permissions, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.SetPermissionsAsync(permissions, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task SetPermissionsAsync(BlobContainerPermissions permissions, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.SetPermissionsAsync(permissions, accessCondition, options, operationContext, cancellationToken));
        }
    }
}
