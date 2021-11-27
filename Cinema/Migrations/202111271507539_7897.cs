namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7897 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128, fixedLength: true),
                        Password = c.String(nullable: false, maxLength: 128, fixedLength: true),
                        ConfirmPassword = c.String(),
                        RoleID = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.UserName);
            
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
                "dbo.Giochieux",
                c => new
                    {
                        IDGioChieu = c.String(nullable: false, maxLength: 128),
                        ThoiGianChieu = c.String(),
                    })
                .PrimaryKey(t => t.IDGioChieu);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        MovieID = c.String(nullable: false, maxLength: 128),
                        MovieName = c.String(),
                        IDGioChieu = c.String(maxLength: 128),
                        MovieMoney = c.Single(nullable: false),
                        MovieSeat = c.String(),
                        ProductImageName = c.String(),
                    })
                .PrimaryKey(t => t.MovieID)
                .ForeignKey("dbo.Giochieux", t => t.IDGioChieu)
                .Index(t => t.IDGioChieu);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationID = c.String(nullable: false, maxLength: 128),
                        CustomerID = c.String(),
                        MovieID = c.String(),
                    })
                .PrimaryKey(t => t.ReservationID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.String(nullable: false, maxLength: 10),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "IDGioChieu", "dbo.Giochieux");
            DropIndex("dbo.Movies", new[] { "IDGioChieu" });
            DropTable("dbo.Roles");
            DropTable("dbo.Reservations");
            DropTable("dbo.Movies");
            DropTable("dbo.Giochieux");
            DropTable("dbo.Customer");
            DropTable("dbo.Accounts");
        }
    }
}
