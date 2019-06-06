using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
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
        public string Tabla;
        public string NModulo;
        Libreria.Entidad entidad = new Libreria.Entidad();
        Libreria.Ejecutar ejecutar = new Libreria.Ejecutar();
        private DateTime ahora;
        private DateTime inicio;
        List<string> _Lista;

        public frmPedido()
        {
            InitializeComponent();
            entidad.fechainicio = Convert.ToDateTime(DateTime.Today).ToString("yyyyMMdd");
            ahora = DateTime.Now;
            inicio = new DateTime(ahora.Year, ahora.Month, 1);
            entidad.fechafin = Convert.ToDateTime(DateTime.Today.AddDays(1)).ToString("yyyyMMdd");
        }

        void Refrescar()
        {
            using (var CTX = new LiderEntities())
            {
                var FiltroDetalle = CTX.Filtroes.Where(w => w.tabla == Tabla).OrderBy(o => o.Orden).ToList();
                _Lista = new List<string>();
                _Lista.Clear();
                foreach (var X in FiltroDetalle)
                {
                    string Campo = X.campo;
                    string Condicion = X.condicion;
                    string Valor = X.valor;
                    string Operador = X.union;
                    _Lista.Add(Tabla + "." + "[" + Campo + "]" + Condicion + "'" + Valor + "'" + Operador);
                }
                string cadena = string.Join(" ", _Lista.ToArray());
                Condicion(cadena);
            }
        }

        void CamposPedido_(string CdPedido, string TpDoc, string CdVendedor, string CdCliente, string CdFP, DateTime Fecha, string NmCliente, string Ruc, string Direccion, string Dni, string NmVendedor,
            string Gestion, string IdDistrito, DataGridView dgv)
        {
            using (LiderEntities CTX = new LiderEntities())
            {
                var Rutina = new Libreria.Rutina();
                var i = CTX.PEDIDOes.Where(x => x.Personal == CdVendedor && x.Fecha == Fecha);
                string _Correlativo = CdVendedor + Fecha.Year.ToString().Substring(2, 2) + Fecha.Month + Convert.ToInt32(Fecha.Day) + (i.Count() + 1).ToString("D2");
                PEDIDO Cp = new PEDIDO();
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
                CTX.Configuration.ValidateOnSaveEnabled = false;
                CTX.PEDIDOes.Add(Cp);
                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    DETPEDIDO ItemCp = new DETPEDIDO();
                    ItemCp.Pedido = _Correlativo;
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
                    CTX.DETPEDIDOes.Add(ItemCp);
                }
                CTX.SaveChanges();
                Rutina.ejecutar("sp_stock_sistema '" + DateTime.Now.Date.ToString("yyyyMMdd") + "', 2");
                Rutina.ejecutar("sp_stock_sistema_web '" + DateTime.Now.Date.ToString("yyyyMMdd") + "', 2");
                Refrescar();
            }
        }

        void CamposPedido(string CdPedido, string TpDoc, string CdVendedor, string CdCliente, string CdFP, DateTime Fecha, string NmCliente, string Ruc, string Direccion, string Dni, string NmVendedor,
            string Gestion, string IdDistrito, DataGridView dgv)
        {
            using (LiderEntities CTX = new LiderEntities())
            {
                var Rutina = new Libreria.Rutina();
                PEDIDO Cp = new PEDIDO { Pedido1 = CdPedido };
                CTX.PEDIDOes.Attach(Cp);
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
                CTX.Configuration.ValidateOnSaveEnabled = false;
                CTX.DETPEDIDOes.RemoveRange(CTX.DETPEDIDOes.Where(a => a.Pedido == CdPedido));
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
                    CTX.DETPEDIDOes.Add(ItemCp);
                }
                CTX.SaveChanges();
                Rutina.ejecutar("sp_stock_sistema_nuevo '" + DateTime.Now.Date.ToString("yyyyMMdd") + "', 2");
                Rutina.ejecutar("sp_stock_sistema_web '" + DateTime.Now.Date.ToString("yyyyMMdd") + "', 2");
                Refrescar();
            }
        }

        void Condicion(string cadena)
        {
            using (var CTX = new LiderEntities())
            {
                var Rutina = new Libreria.Rutina();
                string Query = Convert.ToString(CTX.VistaAdministrativas.Where(x => x.IDModulo == (CTX.Moduloes.Where(a => a.Nombre == NModulo).Select(b => b.PKID)).FirstOrDefault()).Select(a => a.Vista.Trim()).FirstOrDefault());
                if (cadena.Length == 0)
                {
                    gridControl1.DataSource = null;
                    gridView1.Columns.Clear();
                    Rutina.consultar(Query, Tabla);
                    gridControl1.DataSource = Rutina.ds.Tables[Tabla];
                    gridView1.BestFitColumns();
                }
                else
                {
                    try
                    {
                        gridControl1.DataSource = null;
                        gridView1.Columns.Clear();
                        Rutina.consultar(Query + " having " + cadena, Tabla);
                        gridControl1.DataSource = Rutina.ds.Tables[Tabla];
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

        void Campos(string Fecha, int Serie)
        {
            var Rutina = new Libreria.Rutina();
            int Contador = 0;
            if (gridView1.SelectedRowsCount > 0)
            {
                List<string> Lista = new List<string>();
                var frmmensage = new Elementos.frmMsg();
                frmmensage.dataGridView1.Columns[0].HeaderText = "Pedido";
                frmmensage.dataGridView1.Columns[1].HeaderText = "Mensage";
                frmmensage.dataGridView1.Columns[2].HeaderText = string.Empty;
                frmmensage.dataGridView1.Columns[3].HeaderText = string.Empty;
                using (var CTX = new LiderEntities())
                {
                    foreach (var fila in gridView1.GetSelectedRows())
                    {
                        string Pedido_ = Convert.ToString(gridView1.GetRowCellValue(fila, "num Pedido"));
                        string Tipo = CTX.PEDIDOes.Where(x => x.Pedido1 == Pedido_).Select(p => p.tipodoc).FirstOrDefault();
                        int Persona = Convert.ToInt32(CTX.PEDIDOes.Where(x => x.Pedido1 == Pedido_).Select(p => p.TipoPersona).FirstOrDefault());
                        var Estado = CTX.PEDIDOes.Where(x => x.Pedido1 == Pedido_).Select(p => p.Procesado).FirstOrDefault();
                        var Aprobado = CTX.PEDIDOes.Where(x => x.Pedido1 == Pedido_).Select(p => p.Aprobado).FirstOrDefault();
                        if (!Estado)
                        {
                            Contador += 1;
                            if (Aprobado is DBNull ? false : (bool)Aprobado)
                            {
                                Contador += 1;
                                Lista.Add(Pedido_);
                                CTX.sp_genera_documento(Pedido_, Persona, Tipo);
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
                        var Documentos = (from doc in CTX.DOCUMENTOes
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
                                        Numero = Convert.ToInt32((from p in CTX.DOCTIPOes.AsEnumerable() where p.PKID == Serie select p.Numero).FirstOrDefault());
                                        serie = Convert.ToString((from p in CTX.DOCTIPOes.AsEnumerable() where p.PKID == Serie select p.Serie).FirstOrDefault());
                                        NumeroComprobante = serie + Numero.ToString("D8");
                                        var Cp = (from p in CTX.DOCUMENTOes where p.Documento1 == fila.Documento && p.TipoDoc == fila.Tipo select p).FirstOrDefault();
                                        Cp.Generado = NumeroComprobante;
                                        var Pd = (from p in CTX.PEDIDOes
                                                  where p.Pedido1 == CTX.DOCUMENTOes.Where(y => y.Documento1 == fila.Documento && y.TipoDoc == fila.Tipo).Select(x => x.Pedido.Trim()).FirstOrDefault()
                                                  select p).FirstOrDefault();
                                        Pd.Procesado = true;
                                        Pd.statusWeb = true;
                                        var DTp = (from p in CTX.DOCTIPOes where p.PKID == Serie select p).FirstOrDefault();
                                        DTp.Numero = DTp.Numero + 1;
                                        break;
                                    case "F":
                                        Numero = Convert.ToInt32((from p in CTX.DOCTIPOes.AsEnumerable() where p.PKID == Serie select p.Numero).FirstOrDefault());
                                        serie = Convert.ToString((from p in CTX.DOCTIPOes.AsEnumerable() where p.PKID == Serie select p.Serie).FirstOrDefault());
                                        NumeroComprobante = serie + Numero.ToString("D8");
                                        var Cp_ = (from p in CTX.DOCUMENTOes where p.Documento1 == fila.Documento && p.TipoDoc == fila.Tipo select p).FirstOrDefault();
                                        Cp_.Generado = NumeroComprobante;
                                        var Pd_ = (from p in CTX.PEDIDOes
                                                   where p.Pedido1 == CTX.DOCUMENTOes.Where(y => y.Documento1 == fila.Documento && y.TipoDoc == fila.Tipo).Select(x => x.Pedido.Trim()).FirstOrDefault()
                                                   select p).FirstOrDefault();
                                        Pd_.Procesado = true;
                                        Pd_.statusWeb = true;
                                        var DTp_ = (from p in CTX.DOCTIPOes where p.PKID == Serie select p).FirstOrDefault();
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
                        CTX.SaveChanges();
                        Rutina.ejecutar("sp_stock_sistema_nuevo '" + DateTime.Now.Date.ToString("yyyyMMdd") + "', 2");
                        Rutina.ejecutar("sp_stock_sistema_web '" + DateTime.Now.Date.ToString("yyyyMMdd") + "', 2");
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
            var Rutina = new Libreria.Rutina();
            Rutina.ejecutar("sp_stock_sistema_nuevo '" + DateTime.Now.Date.ToString("yyyyMMdd") + "', 2");
            Rutina.ejecutar("sp_stock_sistema_web '" + DateTime.Now.Date.ToString("yyyyMMdd") + "', 2");
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
            Modificar();
        }

        private void Modificar()
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                string Comodin = "'C','K'";
                string PedidoNumero = Convert.ToString(gridView1.GetFocusedRowCellValue("num Pedido"));
                var Rutina = new Libreria.Rutina();
                var CTX = new LiderEntities();
                var Pe = CTX.PEDIDOes.Where(p => p.Pedido1.Equals(PedidoNumero));
                var DPe = CTX.DETPEDIDOes.Where(p => p.Pedido == PedidoNumero).ToList();
                var Cl = CTX.CLIENTEs.Where(p => p.Cliente1 == (Pe.Select(s => s.Cliente).FirstOrDefault()));
                var Zn = CTX.ZONAs.Where(p => p.Zona1 == Cl.Select(s => s.Cliente1).FirstOrDefault());
                var Dt = CTX.Distritoes.Where(p => p.iddistrito == Pe.Select(s => s.distllegada).FirstOrDefault());
                var Pv = CTX.provincias.Where(p => p.idprovincia == Dt.Select(s => s.idprovincia).FirstOrDefault());
                var Fp = CTX.FORMAPAGOes.Where(p => p.FormaPago1 == Pe.Select(s => s.FormaPago).FirstOrDefault());
                var Formulario = new Elementos.frmpedido();
                Formulario.Existe = true;
                Formulario.pasar += new Elementos.frmpedido.varaible(CamposPedido);
                string CodigoVendedor = Pe.Select(a => a.Personal).FirstOrDefault();
                string NombreVendedor = Pe.Select(a => a.npersonal).FirstOrDefault();
                string CodigoCliente = Pe.Select(a => a.Cliente).FirstOrDefault();
                string NombreCliente = Cl.Select(a => a.Alias.Trim()).FirstOrDefault();
                string DocumentoCliente = Pe.Select(a => a.ruc.Trim()).FirstOrDefault().Length > 0 ? Pe.Select(a => a.ruc.Trim()).FirstOrDefault() : Pe.Select(a => a.dni.Trim()).FirstOrDefault();
                string DireccionCliente = Pe.Select(a => a.direccion).FirstOrDefault();
                string ZonaCliente = Zn.Select(a => a.Descripcion).FirstOrDefault();
                string DistritoCliente = Dt.Select(a => a.descrip).FirstOrDefault();
                string ProvinciaCliente = Pv.Select(a => a.descrip).FirstOrDefault();
                string Gestion = Pe.Select(a => a.gestion).FirstOrDefault();
                bool Credito = Comodin.Contains(Pe.Select(a => a.FormaPago).FirstOrDefault()) ? false : true;
                string FormaPago = Pe.Select(a => a.FormaPago).FirstOrDefault();
                string FechaEmision = Convert.ToDateTime(Pe.Select(a => a.Fecha).FirstOrDefault()).ToString("dd/MM/yyyy");
                try
                {
                    Formulario.txtcdDocumento.Text = PedidoNumero;
                    Formulario.txtcdVendedor.Text = CodigoVendedor;
                    Formulario.txtnmVendedor.Text = NombreVendedor;
                    Formulario.txtcdCLiente.Text = CodigoCliente;
                    Formulario.txtnmCliente.Text = NombreCliente;
                    Formulario.txtdocCliente.Text = DocumentoCliente;
                    Formulario.txtnmDireccion.EditValue = DireccionCliente;
                    Formulario.txtnmZona.EditValue = ZonaCliente;
                    Formulario.txtcdZona.EditValue = Cl.Select(a => a.Zona).FirstOrDefault();
                    Formulario.txtnmDistrito.EditValue = DistritoCliente;
                    Formulario.txtcdDistrito.EditValue = Dt.Select(a => a.iddistrito).FirstOrDefault();
                    Formulario.txtnmProvincia.EditValue = ProvinciaCliente;
                    Formulario.txtcdProvincia.EditValue = Pv.Select(a => a.idprovincia);
                    Formulario.txtcdGestion.Text = Gestion;
                    Formulario.dateEmision.EditValue = FechaEmision;
                    Formulario.dateEntrega.EditValue = Convert.ToDateTime(FechaEmision).AddDays(1).ToString("dd/MM/yyyy");
                    Formulario.btnCredito.Checked = Credito == true ? true : false;
                    Formulario.txtformaPago.Text = Fp.Select(a => a.Descripcion).FirstOrDefault();
                    Formulario.CodigoFP.Text = FormaPago;
                    foreach (var X in DPe)
                    {
                        string Codigo = X.Producto;
                        string Descripcion = CTX.PRODUCTOes.Where(a => a.Producto1 == X.Producto).Select(s => s.Descripcion).FirstOrDefault();
                        decimal Cantidad = Convert.ToDecimal(X.Cantidad);
                        string Unidad = CTX.PRODUCTOes.Where(a => a.Producto1 == X.Producto).Select(s => s.UniMed).FirstOrDefault();
                        decimal PrecioUnitario = Convert.ToDecimal(X.PrecioUnitario);
                        decimal PrecioNeto = Convert.ToDecimal(X.PrecioNeto);
                        decimal Descuento = Convert.ToDecimal(X.Descuento);
                        decimal Recargo = Convert.ToDecimal(X.Recargo);
                        bool Bonificacion = Convert.ToBoolean(X.Bonif);
                        bool Afecto = Convert.ToBoolean(X.Afecto);
                        var IdBonif = X.IDBonificacion is DBNull ? 0 : X.IDBonificacion;
                        decimal TipoPrecio = Convert.ToInt32(X.TipoPrecio);

                        Formulario.dataGridView1.Rows.Add(Codigo, Descripcion, Cantidad, Cantidad, Unidad, TipoPrecio, PrecioUnitario, PrecioNeto,
                            (Cantidad * PrecioNeto), Descuento, Recargo, Bonificacion, Credito, Afecto, IdBonif);
                        Formulario.dataGridView1.CurrentRow.ReadOnly = Bonificacion == true ? true : false;
                        Formulario.dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                        Formulario.dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                        Formulario.dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = false;
                        Formulario.dataGridView1.CurrentRow.Cells["PrecioNeto"].ReadOnly = false;
                    }
                    Formulario.calculartotal();
                    Formulario.StartPosition = FormStartPosition.CenterScreen;
                    Formulario.Existe = false;
                    Formulario.Show();
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                }
            }
        }

        private void ELIMINAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Rutina = new Libreria.Rutina();
            if (gridView1.SelectedRowsCount > 0)
            {
                if (Rutina.MensageError("¿Continuar?") == DialogResult.Yes)
                {
                    Elementos.frmMsg frmmensage = new Elementos.frmMsg();
                    frmmensage.Scm03.SplashFormStartPosition = SplashFormStartPosition.Default;
                    frmmensage.dataGridView1.Columns[0].HeaderText = "Pedido";
                    frmmensage.dataGridView1.Columns[1].HeaderText = "Resultado";
                    frmmensage.dataGridView1.Columns[2].HeaderText = string.Empty;
                    frmmensage.dataGridView1.Columns[3].HeaderText = string.Empty;
                    frmmensage.Show();
                    frmmensage.Scm03.ShowWaitForm();
                    foreach (var pedido in gridView1.GetSelectedRows())
                    {
                        if (!Rutina.ExistenciaCampo("pedido", "pedido", "procesado = 1 and pedido = '" + gridView1.GetDataRow(pedido)["num Pedido"].ToString() + "'"))
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
                    frmmensage.Scm03.CloseWaitForm();
                    Refrescar();
                }
            }
        }

        private void FILTRO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var CTX = new LiderEntities())
            {
                var Rutina = new Libreria.Rutina();
                Rutina.actualizar("pedido", "FECHA = REPLACE(CONVERT(VARCHAR(10),Fecha,120),'-','')", "procesado = 0 and statusweb is null");
                Rutina.ejecutar(Libreria.Constante.PedidoRecalculo);
                Filtros.frmFiltros filtro = new Filtros.frmFiltros();
                DataGridViewComboBoxColumn i = filtro.dataGridView1.Columns["Index1"] as DataGridViewComboBoxColumn;
                i.DataSource = CTX.FiltroConfiguracions.Where(a => a.Tipo == "CONDICION").ToArray();
                i.DisplayMember = "Descripcion";
                i.ValueMember = "Codigo";
                DataGridViewComboBoxColumn j = filtro.dataGridView1.Columns["Index3"] as DataGridViewComboBoxColumn;
                j.DataSource = CTX.FiltroConfiguracions.Where(a => a.Tipo == "OPERADOR").ToList();
                j.DisplayMember = "Descripcion";
                j.ValueMember = "Codigo";
                DataGridViewComboBoxColumn k = filtro.dataGridView1.Columns["Index0"] as DataGridViewComboBoxColumn;
                k.DataSource = CTX.Database.SqlQuery<string>(Libreria.Constante.Mapa_View + "'vva_pedido'").ToList();
                filtro.pasar += new Filtros.frmFiltros.variables(Condicion);
                filtro.StartPosition = FormStartPosition.CenterScreen;
                foreach (var fila in CTX.Filtroes.Where(w => w.tabla.Equals(Tabla)).OrderBy(x => x.Orden).ToList())
                {
                    filtro.dataGridView1.Rows.Add(fila.campo, fila.condicion, fila.valor, fila.union);
                }
                filtro.entidad = Tabla;
                filtro.ShowDialog();
            }
        }

        private void DESCARGAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                var Rutina = new Libreria.Rutina();
                if (Rutina.MensagePregunta("¿Continuar?") == DialogResult.Yes)
                {
                    Elementos.frmMsg frmmensage = new Elementos.frmMsg();
                    frmmensage.Scm03.SplashFormStartPosition = SplashFormStartPosition.Default;
                    frmmensage.dataGridView1.Columns[0].HeaderText = "Pedido";
                    frmmensage.dataGridView1.Columns[1].HeaderText = "Resultado";
                    frmmensage.dataGridView1.Columns[2].HeaderText = string.Empty;
                    frmmensage.dataGridView1.Columns[3].HeaderText = string.Empty;
                    frmmensage.Show();
                    frmmensage.Scm03.ShowWaitForm();
                    foreach (var pedido in gridView1.GetSelectedRows())
                    {
                        entidad.pedido = gridView1.GetDataRow(pedido)["num Pedido"].ToString();
                        string tipopersona = Rutina.ConsultarCadena("TipoPersona", "pedido", "pedido = '" + entidad.pedido + "'");
                        entidad.tipodocumento = Rutina.ConsultarCadena("TipoDoc", "pedido", "pedido = '" + entidad.pedido + "'");
                        if (!Rutina.ExistenciaCampo("pedido", "pedido", "procesado = 1 and pedido = '" + entidad.pedido + "'"))
                        {
                            if (Rutina.ExistenciaCampo("pedido", "pedido", "statusweb is null and pedido = '" + entidad.pedido + "'"))
                            {
                                frmmensage.dataGridView1.Rows.Add(gridView1.GetDataRow(pedido)["num Pedido"].ToString(),
                                    "Documento Saliente Número : " + entidad.tipodocumento + Rutina.Procedimiento("sp_genera_documento '" + entidad.pedido + "','" + tipopersona + "','" + entidad.tipodocumento + "'"),
                                    string.Empty, string.Empty);
                                Rutina.actualizar("pedido", "StatusWeb = 1", "pedido = '" + entidad.pedido + "'");
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
                    frmmensage.Scm03.CloseWaitForm();
                    Refrescar();
                }
            }
        }

        private void APROBAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var proceso = new Libreria.Rutina();
            var frmmensage = new Elementos.frmMsg();
            frmmensage.dataGridView1.Columns[0].HeaderText = "Pedido";
            frmmensage.dataGridView1.Columns[1].HeaderText = "Mensage";
            frmmensage.dataGridView1.Columns[2].HeaderText = string.Empty;
            frmmensage.dataGridView1.Columns[3].HeaderText = string.Empty;
            if (gridView1.SelectedRowsCount > 0)
            {
                if (proceso.MensagePregunta("¿Continuar?") == DialogResult.Yes)
                {
                    using (var CTX = new LiderEntities())
                    {
                        foreach (var fila in gridView1.GetSelectedRows())
                        {
                            string numPedido = Convert.ToString(gridView1.GetRowCellValue(fila, "num Pedido"));
                            bool Estado = CTX.PEDIDOes.Where(x => x.Pedido1 == numPedido).Select(p => p.Procesado).FirstOrDefault();
                            var Aprob = CTX.PEDIDOes.Where(x => x.Pedido1 == numPedido).Select(p => p.Aprobado).FirstOrDefault();
                            if (!Estado)
                            {
                                if (!(Aprob is DBNull ? false : (bool)Aprob))
                                {
                                    var pedido = (from p in CTX.PEDIDOes where p.Pedido1 == numPedido select p).FirstOrDefault();
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
                        CTX.SaveChanges();
                        frmmensage.Show();
                        Refrescar();
                    }
                }
            }
        }

        private void DESAPROBAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var proceso = new Libreria.Rutina();
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
                    using (var CTX = new LiderEntities())
                    {
                        foreach (var fila in gridView1.GetSelectedRows())
                        {
                            string numPedido = Convert.ToString(gridView1.GetRowCellValue(fila, "num Pedido"));
                            bool Estado = CTX.PEDIDOes.Where(x => x.Pedido1 == numPedido).Select(p => p.Procesado).FirstOrDefault();
                            var Aprob = CTX.PEDIDOes.Where(x => x.Pedido1 == numPedido).Select(p => p.Aprobado).FirstOrDefault();
                            if (!Estado)
                            {
                                if (Aprob is DBNull ? false : (bool)Aprob)
                                {
                                    var pedido = (from p in CTX.PEDIDOes where p.Pedido1 == numPedido select p).FirstOrDefault();
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
                        CTX.SaveChanges();
                        frmmensage.Show();
                        Refrescar();
                    }
                }
            }
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
                Modificar();
        }

        private void frmPedido_Load(object sender, EventArgs e) => Refrescar();

        private void COPIAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                string Comodin = "'C','K'";
                string PedidoNumero = Convert.ToString(gridView1.GetFocusedRowCellValue("num Pedido"));
                var Rutina = new Libreria.Rutina();
                var CTX = new LiderEntities();
                var Pe = CTX.PEDIDOes.Where(p => p.Pedido1.Equals(PedidoNumero));
                var DPe = CTX.DETPEDIDOes.Where(p => p.Pedido == PedidoNumero);
                var Cl = CTX.CLIENTEs.Where(p => p.Cliente1 == (Pe.Select(s => s.Cliente).FirstOrDefault()));
                var Zn = CTX.ZONAs.Where(p => p.Zona1 == Cl.Select(s => s.Cliente1).FirstOrDefault());
                var Dt = CTX.Distritoes.Where(p => p.iddistrito == Pe.Select(s => s.distllegada).FirstOrDefault());
                var Pv = CTX.provincias.Where(p => p.idprovincia == Dt.Select(s => s.idprovincia).FirstOrDefault());
                var Fp = CTX.FORMAPAGOes.Where(p => p.FormaPago1 == Pe.Select(s => s.FormaPago).FirstOrDefault());
                var Formulario = new Elementos.frmpedido();
                Formulario.Existe = true;
                Formulario.pasar += new Elementos.frmpedido.varaible(CamposPedido_);
                string CodigoVendedor = Pe.Select(a => a.Personal).FirstOrDefault();
                string NombreVendedor = Pe.Select(a => a.npersonal).FirstOrDefault();
                string CodigoCliente = Pe.Select(a => a.Cliente).FirstOrDefault();
                string NombreCliente = Cl.Select(a => a.Alias.Trim()).FirstOrDefault();
                string DocumentoCliente = Pe.Select(a => a.ruc).FirstOrDefault().Length > 0 ? Pe.Select(a => a.ruc).FirstOrDefault() : Pe.Select(a => a.dni).FirstOrDefault();
                string DireccionCliente = Pe.Select(a => a.direccion).FirstOrDefault();
                string ZonaCliente = Zn.Select(a => a.Descripcion).FirstOrDefault();
                string DistritoCliente = Dt.Select(a => a.descrip).FirstOrDefault();
                string ProvinciaCliente = Pv.Select(a => a.descrip).FirstOrDefault();
                string Gestion = Pe.Select(a => a.gestion).FirstOrDefault();
                bool Credito = Comodin.Contains(Pe.Select(a => a.FormaPago).FirstOrDefault()) ? false : true;
                string FormaPago = Pe.Select(a => a.FormaPago).FirstOrDefault();
                string FechaEmision = Convert.ToDateTime(Pe.Select(a => a.Fecha).FirstOrDefault()).ToString("dd/MM/yyyy");
                try
                {
                    Formulario.txtcdDocumento.Text = PedidoNumero;
                    Formulario.txtcdVendedor.Text = CodigoVendedor;
                    Formulario.txtnmVendedor.Text = NombreVendedor;
                    Formulario.txtcdCLiente.Text = CodigoCliente;
                    Formulario.txtnmCliente.Text = NombreCliente;
                    Formulario.txtdocCliente.Text = DocumentoCliente;
                    Formulario.txtnmDireccion.EditValue = DireccionCliente;
                    Formulario.txtnmZona.EditValue = ZonaCliente;
                    Formulario.txtcdZona.EditValue = Cl.Select(a => a.Zona).FirstOrDefault();
                    Formulario.txtnmDistrito.EditValue = DistritoCliente;
                    Formulario.txtcdDistrito.EditValue = Dt.Select(a => a.iddistrito).FirstOrDefault();
                    Formulario.txtnmProvincia.EditValue = ProvinciaCliente;
                    Formulario.txtcdProvincia.EditValue = Pv.Select(a => a.idprovincia);
                    Formulario.txtcdGestion.Text = Gestion;
                    Formulario.dateEmision.EditValue = FechaEmision;
                    Formulario.dateEntrega.EditValue = Convert.ToDateTime(FechaEmision).AddDays(1).ToString("dd/MM/yyyy");
                    Formulario.btnCredito.Checked = Credito == true ? true : false;
                    Formulario.txtformaPago.Text = Fp.Select(a => a.Descripcion).FirstOrDefault();
                    Formulario.CodigoFP.Text = FormaPago;
                    foreach (var X in DPe)
                    {
                        string Codigo = X.Producto;
                        string Descripcion = CTX.PRODUCTOes.Where(a => a.Producto1 == X.Producto).Select(s => s.Descripcion).FirstOrDefault();
                        decimal Cantidad = Convert.ToDecimal(X.Cantidad);
                        string Unidad = CTX.PRODUCTOes.Where(a => a.Producto1 == X.Producto).Select(s => s.UniMed).FirstOrDefault();
                        decimal PrecioUnitario = Convert.ToDecimal(X.PrecioUnitario);
                        decimal PrecioNeto = Convert.ToDecimal(X.PrecioNeto);
                        decimal Descuento = Convert.ToDecimal(X.Descuento);
                        decimal Recargo = Convert.ToDecimal(X.Recargo);
                        bool Bonificacion = Convert.ToBoolean(X.Bonif);
                        bool Afecto = Convert.ToBoolean(X.Afecto);
                        var IdBonif = X.IDBonificacion is DBNull ? 0 : X.IDBonificacion;
                        decimal TipoPrecio = Convert.ToInt32(X.TipoPrecio);

                        Formulario.dataGridView1.Rows.Add(Codigo, Descripcion, Cantidad, Cantidad, Unidad, TipoPrecio, PrecioUnitario, PrecioNeto,
                            (Cantidad * PrecioNeto), Descuento, Recargo, Bonificacion, Credito, Afecto, IdBonif);
                        Formulario.dataGridView1.CurrentRow.ReadOnly = Bonificacion == true ? true : false;
                        Formulario.dataGridView1.CurrentRow.Cells["Codigo"].ReadOnly = true;
                        Formulario.dataGridView1.CurrentRow.Cells["Descripcion"].ReadOnly = true;
                        Formulario.dataGridView1.CurrentRow.Cells["Cantidad"].ReadOnly = false;
                        Formulario.dataGridView1.CurrentRow.Cells["PrecioNeto"].ReadOnly = false;
                    }
                    Formulario.calculartotal();
                    Formulario.StartPosition = FormStartPosition.CenterScreen;
                    Formulario.Existe = false;
                    Formulario.Show();
                }
                catch (Exception t)
                {
                    MessageBox.Show(t.Message);
                }
            }
        }

        private void REFRESH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) => Refrescar();

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var proceso = new Libreria.Rutina();
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
                Modificar();
        }

        private void FACTURACIONLOTE_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Formulario = new frmPrincipal();
            Formulario.Scm01.SplashFormStartPosition = SplashFormStartPosition.Default;
            Formulario.Scm01.ShowWaitForm();
            var frmfacturacion = new Modulos.Elementos.frmFacturacion();
            frmfacturacion.StartPosition = FormStartPosition.CenterScreen;
            frmfacturacion.Show();
            Formulario.Scm01.CloseWaitForm();
        }

        private void GridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
                e.Info.DisplayText = e.RowHandle.ToString();
        }

        private void FACTURAR_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var Formulario = new frmPrincipal();
            Formulario.Scm01.SplashFormStartPosition = SplashFormStartPosition.Default;
            Formulario.Scm01.ShowWaitForm();
            var facturar = new Elementos.frmFacturacionPedido();
            facturar.pasar += new Elementos.frmFacturacionPedido.Variables(Campos);
            facturar.StartPosition = FormStartPosition.CenterParent;
            Formulario.Scm01.CloseWaitForm();
            facturar.Show();
            Refrescar();
        }
    }
}