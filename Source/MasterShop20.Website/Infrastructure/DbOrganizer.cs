using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using MasterShop20.Website.Database;
using MasterShop20.Website.Models;

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


        public bool CheckLoginData(Login login)
        {
            if (!_datacontext.Nutzers.Any())
                return false;

            var exists = false;

            try
            {
                exists = _datacontext.Nutzers.Any(n => 
                    n.EMail.Equals(login.MailAddress, StringComparison.InvariantCultureIgnoreCase)
                    && n.Passwort.Equals(login.Password));
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

            var exists = _datacontext.Nutzers.Any(
                p =>
                    p.Vorname.Equals(regist.FirstName, StringComparison.InvariantCultureIgnoreCase) &&
                    p.Name.Equals(regist.LastName, StringComparison.InvariantCultureIgnoreCase) &&
                    p.EMail.Equals(regist.MailAddress, StringComparison.InvariantCultureIgnoreCase) &&
                    p.HausNr.Equals(regist.HouseNr, StringComparison.InvariantCultureIgnoreCase) &&
                    p.Ort.Equals(regist.Place, StringComparison.InvariantCultureIgnoreCase) &&
                    p.Passwort.Equals(regist.Password) &&
                    p.Strasse.Equals(regist.Street, StringComparison.InvariantCultureIgnoreCase) &&
                    p.PLZ.ToString().Equals(regist.PostalCode)
                    );

            return exists;
        }

        public Nutzer ConvertLoginToNutzer(Login login)
        {
            var nutzer = _datacontext.Nutzers.FirstOrDefault(
                    p =>
                        p.EMail.Equals(login.MailAddress,
                            StringComparison.InvariantCultureIgnoreCase) && p.Passwort.Equals(login.Password));

            if (nutzer != null)
                new SessionManager().CreateUserSession(nutzer.IdNutzer);

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

                new SessionManager().CreateUserSession(nutzer.IdNutzer);
                return nutzer;
            }
            catch (Exception)
            {
                return null;
                // todo: error logging or what ever
                throw;
            }
        }

        public long? CheckCurrentLogin(int idNutzer)
        {
            var session = _datacontext.Sessions.FirstOrDefault(n => n.IdNutzer == idNutzer);
            if (session != null)
                return session.IdSession;

            return null;
        }

        public Session GetSessionData(int idNutzer)
        {
            var session = _datacontext.Sessions.FirstOrDefault(n => n.IdNutzer == idNutzer);
            return session ?? null; // = kurzschreibweise für if(session != null) return session else return null
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

        public bool StoreSession(Session session)
        {
            try
            {
                _datacontext.Sessions.InsertOnSubmit(session);
                _datacontext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;   
                throw ex;
            }
        }

    }
}