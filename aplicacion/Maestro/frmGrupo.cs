using System;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Maestro
{
    public partial class frmGrupo : DevExpress.XtraEditors.XtraForm
    {
        public delegate void variables(string codigo, string Descripcion);
        public event variables pasar;
        public frmGrupo()
        {
            InitializeComponent();
        }

        private void insertarColeccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                foreach (var fila in gridView1.GetSelectedRows())
                {
                    pasar(gridView1.GetRowCellValue(fila, "grupo").ToString(), gridView1.GetRowCellValue(fila, "descrip").ToString());
                }
            }
            this.Close();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.RowCount > 0)
            {
                pasar(gridView1.GetFocusedRowCellValue("grupo").ToString(), gridView1.GetFocusedRowCellValue("descrip").ToString());
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

        private void frmGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}