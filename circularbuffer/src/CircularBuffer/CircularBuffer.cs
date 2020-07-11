using System;

namespace CircularBuffer
{

    public class CircularBuffer<T>
    {

        private T[] buffer;
        private int capacity;
        private int head;
        private int tail;
        private int count;

        public bool IsEmpty
        {
            get
            {
                return (count == 0);
            }
        }

        public bool IsFull
        {
            get
            {
                return (count == capacity);
            }
        }

        public CircularBuffer(int capacity)
        {
            this .capacity = capacity;
            this.buffer = new T[capacity];
            this.head = 0;
            this.tail = 0;
            this.count = 0;
        }

        public void ReadFromBuffer()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Buffer is empty");
                return ;
            }
            Console.WriteLine(buffer[head]);
            Array.Clear(buffer, head, 1);
            head = (head + 1) % capacity;
            count--;
        }

        public void WriteToBuffer(T data)
        {
            if (IsFull)
            {
                Console.WriteLine("Buffer is full");
                DisplayContents();
                return;
            }
            buffer[tail] = data;
            tail = (tail + 1) % capacity;
            count++;
            DisplayContents();
            Console.WriteLine();
        }

        public void DisplayContents()
        {
            foreach (T item in buffer)
            {
                Console.Write(item + " ");
            }
        }

        public void Dump()
        {
            while (!IsEmpty)
            {
                ReadFromBuffer();
            }
        }

    }

}