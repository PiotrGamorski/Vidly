namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedBirthdate : DbMigration
    {
        public override void Up()
        {
            Sql("SET DATEFORMAT dmy");
            Sql("UPDATE dbo.Customers SET Birthdate = CAST('1980-01-01' AS DATE) WHERE Id = 1");
        }
        
        public override void Down()
        {
            Sql("UPDATE dbo.Customers SET Birthday = NULL WHERE Id =1");
        }
    }
}
