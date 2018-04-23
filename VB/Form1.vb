Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace EditMergedCells
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			Dim dt As DataTable
			dt = New DataTable()
			dt.Columns.Add("Column1")
			dt.Columns.Add("Column2")

			Dim dr As DataRow = dt.NewRow()
			dr(0) = "Value1"
			dr(1) = "Value2"
			dt.Rows.Add(dr)

			dr = dt.NewRow()
			dr(0) = "Value1"
			dr(1) = "Value3"
			dt.Rows.Add(dr)

			dr = dt.NewRow()
			dr(0) = "Value1"
			dr(1) = "Value5"
			dt.Rows.Add(dr)

			dr = dt.NewRow()
			dr(0) = "Value4"
			dr(1) = "Value5"
			dt.Rows.Add(dr)

			dr = dt.NewRow()
			dr(0) = "Value4"
			dr(1) = "Value5"
			dt.Rows.Add(dr)

			dr = dt.NewRow()
			dr(0) = "Value4"
			dr(1) = "Value5"
			dt.Rows.Add(dr)

			myGridControl1.DataSource = dt
			gridControl1.DataSource = dt

		End Sub

	End Class
End Namespace
