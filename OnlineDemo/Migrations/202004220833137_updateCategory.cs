namespace OnlineDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "IsDeleted");
        }
    }
}
