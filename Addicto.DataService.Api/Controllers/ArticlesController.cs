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
            if (query == "TABLE1")
            {
                return "This is the first table";
            }
            else if (query == "TABLE2")
            {
                return "This is the second table";
            }
            else
            {
                return "";
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
