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
using xtraForm.Model;

namespace xtraForm.Modulos.Ventas
{
    public partial class frmPedido : DevExpress.XtraEditors.XtraForm
    {
        public string NModulo;
        Libreria.Proceso proceso = new Libreria.Proceso();
        Libreria.Pedido pedido = new Libreria.Pedido();
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

        void Refrescar()
        {
            proceso.consultar("select campo, condicion, valor,[union] from filtro where tabla = '" + tabla + "'", tabla);
            List<string> lista_ = new List<string>();
            foreach (DataRow DR_1 in proceso.ds.Tables[tabla].Rows)
                lista_.Add(tabla + "." + "[" + DR_1[0].ToString() + "]" + DR_1[1].ToString() + "'" + DR_1[2].ToString() + "'" + DR_1[3].ToString());
            string cadena = string.Join(" ", lista_.ToArray());
            condicion(cadena);
        }

        void CamposPedido_(string CdPedido, string TpDoc, string CdVendedor, string CdCliente, string CdFP, DateTime Fecha, string NmCliente, string Ruc, string Direccion, string Dni, string NmVendedor,
            string Gestion, string IdDistrito, DataGridView dgv)
        {
            using (LiderEntities Context = new LiderEntities())
            {
                var i = Context.PEDIDOes.Where(x => x.Personal == CdVendedor && x.Fecha ==  Fecha);
                string _Correlativo = CdVendedor + Fecha.Year.ToString().Substring(2,2) + Fecha.Month + Convert.ToInt32(Fecha.Day) + (i.Count() + 1).ToString("D2");
                PEDIDO Cp = new PEDIDO ();
                Cp.Pedido1 = _Correlativo.Trim();
                Cp.Personal = CdVendedor;
                Cp.Cliente = CdCliente;
                Cp.FormaPago = CdFP;
                Cp.Fecha = Fecha;
                Cp.Estado = "P";
                Cp.Reparto = true;
                Cp.TipoPersona = "1";
                Cp.Procesado = false;
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
                Cp.flagCobertura = "N";
                Cp.Fecha_web = DateTime.Now;
                Cp.statusWeb = null;
                Cp.Aprobado = true;
                Context.Configuration.ValidateOnSaveEnabled = false;
                Context.PEDIDOes.Add(Cp);

                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    DETPEDIDO ItemCp = new DETPEDIDO();
                    ItemCp.Pedido = _Correlativo;
                    ItemCp.Producto = Convert.ToString(fila.Cells["Codigo"].Value);
                    ItemCp.PrecUnit = Convert.ToDecimal(fila.Cells["PrecioUnitario"].Value);
                    ItemCp.Cantidad = Convert.ToDecimal(fila.Cells["Cantidad"].Value);
                    ItemCp.Estado = "P";
                    ItemCp.TipoPrecio = Convert.ToString(fila.Cells["TpPrecio"].Value);
                    ItemCp.TranGratuita = (decimal)0.00;
                    ItemCp.lote = string.Empty;
                    ItemCp.fvctolote = Convert.ToDateTime("1990/01/01");
                    ItemCp.flgSurtido = "N";
                    ItemCp.IDBonificacion = Convert.ToInt32(fila.Cells["IDBonificacion"].Value == string.Empty ? 0 : fila.Cells["IDBonificacion"].Value);
                    ItemCp.PrecioUnitario = Convert.ToDecimal(fila.Cells["PrecioUnitario"].Value);
                    ItemCp.PrecioNeto = Convert.ToDecimal(fila.Cells["PrecioNeto"].Value);
                    ItemCp.Descuento = Convert.ToDecimal(fila.Cells["Descuento"].Value);
                    ItemCp.Recargo = Convert.ToDecimal(fila.Cells["Recargo"].Value);
                    ItemCp.Afecto = Convert.ToDecimal(fila.Cells["Afecto"].Value);
                    ItemCp.Bonif = Convert.ToBoolean(fila.Cells["Bonif"].Value);
                    Context.DETPEDIDOes.Add(ItemCp);
                }
                Context.SaveChanges();
                Context.Database.SqlQuery<string>("exec sp_stock_sistema @Fecha,2", DateTime.Now.Date.ToString("yyyyMMdd"));
                Context.Database.SqlQuery<string>("exec sp_stock_sistema_web @Fecha,2", DateTime.Now.Date.ToString("yyyyMMdd"));
                Refrescar();
            }
        }

