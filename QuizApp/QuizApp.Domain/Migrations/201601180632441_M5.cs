namespace QuizApp.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AuthenticationMaster", "UserID", "dbo.User");
            DropIndex("dbo.AuthenticationMaster", new[] { "UserID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.AuthenticationMaster", "UserID");
            AddForeignKey("dbo.AuthenticationMaster", "UserID", "dbo.User", "ID", cascadeDelete: true);
        }
    }
}
