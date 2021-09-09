using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueType_Versus_ReferenceType
{
    class Program
    {
        // https://www.tutlane.com/tutorial/csharp/csharp-value-type-and-reference-type-with-examples
        static void Main(string[] args)
        {
            /*
             * Value type:
             * - data type: bool, byte, char, decimal, double, enum, 
             *   float, int, long, sbyte, short, struct, uint, ulong, ushort.
             * - Stored on stack.
             * - Contains actual value.
             * - Can not contain the value null.
             * 
             * Reference type:
             * - data type: String, Class, Delegates, Array, Interface, Object, Dynamic.
             * - Stored on heap.
             * - Contains reference to a value(in stack).
             * - Can contain the value null.
             */

            // TODO: example value type and reference type.

            Panda p1 = new Panda("Pan Dee");
            Panda p2 = new Panda("Pan Dah");
            Console.WriteLine(p1.Name); // Pan Dee
            Console.WriteLine(p2.Name); // Pan Dah
            Console.WriteLine(Panda.Population); // 2
            Console.ReadLine();
        }
    }

    public class Panda
    {
        public string Name; // Instance field
        public static int Population; // Static field
        public Panda(string n) // Constructor
        {
            Name = n; // Assign the instance field
            Population = Population + 1; // Increment the static Population field
        }
    }
}
