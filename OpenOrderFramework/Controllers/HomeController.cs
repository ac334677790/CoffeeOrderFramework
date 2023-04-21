using System.Web;
using System.Web.Mvc;
using OpenOrderFramework.Helpers;
using System;

namespace OpenOrderFramework.Controllers {
    public class HomeController : BaseController {
        [Authorize]

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult About() {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SelectCulture()
        {
            return View();
        }

        public ActionResult SetCulture(string culture)
        {
            // 取得合適的已實作語系名稱
            culture = CultureHelper.GetImplementedCulture(culture);

            // 將語系名稱儲存於cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // 更新cookie值
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.HttpOnly = false;
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddMonths(3);
            }
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index");
        }

    }
}
