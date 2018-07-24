using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace storage_blobs_dotnet_quickstart.StorageEx
{
    public interface ICloudBlobEx : IListBlobItemEx
    {
        BlobType BlobType { get; }
        StorageUri SnapshotQualifiedStorageUri { get; }
        Uri SnapshotQualifiedUri { get; }
        bool IsSnapshot { get; }
        DateTimeOffset? SnapshotTime { get; }
        IDictionary<string, string> Metadata { get; }
        BlobProperties Properties { get; }
        int StreamMinimumReadSizeInBytes { get; set; }
        int StreamWriteSizeInBytes { get; set; }
        CloudBlobClientEx ServiceClient { get; }
        string Name { get; }
        CopyState CopyState { get; }

        Task AbortCopyAsync(string copyId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task AbortCopyAsync(string copyId);
        Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId = null);
        Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod);
        Task<TimeSpan> BreakLeaseAsync(TimeSpan? breakPeriod, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition);
        Task<string> ChangeLeaseAsync(string proposedLeaseId, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task DeleteAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task DeleteAsync();
        Task<bool> DeleteIfExistsAsync(DeleteSnapshotsOption deleteSnapshotsOption, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task<bool> DeleteIfExistsAsync();
        Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length);
        Task<int> DownloadRangeToByteArrayAsync(byte[] target, int index, long? blobOffset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length);
        Task DownloadRangeToStreamAsync(Stream target, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task<int> DownloadToByteArrayAsync(byte[] target, int index);
        Task<int> DownloadToByteArrayAsync(byte[] target, int index, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task DownloadToFileAsync(string path, FileMode mode);
        Task DownloadToFileAsync(string path, FileMode mode, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task DownloadToStreamAsync(Stream target, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task DownloadToStreamAsync(Stream target);
        Task<bool> ExistsAsync(BlobRequestOptions options, OperationContext operationContext);
        Task<bool> ExistsAsync();
        Task FetchAttributesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task FetchAttributesAsync();
        string GetSharedAccessSignature(SharedAccessBlobPolicy policy);
        string GetSharedAccessSignature(SharedAccessBlobPolicy policy, string groupPolicyIdentifier);
        string GetSharedAccessSignature(SharedAccessBlobPolicy policy, SharedAccessBlobHeaders headers);
        string GetSharedAccessSignature(SharedAccessBlobPolicy policy, SharedAccessBlobHeaders headers, string groupPolicyIdentifier);
        string GetSharedAccessSignature(SharedAccessBlobPolicy policy, SharedAccessBlobHeaders headers, string groupPolicyIdentifier, SharedAccessProtocol? protocols, IPAddressOrRange ipAddressOrRange);
        Task<Stream> OpenReadAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task ReleaseLeaseAsync(AccessCondition accessCondition);
        Task ReleaseLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task RenewLeaseAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task RenewLeaseAsync(AccessCondition accessCondition);
        Task SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task SetMetadataAsync();
        Task SetPropertiesAsync();
        Task SetPropertiesAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task UploadFromByteArrayAsync(byte[] buffer, int index, int count);
        Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task UploadFromFileAsync(string path, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task UploadFromFileAsync(string path);
        Task UploadFromStreamAsync(Stream source, long length);
        Task UploadFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
        Task UploadFromStreamAsync(Stream source);
        Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext);
    }
}
