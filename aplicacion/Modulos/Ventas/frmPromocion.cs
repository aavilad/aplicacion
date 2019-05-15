using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Ventas
{
    public partial class frmPromocion : DevExpress.XtraEditors.XtraForm
    {
        public string NModulo;
        Libreria.maestroBonif_Reglas ejecutar_ = new Libreria.maestroBonif_Reglas();
        Libreria.Ejecutar ejecutar = new Libreria.Ejecutar();
        Libreria.Bonificacion bonificacion = new Libreria.Bonificacion();
        Libreria.Producto producto = new Libreria.Producto();
        Libreria.Proceso proceso = new Libreria.Proceso();
        private string tabla = "Bonificacion";
        private bool Existe = false;

        public frmPromocion()
        {
            InitializeComponent();
        }
        void Refrescar()
        {
            proceso.consultar("select campo, condicion, valor,[union] from filtro where tabla = '" + tabla + "'", tabla);
            List<string> lista_ = new List<string>();
            foreach (DataRow DR_1 in proceso.ds.Tables[tabla].Rows)
                lista_.Add("[" + DR_1[0].ToString() + "]" + DR_1[1].ToString() + "'" + DR_1[2].ToString() + "'" + DR_1[3].ToString());
            string cadena = string.Join(" ", lista_.ToArray());
            condicion(cadena);
        }
        void GrabarBonificacion(int pkid, string Mecanica, int TipoMecanica, string CodigoObsequio, decimal CantidadMinima, int CantidadMaxima, int CantidadObsequio, int MaximoPorCliente,
            decimal Stock, bool Exclusion, int PkidExclusion, string CodigoVenta, string Proveedor, string Desde, string Hasta, bool Activo, int IDAsociado, DataGridView dgv)
        {
            var x = proceso.ID("Bonificacion");
            switch (Existe)
            {
                case true:
                    ejecutar_.saveBonificacion(pkid, Mecanica, TipoMecanica, CodigoObsequio, CantidadMinima, CantidadMaxima, CantidadObsequio, MaximoPorCliente, Stock, Exclusion,
                        PkidExclusion, CodigoVenta, Proveedor, Desde, Hasta, Activo, dgv, proceso.ID("ItemBonificacion"), IDAsociado == 0 ? bonificacion.IdAsociado : IDAsociado);
                    Refrescar();
                    break;
                case false:
                    ejecutar_.insertBonificacion(x, Mecanica, TipoMecanica, CodigoObsequio, CantidadMinima, CantidadMaxima, CantidadObsequio, MaximoPorCliente, Stock, Exclusion,
                        PkidExclusion, CodigoVenta, Proveedor, Desde, Hasta, Activo, dgv, proceso.ID("ItemBonificacion"), IDAsociado == 0 ? bonificacion.IdAsociado : IDAsociado);
                    Refrescar();
                    break;
            }
            Existe = false;
        }
        void condicion(string cadena)
        {
            using (var Context = new LiderEntities())
            {
                string Query = Convert.ToString(Context.VistaAdministrativas.Where(x => x.IDModulo == (Context.Moduloes.Where(a => a.Nombre == NModulo).Select(b => b.PKID)).FirstOrDefault()).Select(a => a.Vista.Trim()).FirstOrDefault());
                if (cadena.Length == 0)
                {
                    proceso.consultar(Query, tabla);
                    gridcontrolBonificacion.DataSource = proceso.ds.Tables[tabla];
                    gridView1.Columns[0].Visible = true;
                    gridView1.Columns["Proveedor"].GroupIndex = 1;
                    gridView1.Columns["TipoMecanica"].GroupIndex = 2;
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.OptionsBehavior.ReadOnly = true;
                    gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                    gridView1.OptionsView.ShowGroupPanel = false;
                    gridView1.GroupRowHeight = 1;
                    gridView1.RowHeight = 1;
                    gridView1.Appearance.Row.FontSizeDelta = 0;
                    gridView1.BestFitColumns();
                    gridView1.OptionsView.ShowFooter = true;
                }
                else
                    try
                    {
                        proceso.consultar(Query + " where " + cadena, tabla);
                        gridcontrolBonificacion.DataSource = proceso.ds.Tables[tabla];
                        gridView1.Columns[0].Visible = true;
                        gridView1.Columns["Proveedor"].GroupIndex = 1;
                        gridView1.Columns["TipoMecanica"].GroupIndex = 2;
                        gridView1.OptionsView.ColumnAutoWidth = false;
                        gridView1.OptionsBehavior.Editable = false;
                        gridView1.OptionsBehavior.ReadOnly = true;
                        gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                        gridView1.OptionsView.ShowGroupPanel = false;
                        gridView1.GroupRowHeight = 1;
                        gridView1.RowHeight = 1;
                        gridView1.Appearance.Row.FontSizeDelta = 0;
                        gridView1.BestFitColumns();
                        gridView1.OptionsView.ShowFooter = true;
                    }
                    catch (Exception t)
                    {
                        MessageBox.Show(t.Message);
                        gridcontrolBonificacion.DataSource = null;
                        gridcontrolBonificacion.Refresh();
                    }
            }
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                Elementos.frmReglaBonificacion frmreglabonificacion = new Elementos.frmReglaBonificacion();
                frmreglabonificacion.pasar += new Elementos.frmReglaBonificacion.variable(GrabarBonificacion);
                bonificacion.Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("PKID"));
                bonificacion.Mecanica = proceso.ConsultarCadena("Mecanica", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.TipoMecanica = proceso.ConsultarEntero("TipoMecanica", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.CodigoTipoMecanica = proceso.ConsultarCadena("Codigo", "TipoBonificacion", "PKID = " + bonificacion.TipoMecanica);
                bonificacion.DescripcionTipoMecanica = proceso.ConsultarCadena("Descripcion", "TipoBonificacion", "PKID = " + bonificacion.TipoMecanica);
                bonificacion.Proveedor = proceso.ConsultarCadena("IDProveedor", "Bonificacion", "PKID = " + bonificacion.Id);
                var Nombreproveedor = proceso.ConsultarCadena("RazonSocial", "Proveedor", "Proveedor = '" + bonificacion.Proveedor + "'");
                bonificacion.CodigoObsequio = proceso.ConsultarCadena("cdProductoRegalo", "Bonificacion", "PKID = " + bonificacion.Id);
                var DescripcionObsequio = proceso.ConsultarCadena("Descripcion", "Vva_Producto", "Codigo = '" + bonificacion.CodigoObsequio + "'");
                bonificacion.Exclusion = proceso.ConsultarVerdad("TieneExclusion", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.IdExclusion = proceso.ConsultarEntero("IDBonifcacionExcluida", "Bonificacion", "PKID = " + bonificacion.Id);
                var DescripcionMecanica = proceso.ConsultarCadena("Mecanica", "Bonificacion", "PKID = " + bonificacion.IdExclusion);
                bonificacion.CodigoVenta = proceso.ConsultarCadena("cdProductoVenta", "Bonificacion", "PKID = " + bonificacion.Id);
                var DescripcionVenta = proceso.ConsultarCadena("Descripcion", "Vva_Producto", "Codigo = '" + bonificacion.CodigoObsequio + "'");
                bonificacion.CantidadMinima = proceso.ConsultarDecimal("CantidadMinima", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.CantidadMaxima = proceso.ConsultarEntero("CantidadMaxima", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.CantidadObsequio = proceso.ConsultarEntero("CantidadRegalo", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.MaximoPorCliente = proceso.ConsultarEntero("CantidadMaximaPorCliente", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.Stock = proceso.ConsultarEntero("stock", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.Desde = proceso.ConsultarCadena("Desde", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.Hasta = proceso.ConsultarCadena("Hasta", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.Activo = proceso.ConsultarVerdad("Activo", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.IdAsociado = proceso.ConsultarEntero("IDAsociado", "ItemBonificacion", "IDBonificacion = " + bonificacion.Id);
                bonificacion.CodigoAsociado = proceso.ConsultarCadena("Codigo", "TipoAsociado", "PKID = " + bonificacion.IdAsociado);
                var Coleccion = proceso.ConsultarTabla_("itembonificacion", "IDBonificacion = " + bonificacion.Id);

                frmreglabonificacion.IDBonificacion.Text = bonificacion.CodigoTipoMecanica;
                frmreglabonificacion.nmBonificacion.Text = bonificacion.DescripcionTipoMecanica;
                frmreglabonificacion.DetalleMecanica.Text = bonificacion.Mecanica;
                frmreglabonificacion.IDProveedor.Text = bonificacion.Proveedor;
                frmreglabonificacion.NmProveedor.Text = Nombreproveedor;
                frmreglabonificacion.IDObsequio.Text = bonificacion.CodigoObsequio;
                frmreglabonificacion.NmObsequio.Text = DescripcionObsequio;
                frmreglabonificacion.TieneExclusion.Checked = bonificacion.Exclusion;
                frmreglabonificacion.IDExclusion.EditValue = bonificacion.Exclusion is false ? string.Empty : bonificacion.IdExclusion.ToString();
                frmreglabonificacion.NmExclusion.Text = bonificacion.Exclusion is false ? string.Empty : DescripcionMecanica;
                frmreglabonificacion.IDCanje.Text = bonificacion.CodigoVenta;
                frmreglabonificacion.NmCanje.Text = DescripcionVenta;
                frmreglabonificacion.CantidadMaxima.Value = bonificacion.CantidadMaxima;
                frmreglabonificacion.CantidadMinima.Value = bonificacion.CantidadMinima;
                frmreglabonificacion.CantidadRegalo.Value = bonificacion.CantidadObsequio;
                frmreglabonificacion.CantidadMaximaCliente.EditValue = bonificacion.MaximoPorCliente;
                frmreglabonificacion.StockPromocional.Value = bonificacion.Stock;
                frmreglabonificacion.fechaDesde.EditValue = Convert.ToDateTime(bonificacion.Desde).ToString("dd/MM/yyyy");
                frmreglabonificacion.fechaHasta.EditValue = Convert.ToDateTime(bonificacion.Hasta).ToString("dd/MM/yyyy");
                frmreglabonificacion.Estado.Checked = bonificacion.Activo;
                frmreglabonificacion.dataGridView1.Rows.Clear();
                switch (bonificacion.CodigoAsociado)
                {
                    case "Marca":
                        frmreglabonificacion.cdMarca.Checked = true;
                        break;
                    case "Linea":
                        frmreglabonificacion.cdLinea.Checked = true;
                        break;
                    case "Grupo":
                        frmreglabonificacion.cdGrupo.Checked = true;
                        break;
                    case "Producto":
                        frmreglabonificacion.cdProducto.Checked = true;
                        break;
                }
                foreach (DataRow DR_0 in Coleccion.Rows)
                {
                    producto.Codigo = DR_0["cdProductoColeccion"].ToString();
                    producto.Descripcion = proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + DR_0["cdProductoColeccion"] + "'");
                    frmreglabonificacion.dataGridView1.Rows.Add(producto.Codigo, producto.Descripcion);
                }
                frmreglabonificacion.StartPosition = FormStartPosition.CenterScreen;
                frmreglabonificacion.Show();
            }
        }

        private void filtrarToolStripMenuItem_Click(object sender, EventArgs e)
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
                k.DataSource = Context.Database.SqlQuery<string>(Libreria.Constante.Mapa_Table + "'" + tabla + "'").ToList();
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

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = (GridView)sender;
            if (e.RowHandle >= 0)
            {
                bool estado = Convert.ToBoolean(view.GetRowCellValue(e.RowHandle, "Activo"));
                if (estado == false)
                {
                    e.Appearance.ForeColor = Color.LightGray;
                }
                else if (Convert.ToDecimal(proceso.ConsultarCadena("iif(stockac = stockdia,stockac,stockac-(stockac-stockdia))", "producto", "producto = '" + view.GetRowCellValue(e.RowHandle, "cdProductoRegalo").ToString() + "'")) <= 0)
                {
                    e.Appearance.ForeColor = Color.LightPink;
                }
            }
        }
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                Existe = true;
                Elementos.frmReglaBonificacion frmreglabonificacion = new Elementos.frmReglaBonificacion();
                frmreglabonificacion.pasar += new Elementos.frmReglaBonificacion.variable(GrabarBonificacion);
                bonificacion.Id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("PKID"));
                bonificacion.Mecanica = proceso.ConsultarCadena("Mecanica", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.TipoMecanica = proceso.ConsultarEntero("TipoMecanica", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.CodigoTipoMecanica = proceso.ConsultarCadena("Codigo", "TipoBonificacion", "PKID = " + bonificacion.TipoMecanica);
                bonificacion.DescripcionTipoMecanica = proceso.ConsultarCadena("Descripcion", "TipoBonificacion", "PKID = " + bonificacion.TipoMecanica);
                bonificacion.Proveedor = proceso.ConsultarCadena("IDProveedor", "Bonificacion", "PKID = " + bonificacion.Id);
                var Nombreproveedor = proceso.ConsultarCadena("RazonSocial", "Proveedor", "Proveedor = '" + bonificacion.Proveedor + "'");
                bonificacion.CodigoObsequio = proceso.ConsultarCadena("cdProductoRegalo", "Bonificacion", "PKID = " + bonificacion.Id);
                var DescripcionObsequio = proceso.ConsultarCadena("Descripcion", "Vva_Producto", "Codigo = '" + bonificacion.CodigoObsequio + "'");
                bonificacion.Exclusion = proceso.ConsultarVerdad("TieneExclusion", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.IdExclusion = proceso.ConsultarEntero("IDBonifcacionExcluida", "Bonificacion", "PKID = " + bonificacion.Id);
                var DescripcionMecanica = proceso.ConsultarCadena("Mecanica", "Bonificacion", "PKID = " + bonificacion.IdExclusion);
                bonificacion.CodigoVenta = proceso.ConsultarCadena("cdProductoVenta", "Bonificacion", "PKID = " + bonificacion.Id);
                var DescripcionVenta = proceso.ConsultarCadena("Descripcion", "Vva_Producto", "Codigo = '" + bonificacion.CodigoObsequio + "'");
                bonificacion.CantidadMinima = proceso.ConsultarDecimal("CantidadMinima", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.CantidadMaxima = proceso.ConsultarEntero("CantidadMaxima", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.CantidadObsequio = proceso.ConsultarEntero("CantidadRegalo", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.MaximoPorCliente = proceso.ConsultarEntero("CantidadMaximaPorCliente", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.Stock = proceso.ConsultarEntero("stock", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.Desde = proceso.ConsultarCadena("Desde", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.Hasta = proceso.ConsultarCadena("Hasta", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.Activo = proceso.ConsultarVerdad("Activo", "Bonificacion", "PKID = " + bonificacion.Id);
                bonificacion.IdAsociado = proceso.ConsultarEntero("IDAsociado", "ItemBonificacion", "IDBonificacion = " + bonificacion.Id);
                bonificacion.CodigoAsociado = proceso.ConsultarCadena("Codigo", "TipoAsociado", "PKID = " + bonificacion.IdAsociado);
                var Coleccion = proceso.ConsultarTabla_("itembonificacion", "IDBonificacion = " + bonificacion.Id);
                frmreglabonificacion.IDControl.Text = Convert.ToString(bonificacion.Id);
                frmreglabonificacion.IDBonificacion.Text = bonificacion.CodigoTipoMecanica;
                frmreglabonificacion.nmBonificacion.Text = bonificacion.DescripcionTipoMecanica;
                frmreglabonificacion.DetalleMecanica.Text = bonificacion.Mecanica;
                frmreglabonificacion.IDProveedor.Text = bonificacion.Proveedor;
                frmreglabonificacion.NmProveedor.Text = Nombreproveedor;
                frmreglabonificacion.IDObsequio.Text = bonificacion.CodigoObsequio;
                frmreglabonificacion.NmObsequio.Text = DescripcionObsequio;
                frmreglabonificacion.TieneExclusion.Checked = bonificacion.Exclusion;
                frmreglabonificacion.IDExclusion.EditValue = bonificacion.Exclusion is false ? string.Empty : bonificacion.IdExclusion.ToString();
                frmreglabonificacion.NmExclusion.Text = bonificacion.Exclusion is false ? string.Empty : DescripcionMecanica;
                frmreglabonificacion.IDCanje.Text = bonificacion.CodigoVenta;
                frmreglabonificacion.NmCanje.Text = DescripcionVenta;
                frmreglabonificacion.CantidadMaxima.Value = bonificacion.CantidadMaxima;
                frmreglabonificacion.CantidadMinima.Value = bonificacion.CantidadMinima;
                frmreglabonificacion.CantidadRegalo.Value = bonificacion.CantidadObsequio;
                frmreglabonificacion.CantidadMaximaCliente.EditValue = bonificacion.MaximoPorCliente;
                frmreglabonificacion.StockPromocional.Value = bonificacion.Stock;
                frmreglabonificacion.fechaDesde.EditValue = Convert.ToDateTime(bonificacion.Desde).ToString("dd/MM/yyyy");
                frmreglabonificacion.fechaHasta.EditValue = Convert.ToDateTime(bonificacion.Hasta).ToString("dd/MM/yyyy");
                frmreglabonificacion.Estado.Checked = bonificacion.Activo;
                frmreglabonificacion.dataGridView1.Rows.Clear();
                switch (bonificacion.CodigoAsociado)
                {
                    case "Marca":
                        frmreglabonificacion.cdMarca.Checked = true;
                        break;
                    case "Linea":
                        frmreglabonificacion.cdLinea.Checked = true;
                        break;
                    case "Grupo":
                        frmreglabonificacion.cdGrupo.Checked = true;
                        break;
                    case "Producto":
                        frmreglabonificacion.cdProducto.Checked = true;
                        break;
                }
                foreach (DataRow DR_0 in Coleccion.Rows)
                {
                    producto.Codigo = DR_0["cdProductoColeccion"].ToString();
                    producto.Descripcion = proceso.ConsultarCadena("Descripcion", "producto", "producto = '" + DR_0["cdProductoColeccion"] + "'");
                    frmreglabonificacion.dataGridView1.Rows.Add(producto.Codigo, producto.Descripcion);
                }
                frmreglabonificacion.StartPosition = FormStartPosition.CenterScreen;
                frmreglabonificacion.Show();
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Elementos.frmReglaBonificacion frmreglabonificacion = new Elementos.frmReglaBonificacion();
            frmreglabonificacion.pasar += new Elementos.frmReglaBonificacion.variable(GrabarBonificacion);
            frmreglabonificacion.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (proceso.MensagePregunta("¿desea continuar?") == DialogResult.Yes)
                {
                    Point loc = new Point(510, 450);
                    Elementos.frmMsg frmmensage = new Elementos.frmMsg();
                    frmmensage.splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Manual;
                    frmmensage.splashScreenManager1.SplashFormLocation = loc;
                    frmmensage.dataGridView1.Columns[0].HeaderText = "Mecanica";
                    frmmensage.dataGridView1.Columns[0].Width = 200;
                    frmmensage.dataGridView1.Columns[1].HeaderText = "Resultado";
                    frmmensage.dataGridView1.Columns[1].Width = 100;
                    frmmensage.dataGridView1.Columns[2].HeaderText = string.Empty;
                    frmmensage.dataGridView1.Columns[3].HeaderText = string.Empty;
                    frmmensage.Show();
                    frmmensage.splashScreenManager1.ShowWaitForm();
                    foreach (var bonificacion in gridView1.GetSelectedRows())
                    {
                        var x = Convert.ToInt32(gridView1.GetDataRow(bonificacion)["PKID"]);
                        if (proceso.ExistenciaCampo("pkid", "Bonificacion", "pkid = " + x))
                        {
                            frmmensage.dataGridView1.Rows.Add(gridView1.GetDataRow(bonificacion)["Mecanica"].ToString(), ejecutar.DeleteBonificacion(x),
                            string.Empty, string.Empty);
                        }
                    }
                    frmmensage.splashScreenManager1.CloseWaitForm();
                    Refrescar();
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}