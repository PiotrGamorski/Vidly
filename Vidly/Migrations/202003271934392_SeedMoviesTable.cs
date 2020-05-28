namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMoviesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Movies (Name, DateAdded, ReleaseDate, NumberInStock, GenreId)" +
               "VALUES ('Hangover', CAST('2009-10-06' AS DATE), CAST('2016-05-04' AS DATE), 5, 5)");

            Sql("INSERT INTO dbo.Movies (Name, DateAdded, ReleaseDate, NumberInStock, GenreId)" +
                "VALUES ('Die Hard', CAST('2009-10-06' AS DATE), CAST('2016-05-04' AS DATE), 10, 1)");

            Sql("INSERT INTO dbo.Movies (Name, DateAdded, ReleaseDate, NumberInStock, GenreId)" +
                "VALUES ('The Terminator', CAST('2009-10-06' AS DATE), CAST('2016-05-04' AS DATE), 33, 1)");

            Sql("INSERT INTO dbo.Movies (Name, DateAdded, ReleaseDate, NumberInStock, GenreId)" +
                "VALUES ('Toy Story', CAST('2009-10-06' AS DATE), CAST('2016-05-04' AS DATE), 7, 3)");

            Sql("INSERT INTO dbo.Movies (Name, DateAdded, ReleaseDate, NumberInStock, GenreId)" +
                "VALUES ('Titanic', CAST('2009-10-06' AS DATE), CAST('2016-05-04' AS DATE), 17, 4)");
        }
        
        public override void Down()
        {
        }
    }
}
