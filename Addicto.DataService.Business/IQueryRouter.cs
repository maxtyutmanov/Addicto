using Addicto.DataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.DataService.Business
{
    public interface IQueryRouter
    {
        DataSource RouteQuery(ArticleQuery query);
    }
}
