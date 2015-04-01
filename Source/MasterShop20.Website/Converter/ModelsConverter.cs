using System;
using System.Collections.Generic;
using MasterShop20.Website.Database;
using MasterShop20.Website.Infrastructure;
using MasterShop20.Website.Models;
using NLog;

namespace MasterShop20.Website.Converter
{
    public class ModelsConverter
    {
        private ILoader _loader;

        public ModelsConverter(ILoader loader)
        {
            _loader = loader;
        }

        public Nutzer RegistrationToNutzer(Registration registration)
        {
            try
            {
                var nutzer = new Nutzer();

                nutzer.Name = registration.LastName;
                nutzer.HausNr = registration.HouseNr;
                nutzer.Ort = registration.Place;

                int plz;

                int.TryParse(registration.PostalCode, out plz);

                if (plz >= 10000)
                    nutzer.PLZ = plz;
                else
                    throw new Exception("PLZ kleiner 10000");
                
                nutzer.Passwort = registration.Password;
                nutzer.Strasse = registration.Street;
                nutzer.Vorname = registration.FirstName;
                nutzer.EMail = registration.MailAddress;

                return nutzer;
            }
            catch (Exception ex)
            {
                var logger = LogManager.GetCurrentClassLogger();
                logger.Log(LogLevel.Fatal, "Konnte kein Nutzer Objekt erzeugen", ex);
            }
            return null;
        }


        public ArticleViewModel ConvertArticleToArticleViewModel(Artikel article)
        {
            var satz = _loader.GetSteuersatz(article.IdSteuersatz);
            return new ArticleViewModel().ToViewModel(article, satz);
            
        } 
    }
}