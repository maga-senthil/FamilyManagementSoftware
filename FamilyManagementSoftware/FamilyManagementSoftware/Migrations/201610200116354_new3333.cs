namespace FamilyManagementSoftware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new3333 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FamilyChores", "Family_Id", "dbo.Families");
            DropForeignKey("dbo.FamilyChores", "Chore_Id", "dbo.Chores");
            DropIndex("dbo.FamilyChores", new[] { "Family_Id" });
            DropIndex("dbo.FamilyChores", new[] { "Chore_Id" });
            AddColumn("dbo.ChoreDetails", "FamilyId", c => c.Int(nullable: false));
            AddColumn("dbo.ChoreDetails", "ChoreId", c => c.Int(nullable: false));
            CreateIndex("dbo.ChoreDetails", "FamilyId");
            CreateIndex("dbo.ChoreDetails", "ChoreId");
            AddForeignKey("dbo.ChoreDetails", "ChoreId", "dbo.Chores", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ChoreDetails", "FamilyId", "dbo.Families", "Id", cascadeDelete: true);
            DropColumn("dbo.ChoreDetails", "Name");
            DropColumn("dbo.ChoreDetails", "Responsibility");
            DropColumn("dbo.ChoreDetails", "Sun");
            DropColumn("dbo.ChoreDetails", "Mon");
            DropColumn("dbo.ChoreDetails", "Tue");
            DropColumn("dbo.ChoreDetails", "Wed");
            DropColumn("dbo.ChoreDetails", "Thu");
            DropColumn("dbo.ChoreDetails", "Fri");
            DropColumn("dbo.ChoreDetails", "Sat");
            DropTable("dbo.FamilyChores");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FamilyChores",
                c => new
                    {
                        Family_Id = c.Int(nullable: false),
                        Chore_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Family_Id, t.Chore_Id });
            
            AddColumn("dbo.ChoreDetails", "Sat", c => c.Boolean(nullable: false));
            AddColumn("dbo.ChoreDetails", "Fri", c => c.Boolean(nullable: false));
            AddColumn("dbo.ChoreDetails", "Thu", c => c.Boolean(nullable: false));
            AddColumn("dbo.ChoreDetails", "Wed", c => c.Boolean(nullable: false));
            AddColumn("dbo.ChoreDetails", "Tue", c => c.Boolean(nullable: false));
            AddColumn("dbo.ChoreDetails", "Mon", c => c.Boolean(nullable: false));
            AddColumn("dbo.ChoreDetails", "Sun", c => c.Boolean(nullable: false));
            AddColumn("dbo.ChoreDetails", "Responsibility", c => c.String());
            AddColumn("dbo.ChoreDetails", "Name", c => c.String());
            DropForeignKey("dbo.ChoreDetails", "FamilyId", "dbo.Families");
            DropForeignKey("dbo.ChoreDetails", "ChoreId", "dbo.Chores");
            DropIndex("dbo.ChoreDetails", new[] { "ChoreId" });
            DropIndex("dbo.ChoreDetails", new[] { "FamilyId" });
            DropColumn("dbo.ChoreDetails", "ChoreId");
            DropColumn("dbo.ChoreDetails", "FamilyId");
            CreateIndex("dbo.FamilyChores", "Chore_Id");
            CreateIndex("dbo.FamilyChores", "Family_Id");
            AddForeignKey("dbo.FamilyChores", "Chore_Id", "dbo.Chores", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FamilyChores", "Family_Id", "dbo.Families", "Id", cascadeDelete: true);
        }
    }
}
