using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace BufferDataStruct
{

    public static class BufferExtensions
    {

        public static IEnumerable<TOutput> AsEnumerableOf<T, TOutput>(
            this IBuffer<T> buffer
        )
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            foreach(T item in buffer)
            {
                var result = converter.ConvertTo(item, typeof(TOutput));
                yield return (TOutput)result;
            }
        }

    }

}