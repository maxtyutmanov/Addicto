using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Addicto.DataService.Api;
using Addicto.DataService.Api.Controllers;

namespace Addicto.DataService.Api.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void GetById()
        {
            // Arrange
            ArticlesController controller = new ArticlesController();

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ArticlesController controller = new ArticlesController();

            // Act
            controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ArticlesController controller = new ArticlesController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ArticlesController controller = new ArticlesController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
