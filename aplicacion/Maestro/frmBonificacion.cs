using System;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Maestro
{
    public partial class frmBonificacion : DevExpress.XtraEditors.XtraForm
    {
        public delegate void variables(int pkid,string Codigo, string Descripcion);
        public event variables pasar;
        public frmBonificacion()
        {
            InitializeComponent();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                pasar(Convert.ToInt32(gridView1.GetFocusedRowCellValue("Pkid")), gridView1.GetFocusedRowCellValue("Codigo").ToString(), gridView1.GetFocusedRowCellValue("Descripcion").ToString());
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

        private void frmBonificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}