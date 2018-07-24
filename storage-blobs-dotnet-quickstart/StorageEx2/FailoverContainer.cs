using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace storage_blobs_dotnet_quickstart.StorageEx2
{
    interface IFailoverContainerContainerProvider<T>
    {
        FailoverContainer<T> FailoverContainer { get; }
    }

    public interface IFailoverExecutor<out T>
    {
        T[] AllElements { get; }

        TResult Execute<TResult>(Func<T, TResult> action);

        Task ExecuteAsync(Func<T, Task> asyncFunc);

        Task<TResult> ExecuteAsync<TResult>(Func<T, Task<TResult>> asyncFunc);
    }

    abstract class FailoverContainer
    {
        protected internal abstract void SetElement(int i, object item);
    }

    class FailoverContainer<T> : FailoverContainer, IFailoverExecutor<T>
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
            get { return this.GetElement(failoverToken.PrimaryIndex); }
        }

        public T[] AllElements
        {
            get { return this.array; }
        }

        public FailoverToken FailoverToken => throw new NotImplementedException();

        private T GetElement(int i)
        {
            return this.array[i];
        }

        private void SetElement(int i, T item)
        {
            this.array[i] = item;
        }

        protected internal sealed override void SetElement(int i, object item)
        {
            this.SetElement(i, (T)item);
        }

        private void RefreshElement(int i)
        {
            var removeList = new List<Tuple<WeakReference<FailoverContainer>, Func<T, object>>>();

            foreach (var tuple in this.childContainers)
            {
                WeakReference<FailoverContainer> weakReference = tuple.Item1;

                if (weakReference.TryGetTarget(out FailoverContainer childFailoverContainer))
                {
                    Func<T, object> ctorFunc = tuple.Item2;
                    object child = ctorFunc(this.GetElement(i));
                    childFailoverContainer.SetElement(i, child);
                }
                else
                {
                    removeList.Add(tuple);
                }
            }

            foreach (var tuple in removeList)
            {
                this.childContainers.Remove(tuple);
            }
        }

        private readonly List<Tuple<WeakReference<FailoverContainer>, Func<T, object>>> childContainers = new List<Tuple<WeakReference<FailoverContainer>, Func<T, object>>>();

        internal FailoverContainer<TChild> CreateChildContainer<TChild>(Func<T, TChild> ctorFunc)
        {
            TChild[] childArray = new TChild[this.array.Length];
            for (int i = 0; i < this.array.Length; i++)
            {
                T element = this.array[i];
                TChild child = ctorFunc(element);
                childArray[i] = child;
            }

            FailoverContainer<TChild> childContainer = new FailoverContainer<TChild>(this.failoverToken, childArray);

            this.AddChildContainer(childContainer, ctorFunc);

            return childContainer;
        }

        private void AddChildContainer<TChild>(FailoverContainer<TChild> childContainer, Func<T, TChild> ctorFunc)
        {
            WeakReference<FailoverContainer> weakReference = new WeakReference<FailoverContainer>(childContainer);
            Func<T, object> objCtorFunc = (t) => (object)ctorFunc(t);

            var tuple = Tuple.Create(weakReference, objCtorFunc);
            childContainers.Add(tuple);
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
                catch (StorageException ex)
                {
                    this.failoverToken.Advance();

                    if (this.failoverToken.PrimaryIndex == initialTokenIndex)
                        throw;
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
}
