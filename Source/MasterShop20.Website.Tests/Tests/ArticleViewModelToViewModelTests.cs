using System;
using MasterShop20.Website.Models;
using MasterShop20.Website.Tests.Models;
using NUnit.Framework;

namespace MasterShop20.Website.Tests.Tests
{
    [TestFixture]
    class ArticleViewModelToViewModelTests
    {
        private TestDataLoader _loader;

        [TestFixtureSetUp] // TestFixtureSetUp wird genau einmal aufgerufen und existiert max. bis zum TestFixtureTearDown
        public void Setup()
        {
            _loader = new TestDataLoader();
        }


        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        public void TestBruttoPreisCalculation(int id)
        {
            var article = _loader.GetArticleById(id);
            var avm = new ArticleViewModel().ToViewModel(article);
            var brutto = Math.Round(article.NettoPreis + (100/article.NettoPreis*19), 2);

            Assert.AreEqual(brutto, avm.Price);
        }


        [TestCase(3)]
        [TestCase(2)]
        [TestCase(1)]
        public void TestDescriptionLength(int id)
        {
            var article = _loader.GetArticleById(id);
            var avm = new ArticleViewModel().ToViewModel(article);

            Assert.GreaterOrEqual(article.Beschreibung.Length, 100);
            Assert.LessOrEqual(avm.Description.Length, 100);
        }

    }
}
