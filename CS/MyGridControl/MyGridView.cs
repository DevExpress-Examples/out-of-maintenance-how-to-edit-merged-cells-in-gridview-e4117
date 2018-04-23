using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraEditors.Container;

namespace MyXtraGrid
{
    [System.ComponentModel.DesignerCategory("")]
    public class MyGridView : DevExpress.XtraGrid.Views.Grid.GridView
    {
        public MyGridView() : this(null) { }
        public MyGridView(DevExpress.XtraGrid.GridControl grid)
            : base(grid)
        {
            OptionsView.AllowCellMerge = true;
        }
        protected override string ViewName { get { return "MyGridView"; } }
        protected override void ActivateEditor(GridCellInfo cell)
        {
            if (cell.MergedCell == null)
                base.ActivateEditor(cell);
            else
                ActivateMergedCellEditor(cell);
        }
        private void ActivateMergedCellEditor(GridCellInfo cell)
        {
            if (cell == null) return;
            cell = cell.MergedCell.MergedCells[0];
            this.fEditingCell = cell;
            Rectangle bounds = GetMergedEditorBounds(cell);
            if (bounds.IsEmpty) return;
            RepositoryItem cellEdit = RequestCellEditor(cell);
            ViewInfo.UpdateCellAppearance(cell);
            ViewInfo.RequestCellEditViewInfo(cell);
            AppearanceObject appearance = new AppearanceObject();
            AppearanceHelper.Combine(appearance, new AppearanceObject[] { GetEditorAppearance(), ViewInfo.PaintAppearance.Row, cell.Appearance });
            if (cellEdit != cell.Editor && cellEdit.DefaultAlignment != HorzAlignment.Default)
            {
                appearance.TextOptions.HAlignment = cellEdit.DefaultAlignment;
            }
            UpdateEditor(cellEdit, new UpdateEditorInfoArgs(GetColumnReadOnly(cell.ColumnInfo.Column), bounds, appearance, cell.CellValue, ElementsLookAndFeel, cell.ViewInfo.ErrorIconText, cell.ViewInfo.ErrorIcon));
            ViewInfo.UpdateCellAppearance(cell);
            if (cell != null)
                InvalidateRow(cell.RowHandle);
        }
        Rectangle GetMergedEditorBounds(GridCellInfo cell)
        {
            Rectangle r = cell.CellValueRect;
            Rectangle bounds = ViewInfo.UpdateFixedRange(r, cell.ColumnInfo);
            if (bounds.Right > ViewInfo.ViewRects.Rows.Right)
            {
                bounds.Width = ViewInfo.ViewRects.Rows.Right - bounds.Left;
            }
            if (bounds.Bottom > ViewInfo.ViewRects.Rows.Bottom)
            {
                bounds.Height = ViewInfo.ViewRects.Rows.Bottom - bounds.Top;
            }
            if (bounds.Width < 1 || bounds.Height < 1) return Rectangle.Empty; ;

            for (int i = 1; i < cell.MergedCell.MergedCells.Count; i++)
                bounds.Height += cell.MergedCell.MergedCells[i].Bounds.Height;
                return bounds;
        }

        protected override bool PostEditor(bool causeValidation)
        {
            if (IsEditing)
                if (this.fEditingCell.MergedCell != null)
                {
                    object CurValue = ExtractEditingValue(this.fEditingCell.ColumnInfo.Column, EditingValue);
                    for (int i = 0; i < fEditingCell.MergedCell.MergedCells.Count; i++)
                        this.SetRowCellValue(this.fEditingCell.RowHandle + i, this.fEditingCell.Column, CurValue);
                }
            return base.PostEditor(causeValidation);
        }
    }
}
