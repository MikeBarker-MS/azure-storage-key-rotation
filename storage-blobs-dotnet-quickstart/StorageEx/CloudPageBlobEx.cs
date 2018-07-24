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
    public class CloudPageBlobEx : CloudBlobEx, ICloudBlobEx, ICloudBlob
    {
        private readonly IFailoverExecutor<CloudPageBlob> failoverExecutor;

        public CloudPageBlobEx(CloudBlobContainerEx cloudBlobContainer, FailoverToken failoverToken, params CloudPageBlob[] cloudPageBlobs)
            : this(cloudBlobContainer, new FailoverContainer<CloudPageBlob>(failoverToken, cloudPageBlobs))
        {
        }

        protected CloudPageBlobEx(CloudBlobContainerEx cloudBlobContainer, IFailoverExecutor<CloudPageBlob> failoverExecutor)
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
        public virtual Task ClearPagesAsync(long startOffset, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ClearPagesAsync(startOffset, length, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task ClearPagesAsync(long startOffset, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ClearPagesAsync(startOffset, length, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task ClearPagesAsync(long startOffset, long length)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ClearPagesAsync(startOffset, length));
        }

        [DoesServiceRequest]
        public virtual Task CreateAsync(long size)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateAsync(size));
        }

        [DoesServiceRequest]
        public virtual Task CreateAsync(long size, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateAsync(size, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task CreateAsync(long size, PremiumPageBlobTier? premiumBlobTier, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateAsync(size, premiumBlobTier, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task CreateAsync(long size, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateAsync(size, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<CloudPageBlob> CreateSnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateSnapshotAsync(metadata, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<CloudPageBlob> CreateSnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateSnapshotAsync(metadata, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<CloudPageBlob> CreateSnapshotAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.CreateSnapshotAsync());
        }

        [DoesServiceRequest]
        public virtual Task<IEnumerable<PageRange>> GetPageRangesAsync()
        {
            return this.failoverExecutor.ExecuteAsync(x => x.GetPageRangesAsync());
        }

        [DoesServiceRequest]
        public virtual Task<IEnumerable<PageRange>> GetPageRangesAsync(long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.GetPageRangesAsync(offset, length, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<IEnumerable<PageRange>> GetPageRangesAsync(long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.GetPageRangesAsync(offset, length, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<IEnumerable<PageDiffRange>> GetPageRangesDiffAsync(DateTimeOffset previousSnapshotTime)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.GetPageRangesDiffAsync(previousSnapshotTime));
        }

        [DoesServiceRequest]
        public virtual Task<IEnumerable<PageDiffRange>> GetPageRangesDiffAsync(DateTimeOffset previousSnapshotTime, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.GetPageRangesDiffAsync(previousSnapshotTime, offset, length, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<IEnumerable<PageDiffRange>> GetPageRangesDiffAsync(DateTimeOffset previousSnapshotTime, long? offset, long? length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.GetPageRangesDiffAsync(previousSnapshotTime, offset, length, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<CloudBlobStream> OpenWriteAsync(long? size)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.OpenWriteAsync(size));
        }

        [DoesServiceRequest]
        public virtual Task<CloudBlobStream> OpenWriteAsync(long? size, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.OpenWriteAsync(size, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<CloudBlobStream> OpenWriteAsync(long? size, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.OpenWriteAsync(size, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task ResizeAsync(long size, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ResizeAsync(size, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task ResizeAsync(long size, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ResizeAsync(size, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task ResizeAsync(long size)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.ResizeAsync(size));
        }

        [DoesServiceRequest]
        public virtual Task SetPremiumBlobTierAsync(PremiumPageBlobTier premiumBlobTier, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetPremiumBlobTierAsync(premiumBlobTier, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task SetPremiumBlobTierAsync(PremiumPageBlobTier premiumBlobTier)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetPremiumBlobTierAsync(premiumBlobTier));
        }

        [DoesServiceRequest]
        public virtual Task SetPremiumBlobTierAsync(PremiumPageBlobTier premiumBlobTier, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetPremiumBlobTierAsync(premiumBlobTier, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task SetSequenceNumberAsync(SequenceNumberAction sequenceNumberAction, long? sequenceNumber, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetSequenceNumberAsync(sequenceNumberAction, sequenceNumber, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task SetSequenceNumberAsync(SequenceNumberAction sequenceNumberAction, long? sequenceNumber)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetSequenceNumberAsync(sequenceNumberAction, sequenceNumber));
        }

        [DoesServiceRequest]
        public virtual Task SetSequenceNumberAsync(SequenceNumberAction sequenceNumberAction, long? sequenceNumber, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.SetSequenceNumberAsync(sequenceNumberAction, sequenceNumber, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartCopyAsync(CloudPageBlob source, PremiumPageBlobTier? premiumBlobTier, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartCopyAsync(source, premiumBlobTier, sourceAccessCondition, destAccessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartCopyAsync(CloudPageBlob source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartCopyAsync(CloudPageBlob source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartCopyAsync(CloudPageBlob source)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartCopyAsync(source));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartIncrementalCopyAsync(Uri sourceSnapshot, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartIncrementalCopyAsync(sourceSnapshot, destAccessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartIncrementalCopyAsync(CloudPageBlob sourceSnapshot, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartIncrementalCopyAsync(sourceSnapshot, destAccessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartIncrementalCopyAsync(Uri sourceSnapshot)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartIncrementalCopyAsync(sourceSnapshot));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartIncrementalCopyAsync(CloudPageBlob sourceSnapshot)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.StartIncrementalCopyAsync(sourceSnapshot));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, PremiumPageBlobTier? premiumBlobTier, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromByteArrayAsync(buffer, index, count, premiumBlobTier, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, PremiumPageBlobTier? premiumBlobTier, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromByteArrayAsync(buffer, index, count, premiumBlobTier, accessCondition, options, operationContext, cancellationToken));
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
        public virtual Task UploadFromFileAsync(string path, PremiumPageBlobTier? premiumBlobTier, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromFileAsync(path, premiumBlobTier, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromFileAsync(string path, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromFileAsync(path, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromFileAsync(string path, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromFileAsync(path, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromFileAsync(string path)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromFileAsync(path));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, long length, PremiumPageBlobTier? premiumBlobTier, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source, length, premiumBlobTier, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, PremiumPageBlobTier? premiumBlobTier, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source, premiumBlobTier, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, long length, PremiumPageBlobTier? premiumBlobTier, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source, length, premiumBlobTier, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, long length)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source, length));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, PremiumPageBlobTier? premiumBlobTier, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source, premiumBlobTier, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source, length, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.UploadFromStreamAsync(source, length, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task WritePagesAsync(Stream pageData, long startOffset, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.WritePagesAsync(pageData, startOffset, contentMD5, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task WritePagesAsync(Stream pageData, long startOffset, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.WritePagesAsync(pageData, startOffset, contentMD5, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task WritePagesAsync(Stream pageData, long startOffset, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.WritePagesAsync(pageData, startOffset, contentMD5, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task WritePagesAsync(Stream pageData, long startOffset, string contentMD5)
        {
            return this.failoverExecutor.ExecuteAsync(x => x.WritePagesAsync(pageData, startOffset, contentMD5));
        }
    }
}
