namespace QuizApp.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AnswerMaster", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.AnswerMaster", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.QuestionMaster", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.QuestionMaster", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.QuizGenerated", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.QuizGenerated", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.QuizMaster", "ExpireDate", c => c.DateTime());
            AlterColumn("dbo.QuizMaster", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.QuizMaster", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.ResultMaster", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.ResultMaster", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.SubjectChild", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.SubjectChild", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.SubjectMaster", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.SubjectMaster", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.User", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.User", "UpdatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.User", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SubjectMaster", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SubjectMaster", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SubjectChild", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SubjectChild", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ResultMaster", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ResultMaster", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.QuizMaster", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.QuizMaster", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.QuizMaster", "ExpireDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.QuizGenerated", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.QuizGenerated", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.QuestionMaster", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.QuestionMaster", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AnswerMaster", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AnswerMaster", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
