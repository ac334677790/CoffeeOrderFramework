using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class Stock
    {
        [Key]
        [Column(Order = 0)]
        [Required(ErrorMessage = "請輸入公司別")]
        [StringLength(6)]
        [Display(Name = "公司別")]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "請輸入產品編號")]
        [StringLength(30)]
        [Display(Name = "產品編號")]
        public string ProductID { get; set; }

        [Key]
        [Column(Order = 3)]
        [Required(ErrorMessage = "請輸入批號")]
        [StringLength(25)]
        [Display(Name = "批號")]
        public string BatNo { get; set; }

        //[Required(ErrorMessage = "請輸入期初量先保留不用")]
        //[StringLength(DECIMAL(9,2)]
        [Display(Name = "期初量先保留不用")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal InitQty { get; set; }

        //[Required(ErrorMessage = "請輸入現有庫存量")]
        //[StringLength(DECIMAL(9,2)]
        [Display(Name = "現有庫存量")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal StockQty { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "請輸入庫存別代碼")]
        [StringLength(20)]
        [Display(Name = "庫存別代碼")]
        public string WarehouseID { get; set; }

        //[Required(ErrorMessage = "請輸入最近異動日期")]
        //[StringLength(DATETIME)]
        [Display(Name = "最近異動日期")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DataType(DataType.Date)]
        public DateTime LastTranDate { get; set; }

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