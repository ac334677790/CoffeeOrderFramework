﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OpenOrderFramework.Models
{
    public class CombProduct_m
    {
        [Key]
        [Column(Order = 0)]
        [Required(ErrorMessage = "請輸入公司別")]
        [StringLength(6)]
        [Display(Name = "公司別")]
        public string CompanyID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "請輸入組合產品編號")]
        [StringLength(16)]
        [Display(Name = "組合產品編號")]
        public string CombProductID { get; set; }

        [Required(ErrorMessage = "請輸入組合產品名稱")]
        [StringLength(50)]
        [Display(Name = "組合產品名稱")]
        public string CombProdName { get; set; }

        [Required(ErrorMessage = "請輸入組合產品規格")]
        //[StringLength(NTEXT)]
        [Display(Name = "組合產品規格")]
        public string CombProdSpec { get; set; }

        //[Required(ErrorMessage = "請輸入圖片")]
        [StringLength(100)]
        [Display(Name = "圖片")]
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