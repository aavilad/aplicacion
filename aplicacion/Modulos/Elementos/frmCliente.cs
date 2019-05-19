using DevExpress.XtraEditors.Controls;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmCliente : DevExpress.XtraEditors.XtraForm
    {
        string Distrito;
        string Provincia;
        string Departamento;
        public delegate void VARIABLES();
        public event VARIABLES PASAR;
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
            string _Codigo = CODIGO.Text.Trim();
            int _TipoPersona = Convert.ToInt32(TIPOPERSONA.EditValue);
            string _Nombres = NOMBRES.Text.Trim();
            string _PNombre = PrimeroNombre.Text.Trim();
            string _SNombre = SEGUNDONOMBRE.Text.Trim();
            string _ApPaterno = APELLIDOPATERNO.Text.Trim();
            string _ApMaterno = APELLIDOMATERNO.Text.Trim();
            string _Direccion = DIRECCION.Text.Trim();
            int _TipoIdentidad = Convert.ToInt32(DOCIDENTIDAD.EditValue);
            string _NroDocumento = NUMERODOCIDENTIDAD.Text.Trim();
            bool _AgenteRetencion = AgenteRetencion.Checked;
            bool _AgentePercepcion = AgentePercepcion.Checked;
            bool _Activo = Activo.Checked;
            bool _InhabBonificacion = InhabilitarBonificacion.Checked;


        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            TpCredito();
            TpContado();
        }
        private void TpCredito()
        {
            var Conexion = new LiderEntities();
            var Registros = from p in Conexion.FORMAPAGOes.Where(x => x.contado != true) select new { Codigo = p.FormaPago1, Descripcion = p.Descripcion };
            TipoCredito.Properties.DataSource = Registros.ToList();
            TipoCredito.Properties.DisplayMember = "Descripcion";
            TipoCredito.Properties.ValueMember = "Codigo";
            LookUpColumnInfoCollection columna = TipoCredito.Properties.Columns;
            columna.Add(new LookUpColumnInfo("Descripcion", 0));
        }
        private void TpContado()
        {
            var Conexion = new LiderEntities();
            var Registros = from p in Conexion.FORMAPAGOes.Where(x => x.contado == true) select new { Codigo = p.FormaPago1, Descripcion = p.Descripcion };
            TipoContado.Properties.DataSource = Registros.ToList();
            TipoContado.Properties.DisplayMember = "Descripcion";
            TipoContado.Properties.ValueMember = "Codigo";
            LookUpColumnInfoCollection columna = TipoContado.Properties.Columns;
            columna.Add(new LookUpColumnInfo("Descripcion", 0));
        }

        private void TIPOPERSONA_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TIPOPERSONA.SelectedIndex)
            {
                case 0:
                    PRIMERNOMBRE.Enabled = true;
                    SEGUNDONOMBRE.Enabled = true;
                    APELLIDOPATERNO.Enabled = true;
                    APELLIDOMATERNO.Enabled = true;
                    
                    break;
                case 1:
                    NOMBRES.Enabled = true;

                    break;
            }
        }
    }
}