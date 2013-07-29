using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MorseCode.CsJs.Common.Observable
{
    public class ObservableCollection<T> : IObservableCollection<T>
    {
        private readonly List<T> _items;

        private int _bulkOperationCount;
        private readonly List<T> _bulkOldItems = new List<T>();
        private readonly List<Action> _queuedChangeEvents = new List<Action>();

        public ObservableCollection()
        {
            _items = new List<T>();
        }

        public ObservableCollection(IEnumerable<T> items)
        {
            _items = new List<T>(items);
        }

        public int IndexOf(T item)
        {
            return _items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            OnBeforeChanged();
            _items.Insert(index, item);
            OnItemAddedInternal(item);
        }

        public void RemoveAt(int index)
        {
            T item = _items[index];
            OnBeforeChanged();
            _items.RemoveAt(index);
            OnItemRemovedInternal(item);
        }

        public T this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                if (!ReferenceEquals(value, _items[index]))
                {
                    OnBeforeChanged();
                    T item = _items[index];
                    _items[index] = value;
                    OnItemChangedInternal(item, value);
                }
            }
        }

        public void Add(T item)
        {
            OnBeforeChanged();
            _items.Add(item);
            OnItemAddedInternal(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            List<T> oldItems = _items.ToList();
            List<T> itemsToAdd = items.ToList();
            OnBeforeChanged();
            _items.AddRange(itemsToAdd);
            OnItemsResetInternal(oldItems, _items);
        }

        public void Clear()
        {
            List<T> oldItems = _items.ToList();
            OnBeforeChanged();
            _items.Clear();
            OnItemsResetInternal(oldItems, _items);
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public bool Remove(T item)
        {
            OnBeforeChanged();
            bool removed = _items.Remove(item);
            OnItemRemovedInternal(item);
            return removed;
        }

        public void ExecuteWhileBatchingChangeEvents(Action action)
        {
            if (_bulkOperationCount == 0)
            {
                _bulkOldItems.AddRange(_items);
            }

            _bulkOperationCount++;

            action();

            _bulkOperationCount--;

            if (_bulkOperationCount == 0)
            {
                List<T> oldItems = _bulkOldItems.ToList();

                _bulkOldItems.Clear();

                if (_queuedChangeEvents.Count == 1)
                {
                    _queuedChangeEvents[0]();
                }
                else if (_queuedChangeEvents.Count > 1)
                {
                    OnItemsResetInternal(oldItems, _items);
                }

                _queuedChangeEvents.Clear();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void FireChangeEvent(Action action)
        {
            if (_bulkOperationCount > 0)
            {
                _queuedChangeEvents.Add(action);
            }
            else
            {
                action();
            }
        }

        private void OnItemAddedInternal(T item)
        {
            FireChangeEvent(() =>
            {
                OnItemAdded(item);
                OnChanged();
            });
        }

        protected virtual void OnItemAdded(T item)
        {
        }

        private void OnItemRemovedInternal(T item)
        {
            FireChangeEvent(() =>
            {
                OnItemRemoved(item);
                OnChanged();
            });
        }

        protected virtual void OnItemRemoved(T item)
        {
        }

        private void OnItemChangedInternal(T oldItem, T newItem)
        {
            FireChangeEvent(() =>
            {
                OnItemsChanged(oldItem, newItem);
                OnChanged();
            });
        }

        protected virtual void OnItemsChanged(T oldItem, T newItem)
        {
        }

        private void OnItemsResetInternal(IEnumerable<T> oldItems, IEnumerable<T> newItems)
        {
            FireChangeEvent(() =>
            {
                OnItemsReset(oldItems, newItems);
                OnChanged();
            });
        }

        protected virtual void OnItemsReset(IEnumerable<T> oldItems, IEnumerable<T> newItems)
        {
        }

        public event EventHandler BeforeChanged;

        protected void OnBeforeChanged()
        {
            if (BeforeChanged != null)
            {
                BeforeChanged(this, EventArgs.Empty);
            }
        }

        protected virtual void OnChanged()
        {
            if (Changed != null)
            {
                Changed(this, EventArgs.Empty);
            }
        }

        public event EventHandler Changed;
    }
}
