namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rentals", name: "Movie_Id", newName: "MovieId");
           
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Rentals", name: "IX_MovieId", newName: "IX_Movie_Id");

        }
    }
}
