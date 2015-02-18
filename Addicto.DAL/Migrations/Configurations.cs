using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.DAL.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<AddictoDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AddictoDBContext context)
        {
            context.AddictoWords.AddOrUpdate(r => r.Key,
                new AddictoWord { Key = "Skode", Value = "Быстро" }
                );
        }
    }
}
