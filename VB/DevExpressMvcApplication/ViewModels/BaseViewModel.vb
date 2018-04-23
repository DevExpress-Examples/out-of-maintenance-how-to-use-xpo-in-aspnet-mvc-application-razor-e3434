Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo

Public MustInherit Class BaseViewModel(Of T)
	Private id_Renamed As Integer = -1
	Public Property ID() As Integer
		Get
			Return id_Renamed
		End Get
		Set(ByVal value As Integer)
			id_Renamed = value
		End Set
	End Property

	Public MustOverride Sub GetData(ByVal model As T)
End Class