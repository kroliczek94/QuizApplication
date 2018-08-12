namespace QuizApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MyEntities", "Test", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MyEntities", "Test");
        }
    }
}
