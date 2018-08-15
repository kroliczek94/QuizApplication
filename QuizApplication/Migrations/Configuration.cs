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
            context.Questions.AddOrUpdate<Question>(cc => cc.Body, new Question() { Body = "Czy moskiewski Kreml jest wpisany na listê Œwiatowego Dziedzictwa UNESCO?", Answer = true });
            context.Questions.AddOrUpdate<Question>(cc => cc.Body, new Question() { Body = "Czy przez £ódŸ przep³ywa rzeka £ódka?", Answer = true });
            context.Questions.AddOrUpdate<Question>(cc => cc.Body, new Question() { Body = "Czy któreœ pañstwo Ameryki Pó³nocnej ma status monarchii konstytucyjnej?", Answer = true });
            context.Questions.AddOrUpdate<Question>(cc => cc.Body, new Question() { Body = "Czy genera³owie Jan Henryk D¹browski i Jaros³aw D¹browski byli braæmi? ", Answer = false });
            context.Questions.AddOrUpdate<Question>(cc => cc.Body, new Question() { Body = "Czy król Stanis³aw August Poniatowski przyst¹pi³ do konfederacji barskiej?", Answer = false });

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
