using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Implementation
{
    public class MyList<T> : IReadOnlyCollection<T>
    {
        private const int DefaulrCount = 4;
        private const int RateFactor = 2;

        private T[] _array;
        private int _capacity;

        public MyList(int capacity)
        {
            _capacity = capacity;
            _array = new T[_capacity];
        }

        public MyList()
            : this(DefaulrCount)
        {
        }

        public int Capacity
        {
            get => _capacity;
            set
            {
                if (!ValidateSetCapacity(value))
                {
                    return;
                }

                _capacity = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (Count == Capacity)
            {
                var isSuccess = IncreaseArray();
                if (!isSuccess)
                {
                    return;
                }
            }

            AddItem(item);
        }

        public void AddRange(IReadOnlyCollection<T> array)
        {
            var capacity = Count + array.Count;

            if (capacity >= Capacity)
            {
                var isSuccess = IncreaseArray(capacity);
                if (!isSuccess)
                {
                    return;
                }
            }

            foreach (var item in array)
            {
                AddItem(item);
            }
        }

        public bool RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                return false;
            }

            var lastIndex = Count - 1;

            for (var i = index; i < lastIndex; i++)
            {
                _array[i] = _array[i + 1];
            }

            _array[lastIndex] = default(T);
            Count--;

            return true;
        }

        public bool Remove(T item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (_array[i].Equals(item))
                {
                    var isSuccess = RemoveAt(i);
                    if (!isSuccess)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(_array, comparer);
        }

        public IEnumerator GetEnumerator()
        {
            return GetGenericEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetGenericEnumerator();
        }

        private bool IncreaseArray(int? capacity = null)
        {
            var tempArray = _array;
            if (capacity == null)
            {
                _capacity = _capacity * RateFactor;
            }
            else
            {
                var isValidCapacity = ValidateSetCapacity(capacity.Value);
                if (!isValidCapacity)
                {
                    return false;
                }

                _capacity = capacity.Value;
            }

            _array = new T[Capacity];

            for (var i = 0; i < tempArray.Length; i++)
            {
                _array[i] = tempArray[i];
            }

            return true;
        }

        private bool ValidateSetCapacity(int capacity)
        {
            return capacity > Count;
        }

        private void AddItem(T item)
        {
            _array[Count] = item;
            Count++;
        }

        private IEnumerator<T> GetGenericEnumerator()
        {
            foreach (var item in _array)
            {
                if (!item.Equals(default(T)))
                {
                    yield return item;
                }
            }
        }
    }
}
