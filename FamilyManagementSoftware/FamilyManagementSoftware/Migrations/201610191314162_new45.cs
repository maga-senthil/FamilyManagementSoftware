namespace FamilyManagementSoftware.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new45 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KidsChores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Chores = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KidsChores");
        }
    }
}
