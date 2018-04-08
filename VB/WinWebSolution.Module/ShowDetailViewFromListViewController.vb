Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.SystemModule

Namespace WinWebSolution.Module
	Public Class ShowDetailViewFromListViewController
		Inherits ViewController(Of ListView)
		Public Const EnabledKeyShowDetailView As String = "ShowDetailViewFromListViewController"
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			Dim controller As ListViewProcessCurrentObjectController = Frame.GetController(Of ListViewProcessCurrentObjectController)()
			If controller IsNot Nothing Then
				Dim modelShowDetailView As IModelShowDetailView = TryCast(View.Model, IModelShowDetailView)
				If modelShowDetailView Is Nothing Then
					controller.ProcessCurrentObjectAction.Enabled(EnabledKeyShowDetailView) = True
				Else
					controller.ProcessCurrentObjectAction.Enabled(EnabledKeyShowDetailView) = modelShowDetailView.ShowDetailView
				End If
			End If
		End Sub
	End Class
End Namespace