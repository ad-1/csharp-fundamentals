using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Linq
{
    public static class LinqExtensions
    {

        public static int Count<T>(this IEnumerable<T> sequence)
        {
            var count = 0;
            foreach(var item in sequence)
            {
                count++;
            }
            return count;
        }

    }
}
