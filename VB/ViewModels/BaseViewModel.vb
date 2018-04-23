Imports DevExpress.Xpo

Public MustInherit Class BaseViewModel(Of T)
'INSTANT VB NOTE: The variable id was renamed since Visual Basic does not allow variables and other class members to have the same name:
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