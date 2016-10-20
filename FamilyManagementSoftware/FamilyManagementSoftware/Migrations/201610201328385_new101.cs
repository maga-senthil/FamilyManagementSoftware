namespace FamilyManagementSoftware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new101 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChoreDetails", "ChoreId", "dbo.Chores");
            DropForeignKey("dbo.ChoreDetails", "FamilyId", "dbo.Families");
            DropForeignKey("dbo.KidsChores", "ChoreId", "dbo.Chores");
            DropIndex("dbo.ChoreDetails", new[] { "FamilyId" });
            DropIndex("dbo.ChoreDetails", new[] { "ChoreId" });
            DropIndex("dbo.KidsChores", new[] { "ChoreId" });
            AddColumn("dbo.Chores", "Done", c => c.Boolean(nullable: false));
            DropTable("dbo.ChoreDetails");
            DropTable("dbo.KidsChores");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.KidsChores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ChoreId = c.Int(nullable: false),
                        Done = c.Boolean(nullable: false),
                        Sun = c.Boolean(nullable: false),
                        Mon = c.Boolean(nullable: false),
                        Tue = c.Boolean(nullable: false),
                        Wed = c.Boolean(nullable: false),
                        Thu = c.Boolean(nullable: false),
                        Fri = c.Boolean(nullable: false),
                        Sat = c.Boolean(nullable: false),
                        PointsEarned = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChoreDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FamilyId = c.Int(nullable: false),
                        ChoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Chores", "Done");
            CreateIndex("dbo.KidsChores", "ChoreId");
            CreateIndex("dbo.ChoreDetails", "ChoreId");
            CreateIndex("dbo.ChoreDetails", "FamilyId");
            AddForeignKey("dbo.KidsChores", "ChoreId", "dbo.Chores", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ChoreDetails", "FamilyId", "dbo.Families", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ChoreDetails", "ChoreId", "dbo.Chores", "Id", cascadeDelete: true);
        }
    }
}
