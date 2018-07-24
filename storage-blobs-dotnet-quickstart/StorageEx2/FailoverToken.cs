using System;

namespace storage_blobs_dotnet_quickstart.StorageEx2
{
    public sealed class FailoverToken
    {
        private readonly int failoverCount;
        private int primaryIndex = 0;

        internal FailoverToken(int failoverCount)
        {
            if (failoverCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(failoverCount), failoverCount, "failoverCount <= 0");

            this.failoverCount = failoverCount;
        }

        internal int PrimaryIndex
        {
            get { return this.primaryIndex; }
        }

        internal int FailoverCount
        {
            get { return this.failoverCount; }
        }

        internal void Advance()
        {
            this.primaryIndex++;
            if ((this.primaryIndex % this.failoverCount) == 0)
            {
                this.primaryIndex = 0;
            }
        }
    }
}
