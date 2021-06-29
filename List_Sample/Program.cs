using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace List_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var primeNumbers = new List<int> {1, 3, 5, 7};
            // adding elements using add() method

            primeNumbers.Find(m => m > 2);

            foreach (var primeNumber in primeNumbers)
            {
                Console.WriteLine(primeNumber);
            }

            var numberArray = new int[] {1, 3, 5, 7};

            Test(numberArray);

            Console.ReadLine();
        }

        static void Test(IEnumerable<int> items)
        {
            // items.ForEach(m =>
            // {
            //     
            // });
        }
    }
}