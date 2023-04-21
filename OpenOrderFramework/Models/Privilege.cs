using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class Privilege
    {
        [Key]
        [Column(Order = 0)]
        [Required(ErrorMessage = "請輸入公司別")]
        [StringLength(6)]
        [Display(Name = "公司別")]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "請輸入群組／使用者帳號")]
        [StringLength(14)]
        [Display(Name = "群組／使用者帳號")]
        public string GroupID { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "請輸入程式代碼")]
        [StringLength(15)]
        [Display(Name = "程式代碼")]
        public string ProgramID { get; set; }

        [Required(ErrorMessage = "請輸入新增權限")]
        [StringLength(1)]
        [Display(Name = "新增權限")]
        public string Add { get; set; }

        [Required(ErrorMessage = "請輸入查詢權限")]
        [StringLength(1)]
        [Display(Name = "查詢權限")]
        public string Search { get; set; }

        [Required(ErrorMessage = "請輸入修改權限")]
        [StringLength(1)]
        [Display(Name = "修改權限")]
        public string Modify { get; set; }

        [Required(ErrorMessage = "請輸入刪除權限")]
        [StringLength(1)]
        [Display(Name = "刪除權限")]
        public string Delete { get; set; }

        [Required(ErrorMessage = "請輸入列印權限")]
        [StringLength(1)]
        [Display(Name = "列印權限")]
        public string Print { get; set; }

        [Required(ErrorMessage = "請輸入執行權限")]
        [StringLength(1)]
        [Display(Name = "執行權限")]
        public string Run { get; set; }

        [Required(ErrorMessage = "請輸入說明權限")]
        [StringLength(1)]
        [Display(Name = "說明權限")]
        public string Help { get; set; }

        [Required(ErrorMessage = "請輸入拋轉權限")]
        [StringLength(1)]
        [Display(Name = "拋轉權限")]
        public string Transform { get; set; }

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