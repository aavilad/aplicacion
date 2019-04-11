using System;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Maestro
{
    public partial class frmProducto : DevExpress.XtraEditors.XtraForm
    {
        public delegate void variables(string codigo, string descripcion, string unidad);
        public event variables pasar;
        public frmProducto()
        {
            InitializeComponent();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                try
                {
                    pasar(gridView1.GetFocusedRowCellValue("Codigo").ToString(), gridView1.GetFocusedRowCellValue("Descripcion").ToString(),
                        gridView1.GetFocusedRowCellValue("Unidad").ToString());
                }
                catch { }

            }
            this.Close();
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                if (gridView1.RowCount > 0)
                {
                    pasar(gridView1.GetFocusedRowCellValue("Codigo").ToString(), gridView1.GetFocusedRowCellValue("Descripcion").ToString(),
                       gridView1.GetFocusedRowCellValue("Unidad").ToString());
                }
                this.Close();
            }
        }

        private void insertarColeccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                try
                {
                    foreach (var fila in gridView1.GetSelectedRows())
                    {
                        pasar(gridView1.GetRowCellValue(fila, "Codigo").ToString(), gridView1.GetRowCellValue(fila, "Descripcion").ToString(),
                               gridView1.GetFocusedRowCellValue("Unidad").ToString());
                    }
                }
                catch
                {

                }

            }
            this.Close();
        }

        private void frmProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}