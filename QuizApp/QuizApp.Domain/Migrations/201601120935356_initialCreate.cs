namespace QuizApp.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthenticationMasters",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Password = c.String(nullable: false),
                        UserID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        FullName = c.String(nullable: false, maxLength: 100),
                        EmailID = c.String(nullable: false),
                        Role = c.String(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuthenticationMasters", "UserID", "dbo.Users");
            DropIndex("dbo.AuthenticationMasters", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.AuthenticationMasters");
        }
    }
}
