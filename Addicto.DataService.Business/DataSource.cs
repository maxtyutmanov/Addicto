using Addicto.DataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.DataService.Business
{
    public abstract class DataSource
    {
        protected readonly ArticleQuery _query;

        public DataSource(ArticleQuery query)
        {
            _query = query;
        }

        public abstract List<Article> ExecuteQuery();
    }
}
