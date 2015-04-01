using System.Web.Mvc;
using MasterShop20.Website.Infrastructure;

namespace MasterShop20.Website.Controllers
{
    public class ProfileController : Controller
    {
        // GET: /Profile/

        private DataLoader _loader;
        private CookieManager _manager;


        public ProfileController()
        {
            _loader = new DataLoader();
            _manager = new CookieManager();
        }


        public ActionResult Index()
        {
            var idNutzer = _manager.LoadUserCookie();

            if (idNutzer != 0)
                return View("Index", _loader.GetNutzerById(idNutzer));

            return View("Login");
        }

        // beispielehafte Vorgehensweise für ein Update von einem schon vorhandenen Objekt
        public ActionResult UpdateNutzerInformation(string vorname, string name)
        {
            var idNutzer = _manager.LoadUserCookie();
            var nutzer = _loader.GetNutzerById(idNutzer);

            nutzer.Name = name;
            nutzer.Vorname = vorname;

            _loader.UpdateNutzer(nutzer);

            return Index();
        }
    }
}
