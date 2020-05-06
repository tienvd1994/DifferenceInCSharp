using System;
using System.Collections;
using System.Collections.Generic;

namespace Dictionary_Versus_HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stores Key-Value pairs with the key must be unique.
            IDictionary<int, string> dict = new Dictionary<int, string>();

            // Before add a KeyValuePair into dictionary, using ContainsKey() to check key exist yet.

            // Not exist.
            if (!dict.ContainsKey(1))
            {
                dict.Add(1, "One");
            }

            dict.Add(2, "Two");
            dict.Add(3, "Three");

            // Use the TryGetValue() method to get the value of the key to avoid possible runtime exception.
            if (dict.TryGetValue(4, out string value))
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.WriteLine("Could not find the specified key.");
            }

            /************************************/
            // Store key value pairs of any data type with the key must be unique.
            Hashtable ht = new Hashtable();
            ht.Add(1, "One");
            ht.Add(2, "Two");
            ht.Add(3, "Three");
            ht.Add(4, "Four");
            ht.Add(5, null);
            ht.Add("Fv", "Five");
            ht.Add(8.5F, 8.5);

            // Retrives an item by compare the hashcode of keys. So it is slower Dictionary.
            foreach (DictionaryEntry item in ht)
                Console.WriteLine("key:{0}, value:{1}", item.Key, item.Value);

            var strValue1 = ht["Fv"];

            Console.ReadLine();
        }
    }
}
