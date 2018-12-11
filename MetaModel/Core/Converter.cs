using System;
using System.Collections.Generic;
using System.Text;

namespace MetaModel.Core
{
    //pure functions, no side effects. Even better than regular classes OuO
    public static class Converter
    {
        public static string StringFromObject(object value)
        {
            switch (ConverterUtils.GetTypeCode(value))
            {
                case TypeCode.Int: return IntToString((int)value);
                case TypeCode.Float: return FloatToString((float)value);
                case TypeCode.Double: return DoubleToString((double)value);
                case TypeCode.DateTime: return DateTimeToString((DateTime)value);
                case TypeCode.String: return (string)value;

                default: throw new UnsopportedTypeException();
            }
        }

        public static object ObjectFromString(System.Type type, string val)
        {
            switch (ConverterUtils.GetTypeCode(type))
            {
                case TypeCode.Int: return Convert.ToInt32(val);
                case TypeCode.Float: return Convert.ToSingle(val);
                case TypeCode.Double: return Convert.ToDouble(val);
                case TypeCode.DateTime: return new DateTime(long.Parse(val));
                case TypeCode.String: return val;

                default: throw new UnsopportedTypeException();
            }
        }


        public static string IntToString(int value)
        {
            return value.ToString();
        }

        public static string FloatToString(float value)
        {
            return value.ToString();
        }
        public static string DoubleToString(double value)
        {
            return value.ToString();
        }
        public static string DateTimeToString(DateTime value)
        {
            return value.Ticks.ToString();
        }
    }
}
