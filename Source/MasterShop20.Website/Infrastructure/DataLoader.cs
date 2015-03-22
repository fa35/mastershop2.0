using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MasterShop20.Website.Converter;
using MasterShop20.Website.Database;
using MasterShop20.Website.Models;
using Newtonsoft.Json;
using NLog;

namespace MasterShop20.Website.Infrastructure
{
    public class DataLoader
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public MasterShopDataContext DatabaseDataContext;

        public DataLoader()
        {
            try
            {
                DatabaseDataContext = new DatabaseManager().GetDataContext();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Fatal, "Kein Connectionstring vorhanden", ex);
            }
        }

        #region check for existing data in db

        public bool CheckIfUserExists(Login login)
        {
            if (!DatabaseDataContext.Nutzers.Any())
                return false;

            bool exists = false;

            try
            {
                exists = DatabaseDataContext.Nutzers.Any(n => n.EMail.Equals(login.MailAddress) && n.Passwort.Equals(login.Password));
            }
            catch (Exception ex)
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                File.WriteAllText(path + @"\error.log", ex.ToString());
            }

            return exists;
        }

        public bool CheckRegistrationData(Registration regist)
        {
            if (!DatabaseDataContext.Nutzers.Any())
                return false;

            var nutzers = new List<Nutzer>();

            nutzers = DatabaseDataContext.Nutzers.Where(p => p.EMail.Equals(regist.MailAddress)).ToList();

            var exists = nutzers.Count >= 1;

            if (exists)
                return true;
            else
                return false;
        }

        #endregion


        public Nutzer ConvertLoginToNutzer(Login login)
        {
            var nutzer = DatabaseDataContext.Nutzers.FirstOrDefault(
                    p => p.EMail.Equals(login.MailAddress) && p.Passwort.Equals(login.Password));
            return nutzer;
        }

        public Nutzer CreateNutzer(Registration regist)
        {
            var nutzer = new ModelsConverter().RegistrationToNutzer(regist);

            try
            {
                DatabaseDataContext.Nutzers.InsertOnSubmit(nutzer);
                DatabaseDataContext.SubmitChanges();
                return nutzer;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Konnte neuen Nutzer nicht anlegen", ex);
            }
            return null;
        }


        public List<Artikel> GetArticlesByIds(List<int> articleIds)
        {
            var articles = new List<Artikel>();

            foreach (var id in articleIds)
                articles.Add(DatabaseDataContext.Artikels.FirstOrDefault(p => p.IdArtikel == id));

            return articles;
        }

        public List<Artikel> GetArticles(int page, int amount)
        {
            var articles_list = new List<Artikel>();

            try
            {
                articles_list = DatabaseDataContext.Artikels.Skip(page * amount).Take(amount).ToList();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Konnte Artikel nicht holen", ex);
            }
            return articles_list;
        }



        public Dictionary<string, List<string>> GetGroups()
        {
            var dic = new Dictionary<string, List<string>>();

            foreach (var hauptgruppe in DatabaseDataContext.Hauptgruppes)
            {
                dic.Add(hauptgruppe.Titel, DatabaseDataContext.Untergruppes
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
                st = DatabaseDataContext.Steuersatzs.FirstOrDefault(s => s.IdSteuersatz == idSteuersatz).Steuersatz1;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Konnte Steuersatz nicht holen", ex);
            }

            return st;
        }

        public Artikel GetArticleById(int id)
        {
            return DatabaseDataContext.Artikels.FirstOrDefault(a => a.IdArtikel == id);
        }

        public Bestellung GetBestellungByNutzerId(string userid)
        {
            int idUser;
            int.TryParse(userid, out idUser);

            return DatabaseDataContext.Bestellungs.FirstOrDefault(p => p.IdNutzer == idUser && p.Bezahlt == false);
        }

        public List<BestellungsDetail> GetDetailsByBestellungId(int idBestellung)
        {
            return DatabaseDataContext.BestellungsDetails.Where(d => d.IdBestellung == idBestellung).ToList();
        }

        public IEnumerable<Artikel> ConvertDetailsToArticles(string articlesId)
        {
            var ids = JsonConvert.DeserializeObject<List<int>>(articlesId);
            var articles = new List<Artikel>();

            foreach (var id in ids)
            {
                var article = DatabaseDataContext.Artikels.FirstOrDefault(a => a.IdArtikel == id);

                if (article != null)
                    articles.Add(article);
            }

            return articles;
        }
    }
}