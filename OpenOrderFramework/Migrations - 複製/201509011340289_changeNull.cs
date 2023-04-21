namespace OpenOrderFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BOXFACTORies", "post_no", c => c.String(maxLength: 6));
            AlterColumn("dbo.BOXFACTORies", "c_post_no", c => c.String(maxLength: 6));
            AlterColumn("dbo.BOXFACTORies", "c_addr", c => c.String(maxLength: 150));
            AlterColumn("dbo.BOXFACTORies", "p_name", c => c.String(maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "country_no", c => c.String(maxLength: 3));
            AlterColumn("dbo.BOXFACTORies", "area_no", c => c.String(maxLength: 4));
            AlterColumn("dbo.BOXFACTORies", "tel_no", c => c.String(maxLength: 15));
            AlterColumn("dbo.BOXFACTORies", "fax_no", c => c.String(maxLength: 15));
            AlterColumn("dbo.BOXFACTORies", "email_addr", c => c.String(maxLength: 50));
            AlterColumn("dbo.BOXFACTORies", "c_name", c => c.String(maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "c_til_name", c => c.String(maxLength: 16));
            AlterColumn("dbo.BOXFACTORies", "c_tel_no", c => c.String(maxLength: 15));
            AlterColumn("dbo.BOXFACTORies", "c_mobile_no", c => c.String(maxLength: 15));
            AlterColumn("dbo.BOXFACTORies", "c_email_addr", c => c.String(maxLength: 50));
            AlterColumn("dbo.BOXFACTORies", "invo_tax_no", c => c.String(maxLength: 8));
            AlterColumn("dbo.BOXFACTORies", "www_addr", c => c.String(maxLength: 150));
            AlterColumn("dbo.BOXFACTORies", "class_kind", c => c.String(maxLength: 3));
            AlterColumn("dbo.BOXFACTORies", "supp_type", c => c.String(maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "bank1", c => c.String(maxLength: 20));
            AlterColumn("dbo.BOXFACTORies", "account_no1", c => c.String(maxLength: 15));
            AlterColumn("dbo.BOXFACTORies", "bank2", c => c.String(maxLength: 20));
            AlterColumn("dbo.BOXFACTORies", "account_no2", c => c.String(maxLength: 15));
            AlterColumn("dbo.BOXFACTORies", "pay_cond", c => c.String(maxLength: 30));
            AlterColumn("dbo.BOXFACTORies", "pay_code", c => c.String(maxLength: 1));
            AlterColumn("dbo.BOXFACTORies", "remarker", c => c.String(maxLength: 120));
            AlterColumn("dbo.BOXFACTORies", "Acct_no_ar1", c => c.String(maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "Acct_no_ar2", c => c.String(maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "Acct_no_ar3", c => c.String(maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "Acct_no_ar4", c => c.String(maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "Acct_no_ar5", c => c.String(maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "Acct_no_ar6", c => c.String(maxLength: 10));
            AlterColumn("dbo.CodeKinds", "memo", c => c.String(maxLength: 50));
            AlterColumn("dbo.CodeKinds", "modify_YN", c => c.String(maxLength: 2));
            AlterColumn("dbo.Codes", "code_name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Codes", "code1", c => c.String(maxLength: 14));
            AlterColumn("dbo.Codes", "code2", c => c.String(maxLength: 14));
            AlterColumn("dbo.Codes", "memo", c => c.String(maxLength: 50));
            AlterColumn("dbo.Codes", "modify_YN", c => c.String(maxLength: 2));
            AlterColumn("dbo.CombProduct_d", "Prod_no", c => c.String(maxLength: 16));
            AlterColumn("dbo.CombProduct_d", "Other_Prod_no", c => c.String(maxLength: 1));
            AlterColumn("dbo.CombProduct_d", "Memo", c => c.String(maxLength: 50));
            AlterColumn("dbo.CombProduct_m", "photo", c => c.String(maxLength: 100));
            AlterColumn("dbo.CombProduct_m", "Memo", c => c.String(maxLength: 50));
            AlterColumn("dbo.Companies", "create_user_id", c => c.String(nullable: false, maxLength: 14));
            AlterColumn("dbo.Companies", "modify_user_id", c => c.String(nullable: false, maxLength: 14));
            AlterColumn("dbo.Custs", "cust_class", c => c.String(maxLength: 10));
            AlterColumn("dbo.Custs", "cust_type", c => c.String(maxLength: 10));
            AlterColumn("dbo.Custs", "c_name", c => c.String(maxLength: 20));
            AlterColumn("dbo.Custs", "c_tel_no", c => c.String(maxLength: 15));
            AlterColumn("dbo.Custs", "c_mobile_no", c => c.String(maxLength: 15));
            AlterColumn("dbo.Custs", "c_email_addr", c => c.String(maxLength: 50));
            AlterColumn("dbo.Custs", "c_email_Ver", c => c.String(maxLength: 1));
            AlterColumn("dbo.Custs", "invo_tax_no", c => c.String(maxLength: 10));
            AlterColumn("dbo.Custs", "b_post_no", c => c.String(maxLength: 6));
            AlterColumn("dbo.Custs", "b_addr", c => c.String(maxLength: 150));
            AlterColumn("dbo.Custs", "b_post_no2", c => c.String(maxLength: 6));
            AlterColumn("dbo.Custs", "b_addr2", c => c.String(maxLength: 150));
            AlterColumn("dbo.Custs", "remarker", c => c.String(maxLength: 120));
            AlterColumn("dbo.Custs", "job", c => c.String(maxLength: 3));
            AlterColumn("dbo.LongOrder_m", "remarker", c => c.String());
            AlterColumn("dbo.Order_d", "Quote_no", c => c.String(maxLength: 20));
            AlterColumn("dbo.Order_d", "Quote_seq", c => c.String(maxLength: 3));
            AlterColumn("dbo.Order_d", "Prod_name", c => c.String(maxLength: 40));
            AlterColumn("dbo.Order_d", "Prod_spec", c => c.String());
            AlterColumn("dbo.Order_d", "remarker", c => c.String());
            AlterColumn("dbo.Order_m", "ef_co", c => c.String(maxLength: 40));
            AlterColumn("dbo.Order_m", "fax_no", c => c.String(maxLength: 15));
            AlterColumn("dbo.Order_m", "c_name", c => c.String(maxLength: 20));
            AlterColumn("dbo.Order_m", "c_tel_no", c => c.String(maxLength: 15));
            AlterColumn("dbo.Order_m", "c_mobile_no", c => c.String(maxLength: 15));
            AlterColumn("dbo.Order_m", "c_email_addr", c => c.String(maxLength: 50));
            AlterColumn("dbo.Order_m", "bill_addr", c => c.String(maxLength: 150));
            AlterColumn("dbo.Order_m", "check_user_id", c => c.String(maxLength: 20));
            AlterColumn("dbo.Order_m", "remarker", c => c.String());
            AlterColumn("dbo.Order_m", "delivery_user_id", c => c.String(maxLength: 20));
            AlterColumn("dbo.Order_m", "promotional", c => c.String(maxLength: 3));
            AlterColumn("dbo.Params", "para2", c => c.String(maxLength: 50));
            AlterColumn("dbo.Params", "para4", c => c.String());
            AlterColumn("dbo.ProductKinds", "Code1", c => c.String(maxLength: 14));
            AlterColumn("dbo.ProductKinds", "Code2", c => c.String(maxLength: 14));
            AlterColumn("dbo.ProductKinds", "photo", c => c.String(maxLength: 100));
            AlterColumn("dbo.ProductKinds", "Memo", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "Prod_barcode", c => c.String(maxLength: 40));
            AlterColumn("dbo.Products", "Prod_spec", c => c.String());
            AlterColumn("dbo.Products", "Prod_color", c => c.String(maxLength: 10));
            AlterColumn("dbo.Products", "Prod_unit", c => c.String(maxLength: 10));
            AlterColumn("dbo.Products", "Prod_photo", c => c.String());
            AlterColumn("dbo.Products", "other_spec4", c => c.String(maxLength: 1));
            AlterColumn("dbo.Products", "other_spec5", c => c.String(maxLength: 100));
            AlterColumn("dbo.Products", "prod_subject", c => c.String());
            AlterColumn("dbo.Products", "FACT_NO", c => c.String(maxLength: 10));
            AlterColumn("dbo.Products", "warehouse_no", c => c.String(maxLength: 20));
            AlterColumn("dbo.Products", "no_barcode", c => c.String(maxLength: 1));
            AlterColumn("dbo.Products", "stk_yn", c => c.String(maxLength: 1));
            AlterColumn("dbo.Products", "stk_io_yn", c => c.String(maxLength: 1));
            AlterColumn("dbo.Products", "temperature", c => c.String(maxLength: 3));
            AlterColumn("dbo.Products", "sugar", c => c.String(maxLength: 3));
            AlterColumn("dbo.Products", "size", c => c.String(maxLength: 3));
            AlterColumn("dbo.Products", "memo_doc", c => c.String(maxLength: 100));
            AlterColumn("dbo.UserGroup_m", "program_used", c => c.String(maxLength: 60));
            AlterColumn("dbo.Warehouses", "tel_no", c => c.String(maxLength: 20));
            AlterColumn("dbo.Warehouses", "w_addr", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Warehouses", "w_addr", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Warehouses", "tel_no", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.UserGroup_m", "program_used", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Products", "memo_doc", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Products", "size", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Products", "sugar", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Products", "temperature", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Products", "stk_io_yn", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.Products", "stk_yn", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.Products", "no_barcode", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.Products", "warehouse_no", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Products", "FACT_NO", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Products", "prod_subject", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "other_spec5", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Products", "other_spec4", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.Products", "Prod_photo", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Prod_unit", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Products", "Prod_color", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Products", "Prod_spec", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Prod_barcode", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.ProductKinds", "Memo", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ProductKinds", "photo", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ProductKinds", "Code2", c => c.String(nullable: false, maxLength: 14));
            AlterColumn("dbo.ProductKinds", "Code1", c => c.String(nullable: false, maxLength: 14));
            AlterColumn("dbo.Params", "para4", c => c.String(nullable: false));
            AlterColumn("dbo.Params", "para2", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Order_m", "promotional", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Order_m", "delivery_user_id", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Order_m", "remarker", c => c.String(nullable: false));
            AlterColumn("dbo.Order_m", "check_user_id", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Order_m", "bill_addr", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Order_m", "c_email_addr", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Order_m", "c_mobile_no", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Order_m", "c_tel_no", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Order_m", "c_name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Order_m", "fax_no", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Order_m", "ef_co", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Order_d", "remarker", c => c.String(nullable: false));
            AlterColumn("dbo.Order_d", "Prod_spec", c => c.String(nullable: false));
            AlterColumn("dbo.Order_d", "Prod_name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Order_d", "Quote_seq", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Order_d", "Quote_no", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.LongOrder_m", "remarker", c => c.String(nullable: false));
            AlterColumn("dbo.Custs", "job", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Custs", "remarker", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.Custs", "b_addr2", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Custs", "b_post_no2", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.Custs", "b_addr", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Custs", "b_post_no", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.Custs", "invo_tax_no", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Custs", "c_email_Ver", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.Custs", "c_email_addr", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Custs", "c_mobile_no", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Custs", "c_tel_no", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Custs", "c_name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Custs", "cust_type", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Custs", "cust_class", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Companies", "modify_user_id", c => c.String(maxLength: 14));
            AlterColumn("dbo.Companies", "create_user_id", c => c.String(maxLength: 14));
            AlterColumn("dbo.CombProduct_m", "Memo", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.CombProduct_m", "photo", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.CombProduct_d", "Memo", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.CombProduct_d", "Other_Prod_no", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.CombProduct_d", "Prod_no", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.Codes", "modify_YN", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Codes", "memo", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Codes", "code2", c => c.String(nullable: false, maxLength: 14));
            AlterColumn("dbo.Codes", "code1", c => c.String(nullable: false, maxLength: 14));
            AlterColumn("dbo.Codes", "code_name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.CodeKinds", "modify_YN", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.CodeKinds", "memo", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.BOXFACTORies", "Acct_no_ar6", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "Acct_no_ar5", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "Acct_no_ar4", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "Acct_no_ar3", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "Acct_no_ar2", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "Acct_no_ar1", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "remarker", c => c.String(nullable: false, maxLength: 120));
            AlterColumn("dbo.BOXFACTORies", "pay_code", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.BOXFACTORies", "pay_cond", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.BOXFACTORies", "account_no2", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.BOXFACTORies", "bank2", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.BOXFACTORies", "account_no1", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.BOXFACTORies", "bank1", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.BOXFACTORies", "supp_type", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "class_kind", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.BOXFACTORies", "www_addr", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.BOXFACTORies", "invo_tax_no", c => c.String(nullable: false, maxLength: 8));
            AlterColumn("dbo.BOXFACTORies", "c_email_addr", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.BOXFACTORies", "c_mobile_no", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.BOXFACTORies", "c_tel_no", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.BOXFACTORies", "c_til_name", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.BOXFACTORies", "c_name", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "email_addr", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.BOXFACTORies", "fax_no", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.BOXFACTORies", "tel_no", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.BOXFACTORies", "area_no", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.BOXFACTORies", "country_no", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.BOXFACTORies", "p_name", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.BOXFACTORies", "c_addr", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.BOXFACTORies", "c_post_no", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.BOXFACTORies", "post_no", c => c.String(nullable: false, maxLength: 6));
        }
    }
}
