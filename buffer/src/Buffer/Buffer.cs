using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{

    public class Buffer<T> : IBuffer<T>
    {

        Queue<T> queue = new Queue<T>();

        public Buffer()
        {
        }

        public virtual bool isEmpty
        {
            get
            {
                return queue.Count == 0;
            }
        }

        public virtual void WriteToBuffer(T value)
        {
            queue.Enqueue(value);
        }
        
        public virtual T ReadFromBuffer()
        {
            return queue.Dequeue();
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            foreach (T item in queue)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }

}