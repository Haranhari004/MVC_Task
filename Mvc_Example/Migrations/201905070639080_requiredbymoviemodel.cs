namespace Mvc_Example.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredbymoviemodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Moviename", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Moviename", c => c.String());
        }
    }
}
