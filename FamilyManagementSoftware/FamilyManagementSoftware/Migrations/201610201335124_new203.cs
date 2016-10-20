namespace FamilyManagementSoftware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new203 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chores", "FamilyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Chores", "FamilyId");
            AddForeignKey("dbo.Chores", "FamilyId", "dbo.Families", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chores", "FamilyId", "dbo.Families");
            DropIndex("dbo.Chores", new[] { "FamilyId" });
            DropColumn("dbo.Chores", "FamilyId");
        }
    }
}
