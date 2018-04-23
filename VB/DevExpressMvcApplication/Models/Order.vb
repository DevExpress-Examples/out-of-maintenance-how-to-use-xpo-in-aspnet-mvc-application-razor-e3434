Imports DevExpress.Xpo

Public Class Order
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

    Private fCustomer As Customer
    <Association("Customer-Orders"), Aggregated> _
    Public Property Customer() As Customer
        Get
            Return fCustomer
        End Get
        Set(ByVal value As Customer)
            SetPropertyValue("Customer", fCustomer, value)
        End Set
    End Property
End Class