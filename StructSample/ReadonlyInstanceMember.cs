using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructSample
{
    /// <summary>
    /// Từ C# 8.0, có thể sử dụng readonly modifier để khai báo một instance member không sửa đổi trạng thái của struct.
    /// Nếu không thể khai báo toàn bộ struct type là readonly, sử dụng modifier để đánh dấu instance members là không sửa đổi trạng thái của struct.
    /// 
    /// Trong một readonly instance member, không thể gán giá trị cho instance fields của struct.
    /// Readonly member có thể call non-readonly member.
    /// </summary>
    struct ReadonlyInstanceMember
    {
        int X, Y;

        // không thể thay đổi giá trị của instance trong readonly method.
        public readonly void ResetX() => X = 0;

        public readonly double Sum()
        {
            return X + Y;
        }

        public double Divide()
        {
            Quantity = 10;

            return Quantity;
        }

        // có thể áp dụng readonly modifier cho các override method được khai báo trong System.Object.
        public readonly override string ToString()
        {
            return $"{X}, {Y}"; ;
        }

        // compiler sẽ khai báo một get accessor của auto-implementd property là readonly.
        public int Quantity { get; set; }

        // properteies and indexers????
        private int _counter;

        public int Count
        {
            get => _counter;
            set => _counter = value;

            //readonly get
            //{
            //    _counter = _counter + 10;

            //    return _counter;
            //}

            //set
            //{
            //    _counter = value;
            //}
        }

        // readonly instance member call readonly member.
        // Compiler sẽ tạo bản sao của structure instance và gọi non-readonly member trên bản sao đó.

    }
}
