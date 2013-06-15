using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MorseCode.CsJs.Common.Observable
{
    public class ObservableCollection<T> : IList<T>, IObservable
    {
        private readonly List<T> _items;

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
            OnChanging();
            _items.Insert(index, item);
            OnItemAdded(item);
            OnChanged();
        }

        public void RemoveAt(int index)
        {
            T item = _items[index];
            OnChanging();
            _items.RemoveAt(index);
            OnItemRemoved(item);
            OnChanged();
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
                    OnChanging();
                    _items[index] = value;
                    OnChanged();
                }
            }
        }

        public void Add(T item)
        {
            OnChanging();
            _items.Add(item);
            OnItemAdded(item);
            OnChanged();
        }

        public void AddRange(IEnumerable<T> items)
        {
            List<T> itemsToAdd = items.ToList();
            OnChanging();
            _items.AddRange(itemsToAdd);
            itemsToAdd.ForEach(OnItemAdded);
            OnChanged();
        }

        public void Clear()
        {
            List<T> oldItems = _items.ToList();
            OnChanging();
            _items.Clear();
            OnItemsReset(oldItems, _items);
            OnChanged();
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
            OnChanging();
            bool removed = _items.Remove(item);
            OnItemRemoved(item);
            OnChanged();
            return removed;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected virtual void OnItemAdded(T item)
        {
        }

        protected virtual void OnItemRemoved(T item)
        {
        }

        protected virtual void OnItemsReset(IEnumerable<T> oldItems, IEnumerable<T> newItems)
        {
        }

        public event EventHandler Changing;

        protected void OnChanging()
        {
            if (Changing != null)
            {
                Changing(this, EventArgs.Empty);
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
