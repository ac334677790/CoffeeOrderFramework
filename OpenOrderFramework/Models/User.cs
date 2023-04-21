using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    //[System.Web.Mvc.Bind(Exclude = "Email")]
    public class User
    {
        [Key]        
        [Column(Order = 0)]
        [Required(ErrorMessage = "請輸入公司別")]
        [StringLength(6)]
        [Display(Name = "公司別")]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "請輸入使用者帳號")]
        [StringLength(14)]
        [Display(Name = "使用者帳號")]
        public string UserID { get; set; }

        [Required(ErrorMessage = "請輸入使用者密碼")]
        [StringLength(16)]
        [Display(Name = "使用者密碼")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "請輸入員工編號")]
        [StringLength(16)]
        [Display(Name = "員工編號")]
        public string EmpID { get; set; }


        //[Required(ErrorMessage = "請輸入E-MAIL位址")]        
        [StringLength(50)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
    ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-MAIL位址")]
        [DisplayFormat(ConvertEmptyStringToNull=false)]        
        public string Email { get; set; }

        //[Required(ErrorMessage = "請輸入備註")]
        [StringLength(30)]
        [Display(Name = "備註")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]     
        public string Memo { get; set; }

        //[Required(ErrorMessage = "請輸入失效日期")]
        //[StringLength(DATETIME)]
        [Display(Name = "失效日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime InValidDate { get; set; }

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