using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class Customer
    {
        [Key]
        [Required(ErrorMessage = "請輸入會員編號")]
        [StringLength(16)]
        [Display(Name = "會員編號")]
        public string CustomerID { get; set; }

        [Required(ErrorMessage = "請輸入會員全名")]
        [StringLength(40)]
        [Display(Name = "會員全名")]
        public string CustName { get; set; }

        [Required(ErrorMessage = "請輸入會員密碼")]
        [StringLength(20)]
        [Display(Name = "會員密碼")]
        public string CustPassword { get; set; }

        [Required(ErrorMessage = "請輸入會員簡稱")]
        [StringLength(12)]
        [Display(Name = "會員簡稱")]
        public string ShortName { get; set; }

        [Required(ErrorMessage = "請輸入性別")]
        [StringLength(1)]
        [Display(Name = "性別")]
        public string SexType { get; set; }

        //[Required(ErrorMessage = "請輸入會員等級")]
        [StringLength(10)]
        [Display(Name = "會員等級")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CustLevel { get; set; }

        //[Required(ErrorMessage = "請輸入會員類別")]
        [StringLength(10)]
        [Display(Name = "會員類別")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CustType { get; set; }

        //[Required(ErrorMessage = "請輸入連絡人姓名")]
        [StringLength(20)]
        [Display(Name = "連絡人姓名")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ContactName { get; set; }

        //[Required(ErrorMessage = "請輸入連絡人電話")]
        [StringLength(15)]
        [Display(Name = "連絡人電話")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TelephoneNumber { get; set; }

        //[Required(ErrorMessage = "請輸入連絡人行動電話")]
        [StringLength(15)]
        [Display(Name = "連絡人行動電話")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string MobileNumber { get; set; }

        //[Required(ErrorMessage = "請輸入連絡人E-MAIL位址")]
        [StringLength(50)]
        [Display(Name = "連絡人E-MAIL位址")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Email { get; set; }

        //[Required(ErrorMessage = "請輸入連絡人E-MAIL位址驗證Y:通過驗證N:未通過驗證")]
        [StringLength(1)]
        [Display(Name = "連絡人E-MAIL位址是否驗證")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string EmailValidated { get; set; }

        //[Required(ErrorMessage = "請輸入統一編號公司稅號")]
        [StringLength(10)]
        [Display(Name = "統一編號公司稅號")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TaxID { get; set; }

        //[Required(ErrorMessage = "請輸入郵遞區號")]
        [StringLength(6)]
        [Display(Name = "郵遞區號")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PostalCode { get; set; }

        //[Required(ErrorMessage = "請輸入地址")]
        [StringLength(150)]
        [Display(Name = "地址")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Address { get; set; }

        //[Required(ErrorMessage = "請輸入送貨郵遞區號2")]
        [StringLength(6)]
        [Display(Name = "送貨郵遞區號2")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PostalCode2 { get; set; }

        //[Required(ErrorMessage = "請輸入送貨地址2")]
        [StringLength(150)]
        [Display(Name = "送貨地址2")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Address2 { get; set; }

        //[Required(ErrorMessage = "請輸入備註")]
        [StringLength(120)]
        [Display(Name = "備註")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Memo { get; set; }

        //[Required(ErrorMessage = "請輸入生效日期只記錄到日期")]
        //[StringLength(DATETIME)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "生效日期")]
        [DataType(DataType.Date)]
        public DateTime ValidDate { get; set; }

        //[Required(ErrorMessage = "請輸入失效日期只記錄到日期")]
        //[StringLength(DATETIME)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "失效日期")]
        [DataType(DataType.Date)]
        public DateTime InValidDate { get; set; }
        
        //[Required(ErrorMessage = "請輸入儲值點數")]
        //[StringLength(INTEGER(20)]
        [Display(Name = "儲值點數")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int StoredPoint { get; set; }
        
        //[Required(ErrorMessage = "請輸入出生年月日")]
        //[StringLength(DATETIME)]
        [Display(Name = "生日")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        
        //[Required(ErrorMessage = "請輸入職業")]
        [StringLength(3)]
        [Display(Name = "職業")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Job { get; set; }

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