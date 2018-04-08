Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports DevExpress.ExpressApp
Imports System.Reflection
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Model


Namespace WinWebSolution.Module
	Public Interface IModelDefaultShowDetailView
	Inherits IModelNode
		<DefaultValue(True)> _
		Property DefaultShowDetailViewFromListView() As Boolean
	End Interface
	Public Interface IModelShowDetailView
	Inherits IModelNode
		Property ShowDetailView() As Boolean
	End Interface
	<DomainLogic(GetType(IModelShowDetailView))> _
	Public NotInheritable Class ModelShowDetailViewLogic
		Public Shared Function Get_ShowDetailView(ByVal showDetailView As IModelShowDetailView) As Boolean
			Dim defaultShowDetailViewFromListView As IModelDefaultShowDetailView = TryCast(showDetailView.Parent, IModelDefaultShowDetailView)
			If defaultShowDetailViewFromListView IsNot Nothing Then
				Return defaultShowDetailViewFromListView.DefaultShowDetailViewFromListView
			End If
			Return True
		End Function
	End Class

	Public NotInheritable Partial Class WinWebSolutionModule
		Inherits ModuleBase
		Public Sub New()
			InitializeComponent()
		End Sub
		Public Overrides Sub ExtendModelInterfaces(ByVal extenders As DevExpress.ExpressApp.Model.ModelInterfaceExtenders)
			MyBase.ExtendModelInterfaces(extenders)
			extenders.Add(Of IModelViews, IModelDefaultShowDetailView)()
			extenders.Add(Of IModelListView, IModelShowDetailView)()
		End Sub
	End Class
End Namespace
