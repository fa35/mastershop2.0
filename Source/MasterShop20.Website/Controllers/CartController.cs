using System.Collections.Generic;
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


        public bool AddArticleToCart(int idNutzer, int articleId)
        {
            var organizer = new DbOrganizer();
            var sessionId = organizer.CheckCurrentLogin(idNutzer);

            if (sessionId == null) // nutzer nicht eingeloggt
            {
                return false; // nutzer muss isch erst einloggen
            }
            else
            {
                // hole session daten
                var session = organizer.GetSessionData(idNutzer);
                // deserialire zu int liste
                var articleIds = JsonConvert.DeserializeObject<List<int>>(session.ArtikelInwarenkorb);
                // füge neue id hinzu
                articleIds.Add(articleId);
                // serialisiere die id liste
                var content = JsonConvert.SerializeObject(articleIds);
                // füge erweiterte liste session hinzu
                session.ArtikelInwarenkorb = content;
                // übergebe session an organizer zum speichern
                return organizer.StoreSession(session);
            }
        }

    }
}
