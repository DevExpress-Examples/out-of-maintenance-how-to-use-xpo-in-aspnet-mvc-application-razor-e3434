Imports DevExpress.Web.Mvc
Imports DevExpress.Xpo
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Mvc

Namespace DevExpressMvcApplication.Controllers
	Public Class CustomersController
		Inherits BaseXpoController(Of Customer)

		Public Function Index() As ActionResult
			Return View(GetCustomers())
		End Function

		Public Function IndexPartial() As ActionResult
			Return PartialView("IndexPartial", GetCustomers())
		End Function

		<HttpPost>
		Public Function EditCustomer(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal customer As CustomerViewModel) As ActionResult
			Save(customer)
			Return PartialView("IndexPartial", GetCustomers())
		End Function

		<HttpPost>
		Public Function DeleteCustomer(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal customer As CustomerViewModel) As ActionResult
			Delete(customer)
			Return PartialView("IndexPartial", GetCustomers())
		End Function

		Private Function GetCustomers() As IEnumerable(Of CustomerViewModel)
			Return (
			    From c In XpoSession.Query(Of Customer)().ToList()
			    Select New CustomerViewModel() With {.ID = c.Oid, .Name = c.Name}).ToList()
		End Function
	End Class
End Namespace
