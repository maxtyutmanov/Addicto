using Addicto.DataService.Dal;
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
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(AddictoDBContext context)
        {
            context.Articles.Add(new DataService.Model.Article()
            {
                Key = "SK_SKOD_ZAHTEVEK",
                Content = "Таблица с убытками"
            });
        }
    }
}
