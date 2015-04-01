using System;
using System.Web;
using System.Web.Mvc;

namespace MasterShop20.Website.Infrastructure
{
    public class CookieManager : Controller
    {

        public void RemoveCookies()
        {
            if (CheckArticlesCookie())
                Response.Cookies["articles"].Expires = DateTime.Now.AddDays(-1);

            if (CheckUserCookie())
                Response.Cookies["user"].Expires = DateTime.Now.AddDays(-1);
        }

        public bool CheckUserCookie()
        {
            if (Request != null && Request.Cookies["user"] != null)
                return true;

            return false;
        }

        public bool CheckArticlesCookie()
        {
            if (Request != null && Request.Cookies["articles"] != null)
                return true;

            return false;
        }

        public void SetUserCookie(int idUser)
        {
            if (Response != null)
                Response.Cookies.Add(new HttpCookie("user") { Value = idUser.ToString() });
        }

        public int LoadUserCookie()
        {
            var id = 0;

            if (!CheckUserCookie())
                return id;

            int.TryParse(Request.Cookies["user"].Value, out id);
            return id;
        }
    }
}