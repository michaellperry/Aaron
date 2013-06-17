namespace Aaron.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Caregivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(maxLength: 25),
                        AuthorizationRequested = c.Boolean(nullable: false),
                        Authorized = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Caregivers");
        }
    }
}
