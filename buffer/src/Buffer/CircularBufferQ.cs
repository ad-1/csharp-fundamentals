using System;

namespace BufferDataStruct
{

    public class CircularBufferQ<T> : Buffer<T>
    {

        int capacity;

        public CircularBufferQ(int capacity = 10)
        {
            this.capacity = capacity;
        }

        public override void Write(T value)
        {
            base.Write(value);
            if (IsFull)
            {
                queue.Dequeue();
            }
            base.ShowContents();
        }

        public bool IsFull
        {
            get
            {
                return base.queue.Count == capacity;
            }
        }

    }

}
