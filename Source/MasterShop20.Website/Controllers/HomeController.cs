using System.Web.Mvc;
using MasterShop20.Website.Infrastructure;

namespace MasterShop20.Website.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/

        private DbOrganizer _organizer;

        public ActionResult Index()
        {
            _organizer = new DbOrganizer();
            var articles = _organizer.GetArticles();

            return View("Index", articles);
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
