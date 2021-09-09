using System;

namespace Boxing_Unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Boxing

            // int i = 123;
            //
            // /*
            //  * Kết quả của statement này là tạo ojbect reference o trên stack, và tham chiếu
            //  * đến một giá trị của type int trên heap. Giá trị này sẽ copy của giá trị value-type
            //  * được gán cho variable i.
            //  */
            //
            // object o = i;

            #endregion

            #region Unboxing

            // int j = (int)o;

            #endregion
            
            object obj = 3.5; // 3.5 is inferred to be of type double
            // int x = (int) (double) obj; // x is now 3
            
            Console.WriteLine("Hello World!");
        }
    }
}