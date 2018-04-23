Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports System.Reflection
Imports DevExpress.Xpo.DB
Imports System.Configuration
Imports DevExpress.Xpo.Metadata

Public NotInheritable Class XpoHelper
	Private Const ConnectionStringName As String = "Q330379"

	Private Sub New()
	End Sub
	Shared Sub New()
		UpdateDatabase()
	End Sub

	Public Shared Function GetNewSession() As Session
		Return New Session(DataLayer)
	End Function

	Public Shared Function GetNewUnitOfWork() As UnitOfWork
		Return New UnitOfWork(DataLayer)
	End Function

	Private ReadOnly Shared lockObject As Object = New Object()

'INSTANT VB TODO TASK: There is no VB.NET equivalent to 'volatile':
'ORIGINAL LINE: static volatile IDataLayer fDataLayer;
	Private Shared fDataLayer As IDataLayer
	Private Shared ReadOnly Property DataLayer() As IDataLayer
		Get
			If fDataLayer Is Nothing Then
				SyncLock lockObject
					If fDataLayer Is Nothing Then
						fDataLayer = GetDataLayer()
					End If
				End SyncLock
			End If
			Return fDataLayer
		End Get
	End Property

	Private Shared Function GetDataLayer() As IDataLayer
		XpoDefault.Session = Nothing
		Dim dict As XPDictionary = New ReflectionDictionary()
		dict.GetDataStoreSchema(System.Reflection.Assembly.GetExecutingAssembly())
		Return New ThreadSafeDataLayer(dict, XpoDefault.GetConnectionProvider(ConfigurationManager.ConnectionStrings(ConnectionStringName).ConnectionString, AutoCreateOption.None))
	End Function

	Private Shared Sub UpdateDatabase()
		Using dal As IDataLayer = XpoDefault.GetDataLayer(ConfigurationManager.ConnectionStrings(ConnectionStringName).ConnectionString, AutoCreateOption.DatabaseAndSchema)
				Using session As New Session(dal)
					Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
					session.UpdateSchema(asm)
					session.CreateObjectTypeRecords(asm)
				End Using
		End Using
	End Sub
End Class
