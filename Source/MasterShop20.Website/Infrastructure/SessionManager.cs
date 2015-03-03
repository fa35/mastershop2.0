using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MasterShop20.Website.Database;
using Newtonsoft.Json;

namespace MasterShop20.Website.Infrastructure
{
    public class SessionManager
    {
        public Session GetUserSession(int idNutzer)
        {
            using (var context = new MasterShopDataContext())
            {
                return context.Sessions.FirstOrDefault(n => n.IdNutzer == idNutzer);
            }
        }

        public bool AddArticleToUserSession(int idNutzer, int idArtikel)
        {
            using (var context = new MasterShopDataContext())
            {
                var session = context.Sessions.FirstOrDefault(n => n.IdNutzer == idNutzer);
                var currentList = JsonConvert.DeserializeObject<List<int>>(session.ArtikelInwarenkorb);
                currentList.Add(idArtikel);
                var content = JsonConvert.SerializeObject(currentList);
                session.ArtikelInwarenkorb = content;

                context.SubmitChanges();
            }
        }
    }
}