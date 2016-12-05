using System.ComponentModel;

namespace DomainCrudCommon
{
    public class CancelEventArgs<T> : CancelEventArgs
    {
        private readonly T _item;

        /// <summary>
        /// Initializes a new instance of the <see cref="CancelEventArgs{T}" /> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public CancelEventArgs(T item)
        {
            _item = item;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <value>The item.</value>
        public T Item
        {
            get { return _item; }
        }
    }
}
