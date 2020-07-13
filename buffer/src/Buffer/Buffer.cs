using System;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;

namespace BufferDataStruct
{

    public class Buffer<T> : IBuffer<T>
    {

        protected Queue<T> queue = new Queue<T>();

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

        public virtual void Write(T value)
        {
            queue.Enqueue(value);
        }

        public virtual T Read()
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

        public void ShowContents()
        {
            foreach (var item in this)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

    }

}