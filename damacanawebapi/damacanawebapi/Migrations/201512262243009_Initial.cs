namespace damacanawebapi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cartproducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        price = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        CartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CartId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        totalprice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.cartproducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.cartproducts", "CartId", "dbo.Carts");
            DropIndex("dbo.cartproducts", new[] { "CartId" });
            DropIndex("dbo.cartproducts", new[] { "ProductId" });
            DropTable("dbo.Purchases");
            DropTable("dbo.Products");
            DropTable("dbo.cartproducts");
        }
    }
}
