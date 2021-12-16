namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hehehhehehehehehe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "hinhthucID", "dbo.HinhThucThanhToans");
            DropIndex("dbo.Customer", new[] { "hinhthucID" });
            DropColumn("dbo.Customer", "hinhthucID");
            DropTable("dbo.HinhThucThanhToans");
            DropTable("dbo.Reservations");
        }
        
        public override void Down()
        {
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
                "dbo.HinhThucThanhToans",
                c => new
                    {
                        hinhthucID = c.String(nullable: false, maxLength: 128),
                        LoaiHinhThuc = c.String(),
                    })
                .PrimaryKey(t => t.hinhthucID);
            
            AddColumn("dbo.Customer", "hinhthucID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customer", "hinhthucID");
            AddForeignKey("dbo.Customer", "hinhthucID", "dbo.HinhThucThanhToans", "hinhthucID");
        }
    }
}
