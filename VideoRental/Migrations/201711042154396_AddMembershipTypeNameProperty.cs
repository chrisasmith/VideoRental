namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeNameProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "name");
        }
    }
}
