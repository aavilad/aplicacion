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
    public partial class frmAvanceClienteDetalle : DevExpress.XtraEditors.XtraForm
    {
        public frmAvanceClienteDetalle()
        {
            InitializeComponent();
        }

        private void CERRRAR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Export":
                    gridView1.ShowPrintPreview();
                    break;
            }
        }
    }
}