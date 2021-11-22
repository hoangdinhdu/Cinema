namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_hehe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        PassWord = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 30),
                        CustomerName = c.String(maxLength: 50),
                        CustomerDate = c.String(),
                        CustomerPhone = c.String(maxLength: 15),
                        CustomerAddress = c.String(maxLength: 50),
                        CustomerEmail = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.String(nullable: false, maxLength: 30),
                        MovieName = c.String(maxLength: 50),
                        MovieTime = c.String(maxLength: 50),
                        MovieMoney = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MovieID);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.String(nullable: false, maxLength: 30),
                        CustomerID = c.String(),
                        MovieID = c.String(),
                        SeatID = c.String(),
                    })
                .PrimaryKey(t => t.ReservationID);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatID = c.String(nullable: false, maxLength: 30),
                        SeatRoom = c.String(maxLength: 30),
                        SeatName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.SeatID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Seats");
            DropTable("dbo.Reservations");
            DropTable("dbo.Movies");
            DropTable("dbo.Customers");
            DropTable("dbo.Account");
        }
    }
}
