using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MasterShop20.Website.Database;

namespace MasterShop20.Website.Models
{
    public class ArticleViewModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PicLink { get; set; }
        public decimal Price { get; set; }


        public ArticleViewModel ToViewModel(Artikel artikel, decimal steuersatz = 19)
        {
            return new ArticleViewModel
            {
                ArticleId = artikel.IdArtikel,
                Title = artikel.Titel,
                Description = artikel.Beschreibung.Length > 100 ? artikel.Beschreibung.Substring(0, 100) : artikel.Beschreibung,
                PicLink = artikel.BildLink,
                Price = Math.Round(artikel.NettoPreis + (100 / artikel.NettoPreis * steuersatz), 2)
            };
        }
    }
}