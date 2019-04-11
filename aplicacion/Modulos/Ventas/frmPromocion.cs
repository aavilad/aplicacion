using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Modulos.Ventas
{
    public partial class frmPromocion : DevExpress.XtraEditors.XtraForm
    {
        Libreria.maestroBonif_Reglas ejecutar_ = new Libreria.maestroBonif_Reglas();
        Libreria.Ejecutar ejecutar = new Libreria.Ejecutar();
        Libreria.Bonificacion bonificacion = new Libreria.Bonificacion();
        Libreria.Producto producto = new Libreria.Producto();
        Libreria.Maestra maestro = new Libreria.Maestra();
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
            {
                lista_.Add("[" + DR_1[0].ToString() + "]" + DR_1[1].ToString() + "'" + DR_1[2].ToString() + "'" + DR_1[3].ToString());
            }
            string cadena = string.Join(" ", lista_.ToArray());
            condicion(cadena);
        }
        void GrabarBonificacion(string Mecanica, int TipoMecanica, string CodigoObsequio, decimal CantidadMinima, int CantidadMaxima, int CantidadObsequio, int MaximoPorCliente,
            decimal Stock, bool Exclusion, int PkidExclusion, string CodigoVenta, string Proveedor, string Desde, string Hasta, bool Activo, int IDAsociado, DataGridView dgv)
        {
            var x = proceso.ID("Bonificacion");
            switch (Existe)
            {
                case true:
                    ejecutar_.saveBonificacion(bonificacion.Id, Mecanica, TipoMecanica, CodigoObsequio, CantidadMinima, CantidadMaxima, CantidadObsequio, MaximoPorCliente, Stock, Exclusion,
                        PkidExclusion, CodigoVenta, Proveedor, Desde, Hasta, Activo, dgv, proceso.ID("ItemBonificacion"), IDAsociado == 0 ? bonificacion.IdAsociado : IDAsociado);
                    Refrescar();
                    break;
                case false:
                    ejecutar_.insertBonificacion(x, Mecanica, TipoMecanica, CodigoObsequio, CantidadMinima, CantidadMaxima, CantidadObsequio, MaximoPorCliente, Stock, Exclusion,
                        PkidExclusion, CodigoVenta, Proveedor, Desde, Hasta, Activo, dgv, proceso.ID("ItemBonificacion"), IDAsociado == 0 ? bonificacion.IdAsociado : IDAsociado);
                    Refrescar();
                    break;
            }
        }
        void condicion(string cadena)
        {
            var sql =
                    @"SELECT DISTINCT
                    dbo.Bonificacion.PKID, dbo.Bonificacion.Mecanica, dbo.Bonificacion.TipoMecanica, dbo.Bonificacion.cdProductoRegalo, dbo.Bonificacion.CantidadMinima, 
                    dbo.Bonificacion.CantidadMaxima, dbo.Bonificacion.CantidadRegalo, dbo.Bonificacion.CantidadMaximaPorCliente, dbo.Bonificacion.Stock, 
                    dbo.Bonificacion.StockEntregado, dbo.Bonificacion.TieneExclusion, dbo.Bonificacion.IDBonifcacionExcluida, dbo.Bonificacion.cdProductoVenta, 
                    dbo.Bonificacion.IDProveedor, dbo.Bonificacion.Desde, dbo.Bonificacion.Hasta, dbo.Bonificacion.Activo, dbo.PROVEEDOR.RazonSocial AS Proveedor, 
                    dbo.TipoAsociado.Codigo AS Asociado
                    FROM
                    dbo.Bonificacion INNER JOIN
                    dbo.PROVEEDOR ON dbo.Bonificacion.IDProveedor = dbo.PROVEEDOR.Proveedor INNER JOIN
                    dbo.ItemBonificacion ON dbo.Bonificacion.PKID = dbo.ItemBonificacion.IDBonificacion INNER JOIN
                    dbo.TipoAsociado ON dbo.ItemBonificacion.IDAsociado = dbo.TipoAsociado.PKID";
            if (cadena.Length == 0)
            {
                proceso.consultar(sql, tabla);
                gridcontrolBonificacion.DataSource = proceso.ds.Tables[tabla];
                gridView1.Columns[0].Visible = false;
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
            }
            else
            {
                try
                {
                    proceso.consultar(sql + " where " + cadena, tabla);
                    gridcontrolBonificacion.DataSource = proceso.ds.Tables[tabla];
                    gridView1.Columns[0].Visible = false;
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
                }
                catch
                {
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
            DataTable mapa = new DataTable();
            mapa.Columns.Add("campos", typeof(System.String));
            Filtros.frmFiltros filtro = new Filtros.frmFiltros();
            proceso.consultar("select campo,condicion,valor,[union] from filtro where tabla = '" + tabla + "'", tabla);
            foreach (string dr in (from t in maestro.bonificacion().Columns.Cast<DataColumn>() select t.ColumnName).ToList())
            {
                mapa.Rows.Add(dr);
            }
            foreach (DataRow dr in proceso.ds.Tables[tabla].Rows)
            {
                filtro.dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
            }
            filtro.tabla = tabla;
            filtro.cboxCampo.DataSource = mapa;
            filtro.cboxCampo.DisplayMember = "campos";
            filtro.cboxCampo.ValueMember = "campos";
            filtro.pasar += new Filtros.frmFiltros.variables(condicion);
            filtro.StartPosition = FormStartPosition.CenterScreen;
            filtro.Show();
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
                    frmmensage.dataGridView1.Columns[2].HeaderText = "";
                    frmmensage.dataGridView1.Columns[3].HeaderText = "";
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
    }
}