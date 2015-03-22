using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MasterShop20.Website.Database;
using NLog;

namespace MasterShop20.Website.Infrastructure
{
    public class DataLoader
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
                var logger = LogManager.GetLogger("logger");
                logger.Log(LogLevel.Fatal, "Es konnte kein Conncetionstring  gefunden werden!", ex);
                return null;
            }
        }
    }
}