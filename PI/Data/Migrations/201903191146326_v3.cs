namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Clientid = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        M_Managerid = c.Int(),
                    })
                .PrimaryKey(t => t.Clientid)
                .ForeignKey("dbo.Managers", t => t.M_Managerid)
                .Index(t => t.M_Managerid);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Managerid = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Managerid);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        Start_Date = c.DateTime(nullable: false),
                        End_Date = c.DateTime(nullable: false),
                        Duration = c.String(),
                        Description = c.String(),
                        C_Clientid = c.Int(),
                        Team_TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Client", t => t.C_Clientid)
                .ForeignKey("dbo.Teams", t => t.Team_TeamId)
                .Index(t => t.C_Clientid)
                .Index(t => t.Team_TeamId);
            
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        DocumentName = c.String(),
                        Type = c.String(),
                        Path = c.String(),
                        Project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId)
                .Index(t => t.Project_ProjectId);
            
            CreateTable(
                "dbo.Phases",
                c => new
                    {
                        PhaseId = c.Int(nullable: false, identity: true),
                        PhaseName = c.String(),
                        Start_Date = c.DateTime(nullable: false),
                        End_Date = c.DateTime(nullable: false),
                        Duration = c.String(),
                        Description = c.String(),
                        P_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.PhaseId)
                .ForeignKey("dbo.Projects", t => t.P_ProjectId)
                .Index(t => t.P_ProjectId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        Start_Date = c.DateTime(nullable: false),
                        End_Date = c.DateTime(nullable: false),
                        Duration = c.String(),
                        Estimation = c.String(),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        T_TaskId = c.Int(),
                        Project_ProjectId = c.Int(),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.Tasks", t => t.T_TaskId)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId)
                .Index(t => t.T_TaskId)
                .Index(t => t.Project_ProjectId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "Team_TeamId", "dbo.Teams");
            DropForeignKey("dbo.Tasks", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "T_TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Phases", "P_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Document", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "C_Clientid", "dbo.Client");
            DropForeignKey("dbo.Client", "M_Managerid", "dbo.Managers");
            DropIndex("dbo.Tasks", new[] { "Project_ProjectId" });
            DropIndex("dbo.Tasks", new[] { "T_TaskId" });
            DropIndex("dbo.Phases", new[] { "P_ProjectId" });
            DropIndex("dbo.Document", new[] { "Project_ProjectId" });
            DropIndex("dbo.Projects", new[] { "Team_TeamId" });
            DropIndex("dbo.Projects", new[] { "C_Clientid" });
            DropIndex("dbo.Client", new[] { "M_Managerid" });
            DropTable("dbo.Teams");
            DropTable("dbo.Tasks");
            DropTable("dbo.Phases");
            DropTable("dbo.Document");
            DropTable("dbo.Projects");
            DropTable("dbo.Managers");
            DropTable("dbo.Client");
        }
    }
}
