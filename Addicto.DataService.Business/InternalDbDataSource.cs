using Addicto.DataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.DataService.Business
{
    public class InternalDbDataSource : DataSource
    {
        public InternalDbDataSource(ArticleQuery query)
            : base(query)
        {

        }

        public override List<Model.Article> ExecuteQuery()
        {
            throw new NotImplementedException();
        }
    }
}
