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

        private DataLoader _organizer;

        public ProfileController()
        {
            _organizer = new DataLoader();
        }

        public ActionResult Index()
        {
            string nutzer = string.Empty;
            if (Request.Cookies["user"] != null)
                nutzer = Request.Cookies["user"].Value;

            return View("Index",nutzer);
        }

    }
}
