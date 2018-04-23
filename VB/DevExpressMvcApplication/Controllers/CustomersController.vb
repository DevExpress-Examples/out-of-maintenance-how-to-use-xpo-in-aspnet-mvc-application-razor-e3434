Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Web.Mvc
Imports DevExpress.Xpo
Imports DevExpress.Web.Mvc
Imports System.Collections.Generic

Namespace DevExpressMvcApplication.Controllers
	Public Class CustomersController
		Inherits BaseXpoController(Of Customer)
		Public Function Index() As ActionResult
			Return View(GetCustomers())
		End Function

		Public Function IndexPartial() As ActionResult
			Return PartialView("IndexPartial", GetCustomers())
		End Function

		<HttpPost> _
		Public Function EditCustomer(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal customer As CustomerViewModel) As ActionResult
			Save(customer)
			Return PartialView("IndexPartial", GetCustomers())
		End Function

		<HttpPost> _
		Public Function DeleteCustomer(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal customer As CustomerViewModel) As ActionResult
			Delete(customer)
			Return PartialView("IndexPartial", GetCustomers())
		End Function

		Private Function GetCustomers() As IEnumerable(Of CustomerViewModel)
			Return ( _
					From c In XpoSession.Query(Of Customer)().ToList() _
					Select New CustomerViewModel() With {.ID = c.Oid, .Name = c.Name}).ToList()
		End Function
	End Class
End Namespace
