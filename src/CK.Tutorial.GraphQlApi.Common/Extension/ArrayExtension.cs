using System;
using System.Linq;

namespace CK.Tutorial.GraphQlApi.Common.Extension
{
    public static class ArrayExtension
    {
        public static bool AnyItem(this string[] value)
        {
            return value != null && value.Any();
        }

        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        public static bool IsTrue(this bool? value)
        {
            return value != null && value == true;
        }
        
        public static byte ConvertToByte(this bool? value)
        {
            if (value ==null )
            {
                throw new ArgumentException("Boolean Item must be convertible");
            }

            return (byte) (value.Value ? 1 : 0);
        }
    }
}