        void CamposPedido(string CdPedido, string TpDoc, string CdVendedor, string CdCliente, string CdFP, DateTime Fecha, string NmCliente, string Ruc, string Direccion, string Dni, string NmVendedor,
            string Gestion, string IdDistrito, DataGridView dgv)
        {
            using (LiderEntities Context = new LiderEntities())
            {
                PEDIDO Cp = new PEDIDO { Pedido1 = CdPedido };
                Context.PEDIDOes.Attach(Cp);
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
                Context.DETPEDIDOes.RemoveRange(Context.DETPEDIDOes.Where(a => a.Pedido == CdPedido));
                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    DETPEDIDO ItemCp = new DETPEDIDO();
                    ItemCp.Pedido = CdPedido;
                    ItemCp.Producto = Convert.ToString(fila.Cells["Codigo"].Value);
                    ItemCp.PrecUnit = Convert.ToDecimal(fila.Cells["PrecioNeto"].Value);
                    ItemCp.Cantidad = Convert.ToDecimal(fila.Cells["Cantidad"].Value);
                    ItemCp.Estado = "P";
                    ItemCp.TipoPrecio = Convert.ToString(fila.Cells["TpPrecio"].Value);
                    ItemCp.TranGratuita = (decimal)0.00;
                    ItemCp.lote = string.Empty;
                    ItemCp.fvctolote = Convert.ToDateTime("1990/01/01");
                    ItemCp.flgSurtido = "N";
                    ItemCp.IDBonificacion = Convert.ToInt32(fila.Cells["IDBonificacion"].Value == string.Empty ? 0 : fila.Cells["IDBonificacion"].Value);
                    ItemCp.PrecioUnitario = Convert.ToDecimal(fila.Cells["PrecioUnitario"].Value);
                    ItemCp.PrecioNeto = Convert.ToDecimal(fila.Cells["PrecioNeto"].Value);
                    ItemCp.Descuento = Convert.ToDecimal(fila.Cells["Descuento"].Value);
                    ItemCp.Recargo = Convert.ToDecimal(fila.Cells["Recargo"].Value);
                    ItemCp.Afecto = Convert.ToDecimal(fila.Cells["Afecto"].Value);
                    ItemCp.Bonif = Convert.ToBoolean(fila.Cells["Bonif"].Value);
                    Context.DETPEDIDOes.Add(ItemCp);
                }
                Context.SaveChanges();
                Context.Database.SqlQuery<string>("exec sp_stock_sistema @Fecha,2", DateTime.Now.Date.ToString("yyyyMMdd"));
                Context.Database.SqlQuery<string>("exec sp_stock_sistema_web @Fecha,2", DateTime.Now.Date.ToString("yyyyMMdd"));
                Refrescar();
            }
        }

        void condicion(string cadena)
        {
            using (var Context = new LiderEntities())
            {
                string Query = Convert.ToString(Context.VistaAdministrativas.Where(x => x.IDModulo == (Context.Moduloes.Where(a => a.Nombre == NModulo).Select(b => b.PKID)).FirstOrDefault()).Select(a => a.Vista.Trim()).FirstOrDefault());
                if (cadena.Length == 0)
                {
                    proceso.consultar(Query, tabla);
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
                        proceso.consultar(Query + " having " + cadena, tabla);
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
                    catch
                    {
                        gridControl1.DataSource = null;
                        gridControl1.Refresh();
                    }
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
            proceso.actualizar("pedido", "Aprobado = 1", queryA + " and pedido.Aprobado is null");
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
                using (var Context = new LiderEntities())
                {
                    foreach (var fila in gridView1.GetSelectedRows())
                    {
                        string Pedido_ = Convert.ToString(gridView1.GetRowCellValue(fila, "num Pedido"));
                        string Tipo = Context.PEDIDOes.Where(x => x.Pedido1 == Pedido_).Select(p => p.tipodoc).FirstOrDefault();
                        int Persona = Convert.ToInt32(Context.PEDIDOes.Where(x => x.Pedido1 == Pedido_).Select(p => p.TipoPersona).FirstOrDefault());
                        var Estado = Context.PEDIDOes.Where(x => x.Pedido1 == Pedido_).Select(p => p.Procesado).FirstOrDefault();
                        var Aprobado = Context.PEDIDOes.Where(x => x.Pedido1 == Pedido_).Select(p => p.Aprobado).FirstOrDefault();
                        if (!Estado)
                        {
                            Contador += 1;
                            if (Aprobado is DBNull ? false : (bool)Aprobado)
                            {
                                Contador += 1;
                                Lista.Add(Pedido_);
                                //Context.sp_genera_documento(Pedido_, Persona, Tipo);
                            }
                            else
                            {
                                frmmensage.dataGridView1.Rows.Add(Pedido_, "Pedido se encuentra desaprobado.");
                            }
                        }
                        else
                        {
                            frmmensage.dataGridView1.Rows.Add(Pedido_, "Pedido se encuentra procesado.");
                        }
                    }
                    if (Contador == 0)
                    {
                        frmmensage.Show();
                    }
                    else if (Contador == 2)
                    {
                        string cadena = string.Join(",", Lista.ToArray());
                        var Documentos = (from doc in Context.DOCUMENTOes
                                          where cadena.Contains(doc.Pedido.Trim())
                                          select new
                                          {
                                              Documento = doc.Documento1,
                                              Tipo = doc.TipoDoc
                                          })
                                          .ToList();
                        foreach (var fila in Documentos)
                        {
                            try
                            {
                                int Numero;
                                string serie, NumeroComprobante;
                                switch (fila.Tipo)
                                {
                                    case "B":
                                        Numero = Convert.ToInt32((from p in Context.DOCTIPOes.AsEnumerable() where p.PKID == SerieB select p.Numero).FirstOrDefault());
                                        serie = Convert.ToString((from p in Context.DOCTIPOes.AsEnumerable() where p.PKID == SerieB select p.Serie).FirstOrDefault());
                                        NumeroComprobante = serie + Numero.ToString("D8");
                                        var Cp = (from p in Context.DOCUMENTOes where p.Documento1 == fila.Documento && p.TipoDoc == fila.Tipo select p).FirstOrDefault();
                                        Cp.Generado = NumeroComprobante;
                                        var Pd = (from p in Context.PEDIDOes
                                                  where p.Pedido1 == Context.DOCUMENTOes.Where(y => y.Documento1 == fila.Documento && y.TipoDoc == fila.Tipo).Select(x => x.Pedido.Trim()).FirstOrDefault()
                                                  select p).FirstOrDefault();
                                        Pd.Procesado = true;
                                        Pd.statusWeb = true;
                                        var DTp = (from p in Context.DOCTIPOes where p.PKID == SerieB select p).FirstOrDefault();
                                        DTp.Numero = DTp.Numero + 1;
                                        break;
                                    case "F":
                                        Numero = Convert.ToInt32((from p in Context.DOCTIPOes.AsEnumerable() where p.PKID == SerieF select p.Numero).FirstOrDefault());
                                        serie = Convert.ToString((from p in Context.DOCTIPOes.AsEnumerable() where p.PKID == SerieF select p.Serie).FirstOrDefault());
                                        NumeroComprobante = serie + Numero.ToString("D8");
                                        var Cp_ = (from p in Context.DOCUMENTOes where p.Documento1 == fila.Documento && p.TipoDoc == fila.Tipo select p).FirstOrDefault();
                                        Cp_.Generado = NumeroComprobante;
                                        var Pd_ = (from p in Context.PEDIDOes
                                                   where p.Pedido1 == Context.DOCUMENTOes.Where(y => y.Documento1 == fila.Documento && y.TipoDoc == fila.Tipo).Select(x => x.Pedido.Trim()).FirstOrDefault()
                                                   select p).FirstOrDefault();
                                        Pd_.Procesado = true;
                                        Pd_.statusWeb = true;
                                        var DTp_ = (from p in Context.DOCTIPOes where p.PKID == SerieB select p).FirstOrDefault();
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
                                Refrescar();
                            }
                        }
                        Context.SaveChanges();
                        Context.Database.SqlQuery<string>("exec sp_stock_sistema @Fecha,2", DateTime.Now.Date.ToString("yyyyMMdd"));
                        Context.Database.SqlQuery<string>("exec sp_stock_sistema_web @Fecha,2", DateTime.Now.Date.ToString("yyyyMMdd"));
                        MessageBox.Show("Se realizo la facturacion de : " + Lista.Count + " con exito.\n Detalles en control genera.");
                        Refrescar();
                    }
                }
            }

        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            popupMenu1.ShowPopup(gridControl1.PointToScreen(e.Point));
        }

        private void NUEVO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Elementos.frmpedido nuevopedido = new Elementos.frmpedido();
            nuevopedido.pasar += new Elementos.frmpedido.varaible(CamposPedido_);
            nuevopedido.StartPosition = FormStartPosition.CenterScreen;
            nuevopedido.dateEmision.EditValue = DateTime.Now.ToShortDateString();
            nuevopedido.dateEntrega.EditValue = DateTime.Now.AddDays(1).ToShortDateString();
            nuevopedido.btnCredito.Enabled = false;
            nuevopedido.txtformaPago.Enabled = false;
            nuevopedido.txtformaPago.Text = "CONTADO";
            nuevopedido.CodigoFP.Text = "C";
            nuevopedido.Show();
        }

        private void MODIFICAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                var Context = new LiderEntities();
                Elementos.frmpedido frmpedido = new Elementos.frmpedido();
                frmpedido.Existe = true;
                frmpedido.pasar += new Elementos.frmpedido.varaible(CamposPedido);
                pedido.NumeroPedido = gridView1.GetFocusedRowCellValue("num Pedido").ToString();
                pedido.CodigoVendedor = Context.PEDIDOes.Where(p => p.Pedido1.Equals(pedido.NumeroPedido)).Select(a => a.Personal).FirstOrDefault();
                pedido.NombreVendedor = Context.PEDIDOes.Where(p => p.Pedido1.Equals(pedido.NumeroPedido)).Select(a => a.npersonal).FirstOrDefault();
                pedido.CodigoCliente = Context.PEDIDOes.Where(p => p.Pedido1.Equals(pedido.NumeroPedido)).Select(a => a.Cliente).FirstOrDefault();
                pedido.NombreCliente = Context.CLIENTEs.Where(p => p.Cliente1.Equals(pedido.CodigoCliente)).Select(a => a.Alias.Trim()).FirstOrDefault();
                pedido.DocumentoCliente = proceso.ConsultarCadena("Documento", "Vva_Cliente", "Codigo = '" + pedido.CodigoCliente + "'");
                pedido.DireccionCliente = Context.PEDIDOes.Where(p => p.Pedido1.Equals(pedido.NumeroPedido)).Select(a => a.direccion).FirstOrDefault();
                pedido.ZonaCliente = proceso.ConsultarCadena("descripcion", "Zona", "Zona = (select zona from Vva_Cliente where Codigo = '" + pedido.CodigoCliente + "')");
                pedido.DistritoCliente = proceso.ConsultarCadena("descrip", "Distrito", "iddistrito = (select distllegada from pedido where pedido = '" + pedido.NumeroPedido + "')");
                pedido.ProvinciaCliente = proceso.ConsultarCadena("descrip", "provincia", " idprovincia = (select idprovincia from Distrito where iddistrito = (select idprovincia from pedido where pedido = '" + pedido.NumeroPedido + "'))");
                pedido.Gestion = Context.PEDIDOes.Where(p => p.Pedido1.Equals(pedido.NumeroPedido)).Select(a => a.gestion).FirstOrDefault();
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

        private void ELIMINAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (gridView1.SelectedRowsCount > 0)
            {
                if (proceso.MensageError("¿Continuar?") == DialogResult.Yes)
                {
                    Elementos.frmMsg frmmensage = new Elementos.frmMsg();
                    frmmensage.splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                    frmmensage.dataGridView1.Columns[0].HeaderText = "Pedido";
                    frmmensage.dataGridView1.Columns[1].HeaderText = "Resultado";
                    frmmensage.dataGridView1.Columns[2].HeaderText = string.Empty;
                    frmmensage.dataGridView1.Columns[3].HeaderText = string.Empty;
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
                    Refrescar();
                }
            }
        }

        private void FILTRO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var Context = new LiderEntities())
            {
                proceso.actualizar("pedido", "FECHA = REPLACE(CONVERT(VARCHAR(10),Fecha,120),'-','')", "procesado = 0 and statusweb is null");
                actualizavalores(inicio.ToString("yyyyMMdd"));
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
                k.DataSource = Context.Database.SqlQuery<string>(Libreria.Constante.Mapa_View + "'vva_pedido'").ToList();
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

        private void DESCARGAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                if (proceso.MensagePregunta("¿Continuar?") == DialogResult.Yes)
                {
                    Elementos.frmMsg frmmensage = new Elementos.frmMsg();
                    frmmensage.splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                    frmmensage.dataGridView1.Columns[0].HeaderText = "Pedido";
                    frmmensage.dataGridView1.Columns[1].HeaderText = "Resultado";
                    frmmensage.dataGridView1.Columns[2].HeaderText = string.Empty;
                    frmmensage.dataGridView1.Columns[3].HeaderText = string.Empty;
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
                    Refrescar();
                }
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var facturar = new Elementos.frmFacturacionPedido();
            facturar.pasar += new Elementos.frmFacturacionPedido.Variables(Campos);
            facturar.StartPosition = FormStartPosition.CenterParent;
            facturar.Show();
            Refrescar();
        }

        private void APROBAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var proceso = new Libreria.Proceso();
            var frmmensage = new Elementos.frmMsg();
            frmmensage.dataGridView1.Columns[0].HeaderText = "Pedido";
            frmmensage.dataGridView1.Columns[1].HeaderText = "Mensage";
            frmmensage.dataGridView1.Columns[2].HeaderText = string.Empty;
            frmmensage.dataGridView1.Columns[3].HeaderText = string.Empty;
            if (gridView1.SelectedRowsCount > 0)
            {
                if (proceso.MensagePregunta("¿Continuar?") == DialogResult.Yes)
                {
                    using (var Context = new LiderEntities())
                    {
                        foreach (var fila in gridView1.GetSelectedRows())
                        {
                            string numPedido = Convert.ToString(gridView1.GetRowCellValue(fila, "num Pedido"));
                            bool Estado = Context.PEDIDOes.Where(x => x.Pedido1 == numPedido).Select(p => p.Procesado).FirstOrDefault();
                            var Aprob = Context.PEDIDOes.Where(x => x.Pedido1 == numPedido).Select(p => p.Aprobado).FirstOrDefault();
                            if (!Estado)
                            {
                                if (!(Aprob is DBNull ? false : (bool)Aprob))
                                {
                                    var pedido = (from p in Context.PEDIDOes where p.Pedido1 == numPedido select p).FirstOrDefault();
                                    pedido.Aprobado = true;
                                    frmmensage.dataGridView1.Rows.Add(numPedido, "Aprobado Exitosamente.");
                                }
                                else
                                {
                                    frmmensage.dataGridView1.Rows.Add(numPedido, "Pedido ya se encuentra aprobado.");
                                }
                            }
                            else
                            {
                                frmmensage.dataGridView1.Rows.Add(numPedido, "Pedido se encuentra facturado y ya no es modificable.");
                            }
                        }
                        Context.SaveChanges();
                        frmmensage.Show();
                        Refrescar();
                    }
                }
            }
        }

        private void DESAPROBAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var proceso = new Libreria.Proceso();
            int Contador = 0;
            var frmmensage = new Elementos.frmMsg();
            frmmensage.dataGridView1.Columns[0].HeaderText = "Pedido";
            frmmensage.dataGridView1.Columns[1].HeaderText = "Mensage";
            frmmensage.dataGridView1.Columns[2].HeaderText = string.Empty;
            frmmensage.dataGridView1.Columns[3].HeaderText = string.Empty;
            if (gridView1.SelectedRowsCount > 0)
            {
                if (proceso.MensagePregunta("¿Continuar?") == DialogResult.Yes)
                {
                    using (var Context = new LiderEntities())
                    {
                        foreach (var fila in gridView1.GetSelectedRows())
                        {
                            string numPedido = Convert.ToString(gridView1.GetRowCellValue(fila, "num Pedido"));
                            bool Estado = Context.PEDIDOes.Where(x => x.Pedido1 == numPedido).Select(p => p.Procesado).FirstOrDefault();
                            var Aprob = Context.PEDIDOes.Where(x => x.Pedido1 == numPedido).Select(p => p.Aprobado).FirstOrDefault();
                            if (!Estado)
                            {
                                if (Aprob is DBNull ? false : (bool)Aprob)
                                {
                                    var pedido = (from p in Context.PEDIDOes where p.Pedido1 == numPedido select p).FirstOrDefault();
                                    pedido.Aprobado = false;
                                    frmmensage.dataGridView1.Rows.Add(numPedido, "Desaprobado Exitosamente.");
                                }
                                else
                                {
                                    Contador += 1;
                                    frmmensage.dataGridView1.Rows.Add(numPedido, "Pedido ya se encuentra desaprobado.");
                                }
                            }
                            else
                            {
                                Contador += 1;
                                frmmensage.dataGridView1.Rows.Add(numPedido, "Pedido se encuentra facturado, ya no es modificable.");
                            }
                        }
                        Context.SaveChanges();
                        frmmensage.Show();
                        Refrescar();
                    }
                }
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                if (gridView1.SelectedRowsCount > 0)
                {
                    var Context = new LiderEntities();
                    Elementos.frmpedido frmpedido = new Elementos.frmpedido();
                    frmpedido.Existe = true;
                    frmpedido.pasar += new Elementos.frmpedido.varaible(CamposPedido);
                    pedido.NumeroPedido = gridView1.GetFocusedRowCellValue("num Pedido").ToString();
                    pedido.CodigoVendedor = Context.PEDIDOes.Where(p => p.Pedido1.Equals(pedido.NumeroPedido)).Select(a => a.Personal).FirstOrDefault();
                    pedido.NombreVendedor = Context.PEDIDOes.Where(p => p.Pedido1.Equals(pedido.NumeroPedido)).Select(a => a.npersonal).FirstOrDefault();
                    pedido.CodigoCliente = Context.PEDIDOes.Where(p => p.Pedido1.Equals(pedido.NumeroPedido)).Select(a => a.Cliente).FirstOrDefault();
                    pedido.NombreCliente = Context.CLIENTEs.Where(p => p.Cliente1.Equals(pedido.CodigoCliente)).Select(a => a.Alias.Trim()).FirstOrDefault();
                    pedido.DocumentoCliente = proceso.ConsultarCadena("Documento", "Vva_Cliente", "Codigo = '" + pedido.CodigoCliente + "'");
                    pedido.DireccionCliente = Context.PEDIDOes.Where(p => p.Pedido1.Equals(pedido.NumeroPedido)).Select(a => a.direccion).FirstOrDefault();
                    pedido.ZonaCliente = proceso.ConsultarCadena("descripcion", "Zona", "Zona = (select zona from Vva_Cliente where Codigo = '" + pedido.CodigoCliente + "')");
                    pedido.DistritoCliente = proceso.ConsultarCadena("descrip", "Distrito", "iddistrito = (select distllegada from pedido where pedido = '" + pedido.NumeroPedido + "')");
                    pedido.ProvinciaCliente = proceso.ConsultarCadena("descrip", "provincia", " idprovincia = (select idprovincia from Distrito where iddistrito = (select idprovincia from pedido where pedido = '" + pedido.NumeroPedido + "'))");
                    pedido.Gestion = Context.PEDIDOes.Where(p => p.Pedido1.Equals(pedido.NumeroPedido)).Select(a => a.gestion).FirstOrDefault();
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
        }

        private void frmPedido_Load(object sender, EventArgs e)
        {
            Refrescar();
        }
    }
}