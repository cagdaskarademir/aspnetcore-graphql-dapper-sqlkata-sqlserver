using System.Linq;

namespace CK.Tutorial.GraphQlApi.Common.Extension
{
    public static class ArrayExtension
    {
        public static bool AnyItem(this string[] value)
        {
            return value!=null && value.Any();
        }
    }
}