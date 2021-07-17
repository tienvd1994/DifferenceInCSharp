using System;

namespace FieldSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var classSample = new ClassSample(10, 12);
            
            // classSample._number2 = classSample._number1;
            // Console.WriteLine(classSample._number1);
            // Console.WriteLine(classSample._number2);
            ClassSample._number3 = 666;
            
            Console.WriteLine(ClassSample._number3);
        }
    }
}