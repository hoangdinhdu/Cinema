namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
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
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "hinhthucID", "dbo.HinhThucThanhToans");
            DropIndex("dbo.Customer", new[] { "hinhthucID" });
            DropColumn("dbo.Customer", "hinhthucID");
            DropTable("dbo.HinhThucThanhToans");
        }
    }
}
