namespace OpenOrderFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Factory : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BOXFACTORies", newName: "Factories");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Factories", newName: "BOXFACTORies");
        }
    }
}
