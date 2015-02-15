using System.IO;
using System.Net;

namespace MasterShop20.GetDataTool.Infrastructure
{
    public class GetHtmlSite
    {

        public string DownloadPage(string url)
        {
            string websitecontent = string.Empty;

            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";

            using (var response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                using (var reader = new StreamReader(stream))
                {
                    websitecontent = reader.ReadToEnd();
                }
            }

            return websitecontent;
        }

    }
}
