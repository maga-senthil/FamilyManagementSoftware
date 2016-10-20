namespace FamilyManagementSoftware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newnigration22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Chores = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.KidsChores", "ChoreId", c => c.Int(nullable: false));
            CreateIndex("dbo.KidsChores", "ChoreId");
            AddForeignKey("dbo.KidsChores", "ChoreId", "dbo.Chores", "Id", cascadeDelete: true);
            DropColumn("dbo.KidsChores", "Chores");
        }
        
        public override void Down()
        {
            AddColumn("dbo.KidsChores", "Chores", c => c.String());
            DropForeignKey("dbo.KidsChores", "ChoreId", "dbo.Chores");
            DropIndex("dbo.KidsChores", new[] { "ChoreId" });
            DropColumn("dbo.KidsChores", "ChoreId");
            DropTable("dbo.Chores");
        }
    }
}
