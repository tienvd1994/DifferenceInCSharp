using System;
using System.Collections;
using System.Collections.Generic;

namespace Generic_Sample
{
    class GenericConstraint
    {
        public delegate void Delegate1();

        public GenericConstraint()
        {
            #region 1. base class constraint.

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
            var parameterlessConstructorConstraint3 = new ParameterlessConstructorConstraint<StaticClass1>();

            #endregion
        }

        #region Base-class constraint

        /// <summary>
        /// Base-class constraint T phải là hoặc bắt nguồn từ (derive) BaseClass.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class BaseClassConstraint<T> where T : BaseClass
        {

        }

        class BaseClass
        {

        }

        class B1 : BaseClass
        {

        }

        #endregion

        #region Interface constraint.

        /// <summary>
        /// Interface constraint T phải là hoặc implement từ IInterface1.
        /// Multiple interface constraints có thể được chỉ định.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        class InterfaceConstraint<T> where T : IInterface1, IInterface2
        {

        }

        class B2 : IInterface1
        {

        }

        interface IInterface1 :  IInterface2
        {

        }

        interface IInterface2
        {

        }

        #endregion

        #region Reference-type constraint.

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

        #region Struct constraint.

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

        #region Parameterless constructor constraint.

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
    }
}
