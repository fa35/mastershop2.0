using System;
using System.Configuration;
using System.IO;
using MasterShop20.Website.Database;
using Newtonsoft.Json;

namespace MasterShop20.Website.Infrastructure
{
    public class DatabaseManager
    {
        public MasterShopDataContext GetDataContext()
        {
            try
            {
                var con = ConfigurationManager.AppSettings["connection"];

                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dbcs.txt");
                var content = "Data Source=TARRAFT-05\\SQLEXPRESSSERVER;Initial Catalog=MasterShopDb;Integrated Security=True\"providerName = \"System.Data.SqlClient";
                var json = JsonConvert.SerializeObject(content);

                string wanted_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

                File.WriteAllText(path, content);


                return new MasterShopDataContext(con);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}