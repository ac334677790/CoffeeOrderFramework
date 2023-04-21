namespace OpenOrderFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class company : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartTTs", "ItemId", "dbo.Items");
            DropIndex("dbo.CartTTs", new[] { "ItemId" });
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        company_name = c.String(nullable: false, maxLength: 40),
                        for_short = c.String(nullable: false, maxLength: 20),
                        area = c.String(nullable: false, maxLength: 10),
                        country_no = c.String(nullable: false, maxLength: 3),
                        area_no = c.String(nullable: false, maxLength: 1),
                        tel_no = c.String(nullable: false, maxLength: 15),
                        fax_no = c.String(nullable: false, maxLength: 15),
                        c_addr = c.String(nullable: false, maxLength: 150),
                        www_addr = c.String(nullable: false, maxLength: 150),
                        email_addr = c.String(nullable: false, maxLength: 50),
                        Bis_time_S = c.String(nullable: false, maxLength: 5),
                        Bis_time_E = c.String(nullable: false, maxLength: 5),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.String(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.company_no);
            
            DropTable("dbo.CartTTs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CartTTs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ItemId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Test = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Companies");
            CreateIndex("dbo.CartTTs", "ItemId");
            AddForeignKey("dbo.CartTTs", "ItemId", "dbo.Items", "ID", cascadeDelete: true);
        }
    }
}
