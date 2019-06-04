using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmAsignacionVendedor : DevExpress.XtraEditors.XtraForm
    {
        public frmAsignacionVendedor()
        {
            InitializeComponent();
        }

        private void AGREGAR_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }
    }
}