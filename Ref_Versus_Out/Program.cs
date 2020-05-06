using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Ref và Out được sử dụng để return một hoặc nhiều giá trị từ method.
/// Ref khi khởi tạo phải gán giá trị cho biến, trong hàm có thể không gán hoặc khởi tạo giá trị cho tham số, phải có từ khóa ref trước tham số của method.
/// Out khi khỏi tạo có thẻ gán hoặc k gán giá trị cho biến, trong hàm bắt buộc phải gán hoặc khỏi tạo giá trị cho tham số, phải có từ khóa out trước tham số của method.
/// </summary>
namespace Ref_Versus_Out
{
    class Program
    {
        static void Main(string[] args)
        {
            int test;
            int period; // Used as out parameter.

            TestOut(20, out period);
            TestRef(20, ref test);
            //TestNormal(20, period);

            Console.WriteLine(period);
            Console.ReadLine();
        }

        /// <summary>
        /// Không truyền vào biến hằng vì hằng số không thay đổi.
        /// Kết thúc hàm giá trị của tham số sẽ thay đổi.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="period"></param>
        static void TestOut(int value, out int period)
        {
            period = value;
        }

        /// <summary>
        /// Không truyền vào biến hằng vì hằng số không thay đổi.
        /// Kết thúc hàm giá trị của tham số sẽ thay đổi.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="period"></param>
        static void TestRef(int value, ref int period)
        {
            //period = value;
        }

        static void TestNormal(int value, int period)
        {
            period = value;
        }
    }
}
