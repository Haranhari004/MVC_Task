namespace Mvc_Example.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyInMovieTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Movies", "Genreid", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "Genreid");
            AddForeignKey("dbo.Movies", "Genreid", "dbo.Genres", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genreid", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genreid" });
            DropColumn("dbo.Movies", "Genreid");
            DropTable("dbo.Genres");
        }
    }
}
