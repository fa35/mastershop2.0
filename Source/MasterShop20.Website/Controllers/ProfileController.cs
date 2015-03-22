using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterShop20.Website.Database;
using MasterShop20.Website.Models;
using MasterShop20.Website.Infrastructure;

namespace MasterShop20.Website.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        private DataLoader _loader;

        public ProfileController()
        {
            _loader = new DataLoader();
        }

        public ActionResult Index()
        {
            string nutzerId = string.Empty;
            Nutzer nutzer = new Nutzer();
            if (Request.Cookies["user"] != null)
            {
                nutzerId = Request.Cookies["user"].Value;
                int nutzerInt;
                int.TryParse(nutzerId, out nutzerInt);
                nutzer = _organizer.GetNutzerById(nutzerInt);

            }

            return View("Index",nutzer);
        }

    }
}
