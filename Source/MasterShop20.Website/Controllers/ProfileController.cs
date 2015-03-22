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
        private Nutzer _nutzer;
        private int _nutzerID;

        public ProfileController()
        {
            _loader = new DataLoader();
        }

        private void _setNutzer()
        {
            if (Request.Cookies["user"] != null)
            {
                string nutzerId = Request.Cookies["user"].Value;
                int.TryParse(nutzerId, out _nutzerID);
                this._nutzer = _loader.GetNutzerById(_nutzerID);
            }
        }

        public ActionResult Index()
        {
            _setNutzer();
            if (this._nutzer != null)
            {
                return View("Index", _nutzer);
            }
            else
            {
                return View("Login");
            }

            
        }

        public ActionResult handle_form(string vorname, string name)
        {
            _setNutzer();
            IQueryable<Nutzer> query = _loader.DatabaseDataContext.Nutzers.Where(n => n.IdNutzer == _nutzerID);
            foreach ( Nutzer user in query)
            {
                user.Name = name;
                user.Vorname = vorname;
            }
            _loader.DatabaseDataContext.SubmitChanges();
            return Index();
        }
    }
}
