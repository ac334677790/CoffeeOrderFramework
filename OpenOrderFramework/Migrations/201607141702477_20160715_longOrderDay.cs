namespace OpenOrderFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20160715_longOrderDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LongOrder_m", "CycleDay1", c => c.String(nullable: false, maxLength: 1));
            AddColumn("dbo.LongOrder_m", "CycleDay2", c => c.String(nullable: false, maxLength: 1));
            AddColumn("dbo.LongOrder_m", "CycleDay3", c => c.String(nullable: false, maxLength: 1));
            AddColumn("dbo.LongOrder_m", "CycleDay4", c => c.String(nullable: false, maxLength: 1));
            AddColumn("dbo.LongOrder_m", "CycleDay5", c => c.String(nullable: false, maxLength: 1));
            AddColumn("dbo.LongOrder_m", "CycleDay6", c => c.String(nullable: false, maxLength: 1));
            AddColumn("dbo.LongOrder_m", "CycleDay7", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.LongOrder_m", "CycleMonth", c => c.String(nullable: false, maxLength: 2));
            DropColumn("dbo.LongOrder_m", "CycleDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LongOrder_m", "CycleDay", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.LongOrder_m", "CycleMonth", c => c.String(nullable: false, maxLength: 1));
            DropColumn("dbo.LongOrder_m", "CycleDay7");
            DropColumn("dbo.LongOrder_m", "CycleDay6");
            DropColumn("dbo.LongOrder_m", "CycleDay5");
            DropColumn("dbo.LongOrder_m", "CycleDay4");
            DropColumn("dbo.LongOrder_m", "CycleDay3");
            DropColumn("dbo.LongOrder_m", "CycleDay2");
            DropColumn("dbo.LongOrder_m", "CycleDay1");
        }
    }
}
