namespace OpenOrderFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class company2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Companies", "area", c => c.String(maxLength: 10));
            AlterColumn("dbo.Companies", "country_no", c => c.String(maxLength: 3));
            AlterColumn("dbo.Companies", "area_no", c => c.String(maxLength: 1));
            AlterColumn("dbo.Companies", "tel_no", c => c.String(maxLength: 15));
            AlterColumn("dbo.Companies", "fax_no", c => c.String(maxLength: 15));
            AlterColumn("dbo.Companies", "c_addr", c => c.String(maxLength: 150));
            AlterColumn("dbo.Companies", "www_addr", c => c.String(maxLength: 150));
            AlterColumn("dbo.Companies", "email_addr", c => c.String(maxLength: 50));
            AlterColumn("dbo.Companies", "Bis_time_S", c => c.String(maxLength: 5));
            AlterColumn("dbo.Companies", "Bis_time_E", c => c.String(maxLength: 5));
            AlterColumn("dbo.Companies", "create_user_id", c => c.String(maxLength: 14));
            AlterColumn("dbo.Companies", "create_datetime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Companies", "modify_user_id", c => c.String(maxLength: 14));
            AlterColumn("dbo.Companies", "modify_datetime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Companies", "modify_datetime", c => c.String(nullable: false));
            AlterColumn("dbo.Companies", "modify_user_id", c => c.String(nullable: false, maxLength: 14));
            AlterColumn("dbo.Companies", "create_datetime", c => c.String(nullable: false));
            AlterColumn("dbo.Companies", "create_user_id", c => c.String(nullable: false, maxLength: 14));
            AlterColumn("dbo.Companies", "Bis_time_E", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Companies", "Bis_time_S", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Companies", "email_addr", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Companies", "www_addr", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Companies", "c_addr", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Companies", "fax_no", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Companies", "tel_no", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Companies", "area_no", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.Companies", "country_no", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Companies", "area", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
