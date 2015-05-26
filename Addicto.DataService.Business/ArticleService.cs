using Addicto.DataService.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.DataService.Business
{
    public class ArticleService : IArticleService
    {
        private readonly IAddictoDbContext _dbContext;

        public ArticleService()
            : this(new AddictoDBContext())
        {
        }

        public ArticleService(IAddictoDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Model.Article GetBestMatch(Model.ArticleQuery query)
        {
            string conStr = (_dbContext as System.Data.Entity.DbContext).Database.Connection.ConnectionString;
            return _dbContext.Articles.FirstOrDefault(x => x.Key == query.QueryText);
        }
    }
}
