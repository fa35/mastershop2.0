using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterShop20.Website.Infrastructure;
using Newtonsoft.Json;

namespace MasterShop20.Website.Controllers
{
    public class CartController : Controller // Warenkorb
    {
        //
        // GET: /Cart/

        public ActionResult Index(int idNutzer)
        {
            // zeige mir den Warenkorb des Nutzers falls dieser eingeloggt ist

            // überprüfe ob nutzer nicht schon ausgeloggt

            var organizer = new DbOrganizer();

            var sessionId = organizer.CheckCurrentLogin(idNutzer);

            if (sessionId == null) // nutzer nicht eingeloggt
            {
                return View("Login"); // nutzer solll sich einloggen
            }
            else
            {
                // hole session daten

                var session = organizer.GetSessionData(idNutzer);
                var articleIds = JsonConvert.DeserializeObject<List<int>>(session.ArtikelInwarenkorb);

                var articles = organizer.GetArticlesByIds(articleIds);

                return View("Index", articles);
            }

            
        }



    }
}
