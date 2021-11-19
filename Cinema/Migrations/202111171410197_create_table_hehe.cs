namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_hehe : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Account", newName: "Accounts");
            DropPrimaryKey("dbo.Accounts");
            AddColumn("dbo.Customer", "MovieID", c => c.String());
            AddColumn("dbo.Customer", "MovieName", c => c.String());
            AddColumn("dbo.Customer", "MovieHour", c => c.String());
            AddColumn("dbo.Customer", "MovieMoney", c => c.Single());
            AddColumn("dbo.Customer", "MovieSeat", c => c.String());
            AddColumn("dbo.Customer", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Accounts", "UserName", c => c.String(nullable: false, maxLength: 128, fixedLength: true));
            AlterColumn("dbo.Accounts", "PassWord", c => c.String(maxLength: 128, fixedLength: true));
            AddPrimaryKey("dbo.Accounts", "UserName");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Accounts");
            AlterColumn("dbo.Accounts", "PassWord", c => c.String(maxLength: 10, fixedLength: true));
            AlterColumn("dbo.Accounts", "UserName", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
            DropColumn("dbo.Customer", "Discriminator");
            DropColumn("dbo.Customer", "MovieSeat");
            DropColumn("dbo.Customer", "MovieMoney");
            DropColumn("dbo.Customer", "MovieHour");
            DropColumn("dbo.Customer", "MovieName");
            DropColumn("dbo.Customer", "MovieID");
            AddPrimaryKey("dbo.Accounts", "UserName");
            RenameTable(name: "dbo.Accounts", newName: "Account");
        }
    }
}
