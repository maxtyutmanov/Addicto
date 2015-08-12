using Addicto.DataService.Business;
//using Addicto.DataService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Addicto.DataService.Api.Controllers
{
    public class ArticlesController : ApiController
    {
        private readonly IArticleService _articleService;

        public ArticlesController()
            : this(new ArticleService())
        {
        }

        public ArticlesController(IArticleService articleService)
        {
            this._articleService = articleService;
        }

        // GET api/articles?query=some_query
        public Addicto.DataService.Api.Contracts.Article Get(string query)
        {
            Addicto.DataService.Model.Article foundArticle = this._articleService.GetBestMatch(new Model.ArticleQuery()
            {
                QueryText = query
            });

            if (foundArticle != null)
            {
                return new Contracts.Article()
                {
                    Id = foundArticle.Id,
                    Key = foundArticle.Key,
                    Content = foundArticle.Content
                };
            }
            else
            {
                return null;
            }
        }

        // POST api/articles
        public void Post([FromBody]string value)
        {
        }
    }
}
