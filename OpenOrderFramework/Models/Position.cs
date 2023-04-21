using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class Position
    {
        [Key]
        [Column(Order = 0)]
        [Required(ErrorMessage ="請輸入公司別")]
        [StringLength(6)]
        [Display(Name =" 公司別")]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage ="請輸入職位代碼")]
        [StringLength(8)]
        [Display(Name =" 職位代碼")]
        public string PositionID { get; set; }

        [Required(ErrorMessage ="請輸入職位名稱")]
        [StringLength(16)]
        [Display(Name =" 職位名稱")]
        public string PositionName { get; set; }

        [Required(ErrorMessage ="請輸入職位等級")]
        [StringLength(6)]
        [Display(Name =" 職位等級")]
        public string PositionLevel { get; set; }

        [Required(ErrorMessage ="請輸入建立人員")]
        [StringLength(14)]
        [Display(Name ="建立人員")]
        public string CreateUserID { get; set; }

        [Required(ErrorMessage ="請輸入建立日期")]
        //[StringLength(DATETIME)]
        [Display(Name ="建立日期")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateDateTime { get; set; }

        [Required(ErrorMessage ="請輸入維護人員")]
        [StringLength(14)]
        [Display(Name ="維護人員")]
        public string ModifyUserID { get; set; }

        [Required(ErrorMessage ="請輸入維護日期")]
        //[StringLength(DATETIME)]
        [Display(Name ="維護日期")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ModifyDateTime { get; set; }

    }
}