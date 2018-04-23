using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EditMergedCells
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DataTable dt;
            dt = new DataTable();
            dt.Columns.Add("Column1");
            dt.Columns.Add("Column2");

            DataRow dr = dt.NewRow();
            dr[0] = "Value1";
            dr[1] = "Value2";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "Value1";
            dr[1] = "Value3";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "Value1";
            dr[1] = "Value5";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "Value4";
            dr[1] = "Value5";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "Value4";
            dr[1] = "Value5";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = "Value4";
            dr[1] = "Value5";
            dt.Rows.Add(dr);

            myGridControl1.DataSource = dt;
            gridControl1.DataSource = dt;

        }

    }
}
