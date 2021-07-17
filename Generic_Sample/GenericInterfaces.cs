﻿using System;

namespace Generic_Sample
{
    public class GenericInterfaces
    {
        interface INonGeneric
        {
            int Day { get; set; }
        }

        interface IMonth<T> : INonGeneric
        {
            string DayName { get; }
        }

        interface IJanuary : IMonth<int>
        {
        }
    }

    //Type parameter T in angle brackets.
    public class GenericList<T> : System.Collections.Generic.IEnumerable<T>
    {
        protected Node head;
        protected Node current = null;

        // Nested class is also generic on T
        protected class Node
        {
            public Node next;
            private T data; //T as private member datatype

            public Node(T t) //T used in non-generic constructor
            {
                next = null;
                data = t;
            }

            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            public T Data //T as return type of property
            {
                get { return data; }
                set { data = value; }
            }
        }

        public GenericList() //constructor
        {
            head = null;
        }

        public void AddHead(T t) //T as method parameter type
        {
            Node n = new Node(t);
            n.Next = head;
            head = n;
        }

        // Implementation of the iterator
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        // IEnumerable<T> inherits from IEnumerable, therefore this class
        // must implement both the generic and non-generic versions of
        // GetEnumerator. In most cases, the non-generic method can
        // simply call the generic method.
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class SortedList<T> : GenericList<T> where T : System.IComparable<T>
    {
        // A simple, unoptimized sort algorithm that
        // orders list elements from lowest to highest:

        public void BubbleSort()
        {
            if (null == head || null == head.Next)
            {
                return;
            }

            bool swapped;

            do
            {
                Node previous = null;
                Node current = head;
                swapped = false;

                while (current.next != null)
                {
                    //  Because we need to call this method, the SortedList
                    //  class is constrained on IComparable<T>
                    if (current.Data.CompareTo(current.next.Data) > 0)
                    {
                        Node tmp = current.next;
                        current.next = current.next.next;
                        tmp.next = current;

                        if (previous == null)
                        {
                            head = tmp;
                        }
                        else
                        {
                            previous.next = tmp;
                        }

                        previous = tmp;
                        swapped = true;
                    }
                    else
                    {
                        previous = current;
                        current = current.next;
                    }
                }
            } while (swapped);
        }
    }

    // A simple class that implements IComparable<T> using itself as the
    // type argument. This is a common design pattern in objects that
    // are stored in generic lists.
    public class Person : System.IComparable<Person>
    {
        string name;
        int age;

        public Person(string s, int i)
        {
            name = s;
            age = i;
        }

        // This will cause list elements to be sorted on age values.
        public int CompareTo(Person p)
        {
            return age - p.age;
        }

        public override string ToString()
        {
            return name + ":" + age;
        }

        // Must implement Equals.
        public bool Equals(Person p)
        {
            return (this.age == p.age);
        }
    }
}