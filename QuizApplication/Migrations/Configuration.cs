namespace QuizApplication.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuizApplication.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(QuizApplication.Model1 context)
        {
         
            context.Questions.AddOrUpdate<Question>(new Question() { Body = "Czy 2+2 = 4", Answer = true });
            context.Questions.AddOrUpdate<Question>(new Question() { Body = "Czy 2+5 = 6", Answer = false });
            context.Questions.AddOrUpdate<Question>(new Question() { Body = "Czy 2+3 = 3", Answer = false });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
