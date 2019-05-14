namespace Mvc_Example.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertIntoMembershipTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert MembershipTypes (MembershipTypeName, Amount, DurationInMonth, Discount) values ('PayAsYouGo',0,0,0)");
            Sql("Insert MembershipTypes (MembershipTypeName, Amount, DurationInMonth, Discount) values ('Monthly',100,1,5)");
            Sql("Insert MembershipTypes (MembershipTypeName, Amount, DurationInMonth, Discount) values ('Quaterely',300,3,10)");
            Sql("Insert MembershipTypes (MembershipTypeName, Amount, DurationInMonth, Discount) values ('Half-Yearly',600,6,15)");
            Sql("Insert MembershipTypes (MembershipTypeName, Amount,DurationInMonth, Discount) values ('Yearly',1200,12,20)");
        }
        
        public override void Down()
        {

        }
    }
}
