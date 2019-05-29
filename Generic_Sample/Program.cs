using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    /// <summary>
    /// Generics in C# is used to make the code reusable and decreases the code redundancy and increases the performance and type safety.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MyGenericClass<T>
    {
        private T genericMemberVariable;

        public MyGenericClass(T value)
        {
            genericMemberVariable = value;
        }

        public T genericMethod(T genericParameter)
        {
            Console.WriteLine("Parameter type: {0}, value: {1}", typeof(T).ToString(), genericParameter);
            Console.WriteLine("Return type: {0}, value: {1}", typeof(T).ToString(), genericMemberVariable);

            return genericMemberVariable;
        }

        public T genericProperty { get; set; }
    }
}
