using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class Company
    {
        [Key]
        [Required(ErrorMessage = "請輸入公司代碼")]
        [StringLength(6)]
        [Display(Name = "公司代碼")]
        public string CompanyID { get; set; }

        [Required(ErrorMessage = "請輸入公司名稱")]
        [StringLength(40)]
        [Display(Name = "公司名稱")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "請輸入公司簡稱")]
        [StringLength(20)]
        [Display(Name = "公司簡稱")]
        public string ShortName { get; set; }

        //[Required(ErrorMessage = "請輸入公司區域")]
        [StringLength(10)]
        [Display(Name = "公司區域")]
        public string Area { get; set; }

        //[Required(ErrorMessage = "請輸入公司logo")]
        //[StringLength(IMAGE)]
        //[Display(Name = "公司logo")]
        //public string Logo { get; set; }

        //[Required(ErrorMessage = "請輸入電話國碼")]
        [StringLength(3)]
        [Display(Name = "電話國碼")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PhoneCountryCode { get; set; }

        //[Required(ErrorMessage = "請輸入電話區碼")]
        [StringLength(1)]
        [Display(Name = "電話區碼")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PhoneAreaCode { get; set; }

        //[Required(ErrorMessage = "請輸入電話號碼")]
        [StringLength(15)]
        [Display(Name = "電話號碼")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessage = "請輸入傳真號碼")]
        [StringLength(15)]
        [Display(Name = "傳真號碼")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FaxNumber { get; set; }

        //[Required(ErrorMessage = "請輸入地址／公司地址")]
        [StringLength(150)]
        [Display(Name = "地址／公司地址")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CompanyAddress { get; set; }

        //[Required(ErrorMessage = "請輸入網址")]
        [StringLength(150)]
        [Display(Name = "網址")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Site { get; set; }

        //[Required(ErrorMessage = "請輸入E-MAIL位址")]
        [StringLength(50)]
        [Display(Name = "E-MAIL位址")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Email { get; set; }

        //[Required(ErrorMessage = "請輸入營業時間(起)")]
        [StringLength(5)]
        [Display(Name = "營業時間(起)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string BusinessHourS { get; set; }

        //[Required(ErrorMessage = "請輸入營業時間(迄)")]
        [StringLength(5)]
        [Display(Name = "營業時間(迄)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string BusinessHourE { get; set; }

        [Required(ErrorMessage = "請輸入建立人員")]
        [StringLength(14)]
        [Display(Name = "建立人員")]
        public string CreateUserID { get; set; }

        [Required(ErrorMessage = "請輸入建立日期")]        
        [Display(Name = "建立日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime CreateDateTime { get; set; }

        [Required(ErrorMessage = "請輸入維護人員")]
        [StringLength(14)]
        [Display(Name = "維護人員")]
        public string ModifyUserID { get; set; }

        [Required(ErrorMessage = "請輸入維護日期")]        
        [Display(Name = "維護日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime ModifyDateTime { get; set; }



    }
}