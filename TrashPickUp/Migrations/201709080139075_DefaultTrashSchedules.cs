namespace TrashPickUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefaultTrashSchedules : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DefaultTrashSchedules",
                c => new
                    {
                        User = c.Guid(nullable: false),
                        Day = c.Int(nullable: false),
                        DefaultTrashSchedule_User = c.Guid(),
                    })
                .PrimaryKey(t => t.User)
                .ForeignKey("dbo.DefaultTrashSchedules", t => t.DefaultTrashSchedule_User)
                .Index(t => t.DefaultTrashSchedule_User);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DefaultTrashSchedules", "DefaultTrashSchedule_User", "dbo.DefaultTrashSchedules");
            DropIndex("dbo.DefaultTrashSchedules", new[] { "DefaultTrashSchedule_User" });
            DropTable("dbo.DefaultTrashSchedules");
        }
    }
}
