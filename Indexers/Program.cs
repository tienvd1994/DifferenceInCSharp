using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            // var employee = new Employee
            // {
            //     EmployeeId = 1
            // };
            //
            // Console.WriteLine(employee[0]);

            // var stringCollection = new SampleCollection<string>();
            // stringCollection[0] = "Hello, World";
            // // stringCollection.Add("Hello, World");
            // Console.WriteLine(stringCollection[0]);
            
            Console.ReadLine();
        }
    }

    class SampleCollection<T>/* : ISampleCollection<T>*/
    {
        private T[] arr = new T[100];
        private string[] arr2 = "Hello World".Split();
        // reference to underlying 2D array
        int[, ] data = new int[5, 5];
        
        // private int nextIndex = 0;

        // public void Add(T value)
        // {
        //     if (nextIndex > arr.Length)
        //     {
        //         throw new IndexOutOfRangeException();
        //     }
        //
        //     arr[nextIndex++] = value;
        // }
        
        // Indexer declaration
        [System.Runtime.CompilerServices.IndexerName("TheItem")]
        public T this[int index]
        {
            get => arr[index];
            set => arr[index] = value;
        }
        
        // public int this[int i1, int i2]
        // {
        //     get => data[i1, i2];
        //     set => data[i1, i2] = value;
        // }
        
        // public int this[string i1, string i2]
        // {
        //     get => arr2[index] = value;
        // }
    }

    interface ISampleCollection<T>
    {
        T this[int index]
        {
            get;
            set;
        }
    }
}
