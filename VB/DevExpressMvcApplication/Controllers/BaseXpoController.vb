Imports System.Web.Mvc
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB.Exceptions

Namespace DevExpressMvcApplication.Controllers
    Public MustInherit Class BaseXpoController(Of T As XPObject)
        Inherits Controller

        Private fSession As UnitOfWork

        Public Sub New()
            MyBase.New()
                fSession = CreateSession()
        End Sub

        Protected ReadOnly Property XpoSession() As UnitOfWork
            Get
                Return fSession
            End Get
        End Property

        Protected Overridable Function CreateSession() As UnitOfWork
            Return XpoHelper.GetNewUnitOfWork()
        End Function

        Private Function Save(ByVal viewModel As BaseViewModel(Of T), ByVal delete As Boolean) As Boolean
            Dim model As T = XpoSession.GetObjectByKey(Of T)(viewModel.ID)
            If model Is Nothing AndAlso (Not delete) Then
                model = CType(XpoSession.GetClassInfo(Of T)().CreateNewObject(XpoSession), T)
            End If
            If Not delete Then
                viewModel.GetData(model)
            ElseIf model IsNot Nothing Then
                XpoSession.Delete(model)
            End If
            Try
                XpoSession.CommitChanges()
                Return True
            Catch e1 As LockingException
                Return False
            End Try
        End Function

        Protected Function Save(ByVal viewModel As BaseViewModel(Of T)) As Boolean
            Return Save(viewModel, False)
        End Function

        Protected Function Delete(ByVal viewModel As BaseViewModel(Of T)) As Boolean
            Return Save(viewModel, True)
        End Function
    End Class
End Namespace
