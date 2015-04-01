using System.Collections.Generic;
using System.Web.Mvc;
using MasterShop20.Website.Infrastructure;
using MasterShop20.Website.Models;

namespace MasterShop20.Website.Controllers
{
    public class BillingController : Controller
    {
        // GET: /Billing/

        public ActionResult Bill()
        {
            var manager = new CookieManager();

            // in LoadUserCookie wird überprüft, ob das Cookie gesetzt ist und wenn ja wird der Inhalt zurückgegeben, sonst wird 0 zurückgegeben
            var nutzerId = manager.LoadUserCookie();

            if (nutzerId == 0)
                return View("Login");

            // hole notwendige Daten zum Erstellen der Rechnung
            
            var loader = new DataLoader();
            
            // hole Bestellung des Nutzers
            var bestellung = loader.GetBestellungByUserId(nutzerId);
            // hole die BestellugsDetails der Bestellung
            var details = loader.GetDetailsByBestellungsId(bestellung.IdBestellung);

            var detailsVms = new List<DetailsViewModel>();
            
            // wandle jedes Details in eine DetailsViewModel um und füge es der Liste hinzu
            foreach (var d in details)
                detailsVms.Add(new DetailsViewModel().ToViewModel(d.ArtikelName, d.NettoPreis, d.MwSt, d.Anzahl));

            // erstelle ein RechnungViewModel mit den Daten 
            var rvm = new RechnungViewModel().ToViewModel(bestellung, detailsVms);

            // todo: der View ist unfertig bzw. wurde nur zur Probe erstellt
            return View("Payment", rvm);
        }
    

    }


}
