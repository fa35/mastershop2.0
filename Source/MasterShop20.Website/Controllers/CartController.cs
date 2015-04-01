using System.Collections.Generic;
using System.Web.Mvc;
using MasterShop20.Website.Converter;
using MasterShop20.Website.Infrastructure;
using MasterShop20.Website.Models;

namespace MasterShop20.Website.Controllers
{
    public class CartController : Controller // Warenkorb
    {
        // GET: /Cart/

        private DataLoader _loader;
        private CookieManager _manager;
        private ModelsConverter _converter;

        public CartController()
        {
            _loader = new DataLoader();
            _manager = new CookieManager();
            _converter = new ModelsConverter(_loader);
        }


        public ActionResult Index()
        {   
            // hole Ids der Artikel in der serialisierten String-Liste
            var stringList = _manager.LoadArticlesIds();

            if(stringList == null)
                return View("../Home/Index");

            var avms = new List<ArticleViewModel>();

            foreach (var stringId in stringList)
            {
                var article = _loader.GetArticleById(int.Parse(stringId));
                avms.Add(_converter.ConvertArticleToArticleViewModel(article));
            }

            return View("Index", avms);
        }


        public void AddArticleToCart(int articleId)
        {
            _manager.SetArticleIdInCookie(articleId);
        }

        public void RemoveArticleFromCart(int articleId)
        {
            _manager.RemoveArticleIdInCookie(articleId);
        }

    }
}
