using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilder_Versus_String
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder?view=netframework-4.6.1
    /// </summary>
    class Program
    {
        unsafe static void Main(string[] args)
        {
            /*
             * String is immutable. Immutable means one we create string object we cannot modify.
             * - Create a new string instance instead of changing the old string.
             */


            // Create new stopwatch
            Stopwatch stopwatch_String = new Stopwatch();

            // Begin timing
            stopwatch_String.Start();

            string myString = "Difference";
            myString += "between";
            myString += "String";
            myString += "and";
            myString += "StringBuilder";

            stopwatch_String.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch_String.Elapsed);

            /*
             * StringBuilder is mutable it means once we create string builder object 
             * we can perform any operation like insert, replace, remove, append 
             * without creating new instance for every time.
             * - Keep and appending in the same instance.
             */

            // Create new stopwatch
            Stopwatch stopwatch_StringBuilder = new Stopwatch();

            // Begin timing
            stopwatch_StringBuilder.Start();

            StringBuilder myStringBuilder = new StringBuilder();
            myStringBuilder.Append(" between");
            myStringBuilder.Append(" String");
            myStringBuilder.Append(" and");
            myStringBuilder.Append(" StringBuilder");

            stopwatch_StringBuilder.Stop();
            Console.WriteLine("Time elapsed: {0}", stopwatch_StringBuilder.Elapsed);

            Console.ReadLine();

            string value = "This is the first sentence" + ".";

            fixed (char* start = value)
            {
                value = string.Concat(value, "This is the second sentence. ");
                fixed (char* current = value)
                {
                    Console.WriteLine(start == current);
                }

                //var value1 = value;
                //fixed (char* current = value1)
                //{
                //    Console.WriteLine(start == current);
                //}
            }

            Console.ReadLine();
        }
    }
}
