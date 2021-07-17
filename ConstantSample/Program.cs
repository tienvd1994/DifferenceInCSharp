using System;

namespace ConstantSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // const int value = 10;
            // value = 10;
            
            // int size = 5;
            const int value = 10 + Customer.AGE;
            Console.WriteLine("Hello World!");
            Console.WriteLine(NopVersion.FULL_VERSION);
        }
    }

    class Customer
    {
        public const int AGE = 10;
    }
    
    public class NopVersion
    {
        public int Age { get; set; }
        
        /// <summary>
        /// Gets the major store version
        /// </summary>
        public const string CURRENT_VERSION = "4.50";

        /// <summary>
        /// Gets the minor store version
        /// </summary>
        public const string MINOR_VERSION = "0";
        
        /// <summary>
        /// Gets the full store version
        /// </summary>
        public const string FULL_VERSION = CURRENT_VERSION + "." + MINOR_VERSION;
    }
}