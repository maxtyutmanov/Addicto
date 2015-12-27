using System;
using NUnit.Framework;
using Moq;
using Addicto.Core.Client.Adapter;
using Addicto.Core.Client.Utils;

namespace Addicto.Core.Client.Tests
{
    [TestFixture]
    public class MainControllerTest
    {
        [Test]
        public void SearchContextIsSetAfterMagicCombinationPressed()
        {
            GlobalContext ctx = CreateGlobalCtx();
            MainController sut = CreateSUT(ctx, "some_text");

            sut.OnMagicCombination();

            Assert.That(ctx.CurrentSearch, Is.Not.Null);
        }

        [Test]
        public void SearchContextAfterMagicCombinationStaysNullIfNoTextSelected()
        {
            GlobalContext ctx = CreateGlobalCtx();
            MainController sut = CreateSUT(ctx, "");

            sut.OnMagicCombination();

            Assert.That(ctx.CurrentSearch, Is.Null);
        }

        [Test]
        public void SearchContextStaysTheSameIfItAlreadySetOnMagicCombination()
        {
            GlobalContext ctx = CreateGlobalCtx();
            MainController sut = CreateSUT(ctx, "some_text");

            ctx.CurrentSearch = new SearchContext() { Query = "some_query" };
            SearchContext prevSearchCtx = ctx.CurrentSearch;
            sut.OnMagicCombination();

            Assert.That(ctx.CurrentSearch, Is.EqualTo(prevSearchCtx));
        }

        private GlobalContext CreateGlobalCtx()
        {
            GlobalContext globalCtx = new GlobalContext();

            Mock<IDataAdapter> da = new Mock<IDataAdapter>();
            Mock<IModuleDescriptor> moduleDescr = new Mock<IModuleDescriptor>();
            moduleDescr.SetupGet(m => m.DataAdapter).Returns(da.Object);
            globalCtx.RegisterModule(moduleDescr.Object);

            return globalCtx;
        }

        private MainController CreateSUT(GlobalContext globalCtx, string fetchedText)
        {
            Mock<ITextFetcher> tf = new Mock<ITextFetcher>();
            tf.Setup(t => t.FetchSelectedText()).Returns(fetchedText);

            MainController ctrl = new MainController(globalCtx, tf.Object);

            return ctrl;
        }
    }
}
