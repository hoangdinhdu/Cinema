namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateacc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "Hoten", c => c.String());
            AddColumn("dbo.Accounts", "SDT", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "SDT");
            DropColumn("dbo.Accounts", "Hoten");
        }
    }
}
