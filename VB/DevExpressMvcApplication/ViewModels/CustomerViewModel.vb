Public Class CustomerViewModel
    Inherits BaseViewModel(Of Customer)

    Public Property Name() As String

    Public Overrides Sub GetData(ByVal model As Customer)
        model.Name = Name
    End Sub
End Class
