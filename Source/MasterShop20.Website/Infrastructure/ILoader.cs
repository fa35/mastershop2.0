using System.Collections.Generic;
using System.Data.Linq;
using MasterShop20.Website.Database;
using MasterShop20.Website.Models;

namespace MasterShop20.Website.Infrastructure
{
    public interface ILoader
    {
        bool CheckIfUserExists(Login login);
        bool CheckRegistrationData(Registration registration);

        Nutzer GetNutzerByLogin(Login login);
        Nutzer CreateNutzer(Registration registration);
        Nutzer GetNutzerById(int idUser);

        List<Artikel> GetArticlesByIds(List<int> idsArticles);
        List<Artikel> GetArticlesList(int page, int amount);
        List<Artikel> GetArticlesListByGroups(int page, int amount, string subgroupName);
        Artikel GetArticleById(int idArticle);

        Dictionary<string, List<string>> GetGroups();
        decimal GetSteuersatz(int idSteuersatz);
        Bestellung GetBestellungByUserId(int idUser);
        List<BestellungsDetail> GetDetailsByBestellungsId(int idBestellung);
    } 
}