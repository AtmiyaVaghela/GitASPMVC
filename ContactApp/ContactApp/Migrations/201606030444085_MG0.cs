namespace ContactApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MG0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        Address = c.String(),
                        Town = c.String(),
                        City = c.String(),
                        Pincode = c.String(),
                        Photo = c.String(),
                        MobileNo = c.String(),
                        HomeNo = c.String(),
                        EmailId = c.String(),
                        BirthDate = c.DateTime(),
                        NirvanTithi = c.DateTime(),
                        BloodGroup = c.String(),
                        Education = c.String(),
                        InterestedIn = c.String(),
                        GurukulSanstha = c.String(),
                        SwaminarayanSampradaay = c.String(),
                        RWSanints = c.String(),
                        PoliticalConnections = c.String(),
                        KnownSaints = c.String(),
                        ReligiousPlaces = c.String(),
                        DevoteeCategory = c.String(),
                        SevaSahyog = c.String(),
                        RId = c.Int(nullable: false),
                        Relation = c.String(),
                        CreatedBy = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactCards");
        }
    }
}
