using System.Collections.Generic;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {

        private List<float> grades = new List<float>()
        {
            88.5F, 23.5F, 66.2F, 55.1F, 73.8F
        };

        [Fact]
        public void StatisticsTest()
        {
            InmemoryBook book = new InmemoryBook("book");
            book.StoreGrades(grades);
            Statistics stats = book.GetStatistics();
            Assert.Equal(88.5F, stats.High, 2);
            Assert.Equal(23.5F, stats.Low, 2);
            Assert.Equal(61.42F, stats.Average, 2);
            Assert.Equal('C', stats.Letter);
        }

        [Fact]
        public void StoreGradeTest()
        {
            var numGrades = grades.Count;
            var book = new InmemoryBook("book");
            book.StoreGrades(grades);
            Assert.Equal(5, book.GetGradeCount());
        }

    }
}
