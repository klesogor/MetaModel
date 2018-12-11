using System;
using System.Collections.Generic;
using System.Text;

namespace MetaModel.Core
{
    public static class ConverterUtils
    {
        private static readonly Dictionary<System.Type, TypeCode> _types = new Dictionary<System.Type, TypeCode> {
            {typeof(int), TypeCode.Int},
            {typeof(float), TypeCode.Float},
            {typeof(double), TypeCode.Double},
            {typeof(DateTime), TypeCode.DateTime},
            {typeof(string), TypeCode.String }
        };

        public static TypeCode GetTypeCode(object obj)
        {
            if (_types.TryGetValue(obj.GetType(), out TypeCode value))
            {
                return value;
            }

            throw new UnsopportedTypeException();
        }

        public static TypeCode GetTypeCode(System.Type type)
        {
            if (_types.TryGetValue(type, out TypeCode value))
            {
                return value;
            }

            throw new UnsopportedTypeException();
        }
    }
}
