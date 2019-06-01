using DevExpress.Data.Browsing;
using DevExpress.Entity.Model.Metadata;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Inventario
{
    public partial class frmExistencia : DevExpress.XtraEditors.XtraForm
    {
        public string tabla = "Vva_Producto";
        Libreria.Rutina proceso = new Libreria.Rutina();
        public frmExistencia()
        {
            InitializeComponent();
            Refrescar();
        }

        void Refrescar()
        {
            proceso.consultar("select campo, condicion, valor,[union] from filtro where tabla = '" + tabla + "'", tabla);
            List<string> lista_ = new List<string>();
            foreach (DataRow DR_1 in proceso.ds.Tables[tabla].Rows)
                lista_.Add(tabla + "." + "[" + DR_1[0].ToString() + "]" + DR_1[1].ToString() + "'" + DR_1[2].ToString() + "'" + DR_1[3].ToString());
            string cadena = string.Join(" ", lista_.ToArray());
            condicion(cadena);
        }

        void CamposProducto(string ProductoProveedor, string CodigoProducto, string CodigoFabrica, string CodigoEan, string CodigoDun, string productoDescripcion, string ProductoLinea,
            string ProductoMarca, string ProductoGrupo, string ProductoClase, string ProductoCategoria, string ProductoObservacion, int ProductoMedida, string ProductoMedidaAnt, decimal ProductoPeso, int ProductoFactorMinimo, bool ProductoVenta, bool ProductoCompra, bool ProductoCombo,
            bool ProductoUnilever, bool ProductoWeb, bool ProductoAfecto, bool ProductoActivo, bool ProductoPercepcion, bool ProductoDetraccion, string ProductoOrden)
        {
            using (var Context = new LiderEntities())
            {
                var Art = (from p in Context.PRODUCTOes where p.Producto1 == CodigoProducto select p).FirstOrDefault();
                Art.ean13 = CodigoEan;
                Art.Marca = ProductoMarca;
                Art.Descripcion = productoDescripcion;
                Art.ConIgv = ProductoAfecto;
                //Art.StockMin = 1;
                //Art.StockMax = 100;
                //Art.StockAc = Convert.ToDecimal(_Producto.Select(x => x.StockAc));
                //Art.StockDia = Convert.ToDecimal(_Producto.Select(x => x.StockDia));
                //Art.PrecMayContado = Convert.ToDecimal(_Producto.Select(x => x.PrecMayContado));
                //Art.PrecMenContado = Convert.ToDecimal(_Producto.Select(x => x.PrecMenContado));
                //Art.PrecMayCredito = Convert.ToDecimal(_Producto.Select(x => x.PrecMayCredito));
                //Art.PrecMenCredito = Convert.ToDecimal(_Producto.Select(x => x.PrecMenCredito));
                //Art.PrecEspecial = Convert.ToDecimal(_Producto.Select(x => x.PrecEspecial));
                Art.CodAlterno = CodigoProducto;
                Art.Peso = ProductoPeso;
                //Art.Costo = Convert.ToDecimal(_Producto.Select(x => x.Costo));
                Art.UniMed = ProductoMedidaAnt;
                Art.Activo = ProductoActivo;
                //Art.Unidades = Convert.ToInt32(_Producto.Select(x => x.Unidades));
                //Art.StockMal = Convert.ToDecimal(_Producto.Select(x => x.StockMal));
                Art.ean13 = CodigoEan;
                Art.grupo = ProductoGrupo;
                //Art.stkbafecha = (decimal)0.00;
                //Art.stkmafecha = (decimal)0.00;
                //Art.comimayor = (decimal)0.00;
                //Art.comimenor = (decimal)0.00;
                //Art.credmayor = (decimal)0.00;
                //Art.credmenor = (decimal)0.00;
                Art.codbase = CodigoProducto;
                Art.proveedor = ProductoProveedor;
                Art.linea = ProductoLinea;
                Art.marcas = string.Empty;
                //Art.minimomay = Convert.ToDecimal(_Producto.Select(x => x.minimomay));
                Art.categoria = ProductoCategoria;
                //Art.ncodigo = string.Empty;
                Art.nunimed = string.Empty;
                //Art.PrecSEspecial = Convert.ToDecimal(_Producto.Select(x => x.PrecSEspecial));
                Art.percepcion = ProductoPercepcion;
                //Art.priesgomaycon = (decimal)0.00;
                //Art.priesgomencon = (decimal)0.00;
                //Art.priesgomaycre = (decimal)0.00;
                //Art.priesgomencre = (decimal)0.00;
                //Art.costorep = (decimal)0.00;
                //Art.PrecSSEspecial = Convert.ToDecimal(_Producto.Select(x => x.PrecSSEspecial));
                //Art.comiespecial = (decimal)0.00;
                //Art.comisespecial = (decimal)0.00;
                Art.detraccion = ProductoDetraccion;
                //Art.pdetraccion = (decimal)0.00;
                Art.conivap = false;
                //Art.Meta_Cant = string.Empty;
                //Art.Meta = string.Empty;
                Art.sku = CodigoFabrica;
                Art.factor = ProductoFactorMinimo;
                Art.clase_producto = ProductoClase;
                Art.Orden = ProductoOrden;
                //Art.CodigoUM = string.Empty;
                //Art.IdClaseBSC = string.Empty;
                //Art.FP = 1;
                Art.StatusWeb = ProductoWeb;
                Art.StatusDms = ProductoUnilever;
                Art.ArticuloVenta = ProductoVenta;
                Art.ArticuloCompra = ProductoVenta;
                Art.ProductoCombo = ProductoCombo;
                Art.IDUnidad = ProductoMedida;
                Context.SaveChanges();
            }
            Refrescar();
        }

        void CamposProducto_(string ProductoProveedor, string CodigoProducto, string CodigoFabrica, string CodigoEan, string CodigoDun, string productoDescripcion, string ProductoLinea,
                    string ProductoMarca, string ProductoGrupo, string ProductoClase, string ProductoCategoria, string ProductoObservacion, int ProductoMedida, string ProductoMedidaAnt,
                    decimal ProductoPeso, int ProductoFactorMinimo, bool ProductoVenta, bool ProductoCompra, bool ProductoCombo, bool ProductoUnilever, bool ProductoWeb, bool ProductoAfecto,
                    bool ProductoActivo, bool ProductoPercepcion, bool ProductoDetraccion, string ProductoOrden)
        {
            using (var Context = new LiderEntities())
            {
                PRODUCTO Art = new PRODUCTO();
                Art.Producto1 = CodigoProducto;
                Art.Marca = ProductoMarca;
                Art.Descripcion = productoDescripcion;
                Art.ConIgv = ProductoAfecto;
                Art.StockMin = 1;
                Art.StockMax = 100;
                Art.StockAc = (decimal)0.00;
                Art.StockDia = (decimal)0.00;
                Art.PrecMayContado = (decimal)0.00;
                Art.PrecMenContado = (decimal)0.00;
                Art.PrecMayCredito = (decimal)0.00;
                Art.PrecMenCredito = (decimal)0.00;
                Art.PrecEspecial = (decimal)0.00;
                Art.CanEspecial = 0;
                Art.CodAlterno = CodigoProducto;
                Art.Peso = ProductoPeso;
                Art.Costo = (decimal)0.00;
                Art.UniMed = Context.PlantillaUnidads.Where(x => x.PKID == ProductoMedida).Select(p => p.Abreviacion.Trim()).FirstOrDefault();
                Art.Activo = ProductoActivo;
                Art.Unidades = 1;
                Art.StockMal = (decimal)0.00;
                Art.ean13 = CodigoEan;
                Art.grupo = ProductoGrupo;
                Art.stkbafecha = (decimal)0.00;
                Art.stkmafecha = (decimal)0.00;
                Art.comimayor = (decimal)0.00;
                Art.comimenor = (decimal)0.00;
                Art.credmayor = (decimal)0.00;
                Art.credmenor = (decimal)0.00;
                Art.codbase = CodigoProducto;
                Art.proveedor = ProductoProveedor;
                Art.linea = ProductoLinea;
                Art.marcas = string.Empty;
                Art.minimomay = (decimal)0.00;
                Art.categoria = ProductoCategoria;
                Art.ncodigo = string.Empty;
                Art.nunimed = string.Empty;
                Art.PrecSEspecial = (decimal)0.00;
                Art.percepcion = ProductoPercepcion;
                Art.priesgomaycon = (decimal)0.00;
                Art.priesgomencon = (decimal)0.00;
                Art.priesgomaycre = (decimal)0.00;
                Art.priesgomencre = (decimal)0.00;
                Art.costorep = (decimal)0.00;
                Art.PrecSSEspecial = (decimal)0.00;
                Art.comiespecial = (decimal)0.00;
                Art.comisespecial = (decimal)0.00;
                Art.detraccion = ProductoDetraccion;
                Art.pdetraccion = (decimal)0.00;
                Art.conivap = false;
                Art.Meta_Cant = string.Empty;
                Art.Meta = string.Empty;
                Art.sku = CodigoFabrica;
                Art.factor = ProductoFactorMinimo;
                Art.clase_producto = ProductoClase;
                Art.Orden = ProductoOrden;
                Art.CodigoUM = string.Empty;
                Art.IdClaseBSC = string.Empty;
                Art.FP = 1;
                Art.StatusWeb = ProductoWeb;
                Art.StatusDms = ProductoUnilever;
                Art.ArticuloVenta = ProductoVenta;
                Art.ArticuloCompra = ProductoVenta;
                Art.ProductoCombo = ProductoCombo;
                Art.IDUnidad = ProductoMedida;
                Context.PRODUCTOes.Add(Art);
                Context.SaveChanges();
            }
            Refrescar();
        }
        void condicion(string cadena)
        {
            try
            {
                if (cadena.Length == 0)
                {
                    proceso.consultar(Libreria.Constante.Existencias, tabla);
                    gridControl1.DataSource = proceso.ds.Tables[tabla];
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.OptionsBehavior.ReadOnly = true;
                    gridView1.OptionsView.ShowGroupPanel = false;
                    gridView1.OptionsView.ShowFooter = true;
                    gridView1.FooterPanelHeight = -2;
                    gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                    gridView1.GroupRowHeight = 1;
                    gridView1.RowHeight = 1;
                    gridView1.Appearance.Row.FontSizeDelta = 0;
                    gridView1.BestFitColumns();
                }
                else
                {
                    proceso.consultar(Libreria.Constante.Existencias + " where " + cadena, tabla);
                    gridControl1.DataSource = proceso.ds.Tables[tabla];
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.OptionsBehavior.ReadOnly = true;
                    gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                    gridView1.OptionsView.ShowGroupPanel = false;
                    gridView1.OptionsView.ShowFooter = true;
                    gridView1.GroupRowHeight = 1;
                    gridView1.RowHeight = 1;
                    gridView1.Appearance.Row.FontSizeDelta = 0;
                    gridView1.BestFitColumns();
                }
            }
            catch (Exception t)
            {
                MessageBox.Show(t.Message);
                gridControl1.DataSource = null;
                gridControl1.Refresh();
            }

        }

        private void NUEVO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Elementos.frmProducto frmproducto = new Elementos.frmProducto();
            frmproducto.pasar += new Elementos.frmProducto.Variables(CamposProducto_);
            frmproducto.StartPosition = FormStartPosition.CenterScreen;
            frmproducto.Show();
        }

        private void MODIFICAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
                try
                {

                    using (var Context = new LiderEntities())
                    {
                        var _LProductos = from Pdo in Context.PRODUCTOes
                                          join Mca in Context.MARCAs on Pdo.Marca equals Mca.Marca1
                                          select new
                                          {
                                              Codigo = Pdo.Producto1.Trim(),
                                              Descripcion = Pdo.Descripcion.Trim(),
                                              IDProv = Mca.Proveedor.Trim(),
                                              cdUnilever = Pdo.sku.Trim(),
                                              cdEan = Pdo.ean13.Trim(),
                                              idLinea = Mca.Linea.Trim(),
                                              idMarca = Mca.Marca1.Trim(),
                                              idGrupo = Pdo.grupo.Trim(),
                                              idClase = Pdo.clase_producto.Trim(),
                                              idCategoria = Pdo.categoria.Trim(),
                                              idUnidad = Pdo.IDUnidad,
                                              cdUnidad = Pdo.UniMed.Trim(),
                                              Peso = Pdo.Peso,
                                              Factor = Pdo.factor,
                                              Orden = Pdo.Orden,
                                              aVenta = (bool)Pdo.ArticuloVenta,
                                              aCompra = (bool)Pdo.ArticuloCompra,
                                              aCombo = (bool)Pdo.ProductoCombo,
                                              esDms = (bool)Pdo.StatusDms,
                                              esWeb = (bool)Pdo.StatusWeb,
                                              Afecto = (bool)Pdo.ConIgv,
                                              Activo = (bool)Pdo.Activo,
                                              Percepcion = (bool)Pdo.percepcion,
                                              Detraccion = (bool)Pdo.detraccion
                                          };
                        Elementos.frmProducto frmproducto = new Elementos.frmProducto();
                        frmproducto.Existe = true;
                        frmproducto.pasar += new Elementos.frmProducto.Variables(CamposProducto);
                        string CodigoProducto = gridView1.GetFocusedRowCellValue("Codigo").ToString();
                        string ProductoProveedor = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.IDProv).FirstOrDefault();
                        string CodigoFabrica = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.cdUnilever).FirstOrDefault();
                        string CodigoEan = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.cdEan).FirstOrDefault();
                        string productoDescripcion = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Descripcion).FirstOrDefault();
                        string ProductoLinea = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.idLinea).FirstOrDefault();
                        string ProductoMarca = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.idMarca).FirstOrDefault();
                        string ProductoGrupo = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.idGrupo).FirstOrDefault();
                        string ProductoClase = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.idClase).FirstOrDefault();
                        string ProductoCategoria = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.idCategoria).FirstOrDefault();
                        int ProductoMedida = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => (int)y.idUnidad).FirstOrDefault();
                        string ProductoMedidaAnt = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.cdUnidad).FirstOrDefault();
                        decimal ProductoPeso = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => (decimal)y.Peso).FirstOrDefault();
                        string ProductoFactorMinimo = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Factor.ToString()).FirstOrDefault();
                        string ProductoOrden = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Orden).FirstOrDefault();
                        bool ProductoVenta = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.aVenta).FirstOrDefault();
                        bool ProductoCompra = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.aCompra).FirstOrDefault();
                        bool ProductoCombo = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.aCombo).FirstOrDefault();
                        bool ProductoUnilever = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.esDms).FirstOrDefault();
                        bool ProductoWeb = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.esWeb).FirstOrDefault();
                        bool ProductoAfecto = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Afecto).FirstOrDefault();
                        bool ProductoActivo = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Activo).FirstOrDefault();
                        bool ProductoPercepcion = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Percepcion).FirstOrDefault();
                        bool ProductoDetraccion = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Detraccion).FirstOrDefault();
                        frmproducto.TxtNmProveedor.EditValue = ProductoProveedor;
                        frmproducto.TxtCodigoProducto.EditValue = CodigoProducto;
                        frmproducto.TxtCodigoFabrica.EditValue = CodigoFabrica;
                        frmproducto.TxtCodigoEan.EditValue = CodigoEan;
                        frmproducto.TxtDescripcionProducto.EditValue = productoDescripcion;
                        frmproducto.TxtLinea.EditValue = ProductoLinea;
                        frmproducto.TxtMarca.EditValue = ProductoMarca;
                        frmproducto.TxtGrupo.EditValue = ProductoGrupo;
                        frmproducto.TxtClase.EditValue = ProductoClase;
                        frmproducto.TxtCategoria.EditValue = ProductoCategoria;
                        frmproducto.TxtProductoMedida.EditValue = ProductoMedida;
                        frmproducto.MedidaAnterior.Text = ProductoMedidaAnt;
                        frmproducto.TxtProductoPeso.EditValue = ProductoPeso;
                        frmproducto.TxtFactorMinimo.EditValue = ProductoFactorMinimo;
                        frmproducto.CheckArticuloVenta.Checked = ProductoVenta;
                        frmproducto.CheckArticuloCompra.Checked = ProductoCompra;
                        frmproducto.CheckProductoCombo.Checked = ProductoCombo;
                        frmproducto.CheckActivoUnilever.Checked = ProductoUnilever;
                        frmproducto.CheckActivoWeb.Checked = ProductoWeb;
                        frmproducto.CheckAfecto.Checked = ProductoAfecto;
                        frmproducto.CheckActivo.Checked = ProductoActivo;
                        frmproducto.CheckPercepcion.Checked = ProductoPercepcion;
                        frmproducto.CheckDetraccion.Checked = ProductoDetraccion;
                        frmproducto.TxtNumeroOrdern.EditValue = ProductoOrden;
                        frmproducto.Existe = false;
                        frmproducto.StartPosition = FormStartPosition.CenterScreen;
                        frmproducto.Show();
                    }
                }
                catch (DbEntityValidationException t)
                {
                    foreach (var eve in t.EntityValidationErrors)
                    {
                        foreach (var ve in eve.ValidationErrors)
                        {
                            MessageBox.Show("Propiedad: \"" + ve.PropertyName + "\", Error: \"" + ve.ErrorMessage + "\"");
                        }
                    }
                }
        }

        private void ELIMINAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (proceso.MensagePregunta("¿Continuar?") == DialogResult.Yes)
                {
                    Elementos.frmMsg frmmensage = new Elementos.frmMsg();
                    frmmensage.StartPosition = FormStartPosition.CenterScreen;
                    frmmensage.splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                    frmmensage.dataGridView1.Columns[0].HeaderText = "Producto";
                    frmmensage.dataGridView1.Columns[1].HeaderText = "Resultado";
                    frmmensage.dataGridView1.Columns[2].HeaderText = string.Empty;
                    frmmensage.dataGridView1.Columns[3].HeaderText = string.Empty;
                    frmmensage.Show();
                    frmmensage.splashScreenManager1.ShowWaitForm();
                    foreach (var fila in gridView1.GetSelectedRows())
                    {
                        if (!proceso.ExistenciaCampo("Producto", "Producto", "producto = '" + Convert.ToString(gridView1.GetDataRow(fila)["Codigo"]) + "'"))
                        {
                            frmmensage.dataGridView1.Rows.Add(Convert.ToString(gridView1.GetDataRow(fila)["Codigo"]), Eliminar(Convert.ToString(gridView1.GetDataRow(fila)["Codigo"])),
                            string.Empty, string.Empty);
                        }
                        else
                        {
                            frmmensage.dataGridView1.Rows.Add(Convert.ToString(gridView1.GetDataRow(fila)["Codigo"]), Eliminar(Convert.ToString(gridView1.GetDataRow(fila)["Codigo"])),
                            string.Empty, string.Empty);
                        }
                    }
                    frmmensage.splashScreenManager1.CloseWaitForm();
                    Refrescar();
                }
                string Eliminar(object campo)
                {
                    string Resultado;
                    try
                    {
                        using (var Context = new LiderEntities())
                        {
                            Context.PRODUCTOes.Remove(Context.PRODUCTOes.Find(Convert.ToString(campo)));
                            Context.SaveChanges();
                        }
                        Resultado = "Producto Eliminado con exito";

                    }
                    catch (SqlException t)
                    {
                        Resultado = t.Message;
                    }
                    return Resultado;
                }
            }

        }

        private void FILTRO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var Context = new LiderEntities())
            {
                Filtros.frmFiltros filtro = new Filtros.frmFiltros();
                DataGridViewComboBoxColumn i = filtro.dataGridView1.Columns["Index1"] as DataGridViewComboBoxColumn;
                i.DataSource = Context.FiltroConfiguracions.Where(a => a.Tipo == "CONDICION").ToArray();
                i.DisplayMember = "Descripcion";
                i.ValueMember = "Codigo";
                DataGridViewComboBoxColumn j = filtro.dataGridView1.Columns["Index3"] as DataGridViewComboBoxColumn;
                j.DataSource = Context.FiltroConfiguracions.Where(a => a.Tipo == "OPERADOR").ToList();
                j.DisplayMember = "Descripcion";
                j.ValueMember = "Codigo";
                DataGridViewComboBoxColumn k = filtro.dataGridView1.Columns["Index0"] as DataGridViewComboBoxColumn;
                k.DataSource = Context.Database.SqlQuery<string>(Libreria.Constante.Mapa_View + "'" + tabla + "'").ToList();
                filtro.pasar += new Filtros.frmFiltros.variables(condicion);
                filtro.StartPosition = FormStartPosition.CenterScreen;
                foreach (var fila in Context.Filtroes.Where(w => w.tabla.Equals(tabla)).ToList())
                {
                    filtro.dataGridView1.Rows.Add(fila.campo, fila.condicion, fila.valor, fila.union);
                }
                filtro.entidad = tabla;
                filtro.ShowDialog();
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                if (gridView1.SelectedRowsCount > 0)
                    try
                    {

                        using (var Context = new LiderEntities())
                        {
                            var _LProductos = from Pdo in Context.PRODUCTOes
                                              join Mca in Context.MARCAs on Pdo.Marca equals Mca.Marca1
                                              select new
                                              {
                                                  Codigo = Pdo.Producto1.Trim(),
                                                  Descripcion = Pdo.Descripcion.Trim(),
                                                  IDProv = Mca.Proveedor.Trim(),
                                                  cdUnilever = Pdo.sku.Trim(),
                                                  cdEan = Pdo.ean13.Trim(),
                                                  idLinea = Mca.Linea.Trim(),
                                                  idMarca = Mca.Marca1.Trim(),
                                                  idGrupo = Pdo.grupo.Trim(),
                                                  idClase = Pdo.clase_producto.Trim(),
                                                  idCategoria = Pdo.categoria.Trim(),
                                                  idUnidad = Pdo.IDUnidad,
                                                  cdUnidad = Pdo.UniMed.Trim(),
                                                  Peso = Pdo.Peso,
                                                  Factor = Pdo.factor,
                                                  Orden = Pdo.Orden,
                                                  aVenta = (bool)Pdo.ArticuloVenta,
                                                  aCompra = (bool)Pdo.ArticuloCompra,
                                                  aCombo = (bool)Pdo.ProductoCombo,
                                                  esDms = (bool)Pdo.StatusDms,
                                                  esWeb = (bool)Pdo.StatusWeb,
                                                  Afecto = (bool)Pdo.ConIgv,
                                                  Activo = (bool)Pdo.Activo,
                                                  Percepcion = (bool)Pdo.percepcion,
                                                  Detraccion = (bool)Pdo.detraccion
                                              };
                            Elementos.frmProducto frmproducto = new Elementos.frmProducto();
                            frmproducto.Existe = true;
                            frmproducto.pasar += new Elementos.frmProducto.Variables(CamposProducto);
                            string CodigoProducto = gridView1.GetFocusedRowCellValue("Codigo").ToString();
                            string ProductoProveedor = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.IDProv).FirstOrDefault();
                            string CodigoFabrica = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.cdUnilever).FirstOrDefault();
                            string CodigoEan = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.cdEan).FirstOrDefault();
                            string productoDescripcion = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Descripcion).FirstOrDefault();
                            string ProductoLinea = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.idLinea).FirstOrDefault();
                            string ProductoMarca = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.idMarca).FirstOrDefault();
                            string ProductoGrupo = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.idGrupo).FirstOrDefault();
                            string ProductoClase = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.idClase).FirstOrDefault();
                            string ProductoCategoria = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.idCategoria).FirstOrDefault();
                            int ProductoMedida = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => (int)y.idUnidad).FirstOrDefault();
                            string ProductoMedidaAnt = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.cdUnidad).FirstOrDefault();
                            decimal ProductoPeso = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => (decimal)y.Peso).FirstOrDefault();
                            string ProductoFactorMinimo = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Factor.ToString()).FirstOrDefault();
                            string ProductoOrden = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Orden).FirstOrDefault();
                            bool ProductoVenta = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.aVenta).FirstOrDefault();
                            bool ProductoCompra = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.aCompra).FirstOrDefault();
                            bool ProductoCombo = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.aCombo).FirstOrDefault();
                            bool ProductoUnilever = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.esDms).FirstOrDefault();
                            bool ProductoWeb = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.esWeb).FirstOrDefault();
                            bool ProductoAfecto = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Afecto).FirstOrDefault();
                            bool ProductoActivo = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Activo).FirstOrDefault();
                            bool ProductoPercepcion = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Percepcion).FirstOrDefault();
                            bool ProductoDetraccion = _LProductos.Where(x => x.Codigo.Equals(CodigoProducto)).Select(y => y.Detraccion).FirstOrDefault();
                            frmproducto.TxtNmProveedor.EditValue = ProductoProveedor;
                            frmproducto.TxtCodigoProducto.EditValue = CodigoProducto;
                            frmproducto.TxtCodigoFabrica.EditValue = CodigoFabrica;
                            frmproducto.TxtCodigoEan.EditValue = CodigoEan;
                            frmproducto.TxtDescripcionProducto.EditValue = productoDescripcion;
                            frmproducto.TxtLinea.EditValue = ProductoLinea;
                            frmproducto.TxtMarca.EditValue = ProductoMarca;
                            frmproducto.TxtGrupo.EditValue = ProductoGrupo;
                            frmproducto.TxtClase.EditValue = ProductoClase;
                            frmproducto.TxtCategoria.EditValue = ProductoCategoria;
                            frmproducto.TxtProductoMedida.EditValue = ProductoMedida;
                            frmproducto.MedidaAnterior.Text = ProductoMedidaAnt;
                            frmproducto.TxtProductoPeso.EditValue = ProductoPeso;
                            frmproducto.TxtFactorMinimo.EditValue = ProductoFactorMinimo;
                            frmproducto.CheckArticuloVenta.Checked = ProductoVenta;
                            frmproducto.CheckArticuloCompra.Checked = ProductoCompra;
                            frmproducto.CheckProductoCombo.Checked = ProductoCombo;
                            frmproducto.CheckActivoUnilever.Checked = ProductoUnilever;
                            frmproducto.CheckActivoWeb.Checked = ProductoWeb;
                            frmproducto.CheckAfecto.Checked = ProductoAfecto;
                            frmproducto.CheckActivo.Checked = ProductoActivo;
                            frmproducto.CheckPercepcion.Checked = ProductoPercepcion;
                            frmproducto.CheckDetraccion.Checked = ProductoDetraccion;
                            frmproducto.TxtNumeroOrdern.EditValue = ProductoOrden;
                            frmproducto.Existe = false;
                            frmproducto.StartPosition = FormStartPosition.CenterScreen;
                            frmproducto.Show();
                        }
                    }
                    catch (DbEntityValidationException t)
                    {
                        foreach (var eve in t.EntityValidationErrors)
                        {
                            foreach (var ve in eve.ValidationErrors)
                            {
                                MessageBox.Show("Propiedad: \"" + ve.PropertyName + "\", Error: \"" + ve.ErrorMessage + "\"");
                            }
                        }
                    }
            }
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            popupMenu1.ShowPopup(gridControl1.PointToScreen(e.Point));
        }
    }
}