using System;
using Xunit;

namespace Reflect.Tests
{
    public class iocTests
    {
        [Fact]
        public void Can_Resolve_Types()
        {
            var ioc = new Container();
            ioc.For<ILogger>().Use<SqlServerLogger>();

            var logger = ioc.Resolve<ILogger>();

            Assert.Equal(typeof(SqlServerLogger), logger.GetType());
        }
    }
}
