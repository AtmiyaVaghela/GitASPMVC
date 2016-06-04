namespace ContactApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MG1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactCards", "RId", c => c.Int());
            AlterColumn("dbo.ContactCards", "CreatedBy", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactCards", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.ContactCards", "RId", c => c.Int(nullable: false));
        }
    }
}
