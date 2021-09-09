using System;
using Assembly1;

namespace AccessModifiersSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(InternalBaseClass.x);
        }
    }

    class DerivedClass : BaseClass
    {
        public DerivedClass()
        {
            Id = 10;
            Age = 100;
            // Name = "Jones";
        }

        void TestMethod()
        {
            var derivedObject = new DerivedClass();
            var baseObject = new BaseClass();

            // Because Id can only be accessed by classess derived from BaseClass.
            // Có thể sử dụng InternalsVisibleTo để cho access protected internal members.
            // baseObject.Id = 10;
            
            // Ok. Because this class derives from BaseClass.
            derivedObject.Id = 100;
        }
    }
}