using Addicto.DataService.Api.Contracts;
using Addicto.DataService.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.UI.Utils
{
    public class DataServiceFacade : IDataServiceFacade
    {
        public async Task<Article> FindArticleAsync(string query)
        {
            var proxy = new ArticleProxy();
            return await proxy.GetAsync(query);
        }
    }
}
