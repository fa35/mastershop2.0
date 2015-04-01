using System;
using System.IO;
using MasterShop20.Website.Models;
using Newtonsoft.Json;

namespace MasterShop20.Website.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            //SaveTestDataAsJson();
        }

        private static void SaveTestDataAsJson()
        {
            var goodRegistrationData = new Registration
            {
                FirstName = "Santa", LastName = "Clause", 
                HouseNr = "2345", MailAddress = "mcsnowy@gmail.com",
                Password = "cookiesforall", Place = "northpole", PostalCode = "12345",
                Street = "Snowy Path"
            };

            var content = JsonConvert.SerializeObject(goodRegistrationData);
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "test_registration_01.json");
            File.WriteAllText(path, content);

        }
    }
}
