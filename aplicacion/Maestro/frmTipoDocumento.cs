using System;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Maestro
{
    public partial class frmTipoDocumento : DevExpress.XtraEditors.XtraForm
    {
        Libreria.Entidad entidad = new Libreria.Entidad();
        public delegate void campos(string Nombre);
        public event campos pasar;
        public frmTipoDocumento()
        {
            InitializeComponent();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                entidad.nombre = gridView1.GetFocusedRowCellValue("Descripcion").ToString();
                pasar(entidad.nombre);
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

        private void frmTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}