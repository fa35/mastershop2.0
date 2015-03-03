using System;
using System.Collections.Generic;
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
            _datacontext = new MasterShopDataContext();
        }


        public bool CheckLoginData(Login login)
        {
            if (!_datacontext.Nutzers.Any())
                return false;

            var exits =
                _datacontext.Nutzers.Any(
                    p =>
                        p.EMail.Equals(login.MailAddress,
                            StringComparison.InvariantCultureIgnoreCase) && p.Passwort.Equals(login.Password));

            return exits;
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

        public List<Artikel> GetArticles()
        {
            return _datacontext.Artikels.Take(20).ToList();
        }

    }
}