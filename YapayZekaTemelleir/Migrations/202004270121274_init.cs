namespace YapayZekaTemelleir.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Country = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Gender = c.String(),
                        MomName = c.String(),
                        FatherName = c.String(),
                        Brother = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.People");
        }
    }
}
