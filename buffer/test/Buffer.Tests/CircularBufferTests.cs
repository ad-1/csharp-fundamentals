using System;
using Xunit;

namespace BufferDataStruct.Tests
{
    public class CircularBufferTests
    {
        
        [Fact]
        public void IsEmptyTest()
        {
            var buffer = new CircularBuffer<int>(5, overwrite: true);
            buffer.Write(1);
            Assert.False(buffer.isEmpty);
            buffer.Read();
            Assert.True(buffer.isEmpty);
        }

        [Fact]
        public void OverwriteTest()
        {
            int capacity = 4;
            var buffer = new CircularBuffer<int>(capacity, overwrite: true);
            for (int i = 1; i < 8; i++)
            {
                buffer.Write(i);
            }
            Assert.Equal(5, buffer.Read());
        }

        [Fact]
        public void DoNotOverwriteTest()
        {
            var buffer = new CircularBuffer<int>(3, overwrite: false);
            for (int i = 6; i < 12; i++)
            {
                buffer.Write(i);
            }
            Assert.Equal(6, buffer.Read());
        }

    }
}
