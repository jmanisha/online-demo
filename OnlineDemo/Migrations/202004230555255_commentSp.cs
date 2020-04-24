namespace OnlineDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentSp : DbMigration
    {
        public override void Up()
        {
            //DropStoredProcedure("dbo.Categories_Insert");
            //DropStoredProcedure("dbo.Categories_Update");
            //DropStoredProcedure("dbo.Categories_Delete");
            //DropStoredProcedure("dbo.Product_Insert");
            //DropStoredProcedure("dbo.Product_Update");
            //DropStoredProcedure("dbo.Product_Delete");
        }
        
        public override void Down()
        {
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
