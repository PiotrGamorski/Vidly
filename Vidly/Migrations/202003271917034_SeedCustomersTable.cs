namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCustomersTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Customers (Name,  IsSubscribedToNewletter, MembershipTypeId)" +
                "VALUES ('John Smith','False',1)");
            Sql("INSERT INTO dbo.Customers (Name, IsSubscribedToNewletter, MembershipTypeId)" +
                "VALUES ('Mary Williams','True',2)");
        }
        
        public override void Down()
        {
        }
    }
}
