namespace ContactBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserMasters", "PID", c => c.Int(nullable: false));
            AlterColumn("dbo.UserMasters", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.UserMasters", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserMasters", "LastName", c => c.String());
            AlterColumn("dbo.UserMasters", "FirstName", c => c.String());
            DropColumn("dbo.UserMasters", "PID");
        }
    }
}
