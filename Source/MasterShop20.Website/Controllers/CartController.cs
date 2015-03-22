using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterShop20.Website.Database;
using MasterShop20.Website.Infrastructure;
using MasterShop20.Website.Models;
using Newtonsoft.Json;

namespace MasterShop20.Website.Controllers
{
    public class CartController : Controller // Warenkorb
    {
        //
        // GET: /Cart/

        private DataLoader _organizer;

        public CartController()
        {
            _organizer = new DataLoader();
        }


        public ActionResult Index()
        {

            // prüfe ob articles cookie gesetzt ist
            if (Request.Cookies["articles"] == null)
                return View("../Home/Index");

            var ids = LoadArticlesIdFromCookie();

            var articles = new List<Artikel>();

            foreach (var id in ids)
                articles.Add(_organizer.GetArticleById(id));

            var avms = new List<ArticleViewModel>();

            foreach (var art in articles)
            {
                var steuersatz = _organizer.GetSteuersatz(art.IdSteuersatz);
                avms.Add(new ArticleViewModel().ToViewModel(art, steuersatz));
            }

            return View("Index", avms);

        }


        public bool AddArticleToCart(int articleId)
        {
            var idsList = new List<int>();

            // prüfe ob articles cookie gesetzt ist, wenn ja hole ids aus cookie
            if (Request.Cookies["articles"] != null)
                idsList = LoadArticlesIdFromCookie();

            idsList.Add(articleId);

            // füge neues cookie articles hinzu bzw. überschreibe wenn schon da
            SaveArticlesIdInCookie(idsList);

            return true;
        }


        public bool RemoveArticleFromCart(int articleId)
        {
            // prüfe ob articles cookie gesetzt ist
            if (Request.Cookies["articles"] == null)
                return false;

            // deserializiere die bisherigen article ids aus dem json im cookie
            var list = LoadArticlesIdFromCookie();

            list.Remove(articleId);

            SaveArticlesIdInCookie(list);

            return true;
        }


        private void SaveArticlesIdInCookie(List<int> list)
        {
            var content = JsonConvert.SerializeObject(list);
            Response.Cookies.Add(new HttpCookie("articles") { Value = content });
        }

        private List<int> LoadArticlesIdFromCookie()
        {
            var articlesId = Request.Cookies["articles"].Value;
            var ids = JsonConvert.DeserializeObject<List<int>>(articlesId);

            return ids;
        }
    }
}
