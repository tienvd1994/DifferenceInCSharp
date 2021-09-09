using System;

namespace Generic_Sample
{
    class A<T> { }
    class A<T1, T2> { }

    class B<T> 
    { 
        void X() 
        {
            // Có thể chỉ định open type (là closed type ở runtime)
            Type t = typeof(T);
        }
    }

    class TypeOfAndUnbound
    {
        public TypeOfAndUnbound()
        {
            // Cách duy nhất để chỉ định một unbound generic type trong c# là qua toán tử typeof
            Type a1 = typeof(A<>);
            Type a2 = typeof(A<,>);

            // Có thể sử dụng toán tử typeof để chỉ định closed type.
            Type a3 = typeof(A<int, int>);

            Console.WriteLine(a1);
            Console.WriteLine(a2);
            Console.WriteLine(a3);
        }
    }
}
