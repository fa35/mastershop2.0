﻿using System.Collections.Generic;
using System.Web.Mvc;
using MasterShop20.Website.Database;
using MasterShop20.Website.Infrastructure;
using MasterShop20.Website.Models;

namespace MasterShop20.Website.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/

        private DbOrganizer _organizer;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetArticleViewModels(int page = 0, int amount = 10)
        {
            _organizer = new DbOrganizer();
            var articles = _organizer.GetArticles(page, amount);
            var vms = new List<ArticleViewModel>();

            foreach (var artikel in articles)
            {
                var satz = _organizer.GetSteuersatz(artikel.IdSteuersatz);

                vms.Add(satz != null
                    ? new ArticleViewModel().ToViewModel(artikel, satz)
                    : new ArticleViewModel().ToViewModel(artikel)
                    );
            }
            return PartialView("_ArticlesList", vms);
        }
        

        public string GetArticleDescription(string articleId)
        {
            _organizer = new DbOrganizer();

            var id = 0;
            int.TryParse(articleId, out id);

            var article = _organizer.GetArticleById(id);

            return article != null ? article.Beschreibung : "";
        }


        public ActionResult GetGroupesFormMenu()
        {
            _organizer = new DbOrganizer();
            var dic = _organizer.GetGroups();
            return PartialView("_NavigationGroups", dic);
        } // == GetNavigationModel


        public List<Artikel> GetArticles(int page = 1, int amount = 10)
        {
            return new List<Artikel>();
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

    }

}
