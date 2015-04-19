using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.DAL
{
    public class AddictoDBContext : DbContext
    {
        public DbSet<AddictoWord> AddictoWords { get; set; }
    }
}
