namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfMembershipTypesRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "name", c => c.String());
        }
    }
}
