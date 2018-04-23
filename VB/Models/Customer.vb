Imports DevExpress.Xpo

Public Class Customer
	Inherits XPObject

	Public Sub New(ByVal session As Session)
		MyBase.New(session)
	End Sub

	Private fName As String
	Public Property Name() As String
		Get
			Return fName
		End Get
		Set(ByVal value As String)
			SetPropertyValue("Name", fName, value)
		End Set
	End Property

	<Association("Customer-Orders")>
	Public ReadOnly Property Orders() As XPCollection(Of Order)
		Get
			Return GetCollection(Of Order)("Orders")
		End Get
	End Property
End Class