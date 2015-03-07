using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MasterShop20.Website.Database;
using Newtonsoft.Json;

namespace MasterShop20.Website.Infrastructure
{
    public class SessionManager
    {
        // todo: diese klasse wird bisher in dborganizer verwendet

        public bool AddArticleToUserSession(int idNutzer, int idArtikel)
        {
            var con = ConfigurationManager.AppSettings["connection"];

            using (var context = new MasterShopDataContext(con))
            {
                var session = context.Sessions.FirstOrDefault(n => n.IdNutzer == idNutzer);
                var currentList = JsonConvert.DeserializeObject<List<int>>(session.ArtikelInwarenkorb);
                currentList.Add(idArtikel);
                var content = JsonConvert.SerializeObject(currentList);
                session.ArtikelInwarenkorb = content;
                context.SubmitChanges();
                return true;
            }
        }

        public bool CreateUserSession(int idNutzer)
        {
            var con = ConfigurationManager.AppSettings["connection"];

            using (var context = new MasterShopDataContext(con))
            {
                if (context.Sessions.Any(p => p.IdNutzer == idNutzer && p.LogoutDateTime == null))
                    return false;

                var session = new Session {IdNutzer = idNutzer, LoginDateTime = DateTime.Now};
                try
                {
                    context.Sessions.InsertOnSubmit(session);
                    context.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
        }


    }
}