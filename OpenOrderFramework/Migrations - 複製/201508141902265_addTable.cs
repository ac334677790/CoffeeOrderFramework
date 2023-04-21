namespace OpenOrderFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BOXFACTORies",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        FACT_NO = c.String(nullable: false, maxLength: 16),
                        bri_co = c.String(nullable: false, maxLength: 10),
                        ef_co = c.String(nullable: false, maxLength: 40),
                        post_no = c.String(nullable: false, maxLength: 6),
                        c_post_no = c.String(nullable: false, maxLength: 6),
                        c_addr = c.String(nullable: false, maxLength: 150),
                        p_name = c.String(nullable: false, maxLength: 10),
                        country_no = c.String(nullable: false, maxLength: 3),
                        area_no = c.String(nullable: false, maxLength: 4),
                        tel_no = c.String(nullable: false, maxLength: 15),
                        fax_no = c.String(nullable: false, maxLength: 15),
                        email_addr = c.String(nullable: false, maxLength: 50),
                        c_name = c.String(nullable: false, maxLength: 10),
                        c_til_name = c.String(nullable: false, maxLength: 16),
                        c_tel_no = c.String(nullable: false, maxLength: 15),
                        c_mobile_no = c.String(nullable: false, maxLength: 15),
                        c_email_addr = c.String(nullable: false, maxLength: 50),
                        cdate = c.Short(nullable: false),
                        pdate = c.Short(nullable: false),
                        Coll_days = c.Short(nullable: false),
                        invo_tax_no = c.String(nullable: false, maxLength: 8),
                        www_addr = c.String(nullable: false, maxLength: 150),
                        class_kind = c.String(nullable: false, maxLength: 3),
                        supp_type = c.String(nullable: false, maxLength: 10),
                        bank1 = c.String(nullable: false, maxLength: 20),
                        account_no1 = c.String(nullable: false, maxLength: 15),
                        bank2 = c.String(nullable: false, maxLength: 20),
                        account_no2 = c.String(nullable: false, maxLength: 15),
                        pay_cond = c.String(nullable: false, maxLength: 30),
                        pay_code = c.String(nullable: false, maxLength: 1),
                        remarker = c.String(nullable: false, maxLength: 120),
                        Acct_no_ar1 = c.String(nullable: false, maxLength: 10),
                        Acct_no_ar2 = c.String(nullable: false, maxLength: 10),
                        Acct_no_ar3 = c.String(nullable: false, maxLength: 10),
                        Acct_no_ar4 = c.String(nullable: false, maxLength: 10),
                        Acct_no_ar5 = c.String(nullable: false, maxLength: 10),
                        Acct_no_ar6 = c.String(nullable: false, maxLength: 10),
                        invalid_date = c.DateTime(nullable: false),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.FACT_NO });
            
            CreateTable(
                "dbo.CodeKinds",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        code_kind = c.String(nullable: false, maxLength: 16),
                        code_kind_name = c.String(nullable: false, maxLength: 30),
                        memo = c.String(nullable: false, maxLength: 50),
                        modify_YN = c.String(nullable: false, maxLength: 2),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.code_kind });
            
            CreateTable(
                "dbo.Codes",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        code_kind = c.String(nullable: false, maxLength: 16),
                        code = c.String(nullable: false, maxLength: 14),
                        code_name = c.String(nullable: false, maxLength: 50),
                        code1 = c.String(nullable: false, maxLength: 14),
                        code2 = c.String(nullable: false, maxLength: 14),
                        memo = c.String(nullable: false, maxLength: 50),
                        modify_YN = c.String(nullable: false, maxLength: 2),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.code_kind, t.code });
            
            CreateTable(
                "dbo.CombProduct_d",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        CombProd_no = c.String(nullable: false, maxLength: 16),
                        CombProd_seq = c.String(nullable: false, maxLength: 16),
                        Prod_no = c.String(nullable: false, maxLength: 16),
                        Other_Prod_no = c.String(nullable: false, maxLength: 1),
                        Memo = c.String(nullable: false, maxLength: 50),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.CombProd_no, t.CombProd_seq });
            
            CreateTable(
                "dbo.CombProduct_m",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        CombProd_no = c.String(nullable: false, maxLength: 16),
                        CombProd_name = c.String(nullable: false, maxLength: 50),
                        CombProd_spec = c.String(nullable: false),
                        photo = c.String(nullable: false, maxLength: 100),
                        Memo = c.String(nullable: false, maxLength: 50),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.CombProd_no });
            
            CreateTable(
                "dbo.Custs",
                c => new
                    {
                        cust_no = c.String(nullable: false, maxLength: 16),
                        ef_co = c.String(nullable: false, maxLength: 40),
                        cust_password = c.String(nullable: false, maxLength: 20),
                        bri_co = c.String(nullable: false, maxLength: 12),
                        sex_type = c.String(nullable: false, maxLength: 1),
                        cust_class = c.String(nullable: false, maxLength: 10),
                        cust_type = c.String(nullable: false, maxLength: 10),
                        c_name = c.String(nullable: false, maxLength: 20),
                        c_tel_no = c.String(nullable: false, maxLength: 15),
                        c_mobile_no = c.String(nullable: false, maxLength: 15),
                        c_email_addr = c.String(nullable: false, maxLength: 50),
                        c_email_Ver = c.String(nullable: false, maxLength: 1),
                        invo_tax_no = c.String(nullable: false, maxLength: 10),
                        b_post_no = c.String(nullable: false, maxLength: 6),
                        b_addr = c.String(nullable: false, maxLength: 150),
                        b_post_no2 = c.String(nullable: false, maxLength: 6),
                        b_addr2 = c.String(nullable: false, maxLength: 150),
                        remarker = c.String(nullable: false, maxLength: 120),
                        valid_date = c.DateTime(nullable: false),
                        invalid_date = c.DateTime(nullable: false),
                        Stored_Point = c.Int(nullable: false),
                        birthday = c.DateTime(nullable: false),
                        job = c.String(nullable: false, maxLength: 3),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.cust_no);
            
            CreateTable(
                "dbo.LongOrder_m",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        LongOrder_No = c.String(nullable: false, maxLength: 20),
                        Order_No = c.String(nullable: false, maxLength: 20),
                        Del_datetimeS = c.DateTime(nullable: false),
                        Del_datetimeE = c.DateTime(nullable: false),
                        Del_cycleD = c.String(nullable: false, maxLength: 1),
                        Del_cycleW = c.String(nullable: false, maxLength: 1),
                        Del_cycleM = c.String(nullable: false, maxLength: 1),
                        Del_datetime = c.DateTime(nullable: false),
                        remarker = c.String(nullable: false),
                        r_status = c.String(nullable: false, maxLength: 1),
                        create_user_id = c.String(nullable: false, maxLength: 20),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 20),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.LongOrder_No });
            
            CreateTable(
                "dbo.Order_d",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        Order_No = c.String(nullable: false, maxLength: 20),
                        Order_seq = c.String(nullable: false, maxLength: 3),
                        Quote_no = c.String(nullable: false, maxLength: 20),
                        Quote_seq = c.String(nullable: false, maxLength: 3),
                        Prod_No = c.String(nullable: false, maxLength: 30),
                        Prod_name = c.String(nullable: false, maxLength: 40),
                        Prod_spec = c.String(nullable: false),
                        QTY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Prod_unit = c.String(nullable: false, maxLength: 10),
                        unit_cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        unit_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        On_slae = c.Decimal(nullable: false, precision: 18, scale: 2),
                        total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        remarker = c.String(nullable: false),
                        Order_status = c.String(nullable: false, maxLength: 1),
                        r_status = c.String(nullable: false, maxLength: 1),
                        end_code = c.String(nullable: false, maxLength: 1),
                        temperature = c.String(nullable: false, maxLength: 3),
                        sugar = c.String(nullable: false, maxLength: 3),
                        size = c.String(nullable: false, maxLength: 3),
                        create_user_id = c.String(nullable: false, maxLength: 20),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 20),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.Order_No, t.Order_seq });
            
            CreateTable(
                "dbo.Order_m",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        Order_No = c.String(nullable: false, maxLength: 20),
                        Order_date = c.DateTime(nullable: false),
                        cust_no = c.String(nullable: false, maxLength: 16),
                        ef_co = c.String(nullable: false, maxLength: 40),
                        fax_no = c.String(nullable: false, maxLength: 15),
                        c_name = c.String(nullable: false, maxLength: 20),
                        c_tel_no = c.String(nullable: false, maxLength: 15),
                        c_mobile_no = c.String(nullable: false, maxLength: 15),
                        c_email_addr = c.String(nullable: false, maxLength: 50),
                        pay_kind = c.String(nullable: false, maxLength: 3),
                        bill_addr = c.String(nullable: false, maxLength: 150),
                        check_user_id = c.String(nullable: false, maxLength: 20),
                        ACCNO = c.String(nullable: false, maxLength: 20),
                        ACCUNIT = c.String(nullable: false, maxLength: 10),
                        ACCNAME = c.String(nullable: false, maxLength: 20),
                        remarker = c.String(nullable: false),
                        r_status = c.String(nullable: false, maxLength: 1),
                        delivery_datetime = c.DateTime(nullable: false),
                        delivery_user_id = c.String(nullable: false, maxLength: 20),
                        promotional = c.String(nullable: false, maxLength: 3),
                        create_user_id = c.String(nullable: false, maxLength: 20),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 20),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.Order_No });
            
            CreateTable(
                "dbo.Params",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        para_kind = c.String(nullable: false, maxLength: 10),
                        para1 = c.String(nullable: false, maxLength: 14),
                        para2 = c.String(nullable: false, maxLength: 50),
                        para3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        para4 = c.String(nullable: false),
                        para_name = c.String(nullable: false, maxLength: 50),
                        modify_YN = c.String(maxLength: 2),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.para_kind, t.para1 });
            
            CreateTable(
                "dbo.Privileges",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        user_id = c.String(nullable: false, maxLength: 14),
                        program_id = c.String(nullable: false, maxLength: 15),
                        up_add = c.String(nullable: false, maxLength: 1),
                        up_query = c.String(nullable: false, maxLength: 1),
                        up_modify = c.String(nullable: false, maxLength: 1),
                        up_delete = c.String(nullable: false, maxLength: 1),
                        up_print = c.String(nullable: false, maxLength: 1),
                        up_run = c.String(nullable: false, maxLength: 1),
                        up_help = c.String(nullable: false, maxLength: 1),
                        up_transform = c.String(nullable: false, maxLength: 1),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.user_id, t.program_id });
            
            CreateTable(
                "dbo.ProductKinds",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        Prod_kind = c.String(nullable: false, maxLength: 16),
                        kind_name = c.String(nullable: false, maxLength: 50),
                        parent_kind = c.String(nullable: false, maxLength: 16),
                        Code1 = c.String(nullable: false, maxLength: 14),
                        Code2 = c.String(nullable: false, maxLength: 14),
                        photo = c.String(nullable: false, maxLength: 100),
                        Memo = c.String(nullable: false, maxLength: 50),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.String(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.Prod_kind });
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        Prod_no = c.String(nullable: false, maxLength: 30),
                        Prod_kind = c.String(nullable: false, maxLength: 6),
                        Prod_barcode = c.String(nullable: false, maxLength: 40),
                        Prod_name = c.String(nullable: false, maxLength: 40),
                        Prod_spec = c.String(nullable: false),
                        Prod_color = c.String(nullable: false, maxLength: 10),
                        Prod_unit = c.String(nullable: false, maxLength: 10),
                        UnitWeight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Prod_photo = c.String(nullable: false),
                        other_spec4 = c.String(nullable: false, maxLength: 1),
                        other_spec5 = c.String(nullable: false, maxLength: 100),
                        prod_subject = c.String(nullable: false),
                        FACT_NO = c.String(nullable: false, maxLength: 10),
                        Last_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Aveg_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        sale_Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        warehouse_no = c.String(nullable: false, maxLength: 20),
                        no_barcode = c.String(nullable: false, maxLength: 1),
                        stk_yn = c.String(nullable: false, maxLength: 1),
                        stk_io_yn = c.String(nullable: false, maxLength: 1),
                        safe_qty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        r_status = c.String(nullable: false, maxLength: 1),
                        temperature = c.String(nullable: false, maxLength: 3),
                        sugar = c.String(nullable: false, maxLength: 3),
                        size = c.String(nullable: false, maxLength: 3),
                        memo_doc = c.String(nullable: false, maxLength: 100),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.Prod_no });
            
            CreateTable(
                "dbo.Programs",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        program_id = c.String(nullable: false, maxLength: 16),
                        parent_program_id = c.String(nullable: false, maxLength: 16),
                        prog_description = c.String(nullable: false, maxLength: 50),
                        up_add = c.String(nullable: false, maxLength: 1),
                        up_query = c.String(nullable: false, maxLength: 1),
                        up_modify = c.String(nullable: false, maxLength: 1),
                        up_delete = c.String(nullable: false, maxLength: 1),
                        up_print = c.String(nullable: false, maxLength: 1),
                        up_run = c.String(nullable: false, maxLength: 1),
                        up_help = c.String(nullable: false, maxLength: 1),
                        up_transform = c.String(nullable: false, maxLength: 1),
                        linkpage = c.String(nullable: false, maxLength: 200),
                        prog_memo = c.String(nullable: false, maxLength: 30),
                        program_order = c.Int(nullable: false),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.program_id });
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        warehouse_no = c.String(nullable: false, maxLength: 20),
                        Prod_no = c.String(nullable: false, maxLength: 30),
                        Bat_no = c.String(nullable: false, maxLength: 25),
                        init_qty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        stock_qty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        last_tran_date = c.DateTime(nullable: false),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.warehouse_no, t.Prod_no, t.Bat_no });
            
            CreateTable(
                "dbo.UserGroup_d",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        group_id = c.String(nullable: false, maxLength: 14),
                        user_id = c.String(nullable: false, maxLength: 10),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.group_id, t.user_id });
            
            CreateTable(
                "dbo.UserGroup_m",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        group_id = c.String(nullable: false, maxLength: 14),
                        group_doc = c.String(nullable: false, maxLength: 40),
                        program_used = c.String(nullable: false, maxLength: 60),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.group_id });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        user_id = c.String(nullable: false, maxLength: 14),
                        user_password = c.String(nullable: false, maxLength: 16),
                        emp_no = c.String(nullable: false, maxLength: 16),
                        email_addr = c.String(nullable: false, maxLength: 50),
                        memo_doc = c.String(nullable: false, maxLength: 30),
                        invalid_date = c.DateTime(nullable: false),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.user_id });
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        company_no = c.String(nullable: false, maxLength: 6),
                        warehouse_no = c.String(nullable: false, maxLength: 10),
                        warehouse_name = c.String(nullable: false, maxLength: 20),
                        tel_no = c.String(nullable: false, maxLength: 20),
                        w_addr = c.String(nullable: false, maxLength: 150),
                        create_user_id = c.String(nullable: false, maxLength: 14),
                        create_datetime = c.DateTime(nullable: false),
                        modify_user_id = c.String(nullable: false, maxLength: 14),
                        modify_datetime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.company_no, t.warehouse_no });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Warehouses");
            DropTable("dbo.Users");
            DropTable("dbo.UserGroup_m");
            DropTable("dbo.UserGroup_d");
            DropTable("dbo.Stocks");
            DropTable("dbo.Programs");
            DropTable("dbo.Products");
            DropTable("dbo.ProductKinds");
            DropTable("dbo.Privileges");
            DropTable("dbo.Params");
            DropTable("dbo.Order_m");
            DropTable("dbo.Order_d");
            DropTable("dbo.LongOrder_m");
            DropTable("dbo.Custs");
            DropTable("dbo.CombProduct_m");
            DropTable("dbo.CombProduct_d");
            DropTable("dbo.Codes");
            DropTable("dbo.CodeKinds");
            DropTable("dbo.BOXFACTORies");
        }
    }
}
