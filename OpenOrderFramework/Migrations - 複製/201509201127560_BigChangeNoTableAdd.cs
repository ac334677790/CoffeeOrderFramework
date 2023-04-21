namespace OpenOrderFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BigChangeNoTableAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
    "dbo.Departments",
    c => new
    {
        CompanyID = c.String(nullable: false, maxLength: 6),
        DeptID = c.String(nullable: false, maxLength: 6),
        DeptName = c.String(nullable: false, maxLength: 30),
        ParentDeptID = c.String(maxLength: 6),
        DeptDirectorID = c.String(maxLength: 8),
        ValidDate = c.DateTime(nullable: false),
        InValidDate = c.DateTime(nullable: false),
        CreateUserID = c.String(nullable: false, maxLength: 14),
        CreateDateTime = c.DateTime(nullable: false),
        ModifyUserID = c.String(nullable: false, maxLength: 14),
        ModifyDateTime = c.DateTime(nullable: false),
    })
    .PrimaryKey(t => new { t.CompanyID, t.DeptID });

            CreateTable(
                "dbo.Employees",
                c => new
                {
                    CompanyID = c.String(nullable: false, maxLength: 6),
                    EmpID = c.String(nullable: false, maxLength: 8),
                    EmpName = c.String(nullable: false, maxLength: 16),
                    DeptID = c.String(nullable: false, maxLength: 6),
                    PositionID = c.String(nullable: false, maxLength: 8),
                    IDCard = c.String(nullable: false, maxLength: 10),
                    PhoneNumber = c.String(maxLength: 30),
                    Email = c.String(maxLength: 50),
                    Memo = c.String(maxLength: 100),
                    Birthday = c.DateTime(nullable: false),
                    EmpCardID = c.String(maxLength: 10),
                    CreateUserID = c.String(maxLength: 14),
                    CreateDateTime = c.DateTime(nullable: false),
                    ModifyUserID = c.String(nullable: false, maxLength: 14),
                    ModifyDateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.CompanyID, t.EmpID });

            CreateTable(
                "dbo.Order_d_tran",
                c => new
                {
                    CompanyID = c.String(nullable: false, maxLength: 6),
                    OrderNo = c.String(nullable: false, maxLength: 20),
                    OrderSeq = c.String(nullable: false, maxLength: 3),
                    TranDateTime = c.DateTime(nullable: false),
                    QuoteNo = c.String(maxLength: 20),
                    QuoteSeq = c.String(maxLength: 3),
                    ProductID = c.String(nullable: false, maxLength: 30),
                    ProdName = c.String(maxLength: 40),
                    ProdSpec = c.String(),
                    Qty = c.Decimal(nullable: false, precision: 18, scale: 2),
                    ProdUnit = c.String(nullable: false, maxLength: 10),
                    CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Memo = c.String(),
                    OrderStatus = c.String(nullable: false, maxLength: 1),
                    DataStatus = c.String(nullable: false, maxLength: 1),
                    EndCode_YN = c.String(nullable: false, maxLength: 1),
                    Temperature = c.String(nullable: false, maxLength: 3),
                    Sugar = c.String(nullable: false, maxLength: 3),
                    Size = c.String(nullable: false, maxLength: 3),
                    CreateUserID = c.String(nullable: false, maxLength: 20),
                    CreateDateTime = c.DateTime(nullable: false),
                    ModifyUserID = c.String(nullable: false, maxLength: 20),
                    ModifyDateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.CompanyID, t.OrderNo, t.OrderSeq, t.TranDateTime });

            CreateTable(
                "dbo.Positions",
                c => new
                {
                    CompanyID = c.String(nullable: false, maxLength: 6),
                    PositionID = c.String(nullable: false, maxLength: 8),
                    PositionName = c.String(nullable: false, maxLength: 16),
                    PositionLevel = c.String(nullable: false, maxLength: 6),
                    CreateUserID = c.String(nullable: false, maxLength: 14),
                    CreateDateTime = c.DateTime(nullable: false),
                    ModifyUserID = c.String(nullable: false, maxLength: 14),
                    ModifyDateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.CompanyID, t.PositionID });

            CreateTable(
                "dbo.Product_d",
                c => new
                {
                    CompanyID = c.String(nullable: false, maxLength: 6),
                    ProductID = c.String(nullable: false, maxLength: 30),
                    Temperature = c.String(nullable: false, maxLength: 3),
                    Size = c.String(nullable: false, maxLength: 3),
                    SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Memo = c.String(maxLength: 100),
                    CreateUserID = c.String(nullable: false, maxLength: 14),
                    CreateDateTime = c.DateTime(nullable: false),
                    ModifyUserID = c.String(nullable: false, maxLength: 14),
                    ModifyDateTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => new { t.CompanyID, t.ProductID, t.Temperature, t.Size });


        }
        
        public override void Down()
        {
            DropTable("dbo.Product_d");
            DropTable("dbo.Positions");
            DropTable("dbo.Order_d_tran");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
            DropTable("dbo.Customers");
        }
    }
}
