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

        private DataLoader _loader;

        public AccountController()
        {
            _loader = new DataLoader();
        }

        public ActionResult Login(Login login)
        {
            // suche in db nach passenden daten
            var exits = _loader.CheckIfUserExists(login);

            if (!exits)
                return View("Error");

            // hole nutzer daten
            var nutzer = _loader.GetNutzerByLogin(login);

            if (nutzer == null)
                return View("Error");

            Response.Cookies.Add(new HttpCookie("user") { Value = nutzer.IdNutzer.ToString() });
            return View("../Home/Index");
        }


        public ActionResult Register(Registration registration)
        {
            // suche in db nach registration der bereits nutzer ist, wenn nicht insert & save
            var exists = _loader.CheckRegistrationData(registration);

            if (exists)
                return View("Login");

            // erstelle nutzer
            var nutzer = _loader.CreateNutzer(registration);
            Response.Cookies.Add(new HttpCookie("user") { Value = nutzer.IdNutzer.ToString() });

            return View("../Home/Index");
        }

    }

}
