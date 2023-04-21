using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class Employee
    {
        [Key]
        [Column(Order = 0)]
        [Required(ErrorMessage = "請輸入公司別")]
        [StringLength(6)]
        [Display(Name = "公司別")]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "請輸入員工編號")]
        [StringLength(8)]
        [Display(Name = "員工編號")]
        public string EmpID { get; set; }

        [Required(ErrorMessage = "請輸入姓名")]
        [StringLength(16)]
        [Display(Name = "姓名")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "請輸入部門代號")]
        [StringLength(6)]
        [Display(Name = "部門代號")]
        public string DeptID { get; set; }

        [Required(ErrorMessage = "請輸入職位代碼")]
        [StringLength(8)]
        [Display(Name = "職位代碼")]
        public string PositionID { get; set; }

        [Required(ErrorMessage = "請輸入身份証字號")]
        [StringLength(10)]
        [Display(Name = "身份証字號")]
        public string IDCard { get; set; }

        //[Required(ErrorMessage = "請輸入聯絡電話")]
        [StringLength(30)]
        [Display(Name = "聯絡電話")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessage = "請輸入電子信箱")]
        [StringLength(50)]
        [Display(Name = "電子信箱")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Email { get; set; }

        //[Required(ErrorMessage = "請輸入備註")]
        [StringLength(100)]
        [Display(Name = "備註")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Memo { get; set; }

        //[Required(ErrorMessage = "請輸入生日 ")]
        [Display(Name = "生日")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        //[Required(ErrorMessage = "請輸入員工卡號")]
        [StringLength(10)]
        [Display(Name = "員工卡號")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string EmpCardID { get; set; }

        //[Required(ErrorMessage = "請輸入建立人員")]
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