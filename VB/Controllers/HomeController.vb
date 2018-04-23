Imports System.Web.Mvc

Namespace DevExpressMvcApplication.Controllers
	Public Class HomeController
		Inherits Controller

		Public Function Index() As ActionResult
			Return View("Index")
		End Function
	End Class
End Namespace
