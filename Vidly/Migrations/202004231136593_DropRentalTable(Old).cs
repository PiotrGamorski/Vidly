namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropRentalTableOld : DbMigration
    {
        public override void Up()
        {
            Sql("DROP TABLE dbo.Rentals");
        }
        
        public override void Down()
        {
        }
    }
}
