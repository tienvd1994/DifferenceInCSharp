using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructSample
{
    struct NormalStruct : IInterface1
    {
        int x;
        int y;

        // Tại sao.
        RefStruct _refStruct;
    }

    class Class1
    {
        // instance của ref struct được phần bổ trên stack.
        // ref struct không thể là kiểu khai báo của field trong class hoặc non-ref struct (vì có thể dẫn đễn boxing).
        RefStruct _refStruct;

        void Method1()
        {
            // Nếu value type xuất hiện như một parameter hoặc local variable, thì nó sẽ nằm trên stack.
            NormalStruct normalStruct = new NormalStruct(); // làm sao biết nằm trên stack.

            // ref struct variable.
            var refStruct = new RefStruct();

            // ref struct không thể là element type của array.
            var points = new RefStruct[100];
            var normalStructs = new NormalStruct[100];

            // boxing to IInterface1.
            IInterface1 boxingStruct = normalStruct;

            // unboxing to NormalStruct
            var unboxingStruct = (NormalStruct)boxingStruct;

            // ref struct không thể là type argument.
            var genericClass = new GenericClass<RefStruct>();

            // ref struct variable không thể sử dụng trong vòng lặp.

            // biến ref variable không thể ghi lại (capture) bởi một lambda expression hoặc local function.
            Func<int, int> square = x => x * refStruct;

            void localFunction()
            {
                var sum = 10 * refStruct;
            }
        }

        // ref struct variable không thể sử dụng trong async method.
        async Task AsyncMethod()
        {
            var refStruct = new RefStruct();
        }

        // Có thể sử dụng trong synchronouns method (return Task hoặc Task<TResult>).
        Task SyncMethod()
        {
            var refStruct = new RefStruct();

            return Task.FromResult(0);
        }
    }

    class Class2
    {
        // Nếu value type xuất hiện như một field trong một class thì nó sẽ nằm trên heap bởi vì class nằm trên heap.
        NormalStruct normalStruct; // làm sao để biết nó nằm trên heap.
    }

    /// <summary>
    /// ref struct không thể implement interface (bởi vì có thể dẫn đến (result in) boxing -> object).
    /// </summary>
    ref struct RefStruct : IInterface1
    {
        int x;
        int y;

    }

    // Từ C# 7.2 có thể thêm ref modifier khi khai báo struct để đảm bảo rằng nó chỉ có thể nằm trên stack.
    class Class3
    {
        RefStruct RefStruct;
    }

    interface IInterface1
    {

    }

    class GenericClass<T> where T : struct
    {

    }
}
