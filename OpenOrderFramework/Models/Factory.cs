using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class Factory
    {
        [Key]
        [Column(Order = 0)]
        [Required(ErrorMessage = "請輸入公司別")]
        [StringLength(6)]
        [Display(Name = "公司別")]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "請輸入廠商編號")]
        [StringLength(16)]
        [Display(Name = "廠商編號")]
        public string FactoryID { get; set; }

        [Required(ErrorMessage = "請輸入廠商簡稱")]
        [StringLength(10)]
        [Display(Name = "廠商簡稱")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]     
        public string ShortName { get; set; }

        [Required(ErrorMessage = "請輸入廠商全銜")]
        [StringLength(40)]
        [Display(Name = "廠商全銜")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FactoryName { get; set; }

        ////[Required(ErrorMessage = "請輸入郵遞區號")]
        //[StringLength(6)]
        //[Display(Name = "郵遞區號")]
        //[DisplayFormat(ConvertEmptyStringToNull = false)]     
        //public string PostalCode { get; set; }

        //[Required(ErrorMessage = "請輸入廠商郵遞區號")]
        [StringLength(6)]
        [Display(Name = "廠商郵遞區號")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]     
        public string PostalCode { get; set; }

        //[Required(ErrorMessage = "請輸入廠商地址")]FactoryAddress
        [StringLength(150)]
        [Display(Name = "廠商地址")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FactoryAddress { get; set; }

        //[Required(ErrorMessage = "請輸入負責人姓名")]
        [StringLength(10)]
        [Display(Name = "負責人姓名")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]     
        public string ChargeName { get; set; }

        //[Required(ErrorMessage = "請輸入電話國碼")]
        [StringLength(3)]
        [Display(Name = "電話國碼")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]     
        public string PhoneCountryCode { get; set; }

        //[Required(ErrorMessage = "請輸入電話區碼")]
        [StringLength(4)]
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

        //[Required(ErrorMessage = "請輸入E-MAIL位址")]
        [StringLength(50)]
        [Display(Name = "E-MAIL位址")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]     
        public string Email { get; set; }

        //[Required(ErrorMessage = "請輸入連絡人姓名")]
        [StringLength(10)]
        [Display(Name = "連絡人姓名")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ContactName { get; set; }

        //[Required(ErrorMessage = "請輸入連絡人職稱")]
        [StringLength(16)]
        [Display(Name = "連絡人職稱")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ContactTiitle { get; set; }

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
        public string ContactEmail { get; set; }

        //[Required(ErrorMessage = "請輸入關帳日")]
        //[StringLength(SMALLINT)]
        [Display(Name = "關帳日")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public Int16 CloseDate { get; set; }

        //[Required(ErrorMessage = "請輸入付款日")]
        //[StringLength(SMALLINT)]
        [Display(Name = "付款日")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public Int16 PayDate { get; set; }

        //[Required(ErrorMessage = "請輸入付款天數")]
        //[StringLength(SMALLINT)]
        [Display(Name = "付款天數")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public Int16 PayDays { get; set; }

        //[Required(ErrorMessage = "請輸入統一編號公司稅號")]
        [StringLength(8)]
        [Display(Name = "統一編號公司稅號")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TaxID { get; set; }

        //[Required(ErrorMessage = "請輸入網址")]
        [StringLength(150)]
        [Display(Name = "網址")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Site { get; set; }

        //[Required(ErrorMessage = "請輸入廠商等級")]
        [StringLength(3)]
        [Display(Name = "廠商等級")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FactoryLevel { get; set; }

        //[Required(ErrorMessage = "請輸入廠商類別")]
        [StringLength(10)]
        [Display(Name = "廠商類別")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FactoryType { get; set; }

        //[Required(ErrorMessage = "請輸入往來銀行(一)")]
        [StringLength(20)]
        [Display(Name = "往來銀行(一)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Bank1 { get; set; }

        //[Required(ErrorMessage = "請輸入帳號(一)")]
        [StringLength(15)]
        [Display(Name = "帳號(一)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Account1 { get; set; }

        //[Required(ErrorMessage = "請輸入往來銀行(二)")]
        [StringLength(20)]
        [Display(Name = "往來銀行(二)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Bank2 { get; set; }

        //[Required(ErrorMessage = "請輸入帳號(二)")]
        [StringLength(15)]
        [Display(Name = "帳號(二)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Account2 { get; set; }

        //[Required(ErrorMessage = "請輸入付款條件")]
        [StringLength(30)]
        [Display(Name = "付款條件")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PayTerms { get; set; }

        //[Required(ErrorMessage = "請輸入付款碼1.現金2.支票3.現金支票")]
        [StringLength(1)]
        [Display(Name = "付款碼1.現金2.支票3.現金支票")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PayCode { get; set; }

        //[Required(ErrorMessage = "請輸入備註")]
        [StringLength(120)]
        [Display(Name = "備註")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Memo { get; set; }

        //[Required(ErrorMessage = "請輸入應付帳款科目")]
        [StringLength(10)]
        [Display(Name = "應付帳款科目")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Acct_no_ar1 { get; set; }

        //[Required(ErrorMessage = "請輸入應付票據科目")]
        [StringLength(10)]
        [Display(Name = "應付票據科目")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Acct_no_ar2 { get; set; }

        //[Required(ErrorMessage = "請輸入預付貨款科目")]
        [StringLength(10)]
        [Display(Name = "預付貨款科目")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Acct_no_ar3 { get; set; }

        //[Required(ErrorMessage = "請輸入應付佣金科目")]
        [StringLength(10)]
        [Display(Name = "應付佣金科目")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Acct_no_ar4 { get; set; }

        //[Required(ErrorMessage = "請輸入佣金收入科目")]
        [StringLength(10)]
        [Display(Name = "佣金收入科目")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Acct_no_ar5 { get; set; }

        //[Required(ErrorMessage = "請輸入慣用銀行科目")]
        [StringLength(10)]
        [Display(Name = "慣用銀行科目")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Acct_no_ar6 { get; set; }

        //[Required(ErrorMessage = "請輸入失效日期")]
        //[StringLength(DATETIME)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "失效日期")]
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