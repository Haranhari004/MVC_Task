namespace Mvc_Example.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTypetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        MembershipTypeName = c.String(),
                        Amount = c.Single(nullable: false),
                        DurationInMonth = c.Int(nullable: false),
                        Discount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MembershipTypes");
        }
    }
}
