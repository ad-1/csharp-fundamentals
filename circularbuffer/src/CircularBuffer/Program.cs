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
            Console.WriteLine("================================");
            while (true)
            {
                Console.Write("Write to buffer: ");
                var bufferInput = Console.ReadLine();
                if (bufferInput == "q")
                {
                    break;
                }
                try
                {
                    buffer.WriteBuffer(double.Parse(bufferInput));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("================================");
            Console.WriteLine("Read buffer: ");
            for (int i = 0; i < capacity; i++)
            {
                Console.WriteLine(buffer.ReadBuffer());
            }
            Console.WriteLine("================================");
        }
    }
}
