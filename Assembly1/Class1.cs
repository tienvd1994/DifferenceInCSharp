using System;
using System.Runtime.CompilerServices;

// [assembly: InternalsVisibleTo("AccessModifiersSample")]
namespace Assembly1
{
    public class InternalBaseClass
    {
        // internal static int x = 10;

        private void Test()
        {
            var baseObject = new BaseClass();
            baseObject.Id = 10;
            
            // Console.WriteLine(x);
        }
    }

    public class BaseClass
    {
        protected internal int Id = 0;
        private protected int Age = 10;
        internal string Name = "Smith";

        public BaseClass()
        {
            Console.WriteLine(Age);
        }
    }

    public class DerivedClass : BaseClass
    {
        public DerivedClass()
        {
            base.Id = 100;
            Age = 100;
        }
    }
}