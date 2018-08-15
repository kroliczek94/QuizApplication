namespace QuizApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuizApplication.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(QuizApplication.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Questions.AddOrUpdate<Question>(cc => cc.Body, new Question() { Body = "Czy moskiewski Kreml jest wpisany na list� �wiatowego Dziedzictwa UNESCO?", Answer = true });
            context.Questions.AddOrUpdate<Question>(cc => cc.Body, new Question() { Body = "Czy przez ��d� przep�ywa rzeka ��dka?", Answer = true });
            context.Questions.AddOrUpdate<Question>(cc => cc.Body, new Question() { Body = "Czy kt�re� pa�stwo Ameryki P�nocnej ma status monarchii konstytucyjnej?", Answer = true });
            context.Questions.AddOrUpdate<Question>(cc => cc.Body, new Question() { Body = "Czy genera�owie Jan Henryk D�browski i Jaros�aw D�browski byli bra�mi? ", Answer = false });
            context.Questions.AddOrUpdate<Question>(cc => cc.Body, new Question() { Body = "Czy kr�l Stanis�aw August Poniatowski przyst�pi� do konfederacji barskiej?", Answer = false });

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
