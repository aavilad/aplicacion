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

namespace xtraForm.Reportes.Vistas
{
    public partial class frmVistaPrincipal : DevExpress.XtraEditors.XtraForm
    {
        public frmVistaPrincipal()
        {
            InitializeComponent();
        }

        private void frmVistaPrincipal_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}