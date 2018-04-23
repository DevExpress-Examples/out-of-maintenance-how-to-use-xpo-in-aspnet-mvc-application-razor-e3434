using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace DevExpressMvcApplication.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View("Index");
        }
    }
}
