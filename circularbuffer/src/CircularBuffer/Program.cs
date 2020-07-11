using System;

namespace CircularBuffer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Buffer capacity: ");
            var input = Console.ReadLine();
            var capacity = int.Parse(input);
            CircularBuffer<double> buffer = new CircularBuffer<double>(capacity);
            ProcessBuffer(capacity, buffer);
        }

        private static void ProcessBuffer(int capacity, CircularBuffer<double> buffer)
        {
            Console.WriteLine("(q) to quit");
            while (true)
            {
                Console.Write("Write to buffer (w); Read from buffer (r): ");
                var action = Console.ReadLine();
                if (action == "q")
                {
                    break;
                }
                else if (action == "w")
                {
                    try
                    {
                        var bufferInput = Console.ReadLine();
                        buffer.WriteToBuffer(double.Parse(bufferInput));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == "r")
                {
                    buffer.ReadFromBuffer();
                }

            }
        }
    }
}
