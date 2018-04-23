using System.Web.Mvc;

namespace DevExpressMvcApplication.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View("Index");
        }
    }
}
