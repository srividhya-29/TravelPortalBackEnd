namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TravelRequests", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.TravelRequests", "ProjectId", "dbo.Projects");
            DropIndex("dbo.TravelRequests", new[] { "EmployeeId" });
            DropIndex("dbo.TravelRequests", new[] { "ProjectId" });
            AddColumn("dbo.TravelRequests", "EmployeeProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.TravelRequests", "EmployeeProjectId");
            AddForeignKey("dbo.TravelRequests", "EmployeeProjectId", "dbo.EmployeesProjects", "Id", cascadeDelete: true);
            DropColumn("dbo.TravelRequests", "EmployeeId");
            DropColumn("dbo.TravelRequests", "ProjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TravelRequests", "ProjectId", c => c.Int(nullable: false));
            AddColumn("dbo.TravelRequests", "EmployeeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TravelRequests", "EmployeeProjectId", "dbo.EmployeesProjects");
            DropIndex("dbo.TravelRequests", new[] { "EmployeeProjectId" });
            DropColumn("dbo.TravelRequests", "EmployeeProjectId");
            CreateIndex("dbo.TravelRequests", "ProjectId");
            CreateIndex("dbo.TravelRequests", "EmployeeId");
            AddForeignKey("dbo.TravelRequests", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.TravelRequests", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
    }
}
