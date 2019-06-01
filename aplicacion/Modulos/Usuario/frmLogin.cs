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

namespace xtraForm.Modulos.Usuario
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
            this.Load += new EventHandler(this.frmLogin_Load);
            this.KeyPress += new KeyPressEventHandler(this.frmLogin_Entrar);
        }

        private void Entrar_Click(object sender, EventArgs e)
        {
            var formulario = new frmPrincipal();
            using (var CTX = new LiderEntities())
            {
                var usuario = CTX.Usuarios.Where(x => x.Codigo == UsuarioID.Text.Trim());
                var Passw = CTX.Usuarios.Where(x => x.Contraseña == UsuarioPass.Text.Trim());
                if (dxValidationProvider1.Validate())
                {
                    if (usuario != null && Passw != null)
                    {
                        formulario.DataUser.Caption = usuario.Select(y => "USUARIO: " + y.Nombre.ToUpper()).FirstOrDefault();
                        this.Hide();
                        formulario.Show();
                    }
                    else
                    {
                        MessageBox.Show("Datos ingresados incorrectos son incorrectos .");
                    }
                }
            }
        }
        private void frmLogin_Entrar(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                Entrar_Click(sender, e);
            }
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            Entrar.Focus();
            Entrar.Select();
        }
    }
}
