using Microsoft.WindowsAzure.Storage;
using System;

namespace storage_blobs_dotnet_quickstart.StorageEx2
{
    public interface IListBlobItemEx
    {
        Uri Uri { get; }
        StorageUri StorageUri { get; }
/*        CloudBlobDirectoryEx Parent { get; }*/
        CloudBlobContainerEx Container { get; }
    }
}
