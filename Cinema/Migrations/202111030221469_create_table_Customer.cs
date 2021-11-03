namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_Customer : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customer");
            DropTable("dbo.Account");
        }
    }
}
