using System;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Maestro
{
    public partial class frmVendedor : DevExpress.XtraEditors.XtraForm
    {
        Libreria.Entidad entidad = new Libreria.Entidad();
        public delegate void campos(string Codigo, string Nombre);
        public event campos pasar;
        public frmVendedor()
        {
            InitializeComponent();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                entidad.codigo = gridView1.GetFocusedRowCellValue("Codigo").ToString();
                entidad.nombre = gridView1.GetFocusedRowCellValue("Nombre").ToString();
                pasar(entidad.codigo, entidad.nombre);
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

        private void frmVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}