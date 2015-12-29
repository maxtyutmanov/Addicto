﻿using System;
using NUnit.Framework;
using Moq;
using Addicto.Core.Client.Adapter;
using Addicto.Core.Client.Utils;
using Addicto.Core.Client.UI.VM.Shared;
using Addicto.Core.Client.UI.VM;

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
        public void CurrentVmIsNotUpdatedIfNoTextSelected()
        {
            GlobalContext ctx = CreateGlobalCtx();
            MainController sut = CreateSUT(ctx, "");

            BaseVm prevVm = ctx.CurrentVm;

            sut.OnMagicCombination();

            Assert.That(ctx.CurrentVm, Is.EqualTo(prevVm));
        }

        [Test]
        public void SearchContextStaysTheSameIfItAlreadySetOnMagicCombination()
        {
            GlobalContext ctx = CreateGlobalCtx();
            MainController sut = CreateSUT(ctx, "some_text");

            ctx.TryStartSearch("some_previous_query");

            SearchContext prevSearchCtx = ctx.CurrentSearch;
            sut.OnMagicCombination();

            Assert.That(ctx.CurrentSearch, Is.EqualTo(prevSearchCtx));
        }

        [Test]
        public void CurrentVmIsSetToSearchFinishedAfterSearch()
        {
            GlobalContext ctx = CreateGlobalCtx();
            MainController sut = CreateSUT(ctx, "some_text");

            sut.OnMagicCombination();

            Assert.That(ctx.CurrentVm, Is.InstanceOf<SearchFinishedVm>());
        }

        [Test]
        public void SearchIsRunAfterMagicCombination() 
        {
            Mock<IDataAdapter> daMock = null;

            GlobalContext ctx = CreateGlobalCtx(ref daMock);
            MainController sut = CreateSUT(ctx, "some_text");

            sut.OnMagicCombination();

            daMock.Verify(da => da.GetAsync(It.IsAny<SearchContext>()), Times.Once);
        }

        private GlobalContext CreateGlobalCtx()
        {
            Mock<IDataAdapter> daMock = null;
            return CreateGlobalCtx(ref daMock);
        }

        private GlobalContext CreateGlobalCtx(ref Mock<IDataAdapter> dataAdapterMock)
        {
            GlobalContext globalCtx = new GlobalContext();

            Mock<IDataAdapter> da = new Mock<IDataAdapter>();
            Mock<IModuleDescriptor> moduleDescr = new Mock<IModuleDescriptor>();
            moduleDescr.SetupGet(m => m.DataAdapter).Returns(da.Object);
            moduleDescr.SetupGet(m => m.VmFactory).Returns(new DefaultVmFactory());
            globalCtx.RegisterModule(moduleDescr.Object);

            dataAdapterMock = da;

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
