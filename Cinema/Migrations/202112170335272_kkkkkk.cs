namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kkkkkk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "MovieID", "dbo.Movies");
            DropIndex("dbo.Customer", new[] { "MovieID" });
            DropTable("dbo.Customer");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 20),
                        CustomerName = c.String(maxLength: 50),
                        CustomerPhone = c.String(),
                        CustomerAddress = c.String(maxLength: 50),
                        CustomerEmail = c.String(maxLength: 50),
                        MovieID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateIndex("dbo.Customer", "MovieID");
            AddForeignKey("dbo.Customer", "MovieID", "dbo.Movies", "MovieID");
        }
    }
}
