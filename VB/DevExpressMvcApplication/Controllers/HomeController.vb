Imports System
Imports System.Linq
Imports System.Web.Mvc
Imports System.Collections.Generic

Namespace DevExpressMvcApplication.Controllers
    Public Class HomeController
        Inherits Controller

        Public Function Index() As ActionResult
            Return View("Index")
        End Function
    End Class
End Namespace
