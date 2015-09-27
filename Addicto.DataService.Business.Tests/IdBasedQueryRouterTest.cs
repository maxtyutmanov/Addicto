using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Addicto.DataService.Business.Tests
{
    [TestClass]
    public class IdBasedQueryRouterTest
    {
        [TestMethod]
        public void ReturnsDataSourceWhenItsRegistered()
        {
            int fakeDsId = 1;

            IdBasedQueryRouter router = new IdBasedQueryRouter();
            router.RegisterRoute(fakeDsId, (query) => new MockDataSource(query));

            DataSource ds = router.RouteQuery(new Model.ArticleQuery()
            {
                DataSourceId = fakeDsId,
                QueryText = "doesnt_matter"
            });

            Assert.IsNotNull(ds);
            Assert.IsInstanceOfType(ds, typeof(MockDataSource));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DoesntReturnDataSourceWhenItsnotRegistered()
        {
            IdBasedQueryRouter router = new IdBasedQueryRouter();

            DataSource ds = router.RouteQuery(new Model.ArticleQuery()
            {
                DataSourceId = 1,
                QueryText = "doesnt_matter"
            });
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CannotRegisterDataSourceTwice()
        {
            IdBasedQueryRouter router = new IdBasedQueryRouter();

            router.RegisterRoute(1, (query) => new MockDataSource(query));
            router.RegisterRoute(1, (query) => new MockDataSource(query));
        }
    }
}
