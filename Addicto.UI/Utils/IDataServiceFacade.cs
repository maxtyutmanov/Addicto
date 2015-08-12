using Addicto.DataService.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.UI.Utils
{
    public interface IDataServiceFacade
    {
        Task<Article> FindArticleAsync(string query);
    }
}
