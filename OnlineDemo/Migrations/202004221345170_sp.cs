namespace OnlineDemo.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class sp : DbMigration
	{
		public override void Up()
		{
			CreateStoredProcedure(
				"dbo.Product_GetProductCategoryData",
				p => new
				{
					OffsetValue=p.Int(),
					PagingSize=p.Int()
				},
				body: @"SELECT ProductId
						,ProductName
						,Products.CategoryId
						,(
							SELECT CategoryName
							FROM Categories
							WHERE CategoryId = Products.CategoryId
							) AS CategoryName
					FROM Products
					LEFT JOIN Categories ON Products.CategoryId = Categories.CategoryId
					order by ProductId
					OFFSET @OffsetValue ROWS FETCH NEXT @PagingSize ROWS ONLY

					SELECT count(ProductId) AS TotalRecords
					FROM Products"
				);
			
			
		}
		
		public override void Down()
		{
			
		}
	}
}
