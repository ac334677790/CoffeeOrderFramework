namespace OpenOrderFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "email_addr", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "memo_doc", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "memo_doc", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "email_addr", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
