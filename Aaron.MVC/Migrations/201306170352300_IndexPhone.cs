namespace Aaron.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndexPhone : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Caregivers", "Phone", unique: true, name: "IX_Phone");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Caregivers", "IX_Phone");
        }
    }
}
