using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {

        [Fact]
        public void GetBookNameTest()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            Assert.Equal("Book 1", book1.Name);
        }

        [Fact]
        public void BookNameTest()
        {
            var book1 = GetBook("Book 1");
            SetName(ref book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void BookObjectTest()
        {
            Book book1 = GetBook("book 1");
            Book book2 = GetBook("book 2");
            Assert.Equal("book 1", book1.Name);
            Assert.Equal("book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void ReferenceObjectTest() 
        {
            var book1 = GetBook("book 1");
            var book2 = book1;
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        [Fact]
        public void StringsBehaviour()
        {
            // strings behave like value types
            var str1 = "Andy";
            var upper = ConvertToUpperCase(str1);
            Assert.Equal("Andy", str1);
            Assert.Equal("ANDY", upper);
        }

        public string ConvertToUpperCase(string str)
        {
            return str.ToUpper();
        }

        Book GetBook(string name)
        {
            return new Book(name, new float[] {});
        }
        
        public void SetName(ref Book book, string name)
        {
            // parameters are always passed by value unless ref keyword is used
            book.Name = name;
        }
        
        public void GetBookSetName(Book book, string name)
        {
            book = GetBook(name);
        }

    }
}
