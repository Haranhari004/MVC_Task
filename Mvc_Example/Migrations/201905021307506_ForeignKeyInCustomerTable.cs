namespace Mvc_Example.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ForeignKeyInCustomerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembershipTypeid", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeid");
            AddForeignKey("dbo.Customers", "MembershipTypeid", "dbo.MembershipTypes", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeid", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeid" });
            DropColumn("dbo.Customers", "MembershipTypeid");
        }
    }
}
