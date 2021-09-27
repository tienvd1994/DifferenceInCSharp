using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructSample
{
    /// <summary>
    /// Áp dụng readonly modifier để khai báo struct là bất biến (immutable).
    /// Tất cả data member của readonly struct phải là readonly.
    /// 
    /// Bất kỳ khai báo field đều phải có readonly modifier.
    /// Bất kỳ property, kể cả auto-implemented phải có readonly modifier.
    /// </summary>
    readonly struct ReadOnlyStruct
    {
        readonly int x;
        readonly int y;

        public ReadOnlyStruct(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{x}-{y}";
        }
    }
}
