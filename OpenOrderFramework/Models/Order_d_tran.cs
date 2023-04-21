using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class Order_d_tran
    {
        [Key]
        [Column(Order = 0)]
        [Required(ErrorMessage = "請輸入公司別")]
        [StringLength(6)]
        [Display(Name = "公司別")]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "請輸入訂單單號")]
        [StringLength(20)]
        [Display(Name = "訂單單號")]
        public string OrderNo { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "請輸入訂單項次")]
        [StringLength(3)]
        [Display(Name = "訂單項次")]
        public string OrderSeq { get; set; }

        //[Required(ErrorMessage = "請輸入報價單號(2015810 Ting：保留先不用)")]
        [StringLength(20)]
        [Display(Name = "報價單號(2015810 Ting：保留先不用)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string QuoteNo { get; set; }

        //[Required(ErrorMessage = "請輸入報價項次(2015810 Ting：保留先不用)")]
        [StringLength(3)]
        [Display(Name = "報價項次(2015810 Ting：保留先不用)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string QuoteSeq { get; set; }

        [Required(ErrorMessage = "請輸入產品編號")]
        [StringLength(30)]
        [Display(Name = "產品編號")]
        public string ProductID { get; set; }

        //[Required(ErrorMessage = "請輸入產品名稱")]
        [StringLength(40)]
        [Display(Name = "產品名稱")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ProdName { get; set; }

        //[Required(ErrorMessage = "請輸入產品規格")]
        //[StringLength(NTEXT)]
        [Display(Name = "產品規格")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ProdSpec { get; set; }

        //[Required(ErrorMessage = "請輸入數量")]
        //[StringLength(DECIMAL(10,3)]
        [Display(Name = "數量")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal Qty { get; set; }

        [Required(ErrorMessage = "請輸入產品單位")]
        [StringLength(10)]
        [Display(Name = "產品單位")]
        public string ProdUnit { get; set; }

        [Required(ErrorMessage = "請輸入成本單價")]
        //[StringLength(DECIMAL(10,3)]
        [Display(Name = "成本單價")]
        public decimal CostPrice { get; set; }

        [Required(ErrorMessage = "請輸入單價")]
        //[StringLength(DECIMAL(10,3)]
        [Display(Name = "單價")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "請輸入折數")]
        //[StringLength(DECIMAL(6,3)]
        [Display(Name = "折數")]
        public decimal Discount { get; set; }

        [Required(ErrorMessage = "請輸入小計")]
        //[StringLength(DECIMAL(6,3)]
        [Display(Name = "小計")]
        public decimal Total { get; set; }

        //[Required(ErrorMessage = "請輸入備註")]
        //[StringLength(NTEXT)]
        [Display(Name = "備註")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Memo { get; set; }

        [Required(ErrorMessage = "請輸入訂單狀態，S：已送達線上付款時，付完請自動更新為P")]
        [StringLength(1)]
        [Display(Name = "訂單狀態，S：已送達線上付款時，付完請自動更新為P")]
        public string OrderStatus { get; set; }

        [Required(ErrorMessage = "請輸入資料狀態，D:為作廢")]
        [StringLength(1)]
        [Display(Name = "資料狀態，D:為作廢")]
        public string DataStatus { get; set; }

        [Required(ErrorMessage = "請輸入結案碼：N.未結案Y.結案已送貨完成，顯示結案 ")]
        [StringLength(1)]
        [Display(Name = "結案碼：N.未結案Y.結案已送貨完成，顯示結案 ")]
        public string EndCode_YN { get; set; }

        [Required(ErrorMessage = "請輸入溫度")]
        [StringLength(3)]
        [Display(Name = "溫度")]
        public string Temperature { get; set; }

        [Required(ErrorMessage = "請輸入甜度")]
        [StringLength(3)]
        [Display(Name = "甜度")]
        public string Sugar { get; set; }

        [Required(ErrorMessage = "請輸入大小")]
        [StringLength(3)]
        [Display(Name = "大小")]
        public string Size { get; set; }

        [Required(ErrorMessage = "請輸入建立人員")]
        [StringLength(20)]
        [Display(Name = "建立人員")]
        public string CreateUserID { get; set; }

        [Required(ErrorMessage = "請輸入建立日期")]
        //[StringLength(DATETIME)]
        [Display(Name = "建立日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateDateTime { get; set; }

        [Required(ErrorMessage = "請輸入維護人員")]
        [StringLength(20)]
        [Display(Name = "維護人員")]        
        public string ModifyUserID { get; set; }

        [Required(ErrorMessage = "請輸入維護日期")]
        //[StringLength(DATETIME)]
        [Display(Name = "維護日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ModifyDateTime { get; set; }

        [Key]
        [Column(Order = 3)]
        [Required(ErrorMessage = "請輸入異動日期")]
        //[StringLength(DATETIME)]
        [Display(Name = "異動日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime TranDateTime { get; set; }
    }
}