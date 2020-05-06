using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealedKeyword
{
    public class A
    {
        public virtual void GetInfo()
        {
            Console.WriteLine("Base Class A Method");
        }

        public virtual void Test()
        {
            Console.WriteLine("Base Class A Test Method");
        }

    }

    public class B : A
    {
        public override void GetInfo()
        {
            Console.WriteLine("Derived Class B Method");
        }

        public override void Test()
        {
            Console.WriteLine("Derived Class B Test Method");
        }

    }

    public class C : B
    {
        // Compile time error

        public override void GetInfo()
        {

        }

        public override void Test()
        {
            Console.WriteLine("Derived Class C Test Method");

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            C c = new C();
            c.GetInfo();
            c.Test();
            Console.WriteLine("\nPress Enter Key to Exit..");

            Console.ReadLine();
        }
    }
}
