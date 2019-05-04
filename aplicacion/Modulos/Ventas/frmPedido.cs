using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
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
        public string tabla = "vva_pedido";
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
            using (var Context = new Model.LiderAppEntities())
            {
                proceso.actualizar("pedido", "FECHA = REPLACE(CONVERT(VARCHAR(10),Fecha,120),'-','')", "procesado = 0 and statusweb is null");
                actualizavalores(inicio.ToString("yyyyMMdd"));
                Filtros.frmFiltros filtro = new Filtros.frmFiltros();
                DataGridViewComboBoxColumn i = filtro.dataGridView1.Columns["Index1"] as DataGridViewComboBoxColumn;
                i.DataSource = Context.FiltroConfiguracion.Where(a => a.Tipo == "CONDICION").ToArray();
                i.DisplayMember = "Descripcion";
                i.ValueMember = "Codigo";
                DataGridViewComboBoxColumn j = filtro.dataGridView1.Columns["Index3"] as DataGridViewComboBoxColumn;
                j.DataSource = Context.FiltroConfiguracion.Where(a => a.Tipo == "OPERADOR").ToList();
                j.DisplayMember = "Descripcion";
                j.ValueMember = "Codigo";
                DataGridViewComboBoxColumn k = filtro.dataGridView1.Columns["Index0"] as DataGridViewComboBoxColumn;
                k.DataSource = Context.Database.SqlQuery<string>(Libreria.Constante.Mapa_View + "'vva_pedido'").ToList();
                filtro.pasar += new Filtros.frmFiltros.variables(condicion);
                filtro.StartPosition = FormStartPosition.CenterScreen;
                foreach (var fila in Context.Filtro.Where(w => w.tabla.Equals(tabla)).ToList())
                {
                    filtro.dataGridView1.Rows.Add(fila.campo, fila.condicion, fila.valor, fila.union);
                }
                filtro.entidad = tabla;
                filtro.ShowDialog();
            }
        }

        void CamposPedido(string CdPedido, string TpDoc, string CdVendedor, string CdCliente, string CdFP, DateTime Fecha, string NmCliente, string Ruc, string Direccion, string Dni, string NmVendedor,
            string Gestion, string IdDistrito, DataGridView dgv)
        {
            using (Model.LiderAppEntities Context = new Model.LiderAppEntities())
            {
                Model.PEDIDO Cp = new Model.PEDIDO { Pedido1 = CdPedido };
                Context.PEDIDO.Attach(Cp);
                Cp.Personal = CdVendedor;
                Cp.Cliente = CdCliente;
                Cp.FormaPago = CdFP;
                Cp.Fecha = Fecha;
                Cp.rsocial = NmCliente;
                Cp.ruc = Ruc;
                Cp.direccion = Direccion;
                Cp.dni = Dni;
                Cp.encargado = CdVendedor;
                Cp.npersonal = NmVendedor;
                Cp.nencargado = NmVendedor;
                Cp.gestion = Gestion;
                Cp.ptollegada = Direccion;
                Cp.distllegada = IdDistrito;
                Cp.tipodoc = TpDoc;
                Context.Configuration.ValidateOnSaveEnabled = false;
                Context.DETPEDIDO.RemoveRange(Context.DETPEDIDO.Where(a => a.Pedido == CdPedido));
                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    Model.DETPEDIDO ItemCp = new Model.DETPEDIDO();
                    ItemCp.Pedido = CdPedido;
                    ItemCp.Producto = Convert.ToString(fila.Cells["Codigo"].Value);
                    ItemCp.PrecUnit = Convert.ToDecimal(fila.Cells["PrecioUnitario"].Value);
                    ItemCp.Cantidad = Convert.ToDecimal(fila.Cells["Cantidad"].Value);
                    ItemCp.Estado = "P";
                    ItemCp.TipoPrecio = Convert.ToString(fila.Cells["TpPrecio"].Value);
                    ItemCp.TranGratuita = (decimal)0.00;
                    ItemCp.lote = string.Empty;
                    ItemCp.fvctolote = Convert.ToDateTime("1990/01/01");
                    ItemCp.flgSurtido = "N";
                    ItemCp.IDBonificacion = Convert.ToInt32(fila.Cells["IDBonificacion"].Value == "" ? 0 : fila.Cells["IDBonificacion"].Value);
                    ItemCp.PrecioUnitario = Convert.ToDecimal(fila.Cells["PrecioUnitario"].Value);
                    ItemCp.PrecioNeto = Convert.ToDecimal(fila.Cells["PrecioNeto"].Value);
                    ItemCp.Descuento = Convert.ToDecimal(fila.Cells["Descuento"].Value);
                    ItemCp.Recargo = Convert.ToDecimal(fila.Cells["Recargo"].Value);
                    ItemCp.Afecto = Convert.ToDecimal(fila.Cells["Afecto"].Value);
                    ItemCp.Bonif = Convert.ToBoolean(fila.Cells["Bonif"].Value);
                    Context.DETPEDIDO.Add(ItemCp);
                }
                Context.SaveChanges();
                Context.Database.SqlQuery<string>("exec sp_stock_sistema @Fecha,2", DateTime.Now.Date.ToString("yyyyMMdd"));
                Context.Database.SqlQuery<string>("exec sp_stock_sistema_web @Fecha,2", DateTime.Now.Date.ToString("yyyyMMdd"));
            }
        }

        void condicion(string cadena)
        {
            if (cadena.Length == 0)
            {
                proceso.consultar(Libreria.Constante.Pedidos, tabla);
                gridControl1.DataSource = proceso.ds.Tables[tabla];
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
                    proceso.consultar(Libreria.Constante.Pedidos + " having " + cadena, tabla);
                    gridControl1.DataSource = proceso.ds.Tables[tabla];
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
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
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
            nuevopedido.txtformaPago.Text = "CONTADO";
            nuevopedido.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                var Context = new Model.LiderAppEntities();
                Elementos.frmpedido frmpedido = new Elementos.frmpedido();
                frmpedido.Existe = true;
                frmpedido.pasar += new Elementos.frmpedido.varaible(CamposPedido);
                pedido.NumeroPedido = gridView1.GetFocusedRowCellValue("num Pedido").ToString();
                pedido.CodigoVendedor = Context.PEDIDO.Where(p => p.Pedido1.Equals(pedido.NumeroPedido)).Select(a => a.Personal).FirstOrDefault();
                pedido.NombreVendedor = Context.PEDIDO.Where(p => p.Pedido1.Equals(pedido.NumeroPedido)).Select(a => a.npersonal).FirstOrDefault();
                pedido.CodigoCliente = Context.PEDIDO.Where(p => p.Pedido1.Equals(pedido.NumeroPedido)).Select(a => a.Cliente).FirstOrDefault();
                pedido.NombreCliente = Context.CLIENTE.Where(p => p.Cliente1.Equals(pedido.CodigoCliente)).Select(a => a.Alias.Trim()).FirstOrDefault();
                pedido.DocumentoCliente = proceso.ConsultarCadena("Documento", "Vva_Cliente", "Codigo = '" + pedido.CodigoCliente + "'");
                pedido.DireccionCliente = Context.PEDIDO.Where(p => p.Pedido1.Equals(pedido.NumeroPedido)).Select(a => a.direccion).FirstOrDefault();
                pedido.ZonaCliente = proceso.ConsultarCadena("descripcion", "Zona", "Zona = (select zona from Vva_Cliente where Codigo = '" + pedido.CodigoCliente + "')");
                pedido.DistritoCliente = proceso.ConsultarCadena("descrip", "Distrito", "iddistrito = (select distllegada from pedido where pedido = '" + pedido.NumeroPedido + "')");
                pedido.ProvinciaCliente = proceso.ConsultarCadena("descrip", "provincia", " idprovincia = (select idprovincia from Distrito where iddistrito = (select idprovincia from pedido where pedido = '" + pedido.NumeroPedido + "'))");
                pedido.Gestion = Context.PEDIDO.Where(p => p.Pedido1.Equals(pedido.NumeroPedido)).Select(a => a.gestion).FirstOrDefault();
                pedido.Credito = proceso.ConsultarVerdad("Credito", "Vva_Pedido", "NrPedido = '" + pedido.NumeroPedido + "'");
                pedido.FormaPago = proceso.ConsultarCadena("FormaPago", "Pedido", "pedido = '" + pedido.NumeroPedido + "'");
                pedido.FechaEmision = proceso.ConsultarCadena("FechaEmision", "Vva_Pedido", "NrPedido = '" + pedido.NumeroPedido + "'");
                try
                {
                    frmpedido.txtcdDocumento.Text = pedido.NumeroPedido;
                    frmpedido.txtcdVendedor.Text = pedido.CodigoVendedor;
                    frmpedido.txtnmVendedor.Text = pedido.NombreVendedor;
                    frmpedido.txtcdCLiente.Text = pedido.CodigoCliente;
                    frmpedido.txtnmCliente.Text = pedido.NombreCliente;
                    frmpedido.txtdocCliente.Text = pedido.DocumentoCliente;
                    frmpedido.txtnmDireccion.EditValue = pedido.DireccionCliente;
                    frmpedido.txtnmZona.EditValue = pedido.ZonaCliente;
                    frmpedido.txtcdZona.EditValue = proceso.ConsultarCadena("Zona", "Vva_Cliente", "Codigo = '" + pedido.CodigoCliente + "'");
                    frmpedido.txtnmDistrito.EditValue = pedido.DistritoCliente;
                    frmpedido.txtcdDistrito.EditValue = proceso.ConsultarCadena("IDDistrito", "Vva_Cliente", "Codigo = '" + pedido.CodigoCliente + "'");
                    frmpedido.txtnmProvincia.EditValue = pedido.ProvinciaCliente;
                    frmpedido.txtcdProvincia.EditValue = proceso.ConsultarCadena("idprovincia", "Distrito", "iddistrito = (select IDDistrito from Vva_Cliente where codigo = '" + pedido.CodigoCliente + "')");
                    frmpedido.txtcdGestion.Text = pedido.Gestion;
                    frmpedido.dateEmision.EditValue = Convert.ToDateTime(pedido.FechaEmision).AddDays(0).ToString("dd/MM/yyyy");
                    frmpedido.dateEntrega.EditValue = Convert.ToDateTime(pedido.FechaEmision).AddDays(1).ToString("dd/MM/yyyy");
                    frmpedido.btnCredito.Checked = pedido.Credito == true ? true : false;
                    frmpedido.txtformaPago.Text = proceso.ConsultarCadena("Descripcion", "FormaPago", "FormaPago = '" + pedido.FormaPago + "'");
                    frmpedido.CodigoFP.Text = pedido.FormaPago;
                    proceso.consultar("select * from detpedido where pedido = '" + pedido.NumeroPedido + "'", tabla);
                    foreach (DataRow DR_0 in proceso.ds.Tables[tabla].Rows)
                    {
                        producto.Codigo = DR_0["Producto"].ToString();
                        producto.Descripcion = proceso.ConsultarCadena("Descripcion", "Vva_Producto", "Codigo = '" + producto.Codigo + "'");
                        producto.Cantidad = (decimal)DR_0["Cantidad"];
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
                        frmpedido.dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = false;
                        frmpedido.dataGridView1.CurrentRow.Cells["PrecioNeto"].ReadOnly = false;
                    }
                    frmpedido.calculartotal();
                    frmpedido.StartPosition = FormStartPosition.CenterScreen;
                    frmpedido.Existe = false;
                    frmpedido.Show();
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                }
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

            if (gridView1.SelectedRowsCount > 0)
            {
                if (proceso.MensageError("¿Continuar?") == DialogResult.Yes)
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

        private void aprobarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                using (var Context = new Model.LiderAppEntities())
                {
                    foreach (var fila in gridView1.GetSelectedRows())
                    {
                        var pedido = (from p in Context.PEDIDO where p.Pedido1 == Convert.ToString(gridView1.GetRowCellValue(fila, "num Pedido")) select p).FirstOrDefault();
                        pedido.Aprobado = true;
                    }
                    Context.SaveChanges();
                }
            }
        }

        private void desaprobarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                using (var Context = new Model.LiderAppEntities())
                {
                    foreach (var fila in gridView1.GetSelectedRows())
                    {
                        var pedido = (from p in Context.PEDIDO where p.Pedido1 == Convert.ToString(gridView1.GetRowCellValue(fila, "num Pedido")) select p).FirstOrDefault();
                        pedido.Aprobado = false;
                    }
                    Context.SaveChanges();
                }
            }
        }

        private void facturarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var facturar = new Elementos.frmFacturacionPedido();
            facturar.pasar += new Elementos.frmFacturacionPedido.Variables(Campos);

            facturar.Show();
        }

        void Campos(string Fecha, int SerieB, int SerieF)
        {
            int Contador = 0;
            if (gridView1.SelectedRowsCount > 0)
            {
                List<string> Lista = new List<string>();
                var frmmensage = new Elementos.frmMsg();
                frmmensage.dataGridView1.Columns[0].HeaderText = "Pedido";
                frmmensage.dataGridView1.Columns[1].HeaderText = "Mensage";
                frmmensage.dataGridView1.Columns[2].HeaderText = string.Empty;
                frmmensage.dataGridView1.Columns[3].HeaderText = string.Empty;
                using (var Context = new Model.LiderAppEntities())
                {
                    foreach (var fila in gridView1.GetSelectedRows())
                    {
                        string Pedido_ = Convert.ToString(gridView1.GetRowCellValue(fila, "num Pedido"));
                        string Tipo = Context.PEDIDO.Where(x => x.Pedido1 == Pedido_).Select(p => p.tipodoc).FirstOrDefault();
                        string Persona = Context.PEDIDO.Where(x => x.Pedido1 == Pedido_).Select(p => p.TipoPersona).FirstOrDefault();
                        var Estado = Context.PEDIDO.Where(x => x.Pedido1 == Pedido_).Select(p => p.Procesado).FirstOrDefault();
                        var Aprobado = Context.PEDIDO.Where(x => x.Pedido1 == Pedido_).Select(p => (bool)p.Aprobado).FirstOrDefault();
                        if (Estado)
                        {
                            Contador += 1;
                            if (Aprobado)
                            {
                                Contador += 1;
                                Lista.Add(Pedido_);
                                Context.sp_genera_documento(Pedido_, Convert.ToInt32(Persona), Tipo);
                            }
                            else
                            {
                                frmmensage.dataGridView1.Rows.Add(Pedido_, "Pedido se encuentra desaprobado.");
                                frmmensage.Show();
                            }
                        }
                        else
                        {
                            frmmensage.dataGridView1.Rows.Add(Pedido_, "Pedido se encuentra procesado.");
                            frmmensage.Show();
                        }
                    }
                    if (Contador == 2)
                    {

                        string cadena = string.Join(",", Lista.ToArray());
                        var Documentos = (from doc in Context.DOCUMENTO
                                          where cadena.Contains(doc.Pedido.Trim())
                                          select new
                                          {
                                              Documento = doc.Documento1,
                                              Tipo = doc.TipoDoc
                                          }).ToList();
                        foreach (var fila in Documentos)
                        {
                            try
                            {
                                int Numero;
                                string serie, NumeroComprobante;
                                switch (fila.Tipo)
                                {
                                    case "B":
                                        Numero = Convert.ToInt32((from p in Context.DOCTIPO.AsEnumerable() where p.PKID == SerieB select p.Numero).FirstOrDefault());
                                        serie = Convert.ToString((from p in Context.DOCTIPO.AsEnumerable() where p.PKID == SerieB select p.Serie).FirstOrDefault());
                                        NumeroComprobante = serie + Numero.ToString("D8");
                                        var Cp = (from p in Context.DOCUMENTO where p.Documento1 == fila.Documento && p.TipoDoc == fila.Tipo select p).FirstOrDefault();
                                        Cp.Generado = NumeroComprobante;
                                        var Pd = (from p in Context.PEDIDO
                                                  where p.Pedido1 == Context.DOCUMENTO.Where(y => y.Documento1 == fila.Documento && y.TipoDoc == fila.Tipo).Select(x => x.Pedido.Trim()).FirstOrDefault()
                                                  select p).FirstOrDefault();
                                        Pd.Procesado = true;
                                        Pd.statusWeb = true;
                                        var DTp = (from p in Context.DOCTIPO where p.PKID == SerieB select p).FirstOrDefault();
                                        DTp.Numero = DTp.Numero + 1;
                                        break;
                                    case "F":
                                        Numero = Convert.ToInt32((from p in Context.DOCTIPO.AsEnumerable() where p.PKID == SerieF select p.Numero).FirstOrDefault());
                                        serie = Convert.ToString((from p in Context.DOCTIPO.AsEnumerable() where p.PKID == SerieF select p.Serie).FirstOrDefault());
                                        NumeroComprobante = serie + Numero.ToString("D8");
                                        var Cp_ = (from p in Context.DOCUMENTO where p.Documento1 == fila.Documento && p.TipoDoc == fila.Tipo select p).FirstOrDefault();
                                        Cp_.Generado = NumeroComprobante;
                                        var Pd_ = (from p in Context.PEDIDO
                                                   where p.Pedido1 == Context.DOCUMENTO.Where(y => y.Documento1 == fila.Documento && y.TipoDoc == fila.Tipo).Select(x => x.Pedido.Trim()).FirstOrDefault()
                                                   select p).FirstOrDefault();
                                        Pd_.Procesado = true;
                                        Pd_.statusWeb = true;
                                        var DTp_ = (from p in Context.DOCTIPO where p.PKID == SerieB select p).FirstOrDefault();
                                        DTp_.Numero = DTp_.Numero + 1;
                                        break;
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
                        Context.SaveChanges();
                        MessageBox.Show("Se realizo la facturacion de : " + Lista.Count + " con exito.\n Detalles en control genera.");
                    }
                }
            }

        }
    }
}