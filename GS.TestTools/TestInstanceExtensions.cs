using System;
using System.Linq.Expressions;
using System.Reflection;

namespace GS.TestTools
{
    public static class TestInstanceExtensions
    {
        public static InstanceT SetProtectedProperty<InstanceT, ValueT>(this InstanceT instance, Expression<Func<InstanceT, ValueT>> expression, ValueT value)
        {
            var propertyInfo = GetPropertyInfo(expression);

            var setMethod = propertyInfo.GetSetMethod(true);

            setMethod.Invoke(instance, new object[] {value});

            return instance;
        }

        public static PropertyInfo GetPropertyInfo<InstanceT, ValueT>(this Expression<Func<InstanceT, ValueT>> expression)
        {
            var type = typeof (InstanceT);

            var member = expression.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    expression));

            var propertyInfo = member.Member as PropertyInfo;
            if (propertyInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    expression));

            if (type != propertyInfo.ReflectedType &&
                !type.IsSubclassOf(propertyInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expresion '{0}' refers to a property that is not from type {1}.",
                    expression, type));

            return propertyInfo;
        }
    }
}
