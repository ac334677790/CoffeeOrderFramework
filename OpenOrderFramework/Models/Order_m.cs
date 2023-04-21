using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class Order_m
    {
        [Key]
        [Column(Order = 0)]
        [Required(ErrorMessage = "請輸入公司別")]
        [StringLength(6)]
        [Display(Name = "公司別")]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "請輸入訂單單號")]
        [StringLength(20)]
        [Display(Name = "訂單單號")]
        public string OrderNo { get; set; }

        [Required(ErrorMessage = "請輸入訂單時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        //[StringLength(DATETIME)]
        [Display(Name = "訂單時間")]
        [DataType(DataType.Date)]
        public DateTime OrderDateTime { get; set; }

        [Required(ErrorMessage = "請輸入客戶編號")]
        [StringLength(16)]
        [Display(Name = "客戶編號")]
        public string CustomerID { get; set; }

        //[Required(ErrorMessage = "請輸入客戶全名／訂購姓名")]
        [StringLength(40)]
        [Display(Name = "訂購姓名")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CustName { get; set; }

        //[Required(ErrorMessage = "請輸入客戶傳真號碼")]
        [StringLength(15)]
        [Display(Name = "客戶傳真號碼")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FaxNumber { get; set; }

        //[Required(ErrorMessage = "請輸入連絡／收件人姓名")]
        [StringLength(20)]
        [Display(Name = "連絡／收件人姓名")]
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

        [Required(ErrorMessage = "請輸入付款方式")]
        [StringLength(3)]
        [Display(Name = "付款方式")]
        public string PayKind { get; set; }

        //[Required(ErrorMessage = "請輸入送貨地址")]
        [StringLength(150)]
        [Display(Name = "送貨地址")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string DeliveryAddress { get; set; }

        //[Required(ErrorMessage = "請輸入覆核人員編號")]
        [StringLength(20)]
        [Display(Name = "覆核人員編號")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CheckUserID { get; set; }

        [Required(ErrorMessage = "請輸入匯款帳號")]
        [StringLength(20)]
        [Display(Name = "匯款帳號")]
        public string PayAccount { get; set; }

        [Required(ErrorMessage = "請輸入申請帳號-銀行代碼")]
        [StringLength(10)]
        [Display(Name = "申請帳號-銀行代碼")]
        public string AppleyAccount { get; set; }

        [Required(ErrorMessage = "請輸入帳號姓名")]
        [StringLength(20)]
        [Display(Name = "帳號姓名")]
        public string AccountNAME { get; set; }

        //[Required(ErrorMessage = "請輸入備註")]
        //[StringLength(NTEXT)]
        [Display(Name = "備註")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Memo { get; set; }

        [Required(ErrorMessage = "請輸入資料狀態")]
        [StringLength(1)]
        [Display(Name = "資料狀態")]
        public string DataStatus { get; set; }

        [Required(ErrorMessage = "請輸入配送時間")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm}", ApplyFormatInEditMode = true)]
        //[StringLength(DATETIME)]
        [Display(Name = "配送時間")]
        [DataType(DataType.DateTime)]
        public DateTime DeliveryDateTime { get; set; }

        //[Required(ErrorMessage = "請輸入配送員")]
        [StringLength(20)]
        [Display(Name = "配送員")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string DeliveryUserID { get; set; }

        //[Required(ErrorMessage = "請輸入活動優惠")]
        [StringLength(3)]
        [Display(Name = "活動優惠")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Promotional { get; set; }

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