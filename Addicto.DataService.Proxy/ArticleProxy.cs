using Addicto.DataService.Api.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.DataService.Client
{
    public class ArticleProxy
    {
        private Uri _articlesBaseUrl;
        private Uri ArticlesBaseUrl
        {
            get
            {
                if (_articlesBaseUrl == null)
                {
                    string urlStr = String.Format("{0}/api/articles", DataServiceProxyConfig.RootUrl);
                    _articlesBaseUrl = new Uri(urlStr);
                }
                
                return _articlesBaseUrl;
            }
        }

        public async Task<Article> GetAsync(string query)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                client.QueryString["query"] = query;
                string responseText = await client.DownloadStringTaskAsync(ArticlesBaseUrl);

                if (!String.IsNullOrEmpty(responseText))
                {
                    return JsonConvert.DeserializeObject<Article>(responseText);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
