using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Mvc;
using MasterShop20.Website.Database;
using MasterShop20.Website.Infrastructure;
using MasterShop20.Website.Models;

namespace MasterShop20.Website.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/

        private DataLoader _loader;

        public HomeController()
        {
            _loader = new DataLoader();
            RemoveCookies();
        }

        public ActionResult Index()
        {
            return View();
        }

        private void RemoveCookies()
        {
            if (Request != null)
            {
                if (Request.Cookies["articles"] != null)
                    Response.Cookies["articles"].Expires = DateTime.Now.AddDays(-1);

                if (Request.Cookies["user"] != null)
                    Response.Cookies["user"].Expires = DateTime.Now.AddDays(-1);
            }
        }

        public ActionResult GetArticleViewModels(int page = 0, int amount = 10, string subgroupName = "")
        {
            var articles = new List<Artikel>();
            
            if (!string.IsNullOrWhiteSpace(subgroupName))
                articles = _loader.GetArticleListByGroups(page, amount, subgroupName);
            else
                articles = _loader.GetArticleList(page, amount);

            var vms = new List<ArticleViewModel>();

            foreach (var artikel in articles)
            {
                var satz = _loader.GetSteuersatz(artikel.IdSteuersatz);
                vms.Add(new ArticleViewModel().ToViewModel(artikel, satz));
            }
            return PartialView("_ArticlesList", vms);
        }

        public string GetArticleDescription(string articleId)
        {
            var id = 0;
            int.TryParse(articleId, out id);

            var article = _loader.GetArticleById(id);

            return article != null ? article.Beschreibung : "";
        }

        public ActionResult GetNavigationGroups()
        {
            var dic = _loader.GetGroups();

            return PartialView("_NavigationGroups", dic);
        }

        public ActionResult Logout()
        {
            RemoveCookies();
            return View("Index");
        }


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


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }

    }

}
