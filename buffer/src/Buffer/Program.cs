using System;

namespace BufferDataStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Buffer capacity: ");
            var input = Console.ReadLine();
            var capacity = int.Parse(input);
            var buffer = new CircularBuffer<double>(capacity, false);
            ProcessBuffer(capacity, buffer);
        }

        private static void ProcessBuffer(int capacity, IBuffer<double> buffer)
        {
            Console.WriteLine("Write to buffer; Read from buffer");
            while (true)
            {
                var action = Console.ReadLine();
                if (action == "i")
                {
                    EnumerateBuffer(buffer);
                }
                else if (string.IsNullOrEmpty(action))
                {
                    ProcessBuffer(buffer);
                }
                else
                {
                    ProcessInput(buffer, action);
                }
            }
        }

        private static void EnumerateBuffer(IBuffer<double> buffer)
        {
            var items = buffer.AsEnumerableOf<double, int>();
            foreach (int item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void ProcessInput(IBuffer<double> buffer, string value)
        {
            try
            {
                buffer.Write(double.Parse(value));
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            if (!buffer.isEmpty)
            {
                Console.WriteLine(buffer.Read());
            }
            else
            {
                Console.WriteLine("Buffer is empty");
            }
        }
    }
}
