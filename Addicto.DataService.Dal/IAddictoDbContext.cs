using Addicto.DataService.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.DataService.Dal
{
    public interface IAddictoDbContext
    {
        DbSet<Article> Articles { get; }
    }
}
