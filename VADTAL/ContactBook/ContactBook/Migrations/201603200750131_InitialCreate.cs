namespace ContactBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserMasters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        ContactNo = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        NativeAddress = c.String(),
                        Email = c.String(),
                        Reference = c.String(),
                        BirthOfDate = c.DateTime(nullable: false),
                        ExDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Education = c.String(),
                        Occupation = c.String(),
                        Designation = c.String(),
                        CompanyName = c.String(),
                        WorkAddress = c.String(),
                        UID = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserMasters");
        }
    }
}
