using Microsoft.WindowsAzure.Storage;
using System;

namespace storage_blobs_dotnet_quickstart.StorageEx
{
    public interface IListBlobItemEx
    {
        Uri Uri { get; }
        StorageUri StorageUri { get; }
        CloudBlobDirectoryEx Parent { get; }
        CloudBlobContainerEx Container { get; }
    }
}
