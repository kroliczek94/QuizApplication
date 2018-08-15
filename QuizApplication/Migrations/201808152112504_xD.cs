namespace QuizApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xD : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistoryEntries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ended = c.DateTime(nullable: false),
                        UserId = c.String(),
                        Score = c.Int(nullable: false),
                        Time = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        Answer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Questions");
            DropTable("dbo.HistoryEntries");
        }
    }
}
