using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Core.Util;
using Microsoft.WindowsAzure.Storage.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace storage_blobs_dotnet_quickstart.StorageEx
{
    public class CloudBlockBlobEx : CloudBlobEx, ICloudBlobEx, ICloudBlob
    {
        private readonly IFailoverExecutor<CloudBlockBlob> failoverExecutor;

        public CloudBlockBlobEx(CloudBlobContainerEx cloudBlobContainer, FailoverToken failoverToken, params CloudBlockBlob[] cloudBlockBlobs)
            : this(cloudBlobContainer, new FailoverContainer<CloudBlockBlob>(failoverToken, cloudBlockBlobs))
        {
        }

        protected CloudBlockBlobEx(CloudBlobContainerEx cloudBlobContainer, IFailoverExecutor<CloudBlockBlob> failoverExecutor)
            : base(cloudBlobContainer, failoverExecutor)
        {
            this.failoverExecutor = failoverExecutor;
        }

        CloudBlobClient ICloudBlob.ServiceClient
        {
            get { throw new NotSupportedException(); }
        }

        public int StreamWriteSizeInBytes
        {
            get
            {
                return this.failoverExecutor.Execute(x => x.StreamWriteSizeInBytes);
            }
            set
            {
                foreach (var element in this.failoverExecutor.AllElements)
                {
                    element.StreamWriteSizeInBytes = value;
                }
            }
        }


        [DoesServiceRequest]
        public virtual Task<CloudBlockBlob> CreateSnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateSnapshotAsync(metadata, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<CloudBlockBlob> CreateSnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateSnapshotAsync(metadata, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<CloudBlockBlob> CreateSnapshotAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateSnapshotAsync());
        }

        [DoesServiceRequest]
        public virtual Task<IEnumerable<ListBlockItem>> DownloadBlockListAsync(BlockListingFilter blockListingFilter, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadBlockListAsync(blockListingFilter, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<IEnumerable<ListBlockItem>> DownloadBlockListAsync(BlockListingFilter blockListingFilter, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadBlockListAsync(blockListingFilter, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<IEnumerable<ListBlockItem>> DownloadBlockListAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadBlockListAsync());
        }

        [DoesServiceRequest]
        public virtual Task<string> DownloadTextAsync(Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadTextAsync(encoding, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<string> DownloadTextAsync(Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadTextAsync(encoding, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<string> DownloadTextAsync(Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadTextAsync(encoding, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<string> DownloadTextAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadTextAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<string> DownloadTextAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.DownloadTextAsync());
        }

        public virtual Task<CloudBlobStream> OpenWriteAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.OpenWriteAsync());
        }

        public virtual Task<CloudBlobStream> OpenWriteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.OpenWriteAsync(accessCondition, options, operationContext));
        }

        public virtual Task<CloudBlobStream> OpenWriteAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.OpenWriteAsync(accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task PutBlockAsync(string blockId, Stream blockData, string contentMD5)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.PutBlockAsync(blockId, blockData, contentMD5));
        }

        [DoesServiceRequest]
        public virtual Task PutBlockAsync(string blockId, Stream blockData, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.PutBlockAsync(blockId, blockData, contentMD5, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task PutBlockAsync(string blockId, Stream blockData, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.PutBlockAsync(blockId, blockData, contentMD5, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task PutBlockAsync(string blockId, Stream blockData, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.PutBlockAsync(blockId, blockData, contentMD5, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task PutBlockListAsync(IEnumerable<string> blockList, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.PutBlockListAsync(blockList, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task PutBlockListAsync(IEnumerable<string> blockList, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.PutBlockListAsync(blockList, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task PutBlockListAsync(IEnumerable<string> blockList)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.PutBlockListAsync(blockList));
        }

        [DoesServiceRequest]
        public virtual Task SetStandardBlobTierAsync(StandardBlobTier standardBlobTier, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetStandardBlobTierAsync(standardBlobTier, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task SetStandardBlobTierAsync(StandardBlobTier standardBlobTier)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetStandardBlobTierAsync(standardBlobTier));
        }

        [DoesServiceRequest]
        public virtual Task SetStandardBlobTierAsync(StandardBlobTier standardBlobTier, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetStandardBlobTierAsync(standardBlobTier, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartCopyAsync(CloudFile source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext, cancellationToken));
        }

        public virtual Task<string> StartCopyAsync(CloudFile source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext));
        }

        public virtual Task<string> StartCopyAsync(CloudBlockBlob source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartCopyAsync(CloudFile source)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartCopyAsync(source));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartCopyAsync(CloudBlockBlob source)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartCopyAsync(source));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartCopyAsync(CloudBlockBlob source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromByteArrayAsync(buffer, index, count, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromByteArrayAsync(buffer, index, count, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromByteArrayAsync(byte[] buffer, int index, int count)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromByteArrayAsync(buffer, index, count));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromByteArrayAsync(buffer, index, count, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromFileAsync(string path, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromFileAsync(path, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromFileAsync(string path)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromFileAsync(path));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromFileAsync(string path, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromFileAsync(path, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromFileAsync(string path, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromFileAsync(path, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source, length, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, long length)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source, length));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source, length, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source, length, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadTextAsync(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadTextAsync(content, encoding, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadTextAsync(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadTextAsync(content, encoding, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task UploadTextAsync(string content, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadTextAsync(content, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task UploadTextAsync(string content)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadTextAsync(content));
        }

        [DoesServiceRequest]
        public virtual Task UploadTextAsync(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadTextAsync(content, encoding, accessCondition, options, operationContext, cancellationToken));
        }
    }
}
