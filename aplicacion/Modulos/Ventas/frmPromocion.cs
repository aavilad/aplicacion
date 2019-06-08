using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using xtraForm.Model;
using Z.BulkOperations;
using Z.EntityFramework;


namespace xtraForm.Modulos.Ventas
{
    public partial class frmPromocion : DevExpress.XtraEditors.XtraForm
    {
        Libreria.Ejecutar ejecutar = new Libreria.Ejecutar();
        private bool Existe = false;
        Libreria.Rutina proceso = new Libreria.Rutina();
        public string NModulo;
        public string Tabla;

        public frmPromocion()
        {
            InitializeComponent();

        }

        void condicion(string cadena)
        {
            using (var Context = new LiderEntities())
            {
                string Query = Convert.ToString(Context.VistaAdministrativas.Where(x => x.IDModulo == (Context.Moduloes.Where(a => a.Nombre == NModulo).Select(b => b.PKID)).FirstOrDefault()).Select(a => a.Vista.Trim()).FirstOrDefault());
                try
                {
                    if (cadena.Length == 0)
                    {
                        proceso.consultar(Query, Tabla);
                        gridcontrolBonificacion.DataSource = proceso.ds.Tables[Tabla];
                        gridView1.Columns[0].Visible = true;
                        gridView1.Columns["Proveedor"].GroupIndex = 1;
                        gridView1.Columns["TipoMecanica"].GroupIndex = 2;
                        gridView1.GroupRowHeight = 1;
                        gridView1.RowHeight = 1;
                        gridView1.BestFitColumns();
                    }
                    else
                    {
                        proceso.consultar(Query + " where " + cadena, Tabla);
                        gridcontrolBonificacion.DataSource = proceso.ds.Tables[Tabla];
                        gridView1.Columns[0].Visible = true;
                        gridView1.Columns["Proveedor"].GroupIndex = 1;
                        gridView1.Columns["TipoMecanica"].GroupIndex = 2;
                        gridView1.GroupRowHeight = 1;
                        gridView1.RowHeight = 1;
                        gridView1.BestFitColumns();
                    }
                }
                catch (Exception t)
                {
                    XtraMessageBox.Show(t.Message);
                    gridcontrolBonificacion.DataSource = null;
                    gridcontrolBonificacion.Refresh();
                }
            }
        }

        private void COPIAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Modificar();
        }

