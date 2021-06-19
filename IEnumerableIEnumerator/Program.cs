using System;
using System.Collections;

namespace IEnumerableIEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] peopleArray = new Person[3]
            {
                new Person("John", "Smith"),
                new Person("Jim", "Johnson"),
                new Person("Sue", "Rabon"),
            };

            People peopleList = new People(peopleArray);

            foreach (Person p in peopleList)
            {
                Console.WriteLine(p.FirstName + " " + p.LastName);
            }

            Console.ReadLine();
        }
    }

    class Person
    {
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class People /*: IEnumerable*/
    {
        private Person[] _people;

        public People(Person[] pArray)
        {
            _people = new Person[pArray.Length];

            for (int i = 0; i < pArray.Length; i++)
            {
                _people[i] = pArray[i];
            }
        }
        
        // // Implementation for the GetEnumerator method.
        // IEnumerator IEnumerable.GetEnumerator()
        // {
        //     return GetEnumerator();
        // }

        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }

    class PeopleEnum /*: IEnumerator*/
    {
        private Person[] _people;
        
        int position = -1;
        
        public PeopleEnum(Person[] list)
        {
            _people = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _people.Length);
        }

        public void Reset()
        {
            position = -1;
        }
        
        // object IEnumerator.Current
        // {
        //     get
        //     {
        //         return Current;
        //     }
        // }

        public object Current {
            get
            {
                try
                {
                    return _people[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
    }
}