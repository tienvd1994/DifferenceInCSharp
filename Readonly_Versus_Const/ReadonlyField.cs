using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readonly_Versus_Const
{
    partial class ReadonlyField
    {
        public int MyProperty { get; set; }

        // Initialize Read Only Fields
        public readonly string name = "Suresh Dasari";
        public readonly string location;
        public readonly int age;

        public ReadonlyField()
        {
            name = "ádfasdf";
            location = "Hyderabad";
            age = 32;
        }

        partial void Method2(string a);
    }
}
