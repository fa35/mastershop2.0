using System;
using System.Net.Security;
using System.Text.RegularExpressions;
using MasterShop20.Website.Database;

namespace MasterShop20.GetDataTool.Infrastructure
{
    public class Creator
    {
        public Artikel CreateArticle(string webcontent, string listtype)
        {
            string beschreibung;
            var artikel = CreatorHelper.GetMainArtikel(listtype, out beschreibung);

            // todo title

            // " müssen maskiert werden -> z.B. durch \" also von " nach \"
            // dementsprechend müssen \ auch maskiert werden, das kann wieder durch \ gemacht werden -> \\
            // var titlepattern = "<strong\\sclass=\"js_prd_shortname\">*\\w*</strong>";
            var titlePattern = "<strong\\sclass=\"js_prd_shortname\">^*\\w.*</strong>";
            var start = "<strong class=\"js_prd_shortname\">";
            var end = "</strong>";

            var title = GetValueAsString(webcontent, titlePattern, start, end);

            if (!string.IsNullOrEmpty(title))
                artikel.Titel = title;
            else
                return null;


            // todo preis

            var pricePattern = "\\sitemprop=\"price\">^*\\d*";
            start = "itemprop=\"price\"> ";
            end = "itemprop=\"price\">";

            var brutto = GetValueAsString(webcontent, pricePattern, start, end);

            decimal bruttopreis = 0m;
            decimal.TryParse(brutto, out bruttopreis);

            if (bruttopreis == null || bruttopreis <= 1)
                return null;

            var netto = (decimal)bruttopreis / 119 * 100;
            artikel.NettoPreis = Math.Round(netto, 2);



            // todo otto artikel nr

            var ottoArtPattern = "<span\\sitemprop=\"productID\"\\s*content=\"sku:*\\d+";
            start = "<span itemprop=\"productID\"\n";
            end = "content=\"sku:";

            var artnr = GetValueAsString(webcontent, ottoArtPattern, start, end);

            var a = artnr.Replace(" ", string.Empty);

            if (string.IsNullOrEmpty(a))
                return null;

            int nr = 0;

            int.TryParse(a, out nr);

            if (nr <= 1)
                return null;

            artikel.IdOriginal = nr;



            // todo link zum bild

            var bildLinkPattern = "<meta\\sname=\"og:image\"\\scontent=\"\\w*.*\">";
            start = "<meta name=\"og:image\" content=\"";
            end = "\">";

            var link = GetValueAsString(webcontent, bildLinkPattern, start, end);

            if (string.IsNullOrEmpty(link))
                return null;

            artikel.BildLink = link;



            // todo beschreibung wenn vorhanden

            var beschreibungPattern = "js_variationDescription\">\\r\\n^.?\\s*\\w*\\s\\w*.*";
            start = "js_variationDescription\">";
            end = "\\r\\n";

            var besch = GetValueAsString(webcontent, beschreibungPattern, start, end);

            if (string.IsNullOrEmpty(besch))
                besch = beschreibung; // von ganz oben

            artikel.Beschreibung = besch;

            return artikel;
        }


        private string GetValueAsString(string content, string pattern, string startpart, string endpart)
        {
            var result = string.Empty;
            var regex = new Regex(pattern);

            var m = regex.Match(content);
            var s = m.ToString();
            result = s.Replace(startpart, string.Empty).Replace(endpart, string.Empty);

            if (string.IsNullOrEmpty(result) || result.Length < 2)
                return null;
            return result;

        }

    }
}
