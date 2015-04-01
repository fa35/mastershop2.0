using System.Collections.Generic;
using System.Web.Mvc;
using MasterShop20.Website.Converter;
using MasterShop20.Website.Database;
using MasterShop20.Website.Infrastructure;
using MasterShop20.Website.Models;

namespace MasterShop20.Website.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/

        private DataLoader _loader;
        private CookieManager _manager;
        private ModelsConverter _converter;

        public HomeController()
        {
            _loader = new DataLoader();

            _manager = new CookieManager();
            _manager.RemoveCookies();

            _converter = new ModelsConverter(_loader);
        }


        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetArticleViewModels(int page = 0, int amount = 10, string subgroupName = "")
        {
            var articles = _loader.GetArticlesList(page, amount, subgroupName);

            var vms = new List<ArticleViewModel>();

            foreach (var article in articles)
                vms.Add(_converter.ConvertArticleToArticleViewModel(article));
            
            return PartialView("_ArticlesList", vms);
        }


        public string GetArticleDescription(string articleId)
        {
            int id;
            int.TryParse(articleId, out id);
            var article = _loader.GetArticleById(id);
            // wenn article != null dann return article.Bescheschreibung, sonst ""
            return article != null ? article.Beschreibung : "";
        }


        public ActionResult GetNavigationGroups()
        {
            return PartialView("_NavigationGroups", _loader.GetGroups());
        }


        public ActionResult Logout()
        {
            _manager.RemoveCookies();
            return View("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }


        #region Impressum, Datenschutz, AGBs

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

        #endregion

    }

}
