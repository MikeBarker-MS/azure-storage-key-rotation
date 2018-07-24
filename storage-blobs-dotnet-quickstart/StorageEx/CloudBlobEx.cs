using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Core.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace storage_blobs_dotnet_quickstart.StorageEx
{
    public class CloudBlobEx : IListBlobItemEx, IListBlobItem
    {
        private readonly CloudBlobContainerEx cloudBlobContainer;
        private readonly IFailoverExecutor<CloudBlob> failoverExecutor;

        public CloudBlobEx(CloudBlobContainerEx cloudBlobContainer, FailoverToken failoverToken, params CloudBlob[] cloudBlobs)
            : this(cloudBlobContainer, new FailoverContainer<CloudBlob>(failoverToken, cloudBlobs))
        {
        }

        protected CloudBlobEx(CloudBlobContainerEx cloudBlobContainer, IFailoverExecutor<CloudBlob> failoverExecutor)
        {
            if (cloudBlobContainer == null)
                throw new ArgumentNullException(nameof(cloudBlobContainer));

            if (failoverExecutor == null)
                throw new ArgumentNullException(nameof(failoverExecutor));


            this.cloudBlobContainer = cloudBlobContainer;
            this.failoverExecutor = failoverExecutor;
        }

        public int StreamMinimumReadSizeInBytes
        {
            get
            {
                return this.failoverExecutor.Execute(x => x.StreamMinimumReadSizeInBytes);
            }
            set
            {
                foreach (var element in this.failoverExecutor.AllElements)
                {
                    element.StreamMinimumReadSizeInBytes = value;
                }
            }
        }

        public BlobProperties Properties
        {
            get
            {
                return this.failoverExecutor.Execute(x => x.Properties);
            }
        }

        public IDictionary<string, string> Metadata
        {
            get
            {
                return this.failoverExecutor.Execute(x => x.Metadata);
            }
        }

        public Uri Uri
        {
            get
            {
                return this.failoverExecutor.Execute(x => x.Uri);
            }
        }

        public StorageUri StorageUri
        {
            get
            {
                return this.failoverExecutor.Execute(x => x.StorageUri);
            }
        }

        public DateTimeOffset? SnapshotTime
        {
            get
            {
                return this.failoverExecutor.Execute(x => x.SnapshotTime);
            }
        }

        public StorageUri SnapshotQualifiedStorageUri
        {
            get
            {
                return this.failoverExecutor.Execute(x => x.SnapshotQualifiedStorageUri);
            }
        }

        public bool IsDeleted
        {
            get
            {
                return this.failoverExecutor.Execute(x => x.IsDeleted);
            }
        }

        public Uri SnapshotQualifiedUri
        {
            get
            {
                return this.failoverExecutor.Execute(x => x.SnapshotQualifiedUri);
            }
        }

        public CloudBlobClientEx ServiceClient
        {
            get
            {
                return this.cloudBlobContainer.ServiceClient;
            }
        }

        public CopyState CopyState
        {
            get
            {
                return this.failoverExecutor.Execute(x => x.CopyState);
            }
        }

        public virtual string Name
        {
            get
            {
                return this.failoverExecutor.Execute(x => x.Name);
            }
        }

        public CloudBlobContainerEx Container
        {
            get
            {
                return this.cloudBlobContainer;
            }
        }

        CloudBlobContainer IListBlobItem.Container
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public bool IsSnapshot
        {
            get
            {
                return this.failoverExecutor.Execute(x => x.IsSnapshot);
            }
        }

        public CloudBlobDirectoryEx Parent
        {
            get
            {
                CloudBlobDirectory[] cloudBlobDirectoryArray = new CloudBlobDirectory[this.failoverExecutor.AllElements.Length];
                for (int i = 0; i < this.failoverExecutor.AllElements.Length; i++)
                {
                    CloudBlob cloudBlob = this.failoverExecutor.AllElements[i];
                    CloudBlobDirectory parent = cloudBlob.Parent;
                    cloudBlobDirectoryArray[i] = parent;
                }

                CloudBlobDirectoryEx cloudBlobDirectoryEx = new CloudBlobDirectoryEx(this.cloudBlobContainer, this.failoverExecutor.FailoverToken, cloudBlobDirectoryArray);
                return cloudBlobDirectoryEx;
            }
        }

        CloudBlobDirectory IListBlobItem.Parent
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public BlobType BlobType
        {
            get
            {
                return this.failoverExecutor.Execute(x => x.BlobType);
            }
        }




        [DoesServiceRequest]
        public virtual Task AbortCopyAsync(string copyId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.AbortCopyAsync(copyId, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task AbortCopyAsync(string copyId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.AbortCopyAsync(copyId, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task AbortCopyAsync(string copyId)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.AbortCopyAsync(copyId));
        }

        [DoesServiceRequest]
        public virtual Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.AcquireLeaseAsync(leaseTime, proposedLeaseId, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.AcquireLeaseAsync(leaseTime, proposedLeaseId, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId = null)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.AcquireLeaseAsync(leaseTime, proposedLeaseId = null));
        }

        [DoesServiceRequest]
        public virtual Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.BreakLeaseAsync(breakPeriod, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.BreakLeaseAsync(breakPeriod, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.BreakLeaseAsync(breakPeriod));
        }

        [DoesServiceRequest]
        public virtual Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ChangeLeaseAsync(proposedLeaseId, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ChangeLeaseAsync(proposedLeaseId, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ChangeLeaseAsync(proposedLeaseId, accessCondition));
        }

        [DoesServiceRequest]
        public virtual Task DeleteAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DeleteAsync(deleteSnapshotsOption, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task DeleteAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DeleteAsync());
        }

        [DoesServiceRequest]
        public virtual Task DeleteAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DeleteAsync(deleteSnapshotsOption, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<bool> DeleteIfExistsAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DeleteIfExistsAsync());
        }

        [DoesServiceRequest]
        public virtual Task<bool> DeleteIfExistsAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DeleteIfExistsAsync(deleteSnapshotsOption, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<bool> DeleteIfExistsAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DeleteIfExistsAsync(deleteSnapshotsOption, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadRangeToByteArrayAsync(target, index, blobOffset, length, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadRangeToByteArrayAsync(target, index, blobOffset, length, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadRangeToByteArrayAsync(target, index, blobOffset, length));
        }

        [DoesServiceRequest]
        public virtual Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadRangeToByteArrayAsync(target, index, blobOffset, length, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadRangeToStreamAsync(target, offset, length));
        }

        [DoesServiceRequest]
        public virtual Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadRangeToStreamAsync(target, offset, length, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadRangeToStreamAsync(target, offset, length, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadRangeToStreamAsync(target, offset, length, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<int> DownloadToByteArrayAsync(byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadToByteArrayAsync(target, index, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<int> DownloadToByteArrayAsync(byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadToByteArrayAsync(target, index, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<int> DownloadToByteArrayAsync(byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadToByteArrayAsync(target, index, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<int> DownloadToByteArrayAsync(byte[] target, int index)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadToByteArrayAsync(target, index));
        }

        [DoesServiceRequest]
        public virtual Task DownloadToFileAsync(string path, FileMode mode, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadToFileAsync(path, mode, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task DownloadToFileAsync(string path, FileMode mode, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadToFileAsync(path, mode, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task DownloadToFileAsync(string path, FileMode mode, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadToFileAsync(path, mode, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task DownloadToFileAsync(string path, FileMode mode)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadToFileAsync(path, mode));
        }

        [DoesServiceRequest]
        public virtual Task DownloadToStreamAsync(Stream target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadToStreamAsync(target, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task DownloadToStreamAsync(Stream target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadToStreamAsync(target, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task DownloadToStreamAsync(Stream target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadToStreamAsync(target, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task DownloadToStreamAsync(Stream target)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadToStreamAsync(target));
        }

        [DoesServiceRequest]
        public virtual Task<bool> ExistsAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ExistsAsync());
        }

        [DoesServiceRequest]
        public virtual Task<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ExistsAsync(options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ExistsAsync(options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task FetchAttributesAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.FetchAttributesAsync());
        }

        [DoesServiceRequest]
        public virtual Task FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.FetchAttributesAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.FetchAttributesAsync(accessCondition, options, operationContext, cancellationToken));
        }

        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy)
        {
            return this.failoverExecutor.Execute(x => x.GetSharedAccessSignature(policy));
        }

        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy, string groupPolicyIdentifier)
        {
            return this.failoverExecutor.Execute(x => x.GetSharedAccessSignature(policy, groupPolicyIdentifier));
        }

        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy, SharedAccessBlobHeaders headers)
        {
            return this.failoverExecutor.Execute(x => x.GetSharedAccessSignature(policy, headers));
        }

        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy, SharedAccessBlobHeaders headers, string groupPolicyIdentifier)
        {
            return this.failoverExecutor.Execute(x => x.GetSharedAccessSignature(policy, headers, groupPolicyIdentifier));
        }

        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy, SharedAccessBlobHeaders headers, string groupPolicyIdentifier, SharedAccessProtocol? protocols, IPAddressOrRange ipAddressOrRange)
        {
            return this.failoverExecutor.Execute(x => x.GetSharedAccessSignature(policy, headers, groupPolicyIdentifier, protocols, ipAddressOrRange));
        }

        [DoesServiceRequest]
        public virtual Task<Stream> OpenReadAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.OpenReadAsync());
        }

        [DoesServiceRequest]
        public virtual Task<Stream> OpenReadAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.OpenReadAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<Stream> OpenReadAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.OpenReadAsync(accessCondition, options, operationContext, cancellationToken));
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
        public virtual Task ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ReleaseLeaseAsync(accessCondition, options, operationContext, cancellationToken));
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
        public virtual Task SetMetadataAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetMetadataAsync());
        }

        [DoesServiceRequest]
        public virtual Task SetPropertiesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetPropertiesAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task SetPropertiesAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetPropertiesAsync());
        }

        [DoesServiceRequest]
        public virtual Task SetPropertiesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetPropertiesAsync(accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<CloudBlob> SnapshotAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SnapshotAsync());
        }

        [DoesServiceRequest]
        public virtual Task<CloudBlob> SnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SnapshotAsync(metadata, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<CloudBlob> SnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SnapshotAsync(metadata, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartCopyAsync(Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartCopyAsync(Uri source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartCopyAsync(Uri source)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartCopyAsync(source));
        }

        [DoesServiceRequest]
        public virtual Task UndeleteAsync(CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UndeleteAsync(cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UndeleteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UndeleteAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task UndeleteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UndeleteAsync(accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UndeleteAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UndeleteAsync());
        }

    }
}
