using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IEnumerableGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            TestStreamReaderEnumerable();

            Console.ReadLine();
        }
        
        static void TestStreamReaderEnumerable()
        {
            // Check the memory before the iterator is used.
            long memoryBefore = GC.GetTotalMemory(true);
            // Open a file with the StreamReaderEnumerable and check for a string.
            try
            {
                var stringsFound = from line in new StreamReaderEnumerable(@"d:\files\medu_login_information.txt")
                    where line.Contains("string to search for")
                    select line;
                Console.WriteLine("Found: " + stringsFound.Count());
            }
            catch (FileNotFoundException) {
                Console.WriteLine(@"This example requires a file named d:\files\medu_login_information.txt.");
                return;
            }

            // Check the memory after the iterator and output it to the console.
            long memoryAfter = GC.GetTotalMemory(false);
            Console.WriteLine("Memory Used With Iterator = \t"
                              + string.Format(((memoryAfter - memoryBefore) / 1000).ToString(), "n") + "kb");
        }
    }

    class StreamReaderEnumerable : IEnumerable<string>
    {
        private string _filePath;

        public StreamReaderEnumerable(string filePath)
        {
            _filePath = filePath;
        }
        
        public IEnumerator<string> GetEnumerator()
        {
            return new StreamReaderEnumerator(_filePath);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class StreamReaderEnumerator : IEnumerator<string>
    {
        private StreamReader _sr;
        
        public StreamReaderEnumerator(string filePath)
        {
            _sr = new StreamReader(filePath);
        }
        
        private string _current;
        
        public bool MoveNext()
        {
            _current = _sr.ReadLine();

            return _current != null;
        }

        public void Reset()
        {
            _sr.DiscardBufferedData();
            _sr.BaseStream.Seek(0, SeekOrigin.Begin);
            _current = null;
        }

        public string Current {
            get
            {
                if (_sr == null || _current == null)
                {
                    throw new InvalidOperationException();
                }

                return _current;
            }
        }

        object IEnumerator.Current => Current;

        // Implement IDisposable, which is also implemented by IEnumerator(T).
        private bool disposedValue = false;
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // Dispose of managed resources.
                }

                _current = null;
                
                if (_sr != null)
                {
                    _sr.Close();
                    _sr.Dispose();
                }
            }
            
            this.disposedValue = true;
        }

        ~StreamReaderEnumerator()
        {
            Dispose(false);
        }
    }
}