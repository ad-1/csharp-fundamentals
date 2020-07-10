using System;

namespace CircularBuffer
{

    public class CircularBuffer<T>
    {

        private T[] buffer;
        private int capacity;
        private int head;
        private int tail;


        public CircularBuffer(int capacity)
        {
            this .capacity = capacity;
            this.buffer = new T[capacity];
            this.head = 0;
            this.tail = 0;
        }

        public T ReadBuffer()
        {
            if (tail == capacity) tail = 0;
            var read = buffer[tail];
            tail++;
            return read;
        }

        public void WriteBuffer(T data)
        {
            buffer[head] = data;
            head = (head + 1) % capacity;
        }

    }

}