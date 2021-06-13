using System;
using System.Collections.Generic;

namespace Iterators
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // using (var enumerator = GetArrayAnimal().GetEnumerator())
            // {
            //     while (enumerator.MoveNext())
            //     {
            //         var item = enumerator.Current;
            //         
            //         if (item != null) 
            //             Console.WriteLine(item);
            //     }
            // }

            var enumerator = GetArrayAnimal().GetEnumerator();

            try
            {
                while (enumerator.MoveNext())
                {
                    var item = enumerator.Current;
                
                    if (item != null) 
                        Console.WriteLine(item);
                }
            }
            finally
            {
                enumerator.Dispose();
            }
        }

        private static IEnumerable<string> GetArrayAnimal()
        {
            var myList = new List<string> { "Cat", "Goat", "Dog", "Cow" };

            foreach (var item in myList)
            {
                yield return item;
            }
        }
    }
}