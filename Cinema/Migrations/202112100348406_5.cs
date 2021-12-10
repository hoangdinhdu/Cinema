namespace Cinema.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "MovieMoney", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "MovieMoney", c => c.Single(nullable: false));
        }
    }
}