        private void ELIMINAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
                if (proceso.MensagePregunta("¿desea continuar?") == DialogResult.Yes)
                {
                    Elementos.frmMsg frmmensage = new Elementos.frmMsg();
                    frmmensage.Scm03.SplashFormStartPosition = SplashFormStartPosition.Default;
                    frmmensage.dataGridView1.Columns[0].HeaderText = "Mecanica";
                    frmmensage.dataGridView1.Columns[0].Width = 200;
                    frmmensage.dataGridView1.Columns[1].HeaderText = "Resultado";
                    frmmensage.dataGridView1.Columns[1].Width = 100;
                    frmmensage.dataGridView1.Columns[2].HeaderText = string.Empty;
                    frmmensage.dataGridView1.Columns[3].HeaderText = string.Empty;
                    frmmensage.Show();
                    frmmensage.Scm03.ShowWaitForm();
                    foreach (var bonificacion in gridView1.GetSelectedRows())
                    {
                        var x = Convert.ToInt32(gridView1.GetDataRow(bonificacion)["PKID"]);
                        if (proceso.ExistenciaCampo("pkid", "Bonificacion", "pkid = " + x))
                            frmmensage.dataGridView1.Rows.Add(gridView1.GetDataRow(bonificacion)["Mecanica"].ToString(), ejecutar.DeleteBonificacion(x),
                            string.Empty, string.Empty);
                    }
                    frmmensage.Scm03.CloseWaitForm();
                    Refrescar();
                }
        }

        private void Entidad_Bonificacion(int PKID, string Mecanica, int TipoMecanica, string CodigoObsequio, decimal CantidadMinima, int CantidadMaxima, int CantidadObsequio,
            int MaximoPorCliente, decimal Stock, bool Exclusion, int PkidExclusion, string CodigoVenta, string Proveedor, string Desde, string Hasta, bool Activo, int IDAsociado,
            DataGridView dgv)
        {
            using (var CTX = new LiderEntities())
            {
                var Rutina = new Libreria.Rutina();
                Rutina.Procedimiento("avila.pFB_GenerarID 'Bonificacion',''");
                var IdBon = CTX.IDTablas.Where(w => w.Tabla == "Bonificacion").Select(s => s.ID).FirstOrDefault(); ;
                Bonificacion Bn = new Bonificacion();
                Bn.PKID = IdBon;
                Bn.Mecanica = Mecanica;
                Bn.TipoMecanica = TipoMecanica;
                Bn.cdProductoRegalo = CodigoObsequio;
                Bn.CantidadMinima = CantidadMinima;
                Bn.CantidadMaxima = CantidadMaxima;
                Bn.CantidadRegalo = CantidadObsequio;
                Bn.CantidadMaximaPorCliente = MaximoPorCliente;
                Bn.Stock = Stock;
                Bn.StockEntregado = (decimal)0.00;
                Bn.TieneExclusion = Exclusion;
                Bn.IDBonifcacionExcluida = PkidExclusion;
                Bn.cdProductoVenta = CodigoVenta;
                Bn.IDProveedor = Proveedor;
                Bn.Desde = DateTime.Parse(Desde);
                Bn.Hasta = DateTime.Parse(Hasta);
                Bn.Activo = Activo;
                CTX.Bonificacions.Add(Bn);
                foreach (DataGridViewRow T in dgv.Rows)
                {
                    Rutina.Procedimiento("avila.pFB_GenerarID 'ItemBonificacion',''");
                    ItemBonificacion Ib = new ItemBonificacion();
                    Ib.PKID = CTX.IDTablas.Where(w => w.Tabla == "ItemBonificacion").Select(s => s.ID).FirstOrDefault();
                    Ib.IDBonificacion = PKID;
                    Ib.cdProductoColeccion = Convert.ToString(T.Cells["Codigo"].Value);
                    Ib.IDAsociado = IDAsociado;
                    CTX.ItemBonificacions.Add(Ib);
                }
                CTX.BatchSaveChanges();
                Modificar();
            }
        }

        private void Entidad_Bonificacion_(int PKID, string Mecanica, int TipoMecanica, string CodigoObsequio, decimal CantidadMinima, int CantidadMaxima, int CantidadObsequio,
            int MaximoPorCliente, decimal Stock, bool Exclusion, int PkidExclusion, string CodigoVenta, string Proveedor, string Desde, string Hasta, bool Activo, int IDAsociado,
            DataGridView dgv)
        {
            using (var CTX = new LiderEntities())
            {
                var Bn = (from Bni in CTX.Bonificacions where Bni.PKID == PKID select Bni).FirstOrDefault();
                CTX.ItemBonificacions.Where(w => w.IDBonificacion == PKID).DeleteFromQuery();
                Bn.Mecanica = Mecanica;
                Bn.TipoMecanica = TipoMecanica;
                Bn.cdProductoRegalo = CodigoObsequio;
                Bn.CantidadMinima = CantidadMinima;
                Bn.CantidadMaxima = CantidadMaxima;
                Bn.CantidadRegalo = CantidadObsequio;
                Bn.CantidadMaximaPorCliente = MaximoPorCliente;
                Bn.Stock = Stock;
                Bn.StockEntregado = (decimal)0.00;
                Bn.TieneExclusion = Exclusion;
                Bn.IDBonifcacionExcluida = PkidExclusion;
                Bn.cdProductoVenta = CodigoVenta;
                Bn.IDProveedor = Proveedor;
                Bn.Desde = DateTime.Parse(Desde);
                Bn.Hasta = DateTime.Parse(Hasta);
                Bn.Activo = Activo;
                foreach (DataGridViewRow T in dgv.Rows)
                {
                    var Rutina = new Libreria.Rutina();
                    Rutina.Procedimiento("avila.pFB_GenerarID 'ItemBonificacion',''");
                    ItemBonificacion Ib = new ItemBonificacion();
                    Ib.PKID = CTX.IDTablas.Where(w => w.Tabla == "ItemBonificacion").Select(s => s.ID).FirstOrDefault();
                    Ib.IDBonificacion = PKID;
                    Ib.cdProductoColeccion = Convert.ToString(T.Cells["Codigo"].Value);
                    Ib.IDAsociado = IDAsociado;
                    CTX.ItemBonificacions.Add(Ib);
                }
                CTX.BatchSaveChanges();
                Refrescar();
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
                k.DataSource = Context.Database.SqlQuery<string>(Libreria.Constante.Mapa_Table + "'" + Tabla + "'").ToList();
                filtro.pasar += new Filtros.frmFiltros.variables(condicion);
                filtro.StartPosition = FormStartPosition.CenterScreen;
                foreach (var fila in Context.Filtroes.Where(w => w.tabla.Equals(Tabla)).ToList())
                    filtro.dataGridView1.Rows.Add(fila.campo, fila.condicion, fila.valor, fila.union);
                filtro.entidad = Tabla;
                filtro.ShowDialog();
            }
        }

        private void frmPromocion_Load(object sender, EventArgs e) => Refrescar();

        private void GridView1_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRowCell)
            {
                Existe = true;
                Modificar();
            }
        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            MenuPrincipal.ShowPopup(gridcontrolBonificacion.PointToScreen(e.Point));
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.RowHandle >= 0)
            {
                bool estado = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "Activo"));
                if (estado == false)
                    e.Appearance.ForeColor = Color.LightGray;
                else if (Convert.ToDecimal(proceso.ConsultarCadena("iif(stockac = stockdia,stockac,stockac-(stockac-stockdia))", "producto", "producto = '" + view.GetRowCellValue(e.RowHandle, "cdProductoRegalo").ToString() + "'")) <= 0)
                    e.Appearance.ForeColor = Color.LightPink;
            }
        }

        private void Modificar()
        {
            if (gridView1.SelectedRowsCount > 0)
                using (var CTX = new LiderEntities())
                {
                    var Formulario = new Elementos.frmReglaBonificacion();
                    Formulario.pasar += new Elementos.frmReglaBonificacion.variable(Entidad_Bonificacion_);
                    int Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("PKID"));
                    var Result = CTX.Bonificacions.Where(w => w.PKID == Id);
                    string Mecanica = Result.Select(s => s.Mecanica).FirstOrDefault();
                    int TipoMecanica = Result.Select(s => s.TipoMecanica).FirstOrDefault();
                    string CodigoTipoMecanica = CTX.TipoBonificacions.Where(w => w.PKID == TipoMecanica).Select(s => s.Codigo).FirstOrDefault();
                    string DescripcionTipoMecanica = CTX.TipoBonificacions.Where(w => w.PKID == TipoMecanica).Select(s => s.Descripcion).FirstOrDefault();
                    string Proveedor = Result.Select(s => s.IDProveedor).FirstOrDefault();
                    string ProveedorNombre = CTX.PROVEEDORs.Where(w => w.Proveedor1 == Proveedor.Trim()).Select(s => s.RazonSocial).FirstOrDefault();
                    string CodigoObsequio = Result.Select(s => s.cdProductoRegalo).FirstOrDefault();
                    string DescripcionObsequio = CTX.PRODUCTOes.Where(w => w.Producto1 == CodigoObsequio).Select(s => s.Descripcion).FirstOrDefault();
                    bool Exclusion = Result.Select(s => s.TieneExclusion).FirstOrDefault();
                    int IdExclusion = Result.Select(s => s.IDBonifcacionExcluida).FirstOrDefault();
                    string CodigoVenta = Result.Select(s => s.cdProductoVenta).FirstOrDefault();
                    string DescripcionVenta = CTX.PRODUCTOes.Where(w => w.Producto1 == CodigoVenta).Select(s => s.Descripcion).FirstOrDefault();
                    decimal CantidadMinima = Result.Select(s => s.CantidadMinima).FirstOrDefault();
                    int CantidadMaxima = Result.Select(s => s.CantidadMaxima).FirstOrDefault();
                    int CantidadObsequio = Result.Select(s => s.CantidadRegalo).FirstOrDefault();
                    int MaximoPorCliente = Result.Select(s => s.CantidadMaximaPorCliente).FirstOrDefault();
                    decimal Stock = Result.Select(s => s.Stock).FirstOrDefault();
                    DateTime Desde = Result.Select(s => s.Desde).FirstOrDefault();
                    DateTime Hasta = Result.Select(s => s.Hasta).FirstOrDefault();
                    bool Activo = Result.Select(s => s.Activo).FirstOrDefault();
                    int IdAsociado = CTX.ItemBonificacions.Where(w => w.IDBonificacion == Id).Select(s => s.IDAsociado).FirstOrDefault();
                    string CodigoAsociado = CTX.TipoAsociadoes.Where(w => w.PKID == IdAsociado).Select(s => s.Codigo).FirstOrDefault();
                    var Coleccion = CTX.ItemBonificacions.Where(w => w.IDBonificacion == Id);
                    Formulario.IDControl.Text = Convert.ToString(Id);
                    Formulario.IDBonificacion.EditValue = CodigoTipoMecanica;
                    Formulario.nmBonificacion.Text = DescripcionTipoMecanica;
                    Formulario.DetalleMecanica.Text = Mecanica;
                    Formulario.IDProveedor.Text = Proveedor;
                    Formulario.NmProveedor.Text = ProveedorNombre;
                    Formulario.IDObsequio.Text = CodigoObsequio;
                    Formulario.NmObsequio.Text = DescripcionObsequio;
                    Formulario.Exclusion.Checked = Exclusion;
                    Formulario.IDExclusion.EditValue = Exclusion is false ? string.Empty : Convert.ToString(IdExclusion);
                    Formulario.NmExclusion.Text = Exclusion is false ? string.Empty : Mecanica;
                    Formulario.IDCanje.Text = CodigoVenta;
                    Formulario.NmCanje.Text = DescripcionVenta;
                    Formulario.CantidadMaxima.Value = CantidadMaxima;
                    Formulario.CantidadMinima.Value = CantidadMinima;
                    Formulario.CantidadRegalo.Value = CantidadObsequio;
                    Formulario.CantidadMaximaCliente.EditValue = MaximoPorCliente;
                    Formulario.StockPromocional.Value = Stock;
                    Formulario.fechaDesde.EditValue = Convert.ToDateTime(Desde).ToString("dd/MM/yyyy");
                    Formulario.fechaHasta.EditValue = Convert.ToDateTime(Hasta).ToString("dd/MM/yyyy");
                    Formulario.Estado.Checked = Activo;
                    Formulario.dataGridView1.Rows.Clear();
                    Formulario.BoxTipoAsociado.EditValue = IdAsociado;
                    foreach (var X in Coleccion)
                    {
                        string Codigo = X.cdProductoColeccion;
                        string Descripcion = CTX.PRODUCTOes.Where(w => w.Producto1 == Codigo).Select(s => s.Descripcion).FirstOrDefault();
                        Formulario.dataGridView1.Rows.Add(Codigo, Descripcion);
                    }
                    if (TipoMecanica == 1 || TipoMecanica == 3)
                        Formulario.CantidadMaxima.Enabled = false;
                    else
                        Formulario.CantidadMaxima.Enabled = true;

                    Formulario.StartPosition = FormStartPosition.CenterScreen;
                    Formulario.Show();
                }
        }

        private void MODIFICAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Existe = true;
            Modificar();
        }
        void Refrescar()
        {
            try
            {
                using (var CTX = new LiderEntities())
                {
                    List<string> Lista = new List<string>();
                    var Result = CTX.Filtroes.Where(w => w.tabla == Tabla).OrderBy(o => o.Orden);
                    foreach (var X in Result)
                        Lista.Add(Tabla + "." + "[" + X.campo + "]" + X.condicion + "'" + X.valor + "'" + X.union);
                    string cadena = string.Join(" ", Lista.ToArray());
                    condicion(cadena);
                }
            }
            catch (Exception t)
            {
                MessageBox.Show(t.Message);
            }
        }

        private void REFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => Refrescar();

        private void BONIFICACION_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Elementos.frmReglaBonificacion frmreglabonificacion = new Elementos.frmReglaBonificacion();
            frmreglabonificacion.pasar += new Elementos.frmReglaBonificacion.variable(Entidad_Bonificacion);
            frmreglabonificacion.Show();
        }

        private void COMBO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}