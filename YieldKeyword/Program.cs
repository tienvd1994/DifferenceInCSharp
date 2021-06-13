using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace YieldKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            // var stopwatch = new System.Diagnostics.Stopwatch();
            // stopwatch.Start();
            // var list1 = GetList();
            // stopwatch.Stop();
            // var elapsedTicks1 = stopwatch.ElapsedTicks;
            // Console.WriteLine($"elapsedTicks1 {elapsedTicks1}");
            //
            // stopwatch.Restart();
            // var list2 = GetListYield();
            // stopwatch.Stop();
            // var elapsedTicks2 = stopwatch.ElapsedTicks;
            //
            // Console.WriteLine($"elapsedTicks2 {elapsedTicks2}");

            // foreach (int i in Power(2, 2))
            // {
            //     Console.Write("{0} ", i);
            // }
            
            IEnumerator<int> intsEnumerator = GetInts();
            Console.WriteLine("...");
            
            Console.WriteLine(intsEnumerator.Current);

            intsEnumerator.MoveNext();
            Console.WriteLine(intsEnumerator.Current);
            
            Console.WriteLine(intsEnumerator.MoveNext());
            Console.WriteLine(intsEnumerator.Current);
            
            Console.WriteLine(intsEnumerator.MoveNext());
            Console.WriteLine(intsEnumerator.Current);
            
            Console.ReadLine();
        }

        public static IEnumerable<long> GetList()
        {
            var list = new List<long>();
            for (long i = 0; i < 10000000; i++)
                list.Add(i);

            return list;
        }

        public static IEnumerable<long> GetListYield()
        {
            for (long i = 0; i < 10000000; i++)
                yield return i;
        }

        private static IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result *= number;
                yield return result;
            }
        }
        
        static IEnumerator<int> GetInts()
        {
            Console.WriteLine("first");
            yield return 1;

            Console.WriteLine("second");
            yield return 2;
        }
    }
}