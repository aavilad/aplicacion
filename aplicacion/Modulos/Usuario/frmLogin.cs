using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
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
using xtraForm.Model;
using xtraForm.Properties;

namespace xtraForm.Modulos.Usuario
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void SALIR_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Entrar_Click(object sender, EventArgs e)
        {
            var formulario = new frmPrincipal();
            using (var CTX = new LiderEntities())
            {
               
            }
            this.Hide();
            formulario.Show();
        }
    }
}