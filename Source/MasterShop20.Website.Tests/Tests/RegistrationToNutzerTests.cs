using System;
using MasterShop20.Website.Converter;
using MasterShop20.Website.Models;
using MasterShop20.Website.Tests.Models;
using NUnit.Framework;

namespace MasterShop20.Website.Tests.Tests
{
    [TestFixture]
    class RegistrationToNutzerTests
    {
        private TestDataLoader _loader;
        private Registration _registration;
        private ModelsConverter _converter;

        [TestFixtureSetUp]
        public void Setup()
        {
            _loader = new TestDataLoader();
            _registration = _loader.GetRegistrationTestData();
            _converter = new ModelsConverter();
        }

        [Test]
        public void TestRegistrationToNutzer()
        {
            var nutzer = _converter.RegistrationToNutzer(_registration);

            Assert.IsTrue(nutzer != null);
        }


        [Test]
        public void TestExceptionHandling()
        {
            bool wasHandled;
            _registration.PostalCode = "numbers";

            try
            {
                var nutzer = _converter.RegistrationToNutzer(_registration);
                wasHandled = true;
            }
            catch (Exception)
            {
                wasHandled = false;
            }

            Assert.IsTrue(wasHandled);
        }

    }
}
