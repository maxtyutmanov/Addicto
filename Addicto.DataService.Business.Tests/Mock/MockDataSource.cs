using Addicto.DataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.DataService.Business.Tests
{
    public class MockDataSource : DataSource
    {
        private List<Article> _articles;

        public MockDataSource(ArticleQuery query)
            : base(query)
        {
            _articles = new List<Article>()
            {
                new Article() { Id = 1, Key = "SK_SKOD_ZAHTEVEK", Content = "Таблица с убытками" },
                new Article() { Id = 2, Key = "SK_SKOD_SPIS", Content = "Таблица с выплатными делами" }
            };
        }

        public override List<Model.Article> ExecuteQuery()
        {
            return _articles
                .Where(x => x.Key == _query.QueryText)
                .ToList();
        }
    }
}
