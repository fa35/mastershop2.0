using MasterShop20.Website.Database;
using MasterShop20.Website.Models;
using NUnit.Framework;

namespace MasterShop20.Website.Tests
{
    [TestFixture]
    class ArticleViewModelToViewModelTests
    {
        private Artikel _testArticle ;
       
        [SetUp] // SetUp wird immer vor einem Test der Testklasse aufgerufen
        public void Setup()
        {
            _testArticle = new Artikel
            {
                IdArtikel = 1,
                Beschreibung = "Test - Beschreibung: Ist hier nun über 100 Zeichen lang damit die Methode ToViewModel richtig getestet werden kann. Dort wird nämlich die Beschreibung auf 100 Zeichen gekürzt, falls die Beschreibung bzw. der Text darin länger als 100 Zeichen ist.",
                BildLink = "http://www.moviepilot.de/movies/the-awakening--2/images",
                Datenblatt = string.Empty,
                IdOriginal = 2314,
                IdSteuersatz = 1,
                IdUntergruppe = 2,
                NettoPreis = 100,
                Titel = "der Titel"
            };
        }

        [TearDown]
        public void Teardown()
        {
            
        }

        [Test]
        public void TestBruttoPreisCalculation()
        {

            var avm = new ArticleViewModel().ToViewModel(_testArticle);

            Assert.AreEqual(119, avm.Price);
        }


        [Test]
        public void TestDescriptionLength()
        {
            var avm = new ArticleViewModel().ToViewModel(_testArticle);

            Assert.GreaterOrEqual(_testArticle.Beschreibung.Length, 100);
            Assert.LessOrEqual(avm.Description.Length, 100);
        }

    }
}
