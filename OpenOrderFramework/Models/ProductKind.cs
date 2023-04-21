using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class ProductKind
    {
        [Key]
        [Column(Order = 0)]
        [Required(ErrorMessage = "請輸入公司別")]
        [StringLength(6)]
        [Display(Name = "公司別")]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "請輸入產品類別代碼")]
        [StringLength(16)]
        [Display(Name = "產品類別代碼")]
        public string ProdKind { get; set; }

        [Required(ErrorMessage = "請輸入產品類別名稱")]
        [StringLength(50)]
        [Display(Name = "產品類別名稱")]
        public string ProdKindName { get; set; }

        [Required(ErrorMessage = "請輸入父階產品類別代碼")]
        [StringLength(16)]
        [Display(Name = "父階產品類別代碼")]
        public string ParentProdKind { get; set; }

        //[Required(ErrorMessage = "請輸入代碼(1)起")]
        [StringLength(14)]
        [Display(Name = "代碼(1)起")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Code1 { get; set; }

        //[Required(ErrorMessage = "請輸入代碼(2)迄")]
        [StringLength(14)]
        [Display(Name = "代碼(2)迄")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Code2 { get; set; }

        //[Required(ErrorMessage = "請輸入圖片")]
        [StringLength(100)]
        [Display(Name = "圖片")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Photo { get; set; }

        //[Required(ErrorMessage = "請輸入備註")]
        [StringLength(50)]
        [Display(Name = "備註")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Memo { get; set; }

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