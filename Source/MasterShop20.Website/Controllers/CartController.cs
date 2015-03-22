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
            var articlesId = string.Empty;
            // versuche aus den cookies die artikel ids zu holen
            if (Request.Cookies["articles"] != null)
                articlesId = Request.Cookies["articles"].Value;

            var ids = JsonConvert.DeserializeObject<List<int>>(articlesId);

            var articles = new List<Artikel>();

            foreach (var id in ids)
            {
                articles.Add(_organizer.GetArticleById(id));
            }

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
            var articlesId = string.Empty;
            // versuche aus den cookies die artikel ids zu holen
            if (Request.Cookies["articles"] != null)
                articlesId = Request.Cookies["articles"].Value;

            if (string.IsNullOrWhiteSpace(articlesId))
            {
                var list = new List<int>();
                list.Add(articleId);
                var content = JsonConvert.SerializeObject(list);
                Response.Cookies.Add(new HttpCookie("articles") { Value = content });
            }
            else
            {
                var articlesIdList = JsonConvert.DeserializeObject<List<int>>(articlesId);

                if (articlesIdList != null)
                    articlesIdList.Add(articleId);

                var content = JsonConvert.SerializeObject(articlesIdList);
                Response.Cookies.Add(new HttpCookie("articles") { Value = content });
            }
            return true;
        }


        public bool RemoveArticleFromCart(int articleId)
        {
            var articlesId = string.Empty;
            // versuche aus den cookies die artikel ids zu holen
            if (Request.Cookies["articles"] != null && !string.IsNullOrWhiteSpace(Request.Cookies["articles"].Value))
                articlesId = Request.Cookies["articles"].Value;
            else
                return false;

            var list = JsonConvert.DeserializeObject<List<int>>(articlesId);

            list.Remove(articleId);

            var content = JsonConvert.SerializeObject(list);
            Response.Cookies.Add(new HttpCookie("articles") { Value = content });
            return true;
        }


    }
}
