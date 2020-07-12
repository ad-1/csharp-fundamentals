using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Buffer capacity: ");
            var input = Console.ReadLine();
            var capacity = int.Parse(input);
            CircularBuffer<double> buffer = new CircularBuffer<double>(capacity, true);
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
            foreach (double item in buffer)
            {
                Console.WriteLine(item);
            }
        }

        private static void ProcessInput(IBuffer<double> buffer, string value)
        {
            try
            {
                buffer.WriteToBuffer(double.Parse(value));
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
                Console.WriteLine(buffer.ReadFromBuffer());
            }
            else
            {
                Console.WriteLine("Buffer is empty");
            }
        }
    }
}
