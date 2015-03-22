using System;
using System.Configuration;
using MasterShop20.Website.Database;

namespace MasterShop20.Website.Infrastructure
{
    public class DatabaseManager
    {
        public MasterShopDataContext GetDataContext()
        {
            try
            {
                var con = ConfigurationManager.AppSettings["connection"];
                return new MasterShopDataContext(con);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}