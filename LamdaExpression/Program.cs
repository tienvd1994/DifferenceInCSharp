using System;

namespace LamdaExpression
{
    internal class Program
    {
        delegate bool IsTeenAger(Student student);
        
        public static void Main(string[] args)
        { 
            Func<Student, bool> isTeenAger = s => s.Age > 12 && s.Age < 20;
        }
    }

    class Student
    {
        public string Id { get; set; }
        public int Age { get; set; }
    }
}