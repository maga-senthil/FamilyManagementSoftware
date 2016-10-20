namespace FamilyManagementSoftware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new99 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FamilyChores",
                c => new
                    {
                        Family_Id = c.Int(nullable: false),
                        Chore_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Family_Id, t.Chore_Id })
                .ForeignKey("dbo.Families", t => t.Family_Id, cascadeDelete: true)
                .ForeignKey("dbo.Chores", t => t.Chore_Id, cascadeDelete: true)
                .Index(t => t.Family_Id)
                .Index(t => t.Chore_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FamilyChores", "Chore_Id", "dbo.Chores");
            DropForeignKey("dbo.FamilyChores", "Family_Id", "dbo.Families");
            DropIndex("dbo.FamilyChores", new[] { "Chore_Id" });
            DropIndex("dbo.FamilyChores", new[] { "Family_Id" });
            DropTable("dbo.FamilyChores");
            DropTable("dbo.Families");
        }
    }
}
