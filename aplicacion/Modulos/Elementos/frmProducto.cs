using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Elementos
{
    public partial class frmProducto : DevExpress.XtraEditors.XtraForm
    {
        public delegate void Variables(string ProductoProveedor, string CodigoProducto, string CodigoFabrica, string CodigoEan, string CodigoDun, string productoDescripcion, string ProductoLinea,
            string ProductoMarca, string ProductoGrupo, string ProductoClase, string ProductoCategoria, string ProductoObservacion, int ProductoMedida, string ProductoMedidaAnt, decimal ProductoPeso, int ProductoFactorMinimo, bool ProductoVenta, bool ProductoCompra, bool ProductoCombo,
            bool ProductoUnilever, bool ProductoWeb, bool ProductoAfecto, bool ProductoActivo, bool ProductoPercepcion, bool ProductoDetraccion, string ProductoOrden);
        public event Variables pasar;
        public bool Existe;
        public frmProducto()
        {
            InitializeComponent();
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            using (var Context = new LiderEntities())
            {
                TxtNmProveedor.Properties.DataSource = Context.PROVEEDORs.Select(p => new { Codigo = p.Proveedor1.Trim(), Nombre = p.RazonSocial.Trim() }).ToList();
                TxtNmProveedor.Properties.DisplayMember = "Nombre";
                TxtNmProveedor.Properties.ValueMember = "Codigo";
                LookUpColumnInfoCollection ColumnaA = TxtNmProveedor.Properties.Columns;
                ColumnaA.Add(new LookUpColumnInfo("Nombre", string.Empty));
                TxtLinea.Properties.DataSource = Context.LINEAs.Select(p => new { Codigo = p.Linea1.Trim(), Descripcion = p.Descripcion.Trim() }).ToList();
                TxtLinea.Properties.DisplayMember = "Descripcion";
                TxtLinea.Properties.ValueMember = "Codigo";
                LookUpColumnInfoCollection ColumnaB = TxtLinea.Properties.Columns;
                ColumnaB.Add(new LookUpColumnInfo("Descripcion", string.Empty));
                TxtMarca.Properties.DataSource = Context.MARCAs.Select(p => new { Codigo = p.Marca1.Trim(), Descripcion = p.Descripcion.Trim() }).ToList();
                TxtMarca.Properties.DisplayMember = "Descripcion";
                TxtMarca.Properties.ValueMember = "Codigo";
                LookUpColumnInfoCollection ColumnaC = TxtMarca.Properties.Columns;
                ColumnaC.Add(new LookUpColumnInfo("Descripcion", string.Empty));
                TxtGrupo.Properties.DataSource = Context.grupoes.Select(p => new { Codigo = p.grupo1.Trim(), Descripcion = p.descrip.Trim() }).ToList();
                TxtGrupo.Properties.DisplayMember = "Descripcion";
                TxtGrupo.Properties.ValueMember = "Codigo";
                LookUpColumnInfoCollection ColumnaD = TxtGrupo.Properties.Columns;
                ColumnaD.Add(new LookUpColumnInfo("Descripcion", string.Empty));
                TxtClase.Properties.DataSource = Context.Clase_Producto.Select(p => new { Codigo = p.Clase_Producto1.Trim(), Descripcion = p.Descripcion.Trim() }).ToList();
                TxtClase.Properties.DisplayMember = "Descripcion";
                TxtClase.Properties.ValueMember = "Codigo";
                LookUpColumnInfoCollection ColumnaE = TxtClase.Properties.Columns;
                ColumnaE.Add(new LookUpColumnInfo("Descripcion", string.Empty));
                TxtCategoria.Properties.DataSource = Context.categorias.Select(p => new { Codigo = p.categoria1.Trim(), Descripcion = p.descrip.Trim() }).ToList();
                TxtCategoria.Properties.DisplayMember = "Descripcion";
                TxtCategoria.Properties.ValueMember = "Codigo";
                LookUpColumnInfoCollection ColumnaF = TxtCategoria.Properties.Columns;
                ColumnaF.Add(new LookUpColumnInfo("Descripcion", string.Empty));
                TxtProductoMedida.Properties.DataSource = Context.PlantillaUnidads.ToList();
                TxtProductoMedida.Properties.DisplayMember = "Descripcion";
                TxtProductoMedida.Properties.ValueMember = "PKID";
                TxtProductoMedida.Properties.Columns.Add(new LookUpColumnInfo("Descripcion", string.Empty));
                TxtProductoMedida.Properties.Columns.Add(new LookUpColumnInfo("Factor", string.Empty));
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Libreria.Proceso proceso = new Libreria.Proceso();
            if (proceso.MensagePregunta("¿Cancelar?") == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            string ProductoProveedor = Convert.ToString(TxtNmProveedor.EditValue).Trim();
            string CodigoProducto = Convert.ToString(TxtCodigoProducto.EditValue).Trim();
            string CodigoFabrica = Convert.ToString(TxtCodigoFabrica.EditValue).Trim();
            string CodigoEan = Convert.ToString(TxtCodigoEan.EditValue).Trim();
            string CodigoDun = Convert.ToString(TxtCodigoDun.EditValue).Trim();
            string productoDescripcion = Convert.ToString(TxtDescripcionProducto.EditValue).Trim();
            string ProductoLinea = Convert.ToString(TxtLinea.EditValue).Trim();
            string ProductoMarca = Convert.ToString(TxtMarca.EditValue).Trim();
            string ProductoGrupo = Convert.ToString(TxtGrupo.EditValue).Trim();
            string ProductoClase = Convert.ToString(TxtClase.EditValue).Trim();
            string ProductoCategoria = Convert.ToString(TxtCategoria.EditValue).Trim();
            string ProductoObservacion = Convert.ToString(TxtProductoObs.EditValue).Trim();
            int ProductoMedida = Convert.ToInt32(TxtProductoMedida.EditValue);
            string ProductoMedidaAnt = Convert.ToString(MedidaAnterior.Text);
            decimal ProductoPeso = Convert.ToDecimal(TxtProductoPeso.EditValue);
            int ProductoFactorMinimo = Convert.ToInt32(TxtFactorMinimo.EditValue);
            string ProductoOrden = Convert.ToString(TxtNumeroOrdern.EditValue);
            bool ProductoVenta = CheckArticuloVenta.Checked;
            bool ProductoCompra = CheckArticuloCompra.Checked;
            bool ProductoCombo = CheckProductoCombo.Checked;
            bool ProductoUnilever = CheckActivoUnilever.Checked;
            bool ProductoWeb = CheckActivoWeb.Checked;
            bool ProductoAfecto = CheckAfecto.Checked;
            bool ProductoActivo = CheckActivo.Checked;
            bool ProductoPercepcion = CheckPercepcion.Checked;
            bool ProductoDetraccion = CheckDetraccion.Checked;

            try
            {
                if (dxValidationProvider1.Validate())
                {
                    pasar(ProductoProveedor, CodigoProducto, CodigoFabrica, CodigoEan, CodigoDun, productoDescripcion, ProductoLinea, ProductoMarca, ProductoGrupo, ProductoClase, ProductoCategoria,
                        ProductoObservacion, ProductoMedida, ProductoMedidaAnt, ProductoPeso, ProductoFactorMinimo, ProductoVenta, ProductoCompra, ProductoCombo, ProductoUnilever, ProductoWeb, ProductoAfecto, ProductoActivo,
                        ProductoPercepcion, ProductoDetraccion, ProductoOrden);
                    this.Close();
                }
            }
            catch (DbEntityValidationException t)
            {
                foreach (var eve in t.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        MessageBox.Show("- Property: \"" + ve.PropertyName + "\", Error: \"" + ve.ErrorMessage + "\"");
                    }
                }
            }
        }

        private void TxtProductoMedida_EditValueChanged(object sender, EventArgs e)
        {
            if (!Existe)
            {
                using (var Context = new LiderEntities())
                {
                    int valor = Convert.ToInt32(TxtProductoMedida.EditValue);
                    TxtFactorMinimo.EditValue = Context.PlantillaUnidads.Where(x => x.PKID == valor).Select(p => p.Factor).FirstOrDefault(); ;
                }
            }
        }
    }
}