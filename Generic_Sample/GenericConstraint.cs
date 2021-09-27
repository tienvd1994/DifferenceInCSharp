using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Generic_Sample
{
    #region Static data là duy nhất cho mỗi closed type.

    class Bob<T>
    {
        public static int Count;
    }

    #endregion

    class GenericConstraint
    {
        public delegate void Delegate1();

        public GenericConstraint()
        {
            #region 1. Base class constraint.

            var baseClassConstraint1 = new BaseClassConstraint<B1>();
            var baseClassConstraint2 = new BaseClassConstraint<BaseClass>();

            #endregion

            #region 2. Interface constraint.

            var interfaceConstraint1 = new InterfaceConstraint<B2>();
            var interfaceConstraint2 = new InterfaceConstraint<IInterface1>();

            #endregion

            #region 3. Reference-type constraint.

            // 3.1. Class
            var referenceTypeConstraintClass = new ReferenceTypeConstraint<BaseClass>();

            // 3.2. Interface
            var referenceTypeConstraintInterface = new ReferenceTypeConstraint<IInterface1>();

            // 3.3. Array type.
            var referenceTypeConstraintArray = new ReferenceTypeConstraint<Array>();

            // 3.4. Delegate
            var referenceTypeConstraintDelegate = new ReferenceTypeConstraint<Delegate1>();

            #endregion

            #region 4. Value-type constraint.

            var structConstraint1 = new StructConstraint<Struct1>();
            var structConstraint2 = new StructConstraint<int>();

            #endregion

            #region 5. Parameterless constructor constraint.

            var parameterlessConstructorConstraint1 = new ParameterlessConstructorConstraint<BaseClass>();

            // Vì tất cả value type đều có parameterless constructor có thể truy cập nên có thể áp dụng cho new() constraint.
            var parameterlessConstructorConstraint2 = new ParameterlessConstructorConstraint<int>();
            //var parameterlessConstructorConstraint3 = new ParameterlessConstructorConstraint<AbstractClass1>();

            #endregion

            #region 6. Unmanaged constraint.

            //var unmanagedConstraint = new UnmanagedConstraint<Struct2>();

            #endregion

            #region 7. Naked type constraint.

            var nakedTypeConstraint = new NakedTypeConstraint<BaseClass>();
            var text = nakedTypeConstraint.Method1<BaseClass>();

            #endregion
        }

        #region 1. Base-class constraint

        /// <summary>
        /// Base-class constraint T phải là hoặc bắt nguồn từ (derive) BaseClass.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class BaseClassConstraint<T> where T : BaseClass
        {
            public StringBuilder Method3<U>(U arg)
            {
                if (arg is StringBuilder)
                {
                    //return (StringBuilder)arg; // Will not compile

                    // Sử dụng toán tử as để chuyển đổi type argument.
                    //return arg as StringBuilder;

                    // Giải pháp khác là cast to object trước, sau đó là type cụ thể.
                    return (StringBuilder)(object)arg;
                }

                return new StringBuilder();
            }
        }

        class BaseClass
        {
        }

        class B1 : BaseClass
        {
            // TODO: Làm sao để tạo class k có public parameterless contructor.
        }

        #endregion

        #region 2. Interface constraint.

        /// <summary>
        /// Interface constraint T phải là hoặc implement từ IInterface1.
        /// Multiple interface constraints có thể được chỉ định.
        /// Constraint inteface cũng có thể là generic.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class InterfaceConstraint<T> where T : IInterface1, IInterface2
        {

        }

        class B2 : IInterface1
        {

        }

        interface IInterface1 : IInterface2
        {

        }

        interface IInterface2
        {

        }

        #endregion

        #region 3. Reference-type constraint.

        /// <summary>
        /// T (type argument) phải là reference type.
        /// Trong nullable context từ C# 8 trở đi, T phải là non-nullable reference type.
        /// Constraint này áp dụng cho bất kỳ class, interface, delegate, array type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class ReferenceTypeConstraint<T> where T : class
        {

        }

        #endregion

        #region 4. Struct constraint.

        /// <summary>
        /// T (type argument) phải là non-nullable value type.
        /// Không thể kết hợp struct constraint với unmanaged constraint. (Tại sao?)
        /// Bởi vì tất cả các value types có constructor không có tham số có thể truy cập (public constructor parameterless), 
        /// nên struct constraint bao hàm (imply) cả new() constraint và không thể kết hợp với new() constraint.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class StructConstraint<T> where T : struct
        {

        }

        struct Struct1
        {

        }

        #endregion

        #region 5. Parameterless constructor constraint.

        /// <summary>
        /// T (type argument) phải có một public parameterless constructor.
        /// Khi sử dụng với các constraint khác, new() constraint phải được chỉ định ở cuối cùng.
        /// new() constraint không thể kết hợp với struct và unmanaged constraints.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class ParameterlessConstructorConstraint<T> where T : new()
        {

        }

        /// <summary>
        /// abstract class không thể khởi tạo nên k có default constructor (public parameterless constructor).
        /// </summary>
        abstract class AbstractClass1
        {

        }

        #endregion

        #region 6. Unmanaged constraint

        /// <summary>
        /// Bắt đầu từ C# 7.3, có thể sử dụng unmanaged constraint để chỉ định type parameter phải là một non-nullable unmanaged type.
        /// Không thể kết hợp với struct constraint, bởi vì unmanaged constraint bao hàm struct constraint.
        /// Vì struct constraint bao hàm new() constraint, nên unmanaged constraint không thể kết hợp với new() constraint.
        /// _____________
        /// Unmanaged constraint là một phiên bản mạnh mẽ hơn của struct constraint: T phải là simple value types hoặc struct không có bất kỳ reference type nào.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class UnmanagedConstraint<T> where T : unmanaged
        {

        }

        struct Struct2
        {

            //public Struct2(double x, double y)
            //{
            //    X = x;
            //    Y = y;
            //}

            private string _x;

            public double X { get; }
            public double Y { get; }

            public override string ToString() => $"({X}, {Y})";
        }

        #endregion

        #region 7. Naked type constraint

        /// <summary>
        /// Type argummet cung cấp cho U phải là hoặc dẫn xuất từ argument cung cấp cho T.
        /// Trong nullable context, nếu U là non-nullable reference type thì T phải là non-nullable reference type. Nếu U là nullable reference type thì T có thể là nullable hoặc non-nullable reference type.
        /// (Struct không thể kế thừa từ struct khác).
        /// _____________
        /// Một type parameter phải là hoặc dẫn xuất từ type parameter khác.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class NakedTypeConstraint<T> where T : class
        {
            public string Method1<U>() where U : T
            {
                return string.Empty;
            }
        }

        #endregion

        #region 8.Notnull constraint.

        /// <summary>
        /// Từ C# 8, có thể sử dụng notnull constraint để chỉ định type parameter phải là non-null type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class NotnullConstraint<T> /*where T : notnull*/
        {

        }

        #endregion

        #region 9. Default constraint

        #endregion

        #region Self-Referencing generic declarations.

        public interface IEquatable<T>
        {
            bool Equals(T obj);
        }

        class Balloon : IEquatable<Balloon>
        {
            public bool Equals(Balloon obj)
            {
                throw new NotImplementedException();
            }
        }

        class Bar<T> where T : Bar<T>
        {

        }

        class Foo<T> where T : IComparable<T>
        {

        }

        #endregion
    }
}