using System.Web;
using System.Web.Mvc;
using System.Threading;
using OpenOrderFramework.Helpers;
using System.Web.Routing;
using PagedList;
using OpenOrderFramework.ViewModels;
using OpenOrderFramework.Models;
using System.Collections.Generic;
using System.Linq;

namespace OpenOrderFramework.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        protected override void Initialize(RequestContext rc)
        {
            base.Initialize(rc);

            string cultureName = null;
            // 嘗試由請求（Request）中讀取語系cookie
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages[0]; // 由HTTP標頭取得

            // 確認取得有效的語系名稱
            cultureName = CultureHelper.GetImplementedCulture(cultureName);


            // 修正目前執行緒的語系            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            //取得作業名稱            
            var url = "";
            if(Request.Url.Segments.Length>=2){
                url = Request.Url.Segments[1].Replace("/", "").ToString();
                var a = from PG in db.Programs
                        where PG.ProgramID == url
                        select PG.ProgDescription;

                ViewBag.ProgramName = a.FirstOrDefault();
            }
                
            

        }





    }
}