Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp.Updating
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.BaseImpl

Namespace WinWebSolution.Module
	Public Class Updater
		Inherits ModuleUpdater
		Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
			MyBase.New(objectSpace, currentDBVersion)
		End Sub
		Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
			MyBase.UpdateDatabaseAfterUpdateSchema()
			Using uow As New UnitOfWork(Session.DataLayer)
				Dim p As New Person(uow)
				p.FirstName = "Dennis"
				p.LastName = "Garavsky"
				p.Birthday = New DateTime(1987, 2, 23)

				uow.CommitChanges()
			End Using
		End Sub
	End Class
End Namespace
