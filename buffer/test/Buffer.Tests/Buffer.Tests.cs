using System;
using Xunit;

namespace BufferDataStruct.Tests
{

    public class BufferTests
    {

        [Fact]
        public void IsEmptyTest()
        {
            var buffer = new Buffer<int>();
            buffer.Write(10);
            Assert.False(buffer.isEmpty);
        }

        [Fact]
        public void ReadWithNoDataTest()
        {
            var buffer = new Buffer<int>();
            Assert.Throws<InvalidOperationException>(() => buffer.Read());
        }

    }

}