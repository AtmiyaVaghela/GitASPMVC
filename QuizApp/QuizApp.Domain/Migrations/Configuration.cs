namespace QuizApp.Domain.Migrations
{
    using QuizApp.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuizApp.Domain.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "QuizApp.Domain.Concrete.EFDbContext";
        }

        protected override void Seed(QuizApp.Domain.Concrete.EFDbContext dbContext)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            dbContext.User.AddOrUpdate(
                u => u.UserName,
                new User { ID = new Guid(), UserName = "advaghela", FullName = "Atmiya Vaghela", EmailID = "atmiya@live.com", Role = "SU" }
                );
        }
    }
}
