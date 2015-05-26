using Addicto.DataService.Business;
using Addicto.DataService.Model;
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
        public string Get(string query)
        {
            System.Threading.Thread.Sleep(2000);

            Article foundArticle = this._articleService.GetBestMatch(new Model.ArticleQuery()
            {
                QueryText = query
            });

            if (foundArticle != null)
            {
                return foundArticle.Content;
            }
            else
            {
                return String.Empty;
            }
        }

        // POST api/articles
        public void Post([FromBody]string value)
        {
        }
    }
}
