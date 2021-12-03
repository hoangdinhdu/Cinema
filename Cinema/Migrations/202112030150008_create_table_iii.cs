namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_iii : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "MovieID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Customer", "CustomerPhone", c => c.String());
            CreateIndex("dbo.Customer", "MovieID");
            AddForeignKey("dbo.Customer", "MovieID", "dbo.Movies", "MovieID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "MovieID", "dbo.Movies");
            DropIndex("dbo.Customer", new[] { "MovieID" });
            AlterColumn("dbo.Customer", "CustomerPhone", c => c.Int(nullable: false));
            DropColumn("dbo.Customer", "MovieID");
        }
    }
}
