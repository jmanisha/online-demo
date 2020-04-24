namespace OnlineDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmodel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Categories_CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Categories_CategoryId" });
            DropColumn("dbo.Products", "CategoryId");
            RenameColumn(table: "dbo.Products", name: "Categories_CategoryId", newName: "CategoryId");
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
            AlterColumn("dbo.Products", "CategoryId", c => c.Byte(nullable: false));
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Categories_CategoryId");
            AddColumn("dbo.Products", "CategoryId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Products", "Categories_CategoryId");
            AddForeignKey("dbo.Products", "Categories_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
