namespace Aaron.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessagesPerDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Caregivers", "LastMessageDate", c => c.DateTime());
            AddColumn("dbo.Caregivers", "MessagesToday", c => c.Int(nullable: false, defaultValue: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Caregivers", "MessagesToday");
            DropColumn("dbo.Caregivers", "LastMessageDate");
        }
    }
}
