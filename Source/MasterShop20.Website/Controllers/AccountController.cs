using System.Web;
using System.Web.Mvc;
using MasterShop20.Website.Infrastructure;
using MasterShop20.Website.Models;

namespace MasterShop20.Website.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        private DataLoader _organizer;

        public AccountController()
        {
            _organizer = new DataLoader();
        }

        public ActionResult Login(Login login) // aktuelle Seite sollte mitübergeben werden, sodass der Nutzer nachdem Login wieder dort hinkommt wo er war
        {
            // suche in db nach passenden daten
            var exits = _organizer.CheckIfUserExists(login);

            if (!exits)
                return View("Error");

            // hole nutzer daten
            var nutzer = _organizer.ConvertLoginToNutzer(login);

            if (nutzer != null)
            {
                Response.Cookies.Add(new HttpCookie("user") { Value = nutzer.IdNutzer.ToString() });
                return View("AccountSettings", nutzer);
            }

            return View("Error");
        }


        public ActionResult Register(Registration regist)
        {
            // suche in db nach regist der bereits nutzer ist, wenn nicht insert & save
            var exists = _organizer.CheckRegistrationData(regist);

            if (exists)
                return View("Login");

            // erstelle nutzer
            var nutzer = _organizer.CreateNutzer(regist);
            Response.Cookies.Add(new HttpCookie("user") { Value = nutzer.IdNutzer.ToString() });

            return View("AccountSettings", nutzer);
        }

    }

}
