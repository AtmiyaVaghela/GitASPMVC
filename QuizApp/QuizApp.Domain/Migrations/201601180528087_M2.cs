namespace QuizApp.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AuthenticationMasters", newName: "AuthenticationMaster");
            RenameTable(name: "dbo.Users", newName: "User");
            CreateTable(
                "dbo.AnswerGiven",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuizGeneratedID = c.Int(nullable: false),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.QuizGenerated",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuizId = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                        Trial = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.QuizMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubjectID = c.Int(nullable: false),
                        ChapterID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        NoOfQuestion = c.Int(nullable: false),
                        MaxTrial = c.Int(nullable: false),
                        Trial = c.Int(nullable: false),
                        MinResult = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ResultMaster",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        QuizMasterId = c.Int(nullable: false),
                        Trial = c.Int(nullable: false),
                        Result = c.Int(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResultMaster");
            DropTable("dbo.QuizMaster");
            DropTable("dbo.QuizGenerated");
            DropTable("dbo.AnswerGiven");
            RenameTable(name: "dbo.User", newName: "Users");
            RenameTable(name: "dbo.AuthenticationMaster", newName: "AuthenticationMasters");
        }
    }
}
