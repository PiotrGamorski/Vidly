namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentalProperly : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo._Rental",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo._Rental", "MovieId", "dbo.Movies");
            DropForeignKey("dbo._Rental", "CustomerId", "dbo.Customers");
            DropIndex("dbo._Rental", new[] { "MovieId" });
            DropIndex("dbo._Rental", new[] { "CustomerId" });
            DropTable("dbo._Rental");
        }
    }
}
