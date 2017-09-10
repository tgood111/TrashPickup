namespace TrashPickUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExceptionDays : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExceptionDays",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        User = c.Guid(nullable: false),
                        Exception = c.DateTime(nullable: false),
                        ExceptionDay_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExceptionDays", t => t.ExceptionDay_Id)
                .Index(t => t.ExceptionDay_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExceptionDays", "ExceptionDay_Id", "dbo.ExceptionDays");
            DropIndex("dbo.ExceptionDays", new[] { "ExceptionDay_Id" });
            DropTable("dbo.ExceptionDays");
        }
    }
}
