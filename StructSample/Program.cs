using System;
using System.Collections.Generic;

namespace StructSample
{
    /*
     * https://www.dotnetperls.com/struct
     * https://kalapos.net/Blog/ShowPost/DotNetConceptOfTheWeek16-RefStruct
     */
    interface IInfo
    {
        public string OriginalString { get; set; }
        public string Target { get; set; }
        public int Time { get; set; }
    }
    
    /// <summary>
    /// Contains information about referrers.
    /// </summary>
    struct ReferrerInfo/* : IInfo*/
    {
        // Gọi khi constrctor có tham số được gọi.
        // static member, property được gán data.
        static ReferrerInfo()
        {
            Console.WriteLine("Static constructor in struct");
        }

        public ReferrerInfo(string originalString, string target, int time)
        {
            OriginalString = originalString;
            Target = target;
            Time = time;
        }

        const int TempData = 10;
        
        public int this[int index]
        {
            get { return TempData; }
            set
            {
                /* set the specified index to value here */
            }
        }
        
        public static int Age = 100;
        // public int Id { get; set; }
        
        public string OriginalString;
        public string Target;
        public int Time;

        public override string ToString()
        {
            return "Person: " + Age;
        }
    };

    struct Coordinate
    {
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        public int x { get; set; }
        public int y { get; set; }

        public override string ToString() => $"({x}, {y})";
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            //var _d = new Dictionary<string, ReferrerInfo>();

            //// New struct:
            //// ReferrerInfo i = new ReferrerInfo();
            //ReferrerInfo i = new ReferrerInfo("cat", "mat", 10) /*default*/;
            //// ReferrerInfo.Age = 10;
            //// Console.Write(i[1]);
            //// i.Id = 1;
            //// i.OriginalString = "cat";
            //// i.Target = "mat";
            //// i.Time = 10;
            ////
            //// _d.Add("info", i);

            //Console.WriteLine(i.OriginalString);
            //Console.WriteLine(i.Target);
            //Console.WriteLine(i.Time);
            //Console.WriteLine(i.ToString());

            #region Default keyword, khi được áp dụng vào struct, làm công việc giống như constructor không tham số ngầm của nó.

            Point point = new Point(1, 2, 30);
            Point pointUseDefault = default;

            new Program().Foo(new Point(1, 2, 30));
            new Program().Foo(default);

            Console.ReadLine();

            #endregion
        }

        public void Foo(Point p)
        {

        }
    }
}