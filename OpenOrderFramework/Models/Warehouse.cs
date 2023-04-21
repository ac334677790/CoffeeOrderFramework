using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class Warehouse
    {
        [Key]
        [Column(Order = 0)]
        [Required(ErrorMessage = "請輸入公司別")]
        [StringLength(6)]
        [Display(Name = "公司別")]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "請輸入庫存別代碼")]
        [StringLength(10)]
        [Display(Name = "庫存別代碼")]
        public string WarehouseID { get; set; }

        [Required(ErrorMessage = "請輸入庫存別名稱")]
        [StringLength(20)]
        [Display(Name = "庫存別名稱")]
        public string WarehouseName { get; set; }

        //[Required(ErrorMessage = "請輸入聯絡電話")]
        [StringLength(20)]
        [Display(Name = "聯絡電話")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessage = "請輸入廠商地址")]
        [StringLength(150)]
        [Display(Name = "廠商地址")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string WarehouseAddress { get; set; }

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