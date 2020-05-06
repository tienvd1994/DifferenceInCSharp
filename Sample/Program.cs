using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = "00001";
            string oldOrderStatusText = "oldOrderStatusText";
            string newOrderStatusText = "newOrderStatusText";

            var titleNotifyWeb = $"Thay đổi trạng thái đơn hàng {code} từ \"{oldOrderStatusText}\" thành \"{newOrderStatusText}\"";
            Console.WriteLine(titleNotifyWeb);
            Console.ReadLine();
        }
    }
}
