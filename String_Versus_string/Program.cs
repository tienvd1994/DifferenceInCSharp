using System;

/// <summary>
/// string is alias for the String class in .NET framework. In fact, every C# types has an equivalent in .NET. As another example, short and int in C# map to Int16 and Int32 in .NET.
/// The only tiny difference is that if you use the String class, you need to import the System namespace on top of file, whereas you don't have to do this when using string keyword.
/// </summary>
namespace String_Versus_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Hello world!";
            String s2 = "Hello world!";

            int n1 = 1;
            Int32 n2 = 2;

            Console.WriteLine("{0} {1}", s1.Equals(s2), s2);
            Console.ReadLine();
        }
    }
}
