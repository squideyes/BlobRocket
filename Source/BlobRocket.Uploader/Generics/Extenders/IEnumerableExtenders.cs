using System.Collections.Generic;
using System.Linq;

namespace BlobRocket.Uploader.Generics
{
    public static partial class Extenders
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> items)
        {
            return (items == null) || (!items.Any());
        }
    }
}
