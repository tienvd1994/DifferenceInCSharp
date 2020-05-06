using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var deriveClass = new DeriveClass();
    //        var structKeyword = new StructKeyword();

    //        Console.ReadLine();
    //    }
    //}

    //sealed class SealedClass : ITest, TemperatureConverter
    //{
    //    public int x;
    //    public int y;

    //    public void Method1()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //class SealedTest2
    //{
    //    public int x;
    //    public int y;
    //}

    //interface ITest
    //{
    //    void Method1();
    //}

    //static class TemperatureConverter
    //{
    //    public static int z;
    //    public static int yd;

    //}

    using System;

    class Example
    {
        public Example()
        {
            // Use private setter in the constructor.
            Id = new Random().Next();
        }
        public int Id
        {
            get;
            private set;
        }

        public void Method1()
        {
            this.Id = 1;
        }
    }

    class Program
    {
        static void Main()
        {
            Example example = new Example();
            //example.Id = 3;
            //Console.WriteLine(example.Id);
        }
    }

}
