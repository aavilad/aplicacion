using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
                var usuario = CTX.Usuarios.Where(x => x.Codigo == UsuarioID.Text.Trim() && x.Contraseña == UsuarioPass.Text.Trim());
                if (Validar.Validate())
                    if (usuario.FirstOrDefault() != null)
                    {
                        Scm02.SplashFormStartPosition = DevExpress.XtraSplashScreen.SplashFormStartPosition.Default;
                        Scm02.ShowWaitForm();
                        for (int i = 0; i < 100; i++)
                            Thread.Sleep(i);
                        formulario.DataUser.Caption = usuario.Select(y => "USUARIO => " + y.Nombre.ToUpper()).FirstOrDefault();
                        this.Hide();
                        Scm02.CloseWaitForm();
                        formulario.Show();
                    }
                    else
                        MessageBox.Show("Datos ingresados incorrectos");
            }
        }
        private void frmLogin_Entrar(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
                Entrar_Click(sender, e);
        }
        private void frmLogin_Load(object sender, EventArgs e) => UsuarioID.Select();
    }
}
