using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASAN.Common
{
    public static class HelperMethods
    {
        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }
    }
}