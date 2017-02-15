using System.Collections.Generic;
using System.Data.Entity.Migrations;
using TravelGuide.Models;

namespace TravelGuide.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TravelGuideContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TravelGuideContext context)
        {
        }
    }
}
