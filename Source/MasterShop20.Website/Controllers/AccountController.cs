using System.Web.Mvc;
using MasterShop20.Website.Infrastructure;
using MasterShop20.Website.Models;

namespace MasterShop20.Website.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login(Login login) // aktuelle Seite sollte mitübergeben werden, sodass der Nutzer nachdem Login wieder dort hinkommt wo er war
        {
            var organizer = new DbOrganizer();

            // suche in db nach passenden daten
            var exits = organizer.CheckLoginData(login);

            if (!exits)
                return View("Error");

            // hole nutzer daten
            var nutzer = organizer.ConvertLoginToNutzer(login);

            if (nutzer != null)
                return View("AccountSettings", nutzer);

            return View("Error");
        }


        public ActionResult Register(Registration regist)
        {
            var organizer = new DbOrganizer();
            // suche in db nach regist der bereits nutzer ist, wenn nicht insert & save

            var exists = organizer.CheckRegistrationData(regist);

            if (exists)
                return View("Error");

            // erstelle nutzer
            var nutzer = organizer.CreateNutzer(regist);
            return View("AccountSettings", nutzer);
        }

    }

}
