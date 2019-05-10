using System;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Maestro
{
    public partial class frmCondicion : DevExpress.XtraEditors.XtraForm
    {
        public delegate void variable(string Codigo, string Descripcion);
        public event variable pasar;
        public frmCondicion()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                pasar(dataGridView1.CurrentRow.Cells["FormaPago"].Value.ToString(), dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString());
                this.Close();
            }

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                if (dataGridView1.SelectedRows.Count == 1)
                {
                    pasar(dataGridView1.CurrentRow.Cells["FormaPago"].Value.ToString(), dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString());
                    this.Close();
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                pasar(dataGridView1.CurrentRow.Cells["FormaPago"].Value.ToString(), dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString());
                this.Close();
            }
        }
    }
}