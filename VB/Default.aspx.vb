Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxGridView

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		ASPxGridView1.DataSource = Enumerable.Range(0, 10).Select(Function(i) New With {Key .ID = i, Key .ClientSideCancel = "Example " & i, Key .SampleColumn = "Sample data " & i, Key .ServerSideExample = i * 123})
		ASPxGridView1.DataBind()
	End Sub
	Protected Sub ASPxGridView1_CustomJSProperties(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridView.ASPxGridViewClientJSPropertiesEventArgs)
		Dim clientData = New Dictionary(Of Integer, Object)()
		Dim grid = TryCast(sender, ASPxGridView)
		For i As Integer = grid.VisibleStartIndex To grid.VisibleStartIndex + grid.SettingsPager.PageSize
			Dim rowValues = TryCast(grid.GetRowValues(i, New String() { "ID", "ServerSideExample" }), Object())

			Dim key = Convert.ToInt32(rowValues(0))
			If key Mod 2 <> 0 Then
				clientData.Add(key, "ServerSideExample")
			End If
		Next i
		e.Properties("cp_cellsToDisable") = clientData
	End Sub
End Class