using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class Param
    {
        [Key]
        [Column(Order = 0)]
        //[Required(ErrorMessage = "請輸入公司別")]
        [StringLength(6)]
        [Display(Name = "公司別")]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "請輸入參數類別代號")]
        [StringLength(10)]
        [Display(Name = "參數類別代號")]
        public string ParaKind { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required(ErrorMessage = "請輸入參數(1)")]
        [StringLength(14)]
        [Display(Name = "參數(1)")]
        public string Para1 { get; set; }

        //[Required(ErrorMessage = "請輸入參數(2)")]
        [StringLength(50)]
        [Display(Name = "參數(2)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Para2 { get; set; }

        //[Required(ErrorMessage = "請輸入參數(3)")]
        //[StringLength(DECIMAL(16,3)]
        [Display(Name = "參數(3)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal Para3 { get; set; }

        //[Required(ErrorMessage = "請輸入參數(4)")]
        //[StringLength(NTEXT)]
        [Display(Name = "參數(4)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Para4 { get; set; }

        [Required(ErrorMessage = "請輸入參數說明／備註")]
        [StringLength(50)]
        [Display(Name = "參數說明／備註")]
        public string ParaName { get; set; }

        //[Required(ErrorMessage = "請輸入使用者是否可刪修YN")]
        [StringLength(2)]
        [Display(Name = "使用者是否可刪修YN")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Modify_YN { get; set; }

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