using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xtraForm.Modulos.Ventas
{
    public partial class frmCliente : DevExpress.XtraEditors.XtraForm
    {
        public frmCliente()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Elementos.frmCliente frmcliente = new Elementos.frmCliente();
            frmcliente.Show();
        }
    }
}