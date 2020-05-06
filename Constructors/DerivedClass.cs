using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    class DerivedClass : PrivateConstructor
    {
        public DerivedClass(string a, string b) : base(a, b)
        {
        }
    }
}
