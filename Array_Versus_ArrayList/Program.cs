using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Array stores the values or elements of same data type.
/// ArrayList stores value of different data type.
/// Arrays will use fixed length but ArrayList not uses.
/// </summary>
namespace Array_Versus_ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array declaration and Initialization.
            int[] intArray1 = new int[5];
            intArray1[0] = 0;
            intArray1[1] = 1;
            intArray1[2] = 2;
            intArray1[3] = 3;
            intArray1[4] = 4;
            int[] intArray2 = new int[5] { 0, 1, 2, 3, 4 };
            int[] intArray3 = { 0, 1, 2, 3, 4 };

            Student[] customClassArray = new Student[2];

            customClassArray[0] = new Student() { id = 10 };
            customClassArray[1] = new Student() { id = 20 };

            // ArrayList declaration and initialization.
            ArrayList arrayList1 = new ArrayList();
            arrayList1.Add(1);
            arrayList1.Add("String");
            arrayList1.Add(4.5);
            arrayList1.Add(new Student());

            ArrayList arrayList2 = new ArrayList()
            {
                1, "String", 4.5
            };
        }
    }

    class Student
    {
        public int id { get; set; }
    }
}
