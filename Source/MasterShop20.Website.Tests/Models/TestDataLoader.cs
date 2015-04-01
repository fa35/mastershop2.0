using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Helpers;
using MasterShop20.Website.Database;
using MasterShop20.Website.Infrastructure;
using MasterShop20.Website.Models;
using Newtonsoft.Json;

namespace MasterShop20.Website.Tests.Models
{
    public class TestDataLoader : ILoader
    {
        private List<Artikel> _articles;
        private Registration _registration;

        public TestDataLoader()
        {
            GetTestData();
        }

        void GetTestData()
        {
            _articles = new List<Artikel>();

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData");

            var regPath = string.Empty;

            foreach (var filepath in Directory.EnumerateFiles(path))
            {
                var info = new FileInfo(filepath);

                if (!info.Name.StartsWith("test_article") && info.Name.StartsWith("test_registration"))
                {
                    regPath = filepath;
                    continue;
                }

                var content = File.ReadAllText(filepath);
                _articles.Add(JsonConvert.DeserializeObject<Artikel>(content));
            }

            if (!string.IsNullOrWhiteSpace(regPath))
            {
                var content = File.ReadAllText(regPath);
                _registration = JsonConvert.DeserializeObject<Registration>(content);
            }
        }




        public bool CheckIfUserExists(Login login)
        {
            throw new NotImplementedException();
        }

        public bool CheckRegistrationData(Registration registration)
        {
            throw new NotImplementedException();
        }

        public Nutzer GetNutzerByLogin(Login login)
        {
            throw new NotImplementedException();
        }

        public Nutzer CreateNutzer(Registration registration)
        {
            throw new NotImplementedException();
        }

        public Nutzer GetNutzerById(int idUser)
        {
            throw new NotImplementedException();
        }

        public List<Artikel> GetArticlesByIds(List<int> idsArticles)
        {
            var resultList = new List<Artikel>();

            foreach (int id in idsArticles)
                resultList.Add(_articles.FirstOrDefault(a => a.IdArtikel == id));

            return resultList;
        }

        public List<Artikel> GetArticlesList(int page = 0, int amount = 10)
        {
            return _articles.Skip(page * 1).Take(amount).ToList();
        }

        public List<Artikel> GetArticlesListByGroups(int page, int amount, string subgroupName)
        {
            throw new NotImplementedException();
        }

        public Artikel GetArticleById(int idArticle)
        {
            return _articles.FirstOrDefault(a => a.IdArtikel == idArticle);
        }

        public Dictionary<string, List<string>> GetGroups()
        {
            throw new NotImplementedException();
        }

        public decimal GetSteuersatz(int idSteuersatz)
        {
            throw new NotImplementedException();
        }

        public Bestellung GetBestellungByUserId(int idUser)
        {
            throw new NotImplementedException();
        }

        public List<BestellungsDetail> GetDetailsByBestellungsId(int idBestellung)
        {
            throw new NotImplementedException();
        }

        public Registration GetRegistrationTestData()
        {
            return _registration;
        }
    }
}
