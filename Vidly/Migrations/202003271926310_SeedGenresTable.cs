namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Thriller')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Family')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Romance')");
            Sql("INSERT INTO dbo.Genres (Name) VALUES ('Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
