using System;
using System.Collections.Generic;
using System.Linq;
using MasterShop20.Website.Converter;
using MasterShop20.Website.Database;
using MasterShop20.Website.Models;
using NLog;

namespace MasterShop20.Website.Infrastructure
{
    public class DataLoader : ILoader
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        private MasterShopDataContext _databaseDc;

        public DataLoader()
        {
            try
            {
                _databaseDc = new DatabaseManager().GetDataContext();

                if (_databaseDc == null)
                    return;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Fatal, "Kein Connectionstring vorhanden", ex);
            }
        }



        #region check for existing data in db

        public bool CheckIfUserExists(Login login)
        {
            try
            {
                return _databaseDc.Nutzers.Any(n => n.EMail.Equals(login.MailAddress) && n.Passwort.Equals(login.Password));
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Fatal, "Fehler beim Überprufen auf vorhandenen Nutzer", ex);
                return false;
            }
        }

        public bool CheckRegistrationData(Registration regist)
        {

            var nutzers = new List<Nutzer>();
            try
            {
                nutzers = _databaseDc.Nutzers.Where(p => p.EMail.Equals(regist.MailAddress)).ToList();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Fatal, "Fehler beim Überprufen auf vorhandenen Nutzer", ex);
            }

            return nutzers.Count >= 1;
        }

        #endregion



        public Nutzer GetNutzerByLogin(Login login)
        {
            try
            {
                return _databaseDc.Nutzers
                    .FirstOrDefault(p => p.EMail.Equals(login.MailAddress) && p.Passwort.Equals(login.Password));
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Fatal, "Logindaten passen zu keinem Nutzer", ex);
                return null;
            }

        }

        public Nutzer CreateNutzer(Registration registration)
        {
            var nutzer = new ModelsConverter(this).RegistrationToNutzer(registration);

            try
            {
                _databaseDc.Nutzers.InsertOnSubmit(nutzer);
                _databaseDc.SubmitChanges();
                return nutzer;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Konnte neuen Nutzer nicht anlegen", ex);
                return null;
            }
        }

        public Nutzer GetNutzerById(int idUser)
        {
            return _databaseDc.Nutzers.FirstOrDefault(n => n.IdNutzer == idUser);
        }

        public void UpdateNutzer(Nutzer nutzer)
        {
            // es die Veränderungen wurden direkt auf dem Nutzer-Objekt gemacht, somit müssen die Veränderungen nur noch gesubmittet werden
            _databaseDc.SubmitChanges();
        }

        public List<Artikel> GetArticlesByIds(List<int> idsArticles)
        {
            var articles = new List<Artikel>();

            foreach (var id in idsArticles)
                articles.Add(_databaseDc.Artikels.FirstOrDefault(p => p.IdArtikel == id));

            return articles;
        }

        public List<Artikel> GetArticlesList(int page, int amount, string subgroupName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(subgroupName))
                {
                    return _databaseDc.Artikels.Skip(page * amount).Take(amount).ToList();
                }
                else
                {
                    var subgroup = _databaseDc.Untergruppes.FirstOrDefault(u => u.Titel.Equals(subgroupName));
                    
                    return _databaseDc.Artikels
                        .Where(a => a.IdUntergruppe == subgroup.IdUntergruppe).Skip(page * amount).Take(amount).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Konnte Artikel nach UntergurppenID nicht holen", ex);
                return null;
            }
        }

        public Artikel GetArticleById(int idArticle)
        {
            try
            {
                return _databaseDc.Artikels.FirstOrDefault(a => a.IdArtikel == idArticle);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Fatal, "ArtikelId nicht in vorhanden", ex);
                return null;
            }
        }


        public Dictionary<string, List<string>> GetGroups()
        {
            var dic = new Dictionary<string, List<string>>();

            foreach (var hauptgruppe in _databaseDc.Hauptgruppes)
            {
                var untergruppen =
                    _databaseDc.Untergruppes
                    .Where(u => u.IdHauptgruppe == hauptgruppe.IdHauptgruppe)
                    .Select(p => p.Titel)
                    .ToList();

                dic.Add(hauptgruppe.Titel, untergruppen);
            }
            return dic;
        }

        public decimal GetSteuersatz(int idSteuersatz)
        {
            try
            {
                return _databaseDc.Steuersatzs.FirstOrDefault(s => s.IdSteuersatz == idSteuersatz).Steuersatz1;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Fatal, "Konnte Steuersatz nicht laden", ex);
                return 19;
            }
        }

        public Bestellung GetBestellungByUserId(int idUser)
        {
            try
            {
                return _databaseDc.Bestellungs.FirstOrDefault(p => p.IdNutzer == idUser && p.Bezahlt == false);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Fatal, "Bestellung von dieser NutzerId nicht in vorhanden", ex);
                return null;
            }
        }

        public List<BestellungsDetail> GetDetailsByBestellungsId(int idBestellung)
        {
            try
            {
                return _databaseDc.BestellungsDetails.Where(d => d.IdBestellung == idBestellung).ToList();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Fatal, "Details für diese BestellungsId nicht in vorhanden", ex);
                return null;
            }
        }
    }

}