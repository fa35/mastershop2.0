using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterShop20.Website.Models
{
    public class DetailsViewModel
    {
        public string Name { get; set; }
        public decimal EinzelNettopreis { get; set; }
        public decimal MwSt { get; set; }
        public decimal GesamtNettopreis { get; set; }
        public decimal GesamtBruttopreis { get; set; }
        public int Anzahl { get; set; }

        public DetailsViewModel ToViewModel(string name, decimal nettopreis, decimal mwst, int anzahl)
        {
            return new DetailsViewModel
            {
                Name = name,
                EinzelNettopreis = nettopreis,
                MwSt = mwst,
                GesamtNettopreis = anzahl*nettopreis,
                GesamtBruttopreis = this.GesamtNettopreis + (this.GesamtNettopreis/100*mwst),
                Anzahl = anzahl
            };
        }
    }
}