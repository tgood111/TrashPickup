namespace TrashPickUp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnChanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "Address", newName: "Street");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "Street", newName: "Address");
        }
    }
}
