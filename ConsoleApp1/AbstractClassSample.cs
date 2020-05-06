using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class AbstractClassSample
    {
        // Array of temperature values
        private readonly float[] temps = new float[10] { 56.2F, 56.7F, 56.5F, 56.9F, 58.8F,
                                            61.3F, 65.9F, 62.1F, 59.2F, 57.5F };

        public void TestMethod()
        {
            Console.WriteLine("TestMethod");
        }

        public abstract void TestAbstractMethod();

        // To enable client code to validate input 
        // when accessing your indexer.
        public abstract int Length { get; set; }
        // Indexer declaration.
        // If index is out of range, the temps array will throw the exception.
        public abstract float this[int index] { get; set; }

        public abstract event Action ActionEvent;
    }
}
