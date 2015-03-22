using System.Collections.Generic;
using MasterShop20.Website.Database;

namespace MasterShop20.Website.Models
{
    public class RechnungViewModel
    {
        public int BestellungId { get; set; }
        public string Datum { get; set; }
        public string Bestellungsart { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Adresse { get; set; }
        public List<DetailsViewModel> Details { get; set; }

        public RechnungViewModel ToViewModel(Bestellung bestellung, List<DetailsViewModel> details)
        {
            return new RechnungViewModel
            {
                BestellungId = bestellung.IdBestellung,
                Datum = bestellung.Datum.ToShortDateString(),
                Bestellungsart = "Paypal",
                Name = bestellung.ReName,
                Vorname = bestellung.ReVorname,
                Adresse = bestellung.ReStrasseNr + " - " + bestellung.RePlzOrt,
                Details = details
            };
        }
    }
}