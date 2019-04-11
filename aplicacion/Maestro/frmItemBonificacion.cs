using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace xtraForm.Maestro
{
    public partial class frmItemBonificacion : DevExpress.XtraEditors.XtraForm
    {
        public delegate void variables(string pkid, string Mecanica);
        public event variables pasar;
        public frmItemBonificacion()
        {
            InitializeComponent();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    pasar(gridView1.GetFocusedRowCellValue("PKID").ToString(), gridView1.GetFocusedRowCellValue("Mecanica").ToString());
                }
                this.Close();
            }
            catch
            {

            }
        }

        private void gridControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                gridControl1_DoubleClick(sender, e);
            }
        }

        private void frmItemBonificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}