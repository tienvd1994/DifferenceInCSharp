using System;

namespace Readonly_Versus_Const
{
    public class Customer
    {
        public static readonly uint timeStamp = (uint)DateTime.Now.Ticks;
    }
}