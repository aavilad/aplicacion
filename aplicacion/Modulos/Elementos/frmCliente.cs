using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmCliente : DevExpress.XtraEditors.XtraForm
    {
        Libreria.Proceso proceso = new Libreria.Proceso();
        public frmCliente()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (proceso.MensageError("¿Cancelar?") == DialogResult.Yes)
                this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            var conexion = new Model.LiderAppEntities();
        }
    }
}