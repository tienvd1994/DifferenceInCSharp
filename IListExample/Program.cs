using System;
using System.Collections;

namespace IListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var simpleList = new SimpleList();
            // Populate the List.
            Console.WriteLine("Populate the List");
            simpleList.Add("one");
            simpleList.Add("two");
            simpleList.Add("three");
            simpleList.Add("four");
            simpleList.Add("five");
            simpleList.Add("six");
            simpleList.Add("seven");
            // simpleList.Add("eight");
            
            simpleList.Insert(4, "number");
            
            simpleList.PrintContents();
            
            Console.WriteLine();
            Console.ReadLine();
        }
    }

    class SimpleList : IList
    {
        private object[] _contents = new object[8];
        private int _count;

        public SimpleList()
        {
            _count = 0;
        }

        #region IEnumerable members.

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ICollection members.

        public void CopyTo(Array array, int index)
        {
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(_contents[i], i++);
            }
        }

        public int Count 
        {
            get
            {
                return _count;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this;
            }
        }

        #endregion

        #region IList members.

        public int Add(object? value)
        {
            if (_count < _contents.Length)
            {
                _contents[_count] = value;
                _count++;

                return _count - 1;
            }

            return -1;
        }

        public void Clear()
        {
            _count = 0;
            _contents = Array.Empty<object>();
        }

        public bool Contains(object? value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_contents[i] == value)
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(object? value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_contents[i] == value)
                {
                    return i;
                }
            }
            
            return -1;
        }

        public void Insert(int index, object? value)
        {
            if ((_count + 1 <= _contents.Length) && (index < Count) && (index >= 0))
            {
                _count++;

                for (int i = Count - 1; i > index; i--)
                {
                    _contents[i] = _contents[i - 1];
                }
                _contents[index] = value;
            }
        }

        public void Remove(object? value)
        {
            RemoveAt(IndexOf(value));
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < Count))
            {
                for (int i = index; i < Count - 1; i++)
                {
                    _contents[i] = _contents[i + 1];
                }
                _count--;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return true;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public object? this[int index]
        {
            get => _contents[index];
            set => _contents[index] = value;
        }

        #endregion
        
        public void PrintContents()
        {
            Console.WriteLine($"List has a capacity of {_contents.Length} and currently has {_count} elements.");
            Console.Write("List contents:");
            for (int i = 0; i < Count; i++)
            {
                Console.Write($" {_contents[i]}");
            }
            Console.WriteLine();
        }
    }
}