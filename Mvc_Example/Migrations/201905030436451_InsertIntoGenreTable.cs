namespace Mvc_Example.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertIntoGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Genres (name) values ('Action')");
            Sql("Insert Genres (name) values ('Romantic')");
            Sql("Insert Genres (name) values ('Thriller')");
            Sql("Insert Genres (name) values ('Science Fiction')");
        }
        
        public override void Down()
        {
        }
    }
}
