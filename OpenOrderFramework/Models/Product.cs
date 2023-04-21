using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class Product
    {
        [Key]
        [Column(Order = 0)]
        [Required(ErrorMessage = "請輸入公司別")]
        [StringLength(6)]
        [Display(Name = "公司別")]
        public string CompanyID { get; set; }

        [Required(ErrorMessage = "請輸入產品類別")]
        [StringLength(6)]
        [Display(Name = "產品類別")]
        public string ProdKind { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "請輸入產品編號")]
        [StringLength(30)]
        [Display(Name = "產品編號")]
        public string ProductID { get; set; }

        //[Required(ErrorMessage = "請輸入產品條碼預設同產品編號")]
        [StringLength(40)]
        [Display(Name = "產品條碼預設同產品編號")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string BarCode { get; set; }

        [Required(ErrorMessage = "請輸入產品名稱")]
        [StringLength(40)]
        [Display(Name = "產品名稱")]
        public string ProdName { get; set; }

        //[Required(ErrorMessage = "請輸入產品規格")]
        //[StringLength(NTEXT)]
        [Display(Name = "產品規格")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ProdSpec { get; set; }

        //[Required(ErrorMessage = "請輸入產品顏色")]
        [StringLength(10)]
        [Display(Name = "產品顏色")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ProdColor { get; set; }

        //[Required(ErrorMessage = "請輸入產品單位")]
        [StringLength(10)]
        [Display(Name = "產品單位")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ProdUnit { get; set; }

        //[Required(ErrorMessage = "請輸入單重")]
        //[StringLength(FLOAT)]
        [Display(Name = "單重")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal UnitWeight { get; set; }

        //[Required(ErrorMessage = "請輸入產品照片")]
        //[StringLength(IMAGE)]
        [Display(Name = "產品照片")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ProdPhoto { get; set; }

        //[Required(ErrorMessage = "請輸入是否作為新產品")]
        [StringLength(1)]
        [Display(Name = "是否作為新產品")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string New_YN { get; set; }

        //[Required(ErrorMessage = "請輸入產地")]
        [StringLength(100)]
        [Display(Name = "產地")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ProdOrigin { get; set; }

        //[Required(ErrorMessage = "請輸入產品內容")]
        //[StringLength(NTEXT)]
        [Display(Name = "產品內容")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ProdSubject { get; set; }

        //[Required(ErrorMessage = "請輸入廠商代碼")]
        [StringLength(10)]
        [Display(Name = "廠商代碼")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FactoryID { get; set; }

        //[Required(ErrorMessage = "請輸入最後進價")]
        //[StringLength(DECIMAL(10,3)]
        [Display(Name = "最後進價")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal FinalPrice { get; set; }

        //[Required(ErrorMessage = "請輸入平均進價")]
        //[StringLength(DECIMAL(10,3)]
        [Display(Name = "平均進價")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal AvegPrice { get; set; }

        //[Required(ErrorMessage = "請輸入成本單價")]
        //[StringLength(DECIMAL(10,3)]
        [Display(Name = "成本單價")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal CostPrice { get; set; }

        //[Required(ErrorMessage = "請輸入售價")]
        //[StringLength(DECIMAL(10,3)]
        [Display(Name = "售價")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal SalePrice { get; set; }

        //[Required(ErrorMessage = "請輸入庫別代號")]
        [StringLength(20)]
        [Display(Name = "庫別代號")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string WarehouseID { get; set; }

        //[Required(ErrorMessage = "請輸入商品有無條碼")]
        [StringLength(1)]
        [Display(Name = "商品有無條碼")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string BarCode_YN { get; set; }

        //[Required(ErrorMessage = "請輸入是否盤點，'N'為不盤")]
        [StringLength(1)]
        [Display(Name = "是否盤點，'N'為不盤")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CheckStock_YN { get; set; }

        //[Required(ErrorMessage = "請輸入是否加減庫存")]
        [StringLength(1)]
        [Display(Name = "是否加減庫存")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string StockIO_YN { get; set; }

        //[Required(ErrorMessage = "請輸入安全庫存量")]
        //[StringLength(DECIMAL(9,2)]
        [Display(Name = "安全庫存量")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal SafeQty { get; set; }

        [Required(ErrorMessage = "請輸入資料狀態，D:為作廢")]
        [StringLength(1)]
        [Display(Name = "資料狀態，D:為作廢")]
        public string DataStatus { get; set; }

        ////[Required(ErrorMessage = "請輸入溫度")]
        //[StringLength(3)]
        //[Display(Name = "溫度")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        //public string Temperature { get; set; }

        ////[Required(ErrorMessage = "請輸入甜度")]
        //[StringLength(3)]
        //[Display(Name = "甜度")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        //public string Sugar { get; set; }

        ////[Required(ErrorMessage = "請輸入大小")]
        //[StringLength(3)]
        //[Display(Name = "大小")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        //public string Size { get; set; }

        //[Required(ErrorMessage = "請輸入備註")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [StringLength(100)]
        [Display(Name = "備註")]
        public string Memo { get; set; }

        [Required(ErrorMessage = "請輸入建立人員")]
        [StringLength(14)]
        [Display(Name = "建立人員")]
        public string CreateUserID { get; set; }

        [Required(ErrorMessage = "請輸入建立日期")]
        //[StringLength(DATETIME)]
        [Display(Name = "建立日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateDateTime { get; set; }

        [Required(ErrorMessage = "請輸入維護人員")]
        [StringLength(14)]
        [Display(Name = "維護人員")]
        public string ModifyUserID { get; set; }

        [Required(ErrorMessage = "請輸入維護日期")]
        //[StringLength(DATETIME)]
        [Display(Name = "維護日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ModifyDateTime { get; set; }


    }
}