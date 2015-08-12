using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.DataService.Api.Contracts
{
    public class Article
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Content { get; set; }
    }
}
