using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stockproject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult headerBilgi()
        {
            return PartialView("~/Views/_Partial/_PartialHeader.cshtml");

        }


    }
}