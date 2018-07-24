using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace storage_blobs_dotnet_quickstart.StorageEx
{
    public interface IFailoverExecutor<out T>
    {
        FailoverToken FailoverToken { get; }

        T[] AllElements { get; }

        TResult Execute<TResult>(Func<T, TResult> action);

        Task ExecuteAsync(Func<T, Task> asyncFunc);

        Task<TResult> ExecuteAsync<TResult>(Func<T, Task<TResult>> asyncFunc);
    }

    public class FailoverContainer<T> : IFailoverExecutor<T>
    {
        private readonly T[] array;
        private readonly FailoverToken failoverToken;

        public FailoverContainer(FailoverToken failoverToken, params T[] array)
        {
            if (failoverToken == null)
                throw new ArgumentNullException(nameof(failoverToken));

            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length == 0)
                throw new ArgumentException(nameof(array));

            if (failoverToken.FailoverCount != array.Length)
                throw new ArgumentException();


            this.failoverToken = failoverToken;
            this.array = array;
        }

        private T Primary
        {
            get
            {
                return this.array[this.failoverToken.PrimaryIndex];
            }
        }

        public T[] AllElements
        {
            get { return this.array; }
        }

        public FailoverToken FailoverToken
        {
            get { return this.failoverToken; }
        }

        public TResult Execute<TResult>(Func<T, TResult> action)
        {
            int initialTokenIndex = this.failoverToken.PrimaryIndex;

            while (true)
            {
                try
                {
                    TResult result = action(this.Primary);

                    return result;
                }
                catch (StorageException ex)
                {
                    this.failoverToken.Advance();

                    if (this.failoverToken.PrimaryIndex == initialTokenIndex)
                        throw;
                }
            }
        }

        public async Task ExecuteAsync(Func<T, Task> asyncFunc)
        {
            int initialTokenIndex = this.failoverToken.PrimaryIndex;

            while (true)
            {
                try
                {
                    await asyncFunc(this.Primary);
                    return;
                }
                catch (AggregateException ex)
                {
                    if (ex.InnerException is StorageException)
                    {
                        this.failoverToken.Advance();

                        if (this.failoverToken.PrimaryIndex == initialTokenIndex)
                            throw;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        public async Task<TResult> ExecuteAsync<TResult>(Func<T, Task<TResult>> asyncFunc)
        {
            int initialTokenIndex = this.failoverToken.PrimaryIndex;

            while (true)
            {
                try
                {
                    TResult result = await asyncFunc(this.Primary);
                    return result;
                }
                catch (AggregateException ex)
                {
                    if (ex.InnerException is StorageException)
                    {
                        this.failoverToken.Advance();

                        if (this.failoverToken.PrimaryIndex == initialTokenIndex)
                            throw;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }
    }

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
