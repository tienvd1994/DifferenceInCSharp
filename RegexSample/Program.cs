using System;
using System.Text.RegularExpressions;

namespace RegexSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //string pattern = @"\d{6}";
            string pattern = @"\d{6}$";
            string input = "123456a@985123";

            Match m = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
            if (m.Success)
                Console.WriteLine("Found '{0}' at position {1}.", m.Value, m.Index);

            var regex = new Regex(pattern);
            Console.WriteLine(regex.IsMatch(""));

            Console.WriteLine("==================");
            var list = Regex.Split(input, pattern);

            Console.WriteLine("========Regex replace==========");
            Console.WriteLine(Regex.Replace(input, pattern, string.Empty));

            Console.ReadLine();
        }
    }
}
