Imports Microsoft.VisualBasic
Imports System.Linq
Imports System.Web.Mvc
Imports DevExpress.Xpo
Imports System.Collections.Generic
Imports DevExpress.Web.Mvc

Namespace DevExpressMvcApplication.Controllers
	Public Class OrdersController
		Inherits BaseXpoController(Of Order)
		Public Function Index() As ActionResult
			Return View("Index", GetOrders())
		End Function

		Public Function IndexPartial() As ActionResult
			Return PartialView("IndexPartial", GetOrders())
		End Function

		<HttpPost> _
		Public Function EditOrder(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal order As OrderViewModel) As ActionResult
			Save(order)
			Return PartialView("IndexPartial", GetOrders())
		End Function

		<HttpPost> _
		Public Function DeleteOrder(<ModelBinder(GetType(DevExpressEditorsBinder))> ByVal order As OrderViewModel) As ActionResult
			Delete(order)
			Return PartialView("IndexPartial", GetOrders())
		End Function

		Private Function GetOrders() As OrdersViewModel
			Return New OrdersViewModel() With {.Source = ( _
						From o In XpoSession.Query(Of Order)().ToList() _
						Select New OrderViewModel() With {.ID = o.Oid, .Name = o.Name, .Customer = o.Customer.Oid}).ToList(), .CustomersLookUpData = ( _
						From c In XpoSession.Query(Of Customer)().ToList() _
						Select New CustomerViewModel() With {.ID = c.Oid, .Name = c.Name}).ToList()}
		End Function
	End Class
End Namespace