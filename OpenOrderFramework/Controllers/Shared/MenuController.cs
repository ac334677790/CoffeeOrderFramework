using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenOrderFramework.Models;

namespace OpenOrderFramework.Controllers.Shared
{
    public class MenuController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Menu()
        {
            var ChargeTypes = db.Programs.ToList();
            return PartialView(ChargeTypes);
        }
    }
}