using System;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Maestro
{
    public partial class frmLinea : DevExpress.XtraEditors.XtraForm
    {
        public delegate void variables(string codigo, string Descripcion);
        public event variables pasar;
        public frmLinea()
        {
            InitializeComponent();
        }

        private void inertarColeccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                foreach (var fila in gridView1.GetSelectedRows())
                {
                    pasar(gridView1.GetRowCellValue(fila, "Linea").ToString(), gridView1.GetRowCellValue(fila, "Descripcion").ToString());
                }
            }
            this.Close();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                pasar(gridView1.GetFocusedRowCellValue("Linea").ToString(), gridView1.GetFocusedRowCellValue("Descripcion").ToString());
            }
            this.Close();

        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                gridControl1_DoubleClick(sender, e);
            }
        }

        private void frmLinea_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}