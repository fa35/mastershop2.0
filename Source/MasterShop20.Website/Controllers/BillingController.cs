using System.Web.Mvc;
using MasterShop20.Website.Models;

namespace MasterShop20.Website.Controllers
{
    public class BillingController : Controller
    {
        //
        // GET: /Billing/

        public ActionResult Bill()
        {
            var rvm = new RechnungViewModel();
            rvm.Name = "Rechnungsname";

            return View("Payment", rvm);
        }

    }

    
}
