using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee();
            employee.EmployeeId = 1;

            Console.WriteLine(employee[0]);
            Console.ReadLine();
        }
    }
}
