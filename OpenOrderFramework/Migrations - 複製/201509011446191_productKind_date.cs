namespace OpenOrderFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productKind_date : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductKinds", "create_datetime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductKinds", "modify_datetime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductKinds", "modify_datetime", c => c.String(nullable: false));
            AlterColumn("dbo.ProductKinds", "create_datetime", c => c.String(nullable: false));
        }
    }
}
