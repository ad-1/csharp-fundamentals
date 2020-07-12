using System.Collections.Generic;

namespace DataStructures
{

    public interface IBuffer<T> : IEnumerable<T>
    {
        bool isEmpty { get; }
        void WriteToBuffer(T value);
        T ReadFromBuffer();
        
    }

}