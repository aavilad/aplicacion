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
            //Externos
            string CCodigo = this.Codigo.Text.Trim();
            int CTipoPersona = Convert.ToInt32(this.TipoPersona.EditValue);
            string CNombres = this.Nombres.Text.Trim();
            string CPrimeroNombre = PrimeroNombre.Text.Trim();
            string CSegundoNombre = SegundoNombre.Text.Trim();
            string CApellidoPaterno = ApellidoPaterno.Text.Trim();
            string CApellidoMaterno = ApellodMaterno.Text.Trim();
            string CDireccion = Direccion.Text.Trim();
            int CTipoIdentidad = Convert.ToInt32(TipoDocIdetntidad.EditValue);
            string CNroDocumento = NumeroDocIdentidad.Text.Trim();
            bool CAgenteRetencion = AgenteRetencion.Checked;
            bool CAgentePercepcion = AgentePercepcion.Checked;
            bool CActivo = Activo.Checked;
            bool CInhabBonificacion = InhabilitarBonificacion.Checked;
            //Comercial




        }
        private void frmCliente_Load(object sender, EventArgs e)
        {
            TpCredito();
            TpContado();
            TpCliente();
            TpNegocio();
        }
        private void TpNegocio()
        {
            using (var CTX = new LiderEntities())
            {
                TIPONEGOCIO.Properties.DataSource = CTX.TIPONEGs
                    .Select(x => new
                    {
                        Codigo = x.IdNegocio.Trim(),
                        Descripcion = x.Descrip.Trim(),
                    }).ToList();
                TIPONEGOCIO.Properties.DisplayMember = "Descripcion";
                TIPONEGOCIO.Properties.ValueMember = "Codigo";
                TIPONEGOCIO.Properties.Columns.Add(new LookUpColumnInfo("Descripcion", string.Empty));
            }
        }
        private void TpCliente()
        {
            using (var CTX = new LiderEntities())
            {
                TIPOCLIENTE.Properties.DataSource = CTX.TIPOCLIs
                    .Select(x => new
                    {
                        Codigo = x.TipoCli1.Trim(),
                        Descripcion = x.Descripcion.Trim(),
                    }).ToList();
                TIPOCLIENTE.Properties.DisplayMember = "Descripcion";
                TIPOCLIENTE.Properties.ValueMember = "Codigo";
                TIPOCLIENTE.Properties.Columns.Add(new LookUpColumnInfo("Descripcion", string.Empty));
            }
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
            switch (TipoPersona.SelectedIndex)
            {
                case 0:
                    PRIMERNOMBRE.Enabled = true;
                    SegundoNombre.Enabled = true;
                    ApellidoPaterno.Enabled = true;
                    ApellodMaterno.Enabled = true;

                    break;
                case 1:
                    Nombres.Enabled = true;

                    break;
            }
        }

        private void DIRECCION_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var formulario = new frmClienteDireccion();
            formulario.pasar += new frmClienteDireccion.Variables(CamposDireccionCliente);
            formulario.StartPosition = FormStartPosition.CenterParent;
            formulario.ShowDialog();
        }

        void CamposDireccionCliente(string _Direccion, string CodigoDistrito, string CodigoProvincia, string CodigoDepartamento)
        {
            Direccion.Text = _Direccion;
            Distrito = CodigoDistrito;
            Provincia = CodigoProvincia;
            Departamento = CodigoDepartamento;
        }

        private void ZonaVenta_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (var CTX = new LiderEntities())
            {
                var formulario = new frmZona();
                formulario.gridControl1.DataSource = null;
                formulario.gridView1.Columns.Clear();
                formulario.gridControl1.DataSource = CTX.ZONAs
                    .Where(y => y.Activo == true)
                    .Select(x => new
                    {
                        Codigo = x.Zona1.Trim(),
                        Descripcion = x.Descripcion.Trim(),
                    })
                    .ToList();
                formulario.gridView1.Columns[1].Width = 250;
                formulario.StartPosition = FormStartPosition.CenterParent;
                formulario.ShowDialog();
            }
        }
    }
}