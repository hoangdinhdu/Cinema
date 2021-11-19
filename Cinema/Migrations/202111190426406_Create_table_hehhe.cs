namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_table_hehhe : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customer", newName: "Movies");
            DropPrimaryKey("dbo.Movies");
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 20),
                        CustomerName = c.String(maxLength: 50),
                        CustomerPhone = c.Int(nullable: false),
                        CustomerAddress = c.String(maxLength: 50),
                        CustomerEmail = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.String(nullable: false, maxLength: 128),
                        CustomerID = c.String(),
                        MovieID = c.String(),
                    })
                .PrimaryKey(t => t.ReservationID);
            
            AlterColumn("dbo.Movies", "MovieID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Movies", "MovieMoney", c => c.Single(nullable: false));
            AddPrimaryKey("dbo.Movies", "MovieID");
            DropColumn("dbo.Movies", "CustomerID");
            DropColumn("dbo.Movies", "CustomerName");
            DropColumn("dbo.Movies", "CustomerPhone");
            DropColumn("dbo.Movies", "CustomerAddress");
            DropColumn("dbo.Movies", "CustomerEmail");
            DropColumn("dbo.Movies", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Movies", "CustomerEmail", c => c.String(maxLength: 50));
            AddColumn("dbo.Movies", "CustomerAddress", c => c.String(maxLength: 50));
            AddColumn("dbo.Movies", "CustomerPhone", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "CustomerName", c => c.String(maxLength: 50));
            AddColumn("dbo.Movies", "CustomerID", c => c.String(nullable: false, maxLength: 20));
            DropPrimaryKey("dbo.Movies");
            AlterColumn("dbo.Movies", "MovieMoney", c => c.Single());
            AlterColumn("dbo.Movies", "MovieID", c => c.String());
            DropTable("dbo.Reservations");
            DropTable("dbo.Customer");
            AddPrimaryKey("dbo.Movies", "CustomerID");
            RenameTable(name: "dbo.Movies", newName: "Customer");
        }
    }
}
