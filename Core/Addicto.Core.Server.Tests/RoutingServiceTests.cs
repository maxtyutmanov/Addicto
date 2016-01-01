using Addicto.Core.Server.ErrorHandling;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Addicto.Core.Server.Tests
{
    [TestFixture]
    public class RoutingServiceTests
    {
        [Test]
        public void ModuleIsInvokedOnGet()
        {
            Mock<IModuleSelector> moduleSelector = new Mock<IModuleSelector>(MockBehavior.Strict);
            Mock<IModule> module = new Mock<IModule>(MockBehavior.Loose);
            moduleSelector.Setup(ms => ms.SelectModule("some_module_key")).Returns(module.Object);
            RoutingService sut = new RoutingService(moduleSelector.Object);

            sut.Get("some_query", "some_module_key");

            module.Verify(m => m.Get("some_query"));
        }

        [Test]
        public void UnregisteredModuleKeyLeadsToErrorOnGet()
        {
            Mock<IModuleSelector> moduleSelector = new Mock<IModuleSelector>(MockBehavior.Strict);
            moduleSelector.Setup(ms => ms.SelectModule("unregistered_module_key")).Returns((IModule)null);
            RoutingService sut = new RoutingService(moduleSelector.Object);

            Assert.Throws<ModuleNotRegisteredException>(() => sut.Get("some_query", "unregistered_module_key"));
        }

        [Test]
        public void ModuleIsInvokedOnPost()
        {
            Mock<IModuleSelector> moduleSelector = new Mock<IModuleSelector>(MockBehavior.Strict);
            Mock<IModule> module = new Mock<IModule>(MockBehavior.Loose);
            moduleSelector.Setup(ms => ms.SelectModule("some_module_key")).Returns(module.Object);
            XmlDocument payload = new XmlDocument();

            RoutingService sut = new RoutingService(moduleSelector.Object);

            sut.Post("some_query", payload, "some_module_key");

            module.Verify(m => m.Post("some_query", payload));
        }

        [Test]
        public void UnregisteredModuleKeyLeadsToErrorOnPost()
        {
            Mock<IModuleSelector> moduleSelector = new Mock<IModuleSelector>(MockBehavior.Strict);
            moduleSelector.Setup(ms => ms.SelectModule("unregistered_module_key")).Returns((IModule)null);
            XmlDocument payload = new XmlDocument();

            RoutingService sut = new RoutingService(moduleSelector.Object);

            Assert.Throws<ModuleNotRegisteredException>(() => sut.Post("some_query", payload, "unregistered_module_key"));
        }
    }
}
