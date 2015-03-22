using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using MasterShop20.Website.Database;
using MasterShop20.Website.Models;
using Newtonsoft.Json;
using WebGrease.Css.Extensions;

namespace MasterShop20.Website.Infrastructure
{
    public class DbOrganizer
    {

        private MasterShopDataContext _datacontext;

        public DbOrganizer()
        {
            var con = ConfigurationManager.AppSettings["connection"];
            _datacontext = new MasterShopDataContext(con);
        }


        public bool CheckIfUserExists(Login login)
        {
            if (!_datacontext.Nutzers.Any())
                return false;

            bool exists = false;

            try
            {
                exists = _datacontext.Nutzers.Any(n =>
                    n.EMail.Equals(login.MailAddress) && n.Passwort.Equals(login.Password));
            }
            catch (Exception ex)
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                File.WriteAllText(path + @"\error.log", ex.ToString());
            }

            return exists;
        }

        public bool CheckRegistrationData(Registration regist)
        {
            if (!_datacontext.Nutzers.Any())
                return false;

            var nutzers = new List<Nutzer>();

            nutzers = _datacontext.Nutzers.Where(p => p.EMail.Equals(regist.MailAddress)).ToList();

            var exists = nutzers.Count >= 1;

            if(exists)
                return true;
            else
                return false;
        }

        public Nutzer ConvertLoginToNutzer(Login login)
        {
            var nutzer = _datacontext.Nutzers.FirstOrDefault(
                    p => p.EMail.Equals(login.MailAddress) && p.Passwort.Equals(login.Password));
            return nutzer;
        }

        public Nutzer CreateNutzer(Registration regist)
        {
            var nutzer = new Nutzer();

            nutzer.Name = regist.LastName;
            nutzer.HausNr = regist.HouseNr;
            nutzer.Ort = regist.Place;
            nutzer.PLZ = int.Parse(regist.PostalCode);
            nutzer.Passwort = regist.Password;
            nutzer.Strasse = regist.Street;
            nutzer.Vorname = regist.FirstName;
            nutzer.EMail = regist.MailAddress;

            try
            {
                _datacontext.Nutzers.InsertOnSubmit(nutzer);
                _datacontext.SubmitChanges();
                return nutzer;
            }
            catch (Exception)
            {
                return null;
                // todo: error logging or what ever
                throw;
            }
        }


        public List<Artikel> GetArticlesByIds(List<int> articleIds)
        {
            var articles = new List<Artikel>();

            foreach (var id in articleIds)
                articles.Add(_datacontext.Artikels.FirstOrDefault(p => p.IdArtikel == id));

            return articles;
        }

        public List<Artikel> GetArticles(int page, int amount)
        {
            var articles_list = new List<Artikel>();

            try
            {
                articles_list = _datacontext.Artikels.Skip(page * amount).Take(amount).ToList();
            }
            catch (Exception ex)
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                File.WriteAllText(path + @"\error.log", ex.ToString());
            }
            return articles_list;

        }



        public Dictionary<string, List<string>> GetGroups()
        {
            var dic = new Dictionary<string, List<string>>();

            foreach (var hauptgruppe in _datacontext.Hauptgruppes)
            {
                dic.Add(hauptgruppe.Titel, _datacontext.Untergruppes
                    .Where(u => u.IdHauptgruppe == hauptgruppe.IdHauptgruppe)
                        .Select(p => p.Titel)
                        .ToList());
            }

            return dic;
        }

        public decimal GetSteuersatz(int idSteuersatz)
        {
            decimal st = 19;
            try
            {
                st = _datacontext.Steuersatzs.FirstOrDefault(s => s.IdSteuersatz == idSteuersatz).Steuersatz1;
            }
            catch (Exception)
            {
                st = 19;
            }

            return st;
        }

        public Artikel GetArticleById(int id)
        {
            return _datacontext.Artikels.FirstOrDefault(a => a.IdArtikel == id);
        }

        public Bestellung GetBestellungByNutzerId(string userid)
        {
            int idUser = 0;
            int.TryParse(userid, out idUser);

            return _datacontext.Bestellungs.FirstOrDefault(p => p.IdNutzer == idUser && p.Bezahlt == false);
        }

        public List<BestellungsDetail> GetDetailsByBestellungId(int idBestellung)
        {
            return _datacontext.BestellungsDetails.Where(d => d.IdBestellung == idBestellung).ToList();
        }

        public IEnumerable<Artikel> ConvertDetailsToArticles(string articlesId)
        {
            var ids = JsonConvert.DeserializeObject<List<int>>(articlesId);
            var articles = new List<Artikel>();

            foreach (var id in ids)
            {
                var article = _datacontext.Artikels.FirstOrDefault(a => a.IdArtikel == id);

                if (article != null)
                    articles.Add(article);
            }

            return articles;
        }
    }
}