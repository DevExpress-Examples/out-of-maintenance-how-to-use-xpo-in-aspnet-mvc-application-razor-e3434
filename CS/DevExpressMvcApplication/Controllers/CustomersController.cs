using System;
using System.Linq;
using System.Web.Mvc;
using DevExpress.Xpo;
using DevExpress.Web.Mvc;
using System.Collections.Generic;

namespace DevExpressMvcApplication.Controllers
{
    public class CustomersController : BaseXpoController<Customer>
    {
        public ActionResult Index()
        {
            return View(GetCustomers());
        }

        public ActionResult IndexPartial() {
            return PartialView("IndexPartial", GetCustomers());
        }

        [HttpPost]
        public ActionResult EditCustomer([ModelBinder(typeof(DevExpressEditorsBinder))] CustomerViewModel customer) {
            Save(customer);
            return PartialView("IndexPartial", GetCustomers());
        }

        [HttpPost]
        public ActionResult DeleteCustomer([ModelBinder(typeof(DevExpressEditorsBinder))] CustomerViewModel customer) {
            Delete(customer);
            return PartialView("IndexPartial", GetCustomers());
        }

        IEnumerable<CustomerViewModel> GetCustomers() {
            return (from c in XpoSession.Query<Customer>().ToList()
                    select new CustomerViewModel() { ID = c.Oid, Name = c.Name }).ToList();
        }
    }
}
