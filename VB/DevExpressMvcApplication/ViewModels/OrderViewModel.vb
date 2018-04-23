Imports Microsoft.VisualBasic
Imports System.Collections.Generic

Public Class OrderViewModel
	Inherits BaseViewModel(Of Order)
	Private privateName As String
	Public Property Name() As String
		Get
			Return privateName
		End Get
		Set(ByVal value As String)
			privateName = value
		End Set
	End Property
	Private privateCustomer As Integer
	Public Property Customer() As Integer
		Get
			Return privateCustomer
		End Get
		Set(ByVal value As Integer)
			privateCustomer = value
		End Set
	End Property

	Public Overrides Sub GetData(ByVal model As Order)
		model.Name = Name
		model.Customer = model.Session.GetObjectByKey(Of Customer)(Customer)
	End Sub
End Class
