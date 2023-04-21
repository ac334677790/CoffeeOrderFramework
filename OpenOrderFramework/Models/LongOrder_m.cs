using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class LongOrder_m
    {
        [Key]
        [Column(Order = 0)]
        [Required(ErrorMessage = "請輸入公司別")]
        [StringLength(6)]
        [Display(Name = "公司別")]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "請輸入長期訂單單號")]
        [StringLength(20)]
        [Display(Name = "長期訂單單號")]
        public string LongOrderNo { get; set; }

        [Required(ErrorMessage = "請輸入訂單單號")]
        [StringLength(20)]
        [Display(Name = "訂單單號")]
        public string OrderNo { get; set; }

        [Required(ErrorMessage = "請輸入開始日期")]
        //[StringLength(DATETIME)]
        [Display(Name = "開始日期")]
        [DataType(DataType.Date)]
        public DateTime DatetimeS { get; set; }

        [Required(ErrorMessage = "請輸入結束日期 最多一個月??2015810 Ting：對目前最多一個月")]
        //[StringLength(DATETIME)]
        [Display(Name = "結束日期 最多一個月??2015810 Ting：對目前最多一個月")]
        [DataType(DataType.Date)]
        public DateTime DatetimeE { get; set; }

        [Required(ErrorMessage = "請輸入配送週期(禮拜一)")]
        [StringLength(1)]
        [Display(Name = "配送週期(禮拜一)")]
        public string CycleDay1 { get; set; }

        [Required(ErrorMessage = "請輸入配送週期(禮拜二)")]
        [StringLength(1)]
        [Display(Name = "配送週期(禮拜二)")]
        public string CycleDay2 { get; set; }

        [Required(ErrorMessage = "請輸入配送週期(禮拜三)")]
        [StringLength(1)]
        [Display(Name = "配送週期(禮拜三)")]
        public string CycleDay3 { get; set; }

        [Required(ErrorMessage = "請輸入配送週期(禮拜四)")]
        [StringLength(1)]
        [Display(Name = "配送週期(禮拜四)")]
        public string CycleDay4 { get; set; }

        [Required(ErrorMessage = "請輸入配送週期(禮拜五)")]
        [StringLength(1)]
        [Display(Name = "配送週期(禮拜五)")]
        public string CycleDay5 { get; set; }

        [Required(ErrorMessage = "請輸入配送週期(禮拜六)")]
        [StringLength(1)]
        [Display(Name = "配送週期(禮拜六)")]
        public string CycleDay6 { get; set; }

        [Required(ErrorMessage = "請輸入配送週期(禮拜天)")]
        [StringLength(1)]
        [Display(Name = "配送週期(禮拜天)")]
        public string CycleDay7 { get; set; }

        [Required(ErrorMessage = "請輸入配送週期(每週)")]
        [StringLength(1)]
        [Display(Name = "配送週期(是否每週)")]
        public string CycleWeek { get; set; }

        [Required(ErrorMessage = "請輸入配送週期(每月X號)")]
        [StringLength(2)]
        [Display(Name = "配送週期(每月X號)")]
        public string CycleMonth { get; set; }

        [Required(ErrorMessage = "請輸入配送時間")]
        //[StringLength(DATETIME)]
        [Display(Name = "配送時間")]
        [DataType(DataType.Time)]
        public DateTime CycleHour { get; set; }

        //[Required(ErrorMessage = "請輸入備註")]
        //[StringLength(NTEXT)]
        [Display(Name = "備註")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Memo { get; set; }

        [Required(ErrorMessage = "請輸入資料狀態，N：未結案、Y：已結案、D:為作廢")]
        [StringLength(1)]
        [Display(Name = "資料狀態，N：未結案、Y：已結案、D:為作廢")]
        public string DataStatus { get; set; }

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


    }
}