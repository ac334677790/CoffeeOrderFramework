using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class Department
    {
        [Key]
        [Column(Order=0)]
        [Required(ErrorMessage ="請輸入公司別")]
        [StringLength(6)]
        [Display(Name ="公司別")]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage ="請輸入部門代碼")]
        [StringLength(6)]
        [Display(Name ="部門代碼")]
        public string DeptID { get; set; }

        [Required(ErrorMessage ="請輸入部門名稱")]
        [StringLength(30)]
        [Display(Name ="部門名稱")]
        public string DeptName { get; set; }

        //[Required(ErrorMessage ="請輸入責任部門代碼")]
        [StringLength(6)]
        [Display(Name ="責任部門代碼")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ParentDeptID { get; set; }

        //[Required(ErrorMessage ="請輸入部門主管員工編號")]
        [StringLength(8)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "部門主管員工編號")]
        public string DeptDirectorID { get; set; }

        //[Required(ErrorMessage ="請輸入生效日期<暫不使用>")]
        //[StringLength(DATETIME)]
        [Display(Name ="生效日期 <暫不使用>")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime ValidDate { get; set; }

        //[Required(ErrorMessage ="請輸入失效日期<暫不使用>")]
        //[StringLength(DATETIME)]
        [Display(Name ="失效日期 <暫不使用>")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime InValidDate { get; set; }

        [Required(ErrorMessage ="請輸入建立人員")]
        [StringLength(14)]
        [Display(Name ="建立人員")]
        public string CreateUserID { get; set; }

        [Required(ErrorMessage ="請輸入建立日期")]
        //[StringLength(DATETIME)]
        [Display(Name ="建立日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateDateTime { get; set; }

        [Required(ErrorMessage ="請輸入維護人員")]
        [StringLength(14)]
        [Display(Name ="維護人員")]
        public string ModifyUserID { get; set; }

        [Required(ErrorMessage ="請輸入維護日期")]
        //[StringLength(DATETIME)]
        [Display(Name ="維護日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ModifyDateTime { get; set; }

    }
}