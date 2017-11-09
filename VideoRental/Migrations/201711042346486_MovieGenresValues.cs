namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieGenresValues : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (2, 'Thriller')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (3, 'Family')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (4, 'Romance')");
            Sql("INSERT INTO MovieGenres (Id, Name) VALUES (5, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
