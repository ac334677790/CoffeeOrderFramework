namespace OpenOrderFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ItemId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Test = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CatagorieId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 160),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InternalImage = c.Binary(),
                        ItemPictureUrl = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Catagories", t => t.CatagorieId, cascadeDelete: true)
                .Index(t => t.CatagorieId);
            
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Username = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 160),
                        LastName = c.String(nullable: false, maxLength: 160),
                        Address = c.String(nullable: false, maxLength: 70),
                        City = c.String(nullable: false, maxLength: 40),
                        State = c.String(nullable: false, maxLength: 40),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                        Country = c.String(nullable: false, maxLength: 40),
                        Phone = c.String(nullable: false, maxLength: 24),
                        Experation = c.DateTime(nullable: false),
                        SaveInfo = c.Boolean(nullable: false),
                        Email = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.CodeKinds",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        Code_Kind = c.String(nullable: false, maxLength: 16),
                        Code_KindName = c.String(nullable: false, maxLength: 30),
                        Memo = c.String(maxLength: 50),
                        Modify_YN = c.String(maxLength: 2),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.Code_Kind });
            
            CreateTable(
                "dbo.Codes",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        Code_Kind = c.String(nullable: false, maxLength: 16),
                        CodeID = c.String(nullable: false, maxLength: 14),
                        CodeName = c.String(maxLength: 50),
                        Code1 = c.String(maxLength: 14),
                        Code2 = c.String(maxLength: 14),
                        Memo = c.String(maxLength: 50),
                        Modify_YN = c.String(maxLength: 2),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.Code_Kind, t.CodeID });
            
            CreateTable(
                "dbo.CombProduct_d",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        CombProductID = c.String(nullable: false, maxLength: 16),
                        CombProdSeq = c.String(nullable: false, maxLength: 16),
                        ProductID = c.String(maxLength: 16),
                        OtherProductID = c.String(maxLength: 1),
                        Memo = c.String(maxLength: 50),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.CombProductID, t.CombProdSeq });
            
            CreateTable(
                "dbo.CombProduct_m",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        CombProductID = c.String(nullable: false, maxLength: 16),
                        CombProdName = c.String(nullable: false, maxLength: 50),
                        CombProdSpec = c.String(nullable: false),
                        Photo = c.String(maxLength: 100),
                        Memo = c.String(maxLength: 50),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.CombProductID });
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        CompanyName = c.String(nullable: false, maxLength: 40),
                        ShortName = c.String(nullable: false, maxLength: 20),
                        Area = c.String(maxLength: 10),
                        PhoneCountryCode = c.String(maxLength: 3),
                        PhoneAreaCode = c.String(maxLength: 1),
                        PhoneNumber = c.String(maxLength: 15),
                        FaxNumber = c.String(maxLength: 15),
                        CompanyAddress = c.String(maxLength: 150),
                        Site = c.String(maxLength: 150),
                        Email = c.String(maxLength: 50),
                        BusinessHourS = c.String(maxLength: 5),
                        BusinessHourE = c.String(maxLength: 5),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 16),
                        CustName = c.String(nullable: false, maxLength: 40),
                        CustPassword = c.String(nullable: false, maxLength: 20),
                        ShortName = c.String(nullable: false, maxLength: 12),
                        SexType = c.String(nullable: false, maxLength: 1),
                        CustLevel = c.String(maxLength: 10),
                        CustType = c.String(maxLength: 10),
                        ContactName = c.String(maxLength: 20),
                        TelephoneNumber = c.String(maxLength: 15),
                        MobileNumber = c.String(maxLength: 15),
                        Email = c.String(maxLength: 50),
                        EmailValidated = c.String(maxLength: 1),
                        TaxID = c.String(maxLength: 10),
                        PostalCode = c.String(maxLength: 6),
                        Address = c.String(maxLength: 150),
                        PostalCode2 = c.String(maxLength: 6),
                        Address2 = c.String(maxLength: 150),
                        Memo = c.String(maxLength: 120),
                        ValidDate = c.DateTime(nullable: false),
                        InValidDate = c.DateTime(nullable: false),
                        StoredPoint = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Job = c.String(maxLength: 3),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
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
                "dbo.Factories",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        FactoryID = c.String(nullable: false, maxLength: 16),
                        ShortName = c.String(nullable: false, maxLength: 10),
                        FactoryName = c.String(nullable: false, maxLength: 40),
                        PostalCode = c.String(maxLength: 6),
                        FactoryAddress = c.String(maxLength: 150),
                        ChargeName = c.String(maxLength: 10),
                        PhoneCountryCode = c.String(maxLength: 3),
                        PhoneAreaCode = c.String(maxLength: 4),
                        PhoneNumber = c.String(maxLength: 15),
                        FaxNumber = c.String(maxLength: 15),
                        Email = c.String(maxLength: 50),
                        ContactName = c.String(maxLength: 10),
                        ContactTiitle = c.String(maxLength: 16),
                        TelephoneNumber = c.String(maxLength: 15),
                        MobileNumber = c.String(maxLength: 15),
                        ContactEmail = c.String(maxLength: 50),
                        CloseDate = c.Short(nullable: false),
                        PayDate = c.Short(nullable: false),
                        PayDays = c.Short(nullable: false),
                        TaxID = c.String(maxLength: 8),
                        Site = c.String(maxLength: 150),
                        FactoryLevel = c.String(maxLength: 3),
                        FactoryType = c.String(maxLength: 10),
                        Bank1 = c.String(maxLength: 20),
                        Account1 = c.String(maxLength: 15),
                        Bank2 = c.String(maxLength: 20),
                        Account2 = c.String(maxLength: 15),
                        PayTerms = c.String(maxLength: 30),
                        PayCode = c.String(maxLength: 1),
                        Memo = c.String(maxLength: 120),
                        Acct_no_ar1 = c.String(maxLength: 10),
                        Acct_no_ar2 = c.String(maxLength: 10),
                        Acct_no_ar3 = c.String(maxLength: 10),
                        Acct_no_ar4 = c.String(maxLength: 10),
                        Acct_no_ar5 = c.String(maxLength: 10),
                        Acct_no_ar6 = c.String(maxLength: 10),
                        InValidDate = c.DateTime(nullable: false),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.FactoryID });
            
            CreateTable(
                "dbo.LongOrder_m",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        LongOrderNo = c.String(nullable: false, maxLength: 20),
                        OrderNo = c.String(nullable: false, maxLength: 20),
                        DatetimeS = c.DateTime(nullable: false),
                        DatetimeE = c.DateTime(nullable: false),
                        CycleDay = c.String(nullable: false, maxLength: 1),
                        CycleWeek = c.String(nullable: false, maxLength: 1),
                        CycleMonth = c.String(nullable: false, maxLength: 1),
                        CycleHour = c.DateTime(nullable: false),
                        Memo = c.String(),
                        DataStatus = c.String(nullable: false, maxLength: 1),
                        CreateUserID = c.String(nullable: false, maxLength: 20),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 20),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.LongOrderNo });
            
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
                "dbo.Order_d",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        OrderNo = c.String(nullable: false, maxLength: 20),
                        OrderSeq = c.String(nullable: false, maxLength: 3),
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
                .PrimaryKey(t => new { t.CompanyID, t.OrderNo, t.OrderSeq });
            
            CreateTable(
                "dbo.Order_m",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        OrderNo = c.String(nullable: false, maxLength: 20),
                        OrderDateTime = c.DateTime(nullable: false),
                        CustomerID = c.String(nullable: false, maxLength: 16),
                        CustName = c.String(maxLength: 40),
                        FaxNumber = c.String(maxLength: 15),
                        ContactName = c.String(maxLength: 20),
                        TelephoneNumber = c.String(maxLength: 15),
                        MobileNumber = c.String(maxLength: 15),
                        Email = c.String(maxLength: 50),
                        PayKind = c.String(nullable: false, maxLength: 3),
                        DeliveryAddress = c.String(maxLength: 150),
                        CheckUserID = c.String(maxLength: 20),
                        PayAccount = c.String(nullable: false, maxLength: 20),
                        AppleyAccount = c.String(nullable: false, maxLength: 10),
                        AccountNAME = c.String(nullable: false, maxLength: 20),
                        Memo = c.String(),
                        DataStatus = c.String(nullable: false, maxLength: 1),
                        DeliveryDateTime = c.DateTime(nullable: false),
                        DeliveryUserID = c.String(maxLength: 20),
                        Promotional = c.String(maxLength: 3),
                        CreateUserID = c.String(nullable: false, maxLength: 20),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 20),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.OrderNo });
            
            CreateTable(
                "dbo.Params",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        ParaKind = c.String(nullable: false, maxLength: 10),
                        Para1 = c.String(nullable: false, maxLength: 14),
                        Para2 = c.String(maxLength: 50),
                        Para3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Para4 = c.String(),
                        ParaName = c.String(nullable: false, maxLength: 50),
                        Modify_YN = c.String(maxLength: 2),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.ParaKind, t.Para1 });
            
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
                "dbo.Privileges",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        GroupID = c.String(nullable: false, maxLength: 14),
                        ProgramID = c.String(nullable: false, maxLength: 15),
                        Add = c.String(nullable: false, maxLength: 1),
                        Search = c.String(nullable: false, maxLength: 1),
                        Modify = c.String(nullable: false, maxLength: 1),
                        Delete = c.String(nullable: false, maxLength: 1),
                        Print = c.String(nullable: false, maxLength: 1),
                        Run = c.String(nullable: false, maxLength: 1),
                        Help = c.String(nullable: false, maxLength: 1),
                        Transform = c.String(nullable: false, maxLength: 1),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.GroupID, t.ProgramID });
            
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
            
            CreateTable(
                "dbo.ProductKinds",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        ProdKind = c.String(nullable: false, maxLength: 16),
                        ProdKindName = c.String(nullable: false, maxLength: 50),
                        ParentProdKind = c.String(nullable: false, maxLength: 16),
                        Code1 = c.String(maxLength: 14),
                        Code2 = c.String(maxLength: 14),
                        Photo = c.String(maxLength: 100),
                        Memo = c.String(maxLength: 50),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.ProdKind });
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        ProductID = c.String(nullable: false, maxLength: 30),
                        ProdKind = c.String(nullable: false, maxLength: 6),
                        BarCode = c.String(maxLength: 40),
                        ProdName = c.String(nullable: false, maxLength: 40),
                        ProdSpec = c.String(),
                        ProdColor = c.String(maxLength: 10),
                        ProdUnit = c.String(maxLength: 10),
                        UnitWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProdPhoto = c.String(),
                        New_YN = c.String(maxLength: 1),
                        ProdOrigin = c.String(maxLength: 100),
                        ProdSubject = c.String(),
                        FactoryID = c.String(maxLength: 10),
                        FinalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvegPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        WarehouseID = c.String(maxLength: 20),
                        BarCode_YN = c.String(maxLength: 1),
                        CheckStock_YN = c.String(maxLength: 1),
                        StockIO_YN = c.String(maxLength: 1),
                        SafeQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataStatus = c.String(nullable: false, maxLength: 1),
                        Memo = c.String(maxLength: 100),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.ProductID });
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        ProgramID = c.String(nullable: false, maxLength: 16),
                        ParentProgramID = c.String(nullable: false, maxLength: 16),
                        ProgDescription = c.String(nullable: false, maxLength: 50),
                        Add = c.String(nullable: false, maxLength: 1),
                        Search = c.String(nullable: false, maxLength: 1),
                        Modify = c.String(nullable: false, maxLength: 1),
                        Delete = c.String(nullable: false, maxLength: 1),
                        Print = c.String(nullable: false, maxLength: 1),
                        Run = c.String(nullable: false, maxLength: 1),
                        Help = c.String(nullable: false, maxLength: 1),
                        Transform = c.String(nullable: false, maxLength: 1),
                        LinkPage = c.String(nullable: false, maxLength: 200),
                        Memo = c.String(nullable: false, maxLength: 30),
                        ProgramOrder = c.Int(nullable: false),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.ProgramID });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        WarehouseID = c.String(nullable: false, maxLength: 20),
                        ProductID = c.String(nullable: false, maxLength: 30),
                        BatNo = c.String(nullable: false, maxLength: 25),
                        InitQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockQty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastTranDate = c.DateTime(nullable: false),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.WarehouseID, t.ProductID, t.BatNo });
            
            CreateTable(
                "dbo.UserGroup_d",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        GroupID = c.String(nullable: false, maxLength: 14),
                        UserID = c.String(nullable: false, maxLength: 10),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.GroupID, t.UserID });
            
            CreateTable(
                "dbo.UserGroup_m",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        GroupID = c.String(nullable: false, maxLength: 14),
                        GroupDOC = c.String(nullable: false, maxLength: 40),
                        Memo = c.String(maxLength: 60),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.GroupID });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        UserID = c.String(nullable: false, maxLength: 14),
                        UserPassword = c.String(nullable: false, maxLength: 16),
                        EmpID = c.String(nullable: false, maxLength: 16),
                        Email = c.String(maxLength: 50),
                        Memo = c.String(maxLength: 30),
                        InValidDate = c.DateTime(nullable: false),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.UserID });
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        CompanyID = c.String(nullable: false, maxLength: 6),
                        WarehouseID = c.String(nullable: false, maxLength: 10),
                        WarehouseName = c.String(nullable: false, maxLength: 20),
                        PhoneNumber = c.String(maxLength: 20),
                        WarehouseAddress = c.String(maxLength: 150),
                        CreateUserID = c.String(nullable: false, maxLength: 14),
                        CreateDateTime = c.DateTime(nullable: false),
                        ModifyUserID = c.String(nullable: false, maxLength: 14),
                        ModifyDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CompanyID, t.WarehouseID });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Carts", "ItemId", "dbo.Items");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "CatagorieId", "dbo.Catagories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OrderDetails", new[] { "ItemId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Items", new[] { "CatagorieId" });
            DropIndex("dbo.Carts", new[] { "ItemId" });
            DropTable("dbo.Warehouses");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Users");
            DropTable("dbo.UserGroup_m");
            DropTable("dbo.UserGroup_d");
            DropTable("dbo.Stocks");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Programs");
            DropTable("dbo.Products");
            DropTable("dbo.ProductKinds");
            DropTable("dbo.Product_d");
            DropTable("dbo.Privileges");
            DropTable("dbo.Positions");
            DropTable("dbo.Params");
            DropTable("dbo.Order_m");
            DropTable("dbo.Order_d");
            DropTable("dbo.Order_d_tran");
            DropTable("dbo.LongOrder_m");
            DropTable("dbo.Factories");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
            DropTable("dbo.Customers");
            DropTable("dbo.Companies");
            DropTable("dbo.CombProduct_m");
            DropTable("dbo.CombProduct_d");
            DropTable("dbo.Codes");
            DropTable("dbo.CodeKinds");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Catagories");
            DropTable("dbo.Items");
            DropTable("dbo.Carts");
        }
    }
}
