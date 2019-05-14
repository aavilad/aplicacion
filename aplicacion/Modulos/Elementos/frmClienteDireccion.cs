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
using xtraForm.Model.Conexion.edmx.Conexion.Context.tt;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmClienteDireccion : DevExpress.XtraEditors.XtraForm
    {
        Libreria.Proceso proceso = new Libreria.Proceso();
        public delegate void Variables();
        public event Variables pasar;
        public frmClienteDireccion() => InitializeComponent();

        private void Cancelar_Click(object sender, EventArgs e)
        {
            if (proceso.MensageError("¿cancelar?") == DialogResult.Yes)
                this.Close();
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            pasar();
        }

        private void frmClienteDireccion_Load(object sender, EventArgs e)
        {
            var Base = new LiderAppEntities();
            Distrito.Properties.DataSource = from Dtto in Base.Distrito select Dtto;

        }
    }
}