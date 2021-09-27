using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // int[] arr = { 0, 1, 2, 3, 4 };
            // List<int> list = new List<int>();
            //
            // for (int x = 5; x < 10; x++)
            // {
            //     list.Add(x);
            // }
            //
            // ProcessItems<int>(arr);
            // ProcessItems(list);

            //var sampleClass = new SampleClass<int>();

            //decimal a = 1;
            //decimal b = 2;

            //sampleClass.Swap<decimal>(ref a, ref b);

            // typeof and unbound generic type.
            var typeOfAndUnbound = new TypeOfAndUnbound();

            // Static data.
            Console.WriteLine(++Bob<int>.Count);
            Console.WriteLine(++Bob<int>.Count);
            Console.WriteLine(++Bob<string>.Count);
            Console.WriteLine(++Bob<object>.Count);

            Console.ReadLine();
        }

        #region Generic method

        static void TestSwap()
        {
            int a = 1;
            decimal b = 2;
            
            // complier sẽ suy luận type parameter dựa trên đối số truyền vào method.
            Swap<int, decimal>(ref a, ref b);
            Console.WriteLine(a + " " + b);
        }
        
        static void Swap<T, U>(ref T lhs, ref U rhs)
        {
            // T temp;
            // temp = lhs;
            // lhs = rhs;
            // rhs = temp;
        }

        #endregion
        
        #region generic and array
    
        static void ProcessItems<T>(IList<T> coll)
        {
            Console.WriteLine("IsReadOnly returns {0} for this collection", coll.IsReadOnly);
            
            // The following statement causes a run-time exceptopm for the array, but not for List.
            // coll.RemoveAt(4);

            foreach (T item in coll)
            {
                Console.Write(item + " ");
            }
            
            Console.WriteLine();
        }
        
        #endregion
    }

    class SampleClass<T>
    {
        public SampleClass()
        {
            Console.WriteLine(typeof(T));
        }
        
        // warning [CS0693] Type parameter 'T' has the same name as the type parameter from outer type 'SampleClass<T>'
        public void Swap<T>(ref T lhs, ref T rhs) where T : IComparable<T>
        {
            Console.WriteLine(typeof(T));
        }
    }

    class BaseNode { }
    class BaseNodeGeneric<T> { }

    // concrete type.
    class NodeConcrete<T> : BaseNode { }

    // closed constructed type.
    class NodeClosed<T> : BaseNodeGeneric<int> { }

    // open constructed type.
    class NodeOpen<T> : BaseNodeGeneric<T> { }
    
    // non-generic, in other words, concrete classes có thể kế thừa từ closed constructed type base class.
    class Node1 : BaseNodeGeneric<int> { }

    // class Node2 : BaseNodeGeneric<T> { }
    
    /*
     * Generic classes kế thừa từ open constructed types phải cung cấp type arguments cho bất kỳ base class nào
     * mà không được chia sẻ bởi inheriting class.
     */
    class BaseNodeMultiple<T, U> { }

    // không được chia sẻ bởi inheriting class nên phải cung cấp (int).
    class Node4<T> : BaseNodeMultiple<T, int> { }

    class Node5<T, U> : BaseNodeMultiple<T, U> { }
    
    // class Node6<T> : BaseNodeMultiple<T, U> { }
}
