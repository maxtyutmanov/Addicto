using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.UI.Utils
{
    public class DataServiceFacade : IDataServiceFacade
    {
        public async Task<string> FindArticleAsync(string query)
        {
            var proxy = new DataService.Client.Proxies.Clients.ArticlesClient();

            var response = await proxy.GetAsync(query);
            var result = await response.Content.ReadAsStringAsync();

            return result;
        }
    }
}
