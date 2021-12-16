namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDV : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DatVes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        MovieID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movies", t => t.MovieID)
                .Index(t => t.MovieID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DatVes", "MovieID", "dbo.Movies");
            DropIndex("dbo.DatVes", new[] { "MovieID" });
            DropTable("dbo.DatVes");
        }
    }
}
