using System;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Maestro
{
    public partial class frmMarca : DevExpress.XtraEditors.XtraForm
    {
        public delegate void variables(string marca, string descripcion);
        public event variables pasar;
        public frmMarca()
        {
            InitializeComponent();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                pasar(gridView1.GetFocusedRowCellValue("Marca").ToString(), gridView1.GetFocusedRowCellValue("Descripcion").ToString());
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

        private void insertarColeccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                foreach (var fila in gridView1.GetSelectedRows())
                {
                    pasar(gridView1.GetRowCellValue(fila, "Marca").ToString(), gridView1.GetRowCellValue(fila, "Descripcion").ToString());
                }
            }
            this.Close();
        }

        private void frmMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}