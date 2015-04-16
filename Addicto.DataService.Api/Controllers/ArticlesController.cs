using Addicto.DAL;
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
        // GET api/articles/5
        public string Get(int id)
        {
            return "value";
        }

        // GET api/articles?query=some_query
        public string Get(string query)
        {
            using (var db = new AddictoDBContext())
            {
                AddictoWord foundWord = db.AddictoWords.FirstOrDefault(k => k.Key == query);

                if (foundWord != null)
                {
                    return foundWord.Value;
                }
                else 
                {
                    return String.Empty;
                }
            }
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
