using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try_Catch_Finally_Block
{
    class Program
    {
        

        static void Main(string[] args)
        {
            /*
             * We can only try block without catch block but have to finally block.
             */
            try
            {
                return;
                //throw new Exception();
            }

            /*
             * Multi catch block chỉ thực thi một exception cụ thể.
             * Multi catch block with same exception type is not allowed.
             * Multi catch block is useful when want to handle different exceptions.
             */
            catch (Exception)
            {
                return;
            }
            //catch (Exception )
            //{
            //    throw;
            //}
            /*
             * finally sẽ chạy sau khi đã chạy qua try, catch block. Vì vậy việc đóng kết nối SQL
             * và giải phóng các trình xử lý tệp có thể được xử lý trong finally block.
             * 
             * Finally block vẫn thực thi khi có return hoặc break ở trong try hoặc catch block
             */
            finally
            {
                //return;
            }
        }
    }
}
