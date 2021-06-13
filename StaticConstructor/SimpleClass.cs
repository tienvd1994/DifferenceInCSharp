using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticConstructor
{
    static class SimpleClass
    {
        // Static variable that must be initialized at run time.
        public static readonly long baseline;
        
        // Static constructor is called at most one time, before any
        // instance constructor is invoked or member is accessed.
        static SimpleClass()
        {
            // baseline = DateTime.Now.Ticks;
            Console.WriteLine("static constructor");
        }
    }
}
