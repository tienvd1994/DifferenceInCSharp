using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Sample
{
    class C<T> 
    {
        public C()
        {
            Console.WriteLine(default(C<T>));
        }
    }

    class DefaultGenericValue
    {
        public DefaultGenericValue()
        {
        }
    }
}
