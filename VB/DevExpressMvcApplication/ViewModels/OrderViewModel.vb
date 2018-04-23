Imports System.Collections.Generic

Public Class OrderViewModel
    Inherits BaseViewModel(Of Order)

    Public Property Name() As String
    Public Property Customer() As Integer

    Public Overrides Sub GetData(ByVal model As Order)
        model.Name = Name
        model.Customer = model.Session.GetObjectByKey(Of Customer)(Customer)
    End Sub
End Class
