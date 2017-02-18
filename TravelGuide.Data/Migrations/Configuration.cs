using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using TravelGuide.Models.Articles;

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
            // seeding the roles
            var admin = new IdentityRole("admin");
            var user = new IdentityRole("user");

            context.Roles.Add(admin);
            context.Roles.Add(user);

            //// article
            //var article = new Article()
            //{
            //    Title = "Dive into the Beauty of the Eternal City",
            //    City = "Rome",
            //    Country = "Italy",
            //    Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aliquid vitae minima iusto non odio doloremque sapiente quas perferendis natus reprehenderit, quo ipsa nisi itaque hic ex, reiciendis aspernatur? Pariatur ad maiores velit corporis. Delectus, distinctio, autem. Eum quasi praesentium fugiat at a nobis, sed hic, repudiandae sequi consectetur minima excepturi doloribus. Nihil nam molestiae quisquam, maxime et dolore dignissimos enim quo cum commodi. Voluptatum eveniet dolore alias repellat natus enim molestiae ducimus aliquam. Itaque unde recusandae quasi sint adipisci nesciunt blanditiis nisi quos dignissimos, animi. Culpa maiores blanditiis incidunt sapiente, voluptatum autem suscipit iure impedit consectetur voluptatibus officia esse dolorum harum, distinctio ad sit ab repellendus iusto nesciunt sed nisi qui quas tempora. Nesciunt atque dicta odio soluta, cupiditate odit nostrum. Veritatis provident dignissimos harum maiores architecto expedita veniam rerum, illo, reprehenderit assumenda perspiciatis explicabo nisi ab dolores perferendis. Quos a cupiditate autem, accusamus sint et non nisi minus est quisquam maiores asperiores magni delectus dolor aut qui aliquid similique iste sed cum. Tempora velit optio reprehenderit similique nisi deleniti nostrum, architecto nam reiciendis quae rem impedit facere, itaque, pariatur repudiandae vero nihil numquam possimus dolor at ipsa necessitatibus! Mollitia magnam officiis, veritatis blanditiis reprehenderit suscipit in vitae iste sapiente!",
            //    ImageUrl = "http://media.cntraveler.com/photos/55d24b6f37284fb1079cbc20/4:3/w_500,c_limit/trevi-fountain-rome-night-cr-getty.jpg"
            //};

            //context.Articles.Add(article);
            
            context.SaveChanges();
        }
    }
}
