namespace QuizApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModificationQuestion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Questions", "HistoryEntry_ID", "dbo.HistoryEntries");
            DropIndex("dbo.Questions", new[] { "HistoryEntry_ID" });
            DropColumn("dbo.Questions", "HistoryEntry_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Questions", "HistoryEntry_ID", c => c.Int());
            CreateIndex("dbo.Questions", "HistoryEntry_ID");
            AddForeignKey("dbo.Questions", "HistoryEntry_ID", "dbo.HistoryEntries", "ID");
        }
    }
}
