namespace PlusUltra.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deployment : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Organization", new[] { "Name" });
            AlterColumn("dbo.Genre", "Description", c => c.String(maxLength: 100));
            AlterColumn("dbo.Organization", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organization", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Genre", "Description", c => c.String(maxLength: 50));
            CreateIndex("dbo.Organization", "Name", unique: true);
        }
    }
}
