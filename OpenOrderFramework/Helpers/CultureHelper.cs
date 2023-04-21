using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace OpenOrderFramework.Helpers
{
    public class CultureHelper
    {
        // 實作語系
        private static readonly IList<string> _cultures = new List<string> 
        {
            "zh-TW",   // 中文(繁體)
            "zh-CN", // 中文(简体)
            "ja-JP"    // 日本語                        
        };

        /// <summary>
        /// 依照「name」參數回傳有效並已實作之語系名稱。
        /// 若無合適語系名稱，則回傳預設語系名稱。
        /// 本專案的預設語系名稱為「zh-TW」
        /// </summary>
        /// <param name="name">語系名稱</param>
        public static string GetImplementedCulture(string name)
        {
            // 確認是否為空字串
            if (string.IsNullOrEmpty(name))
                return GetDefaultCulture();  // 若是空字串則回傳預設語系

            // 如果該語系名稱已被實作，則接受使用該語系名稱
            if (_cultures.Where(c =>
                                c.Equals(name,
                                StringComparison.InvariantCultureIgnoreCase))
                               .Count() > 0)
                return name; // 接受這個語系


            // 取得最接近之語系名稱。例如，如果已經實作了「en-US」而使用者的請求是「en-GB」， 
            // 則回傳最接近的「en-US」因為這樣至少是相同的語言（例如：英文）  
            var n = GetNeutralCulture(name);
            foreach (var c in _cultures)
                if (c.StartsWith(n))
                    return c;

            // 如果沒有合適的，就回傳預設語系名稱
            return GetDefaultCulture();
        }


        /// <summary>
        /// 回傳預設的語系名稱        
        /// </summary>    
        public static string GetDefaultCulture()
        {
            return _cultures[0];
        }

        /// <summary>
        /// 取得目前語系名稱
        /// </summary>    
        public static string GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture.Name;
        }

        /// <summary>
        /// 取得目前的中性語系名稱
        /// </summary>    
        public static string GetCurrentNeutralCulture()
        {
            return GetNeutralCulture(Thread.CurrentThread.CurrentCulture.Name);
        }

        /// <summary>
        /// 取得中性語系名稱
        /// </summary>        
        public static string GetNeutralCulture(string name)
        {
            if (name.Length < 2)
                return name;

            return name.Substring(0, 2); // 回傳前兩個字元，例如："en", "es"
        }
    }
}