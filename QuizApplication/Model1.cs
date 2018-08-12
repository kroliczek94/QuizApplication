namespace QuizApplication
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'QuizApplication.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=Model1")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Model1, QuizApplication.Migrations.Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Question> Questions { get; set; }
         public virtual DbSet<HistoryEntry> Entries { get; set; }
    }

    public class Question
    {
        public int ID { get; set; }
        public string Body { get; set; }
        public bool Answer { get; set; }
    }

   
    public class HistoryEntry
    {
        public int ID { get; set; }
        public DateTime Ended { get; set; }
        public string UserId { get; set; }
        public int Score { get; set; }
        public float Time { get; set; }
    }

}