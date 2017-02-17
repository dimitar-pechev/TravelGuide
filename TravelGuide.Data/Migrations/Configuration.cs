using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;

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
            var admin = new IdentityRole("admin");
            var user = new IdentityRole("user");

            context.Roles.Add(admin);
            context.Roles.Add(user);

            context.SaveChanges();
        }
    }
}
