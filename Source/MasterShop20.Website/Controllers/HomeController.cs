using System.Web;
using System.Web.Mvc;

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
