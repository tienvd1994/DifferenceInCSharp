using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DeriveClass : AbstractClassSample
    {
        public DeriveClass()
        {
            base.TestMethod();
        }

        public override float this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int Length { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override event Action ActionEvent;

        public override void TestAbstractMethod()
        {
            throw new NotImplementedException();
        }
    }
}
