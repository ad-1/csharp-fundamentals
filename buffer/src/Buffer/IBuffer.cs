using System.Collections.Generic;

namespace BufferDataStruct
{

    public interface IBuffer<T> : IEnumerable<T>
    {
        bool isEmpty { get; }
        void Write(T value);
        T Read();
        void ShowContents();

    }

}