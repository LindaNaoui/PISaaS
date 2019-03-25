namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v30 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "NomComplet_Nom", c => c.String());
            AddColumn("dbo.Client", "NomComplet_Prenom", c => c.String());
            DropColumn("dbo.Client", "LastName");
            DropColumn("dbo.Client", "FirstName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "FirstName", c => c.String());
            AddColumn("dbo.Client", "LastName", c => c.String());
            DropColumn("dbo.Client", "NomComplet_Prenom");
            DropColumn("dbo.Client", "NomComplet_Nom");
        }
    }
}
