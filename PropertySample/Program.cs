using System;

namespace PropertySample
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("James");
            // person.Age = 10;
            //
            // Console.WriteLine(person.Name);
            
            // Person.Address = "Phú Thọ";
            //
            // Console.WriteLine(Person.Address);
            Console.WriteLine(string.IsNullOrEmpty(person.day));
        }
    }

    class BaseClass
    {
        
    }

    class Person
    {
        public string day;
        
        public Person(string name)
        {
            this.Name = name;
        }
        
        private string _name;  // the name field
        public string Name    // the Name property
        {
            get => _name;
            init => _name = value;
        }

        public int Age
        {
            get;
            internal set;
        }

        public static string Address
        {
            get;
            set;
        } = "Hà Nội";
    }
}