using DevExpress.XtraSplashScreen;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm.Modulos.Ventas
{
    public partial class frmPedido : DevExpress.XtraEditors.XtraForm
    {
        Libreria.Proceso proceso = new Libreria.Proceso();
        Libreria.Pedido pedido = new Libreria.Pedido();
        Libreria.Maestra maestro = new Libreria.Maestra();
        Libreria.Entidad entidad = new Libreria.Entidad();
        Libreria.Ejecutar ejecutar = new Libreria.Ejecutar();
        Libreria.Producto producto = new Libreria.Producto();
        private DateTime ahora;
        private DateTime inicio;
        private string tabla = "pedido";
        public frmPedido()
        {
            InitializeComponent();
            entidad.tabla = "pedido";
            entidad.fechainicio = Convert.ToDateTime(DateTime.Today).ToString("yyyyMMdd");
            ahora = DateTime.Now;
            inicio = new DateTime(ahora.Year, ahora.Month, 1);
            entidad.fechafin = Convert.ToDateTime(DateTime.Today.AddDays(1)).ToString("yyyyMMdd");
        }

        private void filtarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            proceso.actualizar("pedido", "FECHA = REPLACE(CONVERT(VARCHAR(10),Fecha,120),'-','')", "procesado = 0 and statusweb is null");
            actualizavalores(inicio.ToString("yyyyMMdd"));
            DataTable mapa = new DataTable();
            mapa.Columns.Add("campos", typeof(System.String));
            Filtros.frmFiltros filtro = new Filtros.frmFiltros();
            proceso.consultar("select campo,condicion,valor,[union] from filtro where tabla = '" + entidad.tabla + "'", entidad.tabla);
            foreach (string dr in (from t in maestro.pedido().Columns.Cast<DataColumn>() select t.ColumnName).ToList())
            {
                mapa.Rows.Add(dr);
            }
            foreach (DataRow dr in proceso.ds.Tables[entidad.tabla].Rows)
            {
                filtro.dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
            }
            filtro.tabla = entidad.tabla;
            filtro.cboxCampo.DataSource = mapa;
            filtro.cboxCampo.DisplayMember = "campos";
            filtro.cboxCampo.ValueMember = "campos";
            filtro.pasar += new Filtros.frmFiltros.variables(condicion);
            filtro.StartPosition = FormStartPosition.CenterScreen;

            filtro.ShowDialog();
        }

        void CamposPedido(string codigo)
        {

        }

        void condicion(string cadena)
        {
            entidad.sql =
            @"select * from(
            SELECT
                dbo.Vva_Pedido.Gestion,
                dbo.Vva_Pedido.FechaEmision,
                dbo.Vva_Pedido.Hora,
                dbo.Vva_Pedido.IDVend AS [cod Vendedor],
                dbo.PERSONAL.Nombre AS [nom Vendedor],
                dbo.Vva_Cliente.Codigo AS [cod Cliente],
                dbo.Vva_Cliente.Nombre AS [nom Cliente],
                dbo.Vva_Cliente.Documento AS [doc Identidad],
                dbo.Vva_ItemPedido.NrPedido AS [num Pedido],
                ISNULL (dbo.DOCUMENTO.TipoDoc,
                        '') AS [Tipo Documento],
                ISNULL (dbo.DOCUMENTO.Generado,
                        '') AS [num Comprobante],
                dbo.Vva_Pedido.TpPago AS [Tipo Condicion],
                dbo.Vva_Pedido.Credito,
                SUM (dbo.Vva_ItemPedido.Precio * dbo.Vva_ItemPedido.Cantidad) AS [Valor Total],
                SUM (dbo.Vva_ItemPedido.Precio * dbo.Vva_ItemPedido.Cantidad - dbo.Vva_ItemPedido.Precio * dbo.Vva_ItemPedido.Cantidad * 0.18) AS 
                    [Valor Venta],
                SUM (dbo.Vva_ItemPedido.Precio * dbo.Vva_ItemPedido.Cantidad * 0.18) AS Igv,
                SUM (dbo.Vva_ItemPedido.Descuento) AS Descuento,
                SUM (dbo.Vva_ItemPedido.Recargo) AS Recargo,
                dbo.Vva_Pedido.Procesado,
                dbo.Vva_Pedido.Bajado,
                dbo.ZONA.Descripcion AS [Zona Venta],
                dbo.Vva_Pedido.Aprobado
            FROM
                dbo.Vva_ItemPedido
                INNER JOIN
                dbo.Vva_Pedido
                ON dbo.Vva_ItemPedido.NrPedido = dbo.Vva_Pedido.NrPedido
                INNER JOIN
                dbo.PERSONAL
                ON dbo.Vva_Pedido.IDVend = dbo.PERSONAL.Personal
                INNER JOIN
                dbo.Vva_Cliente
                ON dbo.Vva_Pedido.IDClient = dbo.Vva_Cliente.Codigo
                INNER JOIN
                dbo.ZONA
                ON dbo.Vva_Cliente.Zona = dbo.ZONA.Zona
                LEFT OUTER JOIN
                dbo.DOCUMENTO
                ON dbo.Vva_Pedido.NrPedido = dbo.DOCUMENTO.Pedido
            GROUP BY
                dbo.Vva_Pedido.Gestion,
                dbo.Vva_Pedido.FechaEmision,
                dbo.Vva_Pedido.Hora,
                dbo.Vva_Pedido.IDVend,
                dbo.PERSONAL.Nombre,
                dbo.Vva_Cliente.Codigo,
                dbo.Vva_Cliente.Nombre,
                dbo.Vva_Cliente.Documento,
                dbo.Vva_ItemPedido.NrPedido,
                ISNULL (dbo.DOCUMENTO.TipoDoc,
                        ''),
                ISNULL (dbo.DOCUMENTO.Generado,
                        ''),
                dbo.Vva_Pedido.TpPago,
                dbo.Vva_Pedido.Credito,
                dbo.ZONA.Descripcion,
                dbo.Vva_Pedido.Bajado,
                dbo.Vva_Pedido.Procesado,
                dbo.Vva_Pedido.Aprobado) tabla";
            if (cadena.Length == 0)
            {
                proceso.consultar(entidad.sql, entidad.tabla);
                gridControl1.DataSource = proceso.ds.Tables[entidad.tabla];
                gridView1.OptionsView.ColumnAutoWidth = false;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsBehavior.ReadOnly = true;
                gridView1.OptionsView.ShowGroupPanel = false;
                gridView1.OptionsView.ShowFooter = true;
                gridView1.FooterPanelHeight = -2;
                gridView1.Columns["Valor Venta"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["Igv"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["Valor Total"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                gridView1.Columns["Tipo Condicion"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                gridView1.GroupRowHeight = 1;
                gridView1.RowHeight = 1;
                gridView1.Appearance.Row.FontSizeDelta = 0;
                gridView1.BestFitColumns();
            }
            else
            {
                try
                {
                    proceso.consultar(entidad.sql + " where " + cadena, entidad.tabla);
                    gridControl1.DataSource = proceso.ds.Tables[entidad.tabla];
                    gridView1.OptionsView.ColumnAutoWidth = false;
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.OptionsBehavior.ReadOnly = true;
                    gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                    gridView1.OptionsView.ShowGroupPanel = false;
                    gridView1.OptionsView.ShowFooter = true;
                    gridView1.Columns["Valor Venta"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns["Igv"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns["Valor Total"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    gridView1.Columns["Tipo Condicion"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
                    gridView1.GroupRowHeight = 1;
                    gridView1.RowHeight = 1;
                    gridView1.Appearance.Row.FontSizeDelta = 0;
                    gridView1.BestFitColumns();
                }
                catch
                {
                    gridControl1.DataSource = null;
                    gridControl1.Refresh();
                }
            }

        }
        void actualizavalores(string fecha)
        {
            string queryA = @"pedido in (select pedido from pedido where fecha >= '" + fecha + "')";
            string queryB = @"(SELECT CASE WHEN DETPEDIDO.TipoPrecio = 1 THEN PrecMenContado WHEN DETPEDIDO.TipoPrecio = 2 THEN 
                                  PrecMayContado WHEN DETPEDIDO.TipoPrecio = 3 THEN PrecMenCredito WHEN DETPEDIDO.TipoPrecio = 4 THEN 
                                  PrecMayCredito WHEN DETPEDIDO.TipoPrecio = 5 THEN PrecEspecial WHEN DETPEDIDO.TipoPrecio = 6 THEN 
                                  PrecSEspecial WHEN DETPEDIDO.TipoPrecio = 7 THEN PrecSSEspecial END
                          FROM PRODUCTO
                          WHERE Producto = DETPEDIDO.Producto)";

            proceso.actualizar("detpedido", "PrecioNeto = PrecUnit", queryA);
            proceso.actualizar("detpedido", "PrecioUnitario = " + queryB, queryA);
            proceso.actualizar("detpedido", "Descuento = IIF ((PrecioUnitario - PrecioNeto) < 0,0,(PrecioUnitario - PrecioNeto))", queryA);
            proceso.actualizar("detpedido", "Recargo = IIF ((PrecioNeto - PrecioUnitario) < 0,0,(PrecioNeto - PrecioUnitario))", queryA);
            proceso.actualizar("detpedido", "Afecto = (SELECT conigv FROM PRODUCTO WHERE Producto = DETPEDIDO.Producto)", queryA);
            proceso.actualizar("detpedido", "Bonif = CASE WHEN PrecUnit = 0.00 THEN 1 WHEN IDBonificacion > 0 THEN 1 ELSE 0 END", queryA);
            proceso.actualizar("pedido", "Aprobado = 1", queryA);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Elementos.frmpedido nuevopedido = new Elementos.frmpedido();
            nuevopedido.StartPosition = FormStartPosition.CenterScreen;
            nuevopedido.dateEmision.EditValue = DateTime.Now.ToShortDateString();
            nuevopedido.dateEntrega.EditValue = DateTime.Now.AddDays(1).ToShortDateString();
            nuevopedido.btnCredito.Enabled = false;
            nuevopedido.txtformaPago.Enabled = false;
            nuevopedido.txtformaPago.EditValue = "CONTADO";
            nuevopedido.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                Elementos.frmpedido frmpedido = new Elementos.frmpedido();
                frmpedido.Existe = true;
                //frmpedido.pasar += new Elementos.frmpedido.varaible(CamposPedido);
                pedido.NumeroPedido = gridView1.GetFocusedRowCellValue("num Pedido").ToString();
                pedido.CodigoVendedor = proceso.ConsultarCadena("Personal", "Pedido", "pedido = '" + pedido.NumeroPedido + "'");
                pedido.NombreVendedor = proceso.ConsultarCadena("[Nombre Vendedor]", "Vva_Vendedor", "[Codigo vendedor] = '" + pedido.CodigoVendedor + "'");
                pedido.CodigoCliente = proceso.ConsultarCadena("Cliente", "Pedido", "pedido = '" + pedido.NumeroPedido + "'");
                pedido.NombreCliente = proceso.ConsultarCadena("Nombre", "Vva_Cliente", "Codigo = '" + pedido.CodigoCliente + "'");
                pedido.DocumentoCliente = proceso.ConsultarCadena("Documento", "Vva_Cliente", "Codigo = '" + pedido.CodigoCliente + "'");
                pedido.DireccionCliente = proceso.ConsultarCadena("Direccion", "Pedido", "pedido = '" + pedido.NumeroPedido + "'");
                pedido.ZonaCliente = proceso.ConsultarCadena("descripcion", "Zona", "Zona = (select zona from pedido where pedido = '" + pedido.NumeroPedido + "')");
                pedido.DistritoCliente = proceso.ConsultarCadena("descrip", "Distrito", "iddistrito = (select iddistrito from pedido where pedido = '" + pedido.NumeroPedido + "')");
                pedido.ProvinciaCliente = proceso.ConsultarCadena("descrip", "provincia", " idprovincia = (select idprovincia from Distrito where iddistrito = (select idprovincia from pedido where pedido = '" + pedido.NumeroPedido + "'))");
                pedido.Gestion = proceso.ConsultarCadena("Gestion", "Pedido", "pedido = '" + pedido.NumeroPedido + "'");
                pedido.Credito = proceso.ConsultarVerdad("Credito", "Vva_Pedido", "NrPedido = '" + pedido.NumeroPedido + "'");
                pedido.FormaPago = proceso.ConsultarCadena("FormaPago", "Pedido", "pedido = '" + pedido.NumeroPedido + "'");
                pedido.FechaEmision = proceso.ConsultarCadena("FechaEmision", "Vva_Pedido", "NrPedido = '" + pedido.NumeroPedido + "'");
                frmpedido.txtcdDocumento.Text = pedido.NumeroPedido;
                frmpedido.txtcdVendedor.Text = pedido.CodigoVendedor;
                frmpedido.txtnmVendedor.Text = pedido.NombreVendedor;
                frmpedido.txtcdCLiente.Text = pedido.CodigoCliente;
                frmpedido.txtnmCliente.Text = pedido.NombreCliente;
                frmpedido.txtdocCliente.Text = pedido.DocumentoCliente;
                frmpedido.txtnmDireccion.EditValue = pedido.DireccionCliente;
                frmpedido.txtnmZona.EditValue = pedido.ZonaCliente;
                frmpedido.txtnmDistrito.EditValue = pedido.DistritoCliente;
                frmpedido.txtnmProvincia.EditValue = pedido.ProvinciaCliente;
                frmpedido.txtcdGestion.Text = pedido.Gestion;
                frmpedido.dateEmision.EditValue = Convert.ToDateTime(pedido.FechaEmision).ToString("dd/MM/yyyy");
                frmpedido.dateEntrega.EditValue = Convert.ToDateTime(pedido.FechaEmision).AddDays(1).ToString("dd/MM/yyyy");
                frmpedido.btnCredito.Checked = pedido.Credito == true ? true : false;
                frmpedido.txtformaPago.EditValue = proceso.ConsultarCadena("Descripcion", "FormaPago", "FormaPago = '" + pedido.FormaPago + "'");
                proceso.consultar("select * from detpedido where pedido = '" + pedido.NumeroPedido + "'", tabla);
                foreach (DataRow DR_0 in proceso.ds.Tables[tabla].Rows)
                {
                    producto.Codigo = DR_0["Producto"].ToString();
                    producto.Descripcion = proceso.ConsultarCadena("Descripcion", "Vva_Producto", "Codigo = '" + producto.Codigo + "'");
                    producto.Cantidad = Convert.ToDecimal(DR_0["Cantidad"]);
                    producto.Unidad = proceso.ConsultarCadena("Unidad", "Vva_producto", "Codigo = '" + producto.Codigo + "'");
                    producto.PrecioUnitario = Convert.ToDecimal(DR_0["PrecioUnitario"]);
                    producto.PrecioNeto = Convert.ToDecimal(DR_0["PrecioNeto"]);
                    producto.Descuento = Convert.ToDecimal(DR_0["Descuento"]);
                    producto.Recargo = Convert.ToDecimal(DR_0["Recargo"]);
                    producto.Bonificacion = Convert.ToBoolean(DR_0["Bonif"]);
                    producto.Afecto = Convert.ToBoolean(DR_0["Afecto"]);
                    var IdBonif = DR_0["IDBonificacion"] is DBNull ? 0 : DR_0["IDBonificacion"];
                    producto.TipoPrecio = Convert.ToInt32(DR_0["TipoPrecio"]);

                    frmpedido.dataGridView1.Rows.Add(producto.Codigo, producto.Descripcion, producto.Cantidad, producto.Cantidad, producto.Unidad, producto.TipoPrecio, producto.PrecioUnitario, producto.PrecioNeto,
                        (producto.Cantidad * producto.PrecioNeto), producto.Descuento, producto.Recargo, producto.Bonificacion, pedido.Credito, producto.Afecto, IdBonif);
                    frmpedido.dataGridView1.CurrentRow.ReadOnly = producto.Bonificacion == true ? true : false;
                    frmpedido.dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                    frmpedido.dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                }
                frmpedido.calculartotal();
                frmpedido.StartPosition = FormStartPosition.CenterScreen;
                frmpedido.Existe = false;
                frmpedido.Show();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            modificarToolStripMenuItem_Click(sender, e);
        }

        private void descargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                Point loc = new Point(510, 450);
                Elementos.frmMsg frmmensage = new Elementos.frmMsg();
                frmmensage.splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Manual;
                frmmensage.splashScreenManager1.SplashFormLocation = loc;
                frmmensage.dataGridView1.Columns[0].HeaderText = "Pedido";
                frmmensage.dataGridView1.Columns[1].HeaderText = "Resultado";
                frmmensage.dataGridView1.Columns[2].HeaderText = "";
                frmmensage.dataGridView1.Columns[3].HeaderText = "";
                frmmensage.Show();
                frmmensage.splashScreenManager1.ShowWaitForm();
                foreach (var pedido in gridView1.GetSelectedRows())
                {
                    entidad.pedido = gridView1.GetDataRow(pedido)["num Pedido"].ToString();
                    string tipopersona = proceso.ConsultarCadena("TipoPersona", "pedido", "pedido = '" + entidad.pedido + "'");
                    entidad.tipodocumento = proceso.ConsultarCadena("TipoDoc", "pedido", "pedido = '" + entidad.pedido + "'");
                    if (!proceso.ExistenciaCampo("pedido", "pedido", "procesado = 1 and pedido = '" + entidad.pedido + "'"))
                    {
                        if (proceso.ExistenciaCampo("pedido", "pedido", "statusweb is null and pedido = '" + entidad.pedido + "'"))
                        {
                            frmmensage.dataGridView1.Rows.Add(gridView1.GetDataRow(pedido)["num Pedido"].ToString(),
                                "Documento Saliente Número : " + entidad.tipodocumento + proceso.Procedimiento("sp_genera_documento '" + entidad.pedido + "','" + tipopersona + "','" + entidad.tipodocumento + "'"),
                                string.Empty, string.Empty);
                            proceso.actualizar("pedido", "StatusWeb = 1", "pedido = '" + entidad.pedido + "'");
                        }
                        else
                        {
                            frmmensage.dataGridView1.Rows.Add(gridView1.GetDataRow(pedido)["num Pedido"].ToString(), "pedido ya se encuentra descargado!",
                            string.Empty, string.Empty);
                        }
                    }
                    else
                    {
                        frmmensage.dataGridView1.Rows.Add(gridView1.GetDataRow(pedido)["num Pedido"].ToString(), "pedido se encuentra procesado y no puede ser eliminado!",
                        string.Empty, string.Empty);
                    }
                }
                frmmensage.splashScreenManager1.CloseWaitForm();
                gridControl1.DataSource = null;
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (proceso.MensageError("¿Continuar?") == DialogResult.Yes)
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    Point loc = new Point(510, 450);
                    Elementos.frmMsg frmmensage = new Elementos.frmMsg();
                    frmmensage.splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Manual;
                    frmmensage.splashScreenManager1.SplashFormLocation = loc;
                    frmmensage.dataGridView1.Columns[0].HeaderText = "Pedido";
                    frmmensage.dataGridView1.Columns[1].HeaderText = "Resultado";
                    frmmensage.dataGridView1.Columns[2].HeaderText = "";
                    frmmensage.dataGridView1.Columns[3].HeaderText = "";
                    frmmensage.Show();
                    frmmensage.splashScreenManager1.ShowWaitForm();
                    foreach (var pedido in gridView1.GetSelectedRows())
                    {
                        if (!proceso.ExistenciaCampo("pedido", "pedido", "procesado = 1 and pedido = '" + gridView1.GetDataRow(pedido)["num Pedido"].ToString() + "'"))
                        {
                            frmmensage.dataGridView1.Rows.Add(gridView1.GetDataRow(pedido)["num Pedido"].ToString(), ejecutar.deletepedido(gridView1.GetDataRow(pedido)["num Pedido"].ToString()),
                            string.Empty, string.Empty);
                        }
                        else
                        {
                            frmmensage.dataGridView1.Rows.Add(gridView1.GetDataRow(pedido)["num Pedido"].ToString(), "pedido se encuentra procesado y no puede ser eliminado!",
                            string.Empty, string.Empty);
                        }
                    }
                    frmmensage.splashScreenManager1.CloseWaitForm();
                    gridControl1.DataSource = null;
                }
            }


        }
    }
}