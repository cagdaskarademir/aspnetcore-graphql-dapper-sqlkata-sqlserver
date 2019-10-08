using System;

namespace CK.Tutorial.GraphQlApi.Common.Extension
{
    public static class PrimitiveExtension
    {
        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        public static bool IsNotNull(this bool? value)
        {
            return value != null;
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