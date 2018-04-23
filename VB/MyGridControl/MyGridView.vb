Imports Microsoft.VisualBasic
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.Drawing
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Container

Namespace MyXtraGrid
	<System.ComponentModel.DesignerCategory("")> _
	Public Class MyGridView
		Inherits DevExpress.XtraGrid.Views.Grid.GridView
		Public Sub New()
			Me.New(Nothing)
		End Sub
		Public Sub New(ByVal grid As DevExpress.XtraGrid.GridControl)
			MyBase.New(grid)
			OptionsView.AllowCellMerge = True
		End Sub
		Protected Overrides ReadOnly Property ViewName() As String
			Get
				Return "MyGridView"
			End Get
		End Property
		Protected Overrides Sub ActivateEditor(ByVal cell As GridCellInfo)
			If cell.MergedCell Is Nothing Then
				MyBase.ActivateEditor(cell)
			Else
				ActivateMergedCellEditor(cell)
			End If
		End Sub
		Private Sub ActivateMergedCellEditor(ByVal cell As GridCellInfo)
			If cell Is Nothing Then
				Return
			End If
			cell = cell.MergedCell.MergedCells(0)
			Me.fEditingCell = cell
			Dim bounds As Rectangle = GetMergedEditorBounds(cell)
			If bounds.IsEmpty Then
				Return
			End If
			Dim cellEdit As RepositoryItem = RequestCellEditor(cell)
			ViewInfo.UpdateCellAppearance(cell)
			ViewInfo.RequestCellEditViewInfo(cell)
			Dim appearance As New AppearanceObject()
			AppearanceHelper.Combine(appearance, New AppearanceObject() { GetEditorAppearance(), ViewInfo.PaintAppearance.Row, cell.Appearance })
			If cellEdit IsNot cell.Editor AndAlso cellEdit.DefaultAlignment <> HorzAlignment.Default Then
				appearance.TextOptions.HAlignment = cellEdit.DefaultAlignment
			End If
			UpdateEditor(cellEdit, New UpdateEditorInfoArgs(GetColumnReadOnly(cell.ColumnInfo.Column), bounds, appearance, cell.CellValue, ElementsLookAndFeel, cell.ViewInfo.ErrorIconText, cell.ViewInfo.ErrorIcon))
			ViewInfo.UpdateCellAppearance(cell)
			If cell IsNot Nothing Then
				InvalidateRow(cell.RowHandle)
			End If
		End Sub
		Private Function GetMergedEditorBounds(ByVal cell As GridCellInfo) As Rectangle
			Dim r As Rectangle = cell.CellValueRect
			Dim bounds As Rectangle = ViewInfo.UpdateFixedRange(r, cell.ColumnInfo)
			If bounds.Right > ViewInfo.ViewRects.Rows.Right Then
				bounds.Width = ViewInfo.ViewRects.Rows.Right - bounds.Left
			End If
			If bounds.Bottom > ViewInfo.ViewRects.Rows.Bottom Then
				bounds.Height = ViewInfo.ViewRects.Rows.Bottom - bounds.Top
			End If
			If bounds.Width < 1 OrElse bounds.Height < 1 Then
				Return Rectangle.Empty
			End If


			For i As Integer = 1 To cell.MergedCell.MergedCells.Count - 1
				bounds.Height += cell.MergedCell.MergedCells(i).Bounds.Height
			Next i
				Return bounds
		End Function

		Protected Overrides Function PostEditor(ByVal causeValidation As Boolean) As Boolean
			If IsEditing Then
				If Me.fEditingCell.MergedCell IsNot Nothing Then
					Dim CurValue As Object = ExtractEditingValue(Me.fEditingCell.ColumnInfo.Column, EditingValue)
					For i As Integer = 0 To fEditingCell.MergedCell.MergedCells.Count - 1
						Me.SetRowCellValue(Me.fEditingCell.RowHandle + i, Me.fEditingCell.Column, CurValue)
					Next i
				End If
			End If
			Return MyBase.PostEditor(causeValidation)
		End Function
	End Class
End Namespace
