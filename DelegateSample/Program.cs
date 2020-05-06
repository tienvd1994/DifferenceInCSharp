using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateSample
{
    class Program
    {
        delegate int SampleDelegate(string data);

        static void Main()
        {
            SampleDelegate counter = new SampleDelegate(CountCharacters);
            SampleDelegate parser = new SampleDelegate(Parse);

            AsyncCallback callback = new AsyncCallback(DisplayResult);

            counter.BeginInvoke("hello", callback, "Counter returned {0}");
            parser.BeginInvoke("10", callback, "Parser returned {0}");

            Console.WriteLine("Main thread continuing");

            Thread.Sleep(3000);
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        static void DisplayResult(IAsyncResult result)
        {
            string format = (string)result.AsyncState;
            AsyncResult delegateResult = (AsyncResult)result;
            SampleDelegate delegateInstance = (SampleDelegate)delegateResult.AsyncDelegate;

            Console.WriteLine(format, delegateInstance.EndInvoke(result));
        }

        static int CountCharacters(string text)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Counting characters in {0}", text);
            return text.Length;
        }

        static int Parse(string text)
        {
            Thread.Sleep(100);
            Console.WriteLine("Parsing text {0}", text);
            return int.Parse(text);
        }

        public int Method1(string input)
        {
            //... do something
            return 0;
        }

        public void Method2(string input, int test)
        {
            var a = Method1("123");
        }

        public void Method2(string input, int test, int param2)
        {
            var a = Method1("123");
        }

        public bool RunTheMethod(Action<string, int> myMethodName)
        {
            //... do stuff
            myMethodName("My String", 2);
            //... do more stuff
            return true;
        }

        public bool Test() 
        {
            return RunTheMethod(Method2);
        }
    }
}
