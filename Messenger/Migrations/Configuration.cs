namespace Messenger.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Messenger.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Messenger.Data.AppDbContext context)
        {

           /* context.Users.Add(new Models.User()
            {
                FirstName = "Frist Test",

            });

            context.Users.Add(new Models.User()
            {
                FirstName = "Second Test",

            });

            context.Users.Add(new Models.User()
            {
                FirstName = "Third Test",

            });*/




            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
