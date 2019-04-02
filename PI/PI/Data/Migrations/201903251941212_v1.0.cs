namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Task", "ProjectFK", "dbo.Project");
            DropIndex("dbo.Task", new[] { "ProjectFK" });
            RenameColumn(table: "dbo.Task", name: "ProjectFK", newName: "Project_ProjectId");
            AlterColumn("dbo.Task", "Project_ProjectId", c => c.Int());
            CreateIndex("dbo.Task", "Project_ProjectId");
            AddForeignKey("dbo.Task", "Project_ProjectId", "dbo.Project", "ProjectId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "Project_ProjectId", "dbo.Project");
            DropIndex("dbo.Task", new[] { "Project_ProjectId" });
            AlterColumn("dbo.Task", "Project_ProjectId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Task", name: "Project_ProjectId", newName: "ProjectFK");
            CreateIndex("dbo.Task", "ProjectFK");
            AddForeignKey("dbo.Task", "ProjectFK", "dbo.Project", "ProjectId", cascadeDelete: true);
        }
    }
}
