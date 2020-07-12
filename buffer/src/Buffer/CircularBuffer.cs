using System;
using System.Collections.Generic;

namespace DataStructures
{

    public class CircularBuffer<T> : Buffer<T>
    {

        private T[] buffer;
        private int capacity;
        private int head;
        private int tail;
        private int count;
        private bool overwrite;

        public CircularBuffer(int capacity, bool overwrite)
        {
            this.capacity = capacity;
            this.buffer = new T[capacity];
            this.head = 0;
            this.tail = 0;
            this.count = 0;
            this.overwrite = overwrite;
        }

        public bool isFull
        {
            get
            {
                return (count == capacity);
            }
        }

        public override bool isEmpty
        {
            get
            {
                return (count == 0);
            }
        }

        public override T ReadFromBuffer()
        {
            var item = buffer[head];
            Array.Clear(buffer, head, 1);
            head = (head + 1) % capacity;
            count--;
            return item;
        }

        public override void WriteToBuffer(T data)
        {
            if (isFull && !overwrite)
            {
                Console.WriteLine("Buffer is full");
                DisplayContents();
                return;
            }
            buffer[tail] = data;
            DisplayContents();
            tail = (tail + 1) % capacity;
            count++;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            foreach(var item in buffer)
            {
                yield return item;
            }
        }

        private void DisplayContents()
        {
            foreach (var item in buffer)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public void Dump()
        {
            while (!isEmpty)
            {
                ReadFromBuffer();
            }
        }

    }

}