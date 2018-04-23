Imports Microsoft.VisualBasic
Imports System.Linq
Imports System.Collections.Generic

Public Class OrdersViewModel
	Private privateSource As IList(Of OrderViewModel)
	Public Property Source() As IList(Of OrderViewModel)
		Get
			Return privateSource
		End Get
		Set(ByVal value As IList(Of OrderViewModel))
			privateSource = value
		End Set
	End Property
	Private privateCustomersLookUpData As IList(Of CustomerViewModel)
	Public Property CustomersLookUpData() As IList(Of CustomerViewModel)
		Get
			Return privateCustomersLookUpData
		End Get
		Set(ByVal value As IList(Of CustomerViewModel))
			privateCustomersLookUpData = value
		End Set
	End Property
End Class
