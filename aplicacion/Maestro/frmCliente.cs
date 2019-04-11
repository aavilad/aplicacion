using System;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Maestro
{
    public partial class frmCliente : DevExpress.XtraEditors.XtraForm
    {
        Libreria.Entidad entidad = new Libreria.Entidad();
        public delegate void campos(string Codigo, string Nombre, string Documento);
        public event campos pasar;
        public frmCliente()
        {
            InitializeComponent();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                entidad.codigo = gridView1.GetFocusedRowCellValue("Codigo").ToString();
                entidad.nombre = gridView1.GetFocusedRowCellValue("Nombre").ToString();
                entidad.documento = gridView1.GetFocusedRowCellValue("Documento").ToString();
                pasar(entidad.codigo, entidad.nombre, entidad.documento);
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

        private void frmCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}