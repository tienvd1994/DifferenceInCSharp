using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class PrivateConstructor
    {
        // private Constructor

        private PrivateConstructor()
        {
            Console.WriteLine("I am Private Constructor");
        }

        //public static string name, location;

        // Default Constructor

        public PrivateConstructor(string a, string b)
        {
        }

        public virtual void Method1()
        {
            Console.WriteLine("PrivateConstructor method");
        }
    }
}
