using System;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using MasterShop20.Website.Database;

namespace MasterShop20.Website.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult PrivacyPolicy()
        {
            return View("PricacyPolicy");
        }
        
        public ActionResult LegalNotice()
        {
            return View("LegalNotice");
        }

        public ActionResult GeneralBusinessTerms()
        {
            return View("GeneralBusinessTerms");
        }

    }
}
