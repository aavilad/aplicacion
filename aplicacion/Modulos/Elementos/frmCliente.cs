using DevExpress.XtraEditors.Controls;
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
            TpCredito();
            TpContado();
        }
        private void TpCredito()
        {
            var Conexion = new Model.LiderAppEntities();
            var Registros = from p in Conexion.FORMAPAGO.Where(x => x.contado != true) select new { Codigo = p.FormaPago1, Descripcion = p.Descripcion };
            TipoCredito.Properties.DataSource = Registros.ToList();
            TipoCredito.Properties.DisplayMember = "Descripcion";
            TipoCredito.Properties.ValueMember = "Codigo";
            LookUpColumnInfoCollection columna = TipoCredito.Properties.Columns;
            columna.Add(new LookUpColumnInfo("Descripcion", 0));
        }
        private void TpContado()
        {
            var Conexion = new Model.LiderAppEntities();
            var Registros = from p in Conexion.FORMAPAGO.Where(x => x.contado == true) select new { Codigo = p.FormaPago1, Descripcion = p.Descripcion };
            TipoContado.Properties.DataSource = Registros.ToList();
            TipoContado.Properties.DisplayMember = "Descripcion";
            TipoContado.Properties.ValueMember = "Codigo";
            LookUpColumnInfoCollection columna = TipoContado.Properties.Columns;
            columna.Add(new LookUpColumnInfo("Descripcion", 0));
        }
        private void TpCliente()
        {
            var Conexion = new Model.LiderAppEntities();
            //var Registros = from p in Conexion.
            //TipoCliente.Properties.DataSource = Registros.
        }
    }
}