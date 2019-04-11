using System;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Maestro
{
    public partial class frmProveedor : DevExpress.XtraEditors.XtraForm
    {
        public delegate void variables(string codigo, string descripcion);
        public event variables pasar;
        public frmProveedor()
        {
            InitializeComponent();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                pasar(gridView1.GetFocusedRowCellValue("Proveedor").ToString(), gridView1.GetFocusedRowCellValue("Nombre").ToString());
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

        private void frmProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}