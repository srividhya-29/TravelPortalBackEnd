namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ClientName = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Byte(nullable: false, identity: true),
                        DesignationType = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 50),
                        WorkLocation = c.String(nullable: false, maxLength: 25),
                        Address = c.String(nullable: false, maxLength: 4000),
                        MobNo = c.String(nullable: false, maxLength: 8000, unicode: false),
                        FatherName = c.String(nullable: false, maxLength: 4000),
                        MotherName = c.String(nullable: false, maxLength: 4000),
                        PortalPassword = c.String(maxLength: 4000),
                        DesignationId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.EmployeesProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(nullable: false, maxLength: 50),
                        InchargeId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Employees", t => t.InchargeId)
                .Index(t => t.InchargeId);
            
            CreateTable(
                "dbo.FinanceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CashInAdvance = c.Decimal(nullable: false, storeType: "money"),
                        BudgetAllocated = c.Decimal(nullable: false, storeType: "money"),
                        TravelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TravelRequests", t => t.TravelId, cascadeDelete: true)
                .Index(t => t.TravelId);
            
            CreateTable(
                "dbo.TravelRequests",
                c => new
                    {
                        TravelId = c.Int(nullable: false, identity: true),
                        TravelRequestName = c.String(nullable: false, maxLength: 4000),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Place = c.String(nullable: false, maxLength: 4000),
                        InvitationLetterPath = c.String(maxLength: 4000),
                        TravelTypeId = c.Byte(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        StatusId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.TravelId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Statuses", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.TravelTypes", t => t.TravelTypeId, cascadeDelete: true)
                .Index(t => t.TravelTypeId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ClientId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Statuses",
                c => new
                    {
                        StatusId = c.Byte(nullable: false, identity: true),
                        Message = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.TravelTypes",
                c => new
                    {
                        TravelTypeId = c.Byte(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 4000),
                    })
                .PrimaryKey(t => t.TravelTypeId);
            
            CreateTable(
                "dbo.InvitationLetterFormats",
                c => new
                    {
                        InvitationLetterFormatId = c.Byte(nullable: false, identity: true),
                        LetterContent = c.String(nullable: false, maxLength: 4000),
                        DesignationId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.InvitationLetterFormatId)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false, maxLength: 4000),
                        RecievedAt = c.DateTime(nullable: false),
                        TravelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NotificationId)
                .ForeignKey("dbo.TravelRequests", t => t.TravelId, cascadeDelete: true)
                .Index(t => t.TravelId);
            
            CreateTable(
                "dbo.VFSPortalEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VFSLoginId = c.String(nullable: false, maxLength: 4000),
                        VFSLoginPassword = c.String(nullable: false, maxLength: 4000),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.WorkFlows",
                c => new
                    {
                        WorkFlowId = c.Int(nullable: false, identity: true),
                        Role = c.String(nullable: false, maxLength: 4000),
                        CurrentStatusId = c.Byte(),
                        NextStatusId = c.Byte(),
                    })
                .PrimaryKey(t => t.WorkFlowId)
                .ForeignKey("dbo.Statuses", t => t.CurrentStatusId)
                .ForeignKey("dbo.Statuses", t => t.NextStatusId)
                .Index(t => t.CurrentStatusId)
                .Index(t => t.NextStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkFlows", "NextStatusId", "dbo.Statuses");
            DropForeignKey("dbo.WorkFlows", "CurrentStatusId", "dbo.Statuses");
            DropForeignKey("dbo.VFSPortalEntries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Notifications", "TravelId", "dbo.TravelRequests");
            DropForeignKey("dbo.InvitationLetterFormats", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.FinanceDetails", "TravelId", "dbo.TravelRequests");
            DropForeignKey("dbo.TravelRequests", "TravelTypeId", "dbo.TravelTypes");
            DropForeignKey("dbo.TravelRequests", "StatusId", "dbo.Statuses");
            DropForeignKey("dbo.TravelRequests", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.TravelRequests", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.EmployeesProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "InchargeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeesProjects", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropIndex("dbo.WorkFlows", new[] { "NextStatusId" });
            DropIndex("dbo.WorkFlows", new[] { "CurrentStatusId" });
            DropIndex("dbo.VFSPortalEntries", new[] { "EmployeeId" });
            DropIndex("dbo.Notifications", new[] { "TravelId" });
            DropIndex("dbo.InvitationLetterFormats", new[] { "DesignationId" });
            DropIndex("dbo.TravelRequests", new[] { "StatusId" });
            DropIndex("dbo.TravelRequests", new[] { "ClientId" });
            DropIndex("dbo.TravelRequests", new[] { "EmployeeId" });
            DropIndex("dbo.TravelRequests", new[] { "TravelTypeId" });
            DropIndex("dbo.FinanceDetails", new[] { "TravelId" });
            DropIndex("dbo.Projects", new[] { "InchargeId" });
            DropIndex("dbo.EmployeesProjects", new[] { "ProjectId" });
            DropIndex("dbo.EmployeesProjects", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropTable("dbo.WorkFlows");
            DropTable("dbo.VFSPortalEntries");
            DropTable("dbo.Notifications");
            DropTable("dbo.InvitationLetterFormats");
            DropTable("dbo.TravelTypes");
            DropTable("dbo.Statuses");
            DropTable("dbo.TravelRequests");
            DropTable("dbo.FinanceDetails");
            DropTable("dbo.Projects");
            DropTable("dbo.EmployeesProjects");
            DropTable("dbo.Employees");
            DropTable("dbo.Designations");
            DropTable("dbo.Clients");
        }
    }
}
