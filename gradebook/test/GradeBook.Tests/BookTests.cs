using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {

        private float[] exactGrades = new float[] {88.5F, 23.5F, 66.2F, 55.1F, 73.8F};
        private Statistics exactStats = new Statistics(high: 88.5F, low: 23.5F, average: 61.42F);

        [Fact]
        public void StatisticsTest()
        {
            // arange
            Book book = new Book("", new float[] {88.5F, 23.5F, 66.2F, 55.1F, 73.8F});
            // act
            Statistics stats = book.GetStatistics();
            // assert
            Assert.Equal(exactStats.high, stats.high, 2);
            Assert.Equal(exactStats.low, stats.low, 2);
            Assert.Equal(exactStats.average, stats.average, 2);
        }
    }
}
