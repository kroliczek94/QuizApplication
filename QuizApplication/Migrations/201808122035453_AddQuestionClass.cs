namespace QuizApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuestionClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HistoryEntries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
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
                        HistoryEntry_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HistoryEntries", t => t.HistoryEntry_ID)
                .Index(t => t.HistoryEntry_ID);
            
            DropTable("dbo.MyEntities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MyEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Test = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Questions", "HistoryEntry_ID", "dbo.HistoryEntries");
            DropIndex("dbo.Questions", new[] { "HistoryEntry_ID" });
            DropTable("dbo.Questions");
            DropTable("dbo.HistoryEntries");
        }
    }
}
