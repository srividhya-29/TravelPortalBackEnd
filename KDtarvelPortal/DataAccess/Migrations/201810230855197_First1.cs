namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TravelRequests", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.TravelRequests", "ProjectId");
            AddForeignKey("dbo.TravelRequests", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TravelRequests", "ProjectId", "dbo.Projects");
            DropIndex("dbo.TravelRequests", new[] { "ProjectId" });
            DropColumn("dbo.TravelRequests", "ProjectId");
        }
    }
}
