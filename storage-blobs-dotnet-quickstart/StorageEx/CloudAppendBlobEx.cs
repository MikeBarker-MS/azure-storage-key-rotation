using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Core.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace storage_blobs_dotnet_quickstart.StorageEx
{
    public class CloudAppendBlobEx : CloudBlobEx, ICloudBlobEx, ICloudBlob
    {
        private readonly FailoverContainer<CloudAppendBlob> failoverContainer;

        public CloudAppendBlobEx(CloudBlobContainerEx cloudBlobContainer, FailoverToken failoverToken, params CloudAppendBlob[] cloudAppendBlobs)
            : this(cloudBlobContainer, new FailoverContainer<CloudAppendBlob>(failoverToken, cloudAppendBlobs))
        {
        }

        protected CloudAppendBlobEx(CloudBlobContainerEx cloudBlobContainer, FailoverContainer<CloudAppendBlob> failoverContainer)
            : base(cloudBlobContainer, failoverContainer)
        {
            this.failoverContainer = failoverContainer;
        }

        CloudBlobClient ICloudBlob.ServiceClient
        {
            get { throw new NotSupportedException(); }
        }

        public int StreamWriteSizeInBytes
        {
            get
            {
                return this.failoverContainer.Execute(x => x.StreamWriteSizeInBytes);
            }
            set
            {
                foreach (var element in this.failoverContainer.AllElements)
                {
                    element.StreamWriteSizeInBytes = value;
                }
            }
        }


        [DoesServiceRequest]
        public virtual Task<long> AppendBlockAsync(Stream blockData, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendBlockAsync(blockData, contentMD5, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<long> AppendBlockAsync(Stream blockData, string contentMD5, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendBlockAsync(blockData, contentMD5, accessCondition, options, operationContext, cancellationToken));
        }

        public virtual Task<long> AppendBlockAsync(Stream blockData, string contentMD5, AccessCondition accesscondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendBlockAsync(blockData, contentMD5, accesscondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<long> AppendBlockAsync(Stream blockData)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendBlockAsync(blockData));
        }

        [DoesServiceRequest]
        public virtual Task<long> AppendBlockAsync(Stream blockData, string contentMD5)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendBlockAsync(blockData, contentMD5));
        }

        [DoesServiceRequest]
        public virtual Task AppendFromByteArrayAsync(byte[] buffer, int index, int count)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendFromByteArrayAsync(buffer, index, count));
        }

        [DoesServiceRequest]
        public virtual Task AppendFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendFromByteArrayAsync(buffer, index, count, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task AppendFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendFromByteArrayAsync(buffer, index, count, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task AppendFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendFromByteArrayAsync(buffer, index, count, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task AppendFromFileAsync(string path, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendFromFileAsync(path, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task AppendFromFileAsync(string path, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendFromFileAsync(path, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task AppendFromFileAsync(string path, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendFromFileAsync(path, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task AppendFromFileAsync(string path)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendFromFileAsync(path));
        }

        [DoesServiceRequest]
        public virtual Task AppendFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHelper, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendFromStreamAsync(source, length, accessCondition, options, operationContext, progressHelper, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task AppendFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendFromStreamAsync(source, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task AppendFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendFromStreamAsync(source, length, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task AppendFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendFromStreamAsync(source, length, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task AppendFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendFromStreamAsync(source, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task AppendFromStreamAsync(Stream source, long length)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendFromStreamAsync(source, length));
        }

        [DoesServiceRequest]
        public virtual Task AppendFromStreamAsync(Stream source)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendFromStreamAsync(source));
        }

        [DoesServiceRequest]
        public virtual Task AppendFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendFromStreamAsync(source, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task AppendTextAsync(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendTextAsync(content, encoding, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task AppendTextAsync(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendTextAsync(content, encoding, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task AppendTextAsync(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendTextAsync(content, encoding, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task AppendTextAsync(string content)
        {
            return this.failoverContainer.ExecuteAsync(x => x.AppendTextAsync(content));
        }

        [DoesServiceRequest]
        public virtual Task CreateOrReplaceAsync()
        {
            return this.failoverContainer.ExecuteAsync(x => x.CreateOrReplaceAsync());
        }

        [DoesServiceRequest]
        public virtual Task CreateOrReplaceAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.CreateOrReplaceAsync(accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task CreateOrReplaceAsync(AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.CreateOrReplaceAsync(accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<CloudAppendBlob> CreateSnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.CreateSnapshotAsync(metadata, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<CloudAppendBlob> CreateSnapshotAsync()
        {
            return this.failoverContainer.ExecuteAsync(x => x.CreateSnapshotAsync());
        }

        [DoesServiceRequest]
        public virtual Task<CloudAppendBlob> CreateSnapshotAsync(IDictionary<string, string> metadata, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.CreateSnapshotAsync(metadata, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<string> DownloadTextAsync(Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.DownloadTextAsync(encoding, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<string> DownloadTextAsync()
        {
            return this.failoverContainer.ExecuteAsync(x => x.DownloadTextAsync());
        }

        [DoesServiceRequest]
        public virtual Task<string> DownloadTextAsync(Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.DownloadTextAsync(encoding, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<string> DownloadTextAsync(Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.DownloadTextAsync(encoding, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<CloudBlobStream> OpenWriteAsync(bool createNew, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.OpenWriteAsync(createNew, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<CloudBlobStream> OpenWriteAsync(bool createNew, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.OpenWriteAsync(createNew, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<CloudBlobStream> OpenWriteAsync(bool createNew)
        {
            return this.failoverContainer.ExecuteAsync(x => x.OpenWriteAsync(createNew));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartCopyAsync(CloudAppendBlob source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartCopyAsync(CloudAppendBlob source, AccessCondition sourceAccessCondition, AccessCondition destAccessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.StartCopyAsync(source, sourceAccessCondition, destAccessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task<string> StartCopyAsync(CloudAppendBlob source)
        {
            return this.failoverContainer.ExecuteAsync(x => x.StartCopyAsync(source));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromByteArrayAsync(byte[] buffer, int index, int count)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadFromByteArrayAsync(buffer, index, count));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadFromByteArrayAsync(buffer, index, count, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadFromByteArrayAsync(buffer, index, count, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromByteArrayAsync(byte[] buffer, int index, int count, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadFromByteArrayAsync(buffer, index, count, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromFileAsync(string path, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadFromFileAsync(path, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromFileAsync(string path, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadFromFileAsync(path, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromFileAsync(string path, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadFromFileAsync(path, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromFileAsync(string path)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadFromFileAsync(path));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadFromStreamAsync(source));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, long length)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadFromStreamAsync(source, length));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadFromStreamAsync(source, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadFromStreamAsync(source, length, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadFromStreamAsync(source, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadFromStreamAsync(source, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadFromStreamAsync(source, length, accessCondition, options, operationContext, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadFromStreamAsync(Stream source, long length, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadFromStreamAsync(source, length, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task UploadTextAsync(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadTextAsync(content, encoding, accessCondition, options, operationContext));
        }

        [DoesServiceRequest]
        public virtual Task UploadTextAsync(string content)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadTextAsync(content));
        }

        [DoesServiceRequest]
        public virtual Task UploadTextAsync(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, IProgress<StorageProgress> progressHandler, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadTextAsync(content, encoding, accessCondition, options, operationContext, progressHandler, cancellationToken));
        }

        [DoesServiceRequest]
        public virtual Task UploadTextAsync(string content, Encoding encoding, AccessCondition accessCondition, BlobRequestOptions options, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.failoverContainer.ExecuteAsync(x => x.UploadTextAsync(content, encoding, accessCondition, options, operationContext, cancellationToken));
        }

    }
}
