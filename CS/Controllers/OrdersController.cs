using DevExpress.Web.Mvc;
using DevExpress.Xpo;
using System.Linq;
using System.Web.Mvc;

namespace DevExpressMvcApplication.Controllers {
    public class OrdersController : BaseXpoController<Order> {
        public ActionResult Index() {
            return View("Index", GetOrders());
        }

        public ActionResult IndexPartial() {
            return PartialView("IndexPartial", GetOrders());
        }

        [HttpPost]
        public ActionResult EditOrder([ModelBinder(typeof(DevExpressEditorsBinder))] OrderViewModel order) {
            Save(order);
            return PartialView("IndexPartial", GetOrders());
        }

        [HttpPost]
        public ActionResult DeleteOrder([ModelBinder(typeof(DevExpressEditorsBinder))] OrderViewModel order) {
            Delete(order);
            return PartialView("IndexPartial", GetOrders());
        }

        OrdersViewModel GetOrders() {
            return new OrdersViewModel() {
                Source = (from o in XpoSession.Query<Order>().ToList()
                            select new OrderViewModel() {
                                ID = o.Oid, Name = o.Name, Customer = o.Customer.Oid
                            }).ToList(),
                CustomersLookUpData = (from c in XpoSession.Query<Customer>().ToList()
                                        select new CustomerViewModel() {
                                            ID = c.Oid, Name = c.Name
                                        }).ToList()
                };
        }
    }
}