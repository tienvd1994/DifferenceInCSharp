using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            // The following comment line will throw an error because constructor is inaccessible

            //PrivateConstructor user = new PrivateConstructor();



            // Only Default constructor with parameters will invoke

            PrivateConstructor user1 = new PrivateConstructor("Suresh Dasari", "Hyderabad");

            // Console.WriteLine(PrivateConstructor.name + ", " + PrivateConstructor.location);

            Console.WriteLine("\nPress Enter Key to Exit..");

            Console.ReadLine();
        }
    }
}
