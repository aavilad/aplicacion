using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using xtraForm.Modulos.Reportes.Modulos.Distribucion;
using xtraForm.Properties;

namespace xtraForm
{
    public partial class frmPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Form objeto;
        Libreria.Entidad entidad = new Libreria.Entidad();
        Libreria.Rutina proceso = new Libreria.Rutina();
        public frmPrincipal()
        {
            InitializeComponent();
            entidad.fechainicio = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMdd");
            entidad.fechafin = Convert.ToDateTime(DateTime.Now.AddDays(1)).ToString("yyyyMMdd");
        }

        private void btnReglasBonificacion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "Reglas Bonificacion")
                {
                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                splashScreenManager1.ShowWaitForm();
                XtraTabPage promocion = new XtraTabPage();
                objeto = new Modulos.Ventas.frmPromocion
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill,
                    NModulo = e.Item.Name,
                };
                xtraTabControl1.TabPages.Add(promocion);
                xtraTabControl1.SelectedTabPage = promocion;
                promocion.Text = "Reglas Bonificacion";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                promocion.Controls.Add(objeto);
                objeto.Show();
                splashScreenManager1.CloseWaitForm();
            }

        }

        private void xtraTabControl1_HeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.HeaderButtonEventArgs e)
        {
            if (e.Button == TabButtons.Close)
                xtraTabControl1.TabPages.Remove(e.ActivePage as XtraTabPage);
            if (e.Button == TabButtons.Next)
            {

            }
            if (e.Button == TabButtons.Prev)
            {

            }
        }

        private void btnPedido_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "pedidos")
                {
                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                splashScreenManager1.ShowWaitForm();
                XtraTabPage pedidos = new XtraTabPage();
                objeto = new Modulos.Ventas.frmPedido
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill,
                    NModulo = e.Item.Name,
                    Tabla = "vva_pedido"
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "pedidos";
                pedidos.Controls.Add(objeto);
                objeto.Show();
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void btnDescargarPedidos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string query = @"(SELECT CASE WHEN DETPEDIDO.TipoPrecio = 1 THEN PrecMenContado WHEN DETPEDIDO.TipoPrecio = 2 THEN 
                                  PrecMayContado WHEN DETPEDIDO.TipoPrecio = 3 THEN PrecMenCredito WHEN DETPEDIDO.TipoPrecio = 4 THEN 
                                  PrecMayCredito WHEN DETPEDIDO.TipoPrecio = 5 THEN PrecEspecial WHEN DETPEDIDO.TipoPrecio = 6 THEN 
                                  PrecSEspecial WHEN DETPEDIDO.TipoPrecio = 7 THEN PrecSSEspecial END
                              FROM PRODUCTO
                              WHERE Producto = DETPEDIDO.Producto)";
            string query1 = @"(SELECT conigv
                                FROM PRODUCTO
                                WHERE Producto = DETPEDIDO.Producto)";

            Libreria.Rutina proceso = new Libreria.Rutina();
            entidad.i = proceso.ConsultarTabla_("pedido", "fecha >= '" + entidad.fechainicio + "' and fecha < '" + entidad.fechafin + "' and statusweb is null and procesado = 0 ").Rows.Count;
            if (entidad.i > 0)
            {
                if (proceso.MensagePregunta("existen '" + entidad.i.ToString() + "' pedido sin bajar, ¿desea descargarlos?") == DialogResult.Yes)
                {
                    if (proceso.actualizar("pedido", "FECHA = REPLACE(CONVERT(VARCHAR(10),Fecha,120),'-','')", "procesado = 0 and statusweb is null"))
                    {
                        Modulos.Elementos.frmMsg frmmensage = new Modulos.Elementos.frmMsg();
                        Point loc = new Point(510, 450);
                        splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Manual;
                        splashScreenManager1.SplashFormLocation = loc;
                        frmmensage.dataGridView1.Columns[0].HeaderText = "Pedido";
                        frmmensage.dataGridView1.Columns[1].HeaderText = "Documento Generado";
                        frmmensage.dataGridView1.Columns[2].HeaderText = string.Empty;
                        frmmensage.dataGridView1.Columns[3].HeaderText = string.Empty;
                        frmmensage.Show();
                        splashScreenManager1.ShowWaitForm();
                        var Pedidos = proceso.ConsultarTabla_("Pedido", "Fecha = '" + entidad.fechainicio + "' and StatusWeb is null and procesado = 0 and tipodoc is not null ");
                        foreach (DataRow F002 in Pedidos.Rows)
                        {
                            proceso.actualizar("detpedido", "PrecioNeto = PrecUnit", "pedido = '" + F002["Pedido"] + "'");
                            proceso.actualizar("detpedido", "PrecioUnitario = " + query, "pedido = '" + F002["Pedido"] + "'");
                            proceso.actualizar("detpedido", "Descuento = IIF ((PrecioUnitario - PrecioNeto) < 0,0,(PrecioUnitario - PrecioNeto))", "pedido = '" + F002["Pedido"] + "'");
                            proceso.actualizar("detpedido", "Recargo = IIF ((PrecioNeto - PrecioUnitario) < 0,0,(PrecioNeto - PrecioUnitario))", "pedido = '" + F002["Pedido"] + "'");
                            proceso.actualizar("detpedido", "Afecto = " + query1, "pedido = '" + F002["Pedido"] + "'");
                            proceso.actualizar("detpedido", "Bonif = CASE WHEN PrecUnit = 0.00 THEN 1 WHEN IDBonificacion > 0 THEN 1 ELSE 0 END", "pedido = '" + F002["Pedido"] + "'");
                            proceso.actualizar("pedido", "Aprobado = 1", "pedido = '" + F002["Pedido"] + "'");
                            frmmensage.dataGridView1.Rows.Add(F002["Pedido"], F002["TipoDoc"] + "_" + proceso.Procedimiento("sp_genera_documento '" + F002["Pedido"] + "','" + F002["TipoPersona"] + "','" + F002["tipodoc"] + "'"));
                            proceso.actualizar("pedido", "StatusWeb = 1", "pedido = '" + F002["Pedido"] + "'");
                        }
                        splashScreenManager1.CloseWaitForm();
                        frmmensage.txtsalida.Text = " Boletas : " + Pedidos.AsEnumerable().Count(x => x["TipoDoc"].ToString() == "B").ToString() + " | + | Facturas : " +
                            Pedidos.AsEnumerable().Count(x => x["TipoDoc"].ToString() == "F").ToString();
                        MessageBox.Show("Descarga terminada");
                    }
                }
            }
            else
            {
                MessageBox.Show("no existen pedidos sin bajar");
            }
        }

        private void btnPesos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "Pesos SF")
                {
                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Maestro.frmPesos
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "Pesos SF";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
            }
        }

        private void btnComprobantes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "Comprobantes")
                {

                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                splashScreenManager1.ShowWaitForm();
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Elementos.frmComprobantes
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill,
                    NModulo = e.Item.Name,
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "Comprobantes";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void btnNotasCredito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "Notas De Credito")
                {

                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Ventas.frmNotaCredito
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill,
                    Modulo = e.Item.Name,
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "Notas De Credito";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
            }
        }

        private void btnBonificar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
            splashScreenManager1.ShowWaitForm();
            Filtros.frmProcesar frmbonificar = new Filtros.frmProcesar();
            proceso.consultar(@"SELECT Vva_Vendedor.[Codigo vendedor] AS Codigo, 
                                FuerzaVentas.descrip AS FzaVentas, 
                                Vva_Vendedor.[Nombre Vendedor] AS Nombre
                                FROM Vva_Vendedor
                                INNER JOIN FuerzaVentas ON Vva_Vendedor.IDFzaVentas = FuerzaVentas.fzavtas where FuerzaVentas.activo = 1;", "vendedor");
            frmbonificar.gridControl1.DataSource = proceso.ds.Tables["vendedor"];
            frmbonificar.gridView1.OptionsView.ShowGroupPanel = false;
            frmbonificar.gridView1.Columns["FzaVentas"].GroupIndex = 1;
            frmbonificar.gridView1.GroupRowHeight = 1;
            frmbonificar.gridView1.OptionsSelection.MultiSelect = true;
            frmbonificar.gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            frmbonificar.gridView1.RowHeight = 1;
            frmbonificar.gridView1.Appearance.Row.FontSizeDelta = 0;
            frmbonificar.gridView1.BestFitColumns();
            frmbonificar.StartPosition = FormStartPosition.CenterScreen;
            frmbonificar.Show();
            splashScreenManager1.CloseWaitForm();
        }

        private void ClienteBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "Clientes")
                {

                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Ventas.frmCliente
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill,
                    NModulo = e.Item.Name,
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "Clientes";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
            }
        }

        private void BtnOrderdecompra_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "Order De Compra")
                {

                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Compras.frmCompra
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "Orden De Compra";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
            }
        }

        private void BtnExistencias_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "Existencias")
                {

                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                splashScreenManager1.ShowWaitForm();
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Inventario.frmExistencia
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "Existencias";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void BtnMarca_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "Marcas")
                {

                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                splashScreenManager1.ShowWaitForm();
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Inventario.frmMarca
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "Marcas";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
                splashScreenManager1.ShowWaitForm();
            }
        }

        private void BtnCanjear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
            splashScreenManager1.ShowWaitForm();
            var frmfacturacion = new Modulos.Elementos.frmFacturacion();
            frmfacturacion.StartPosition = FormStartPosition.CenterScreen;
            frmfacturacion.Show();
            splashScreenManager1.CloseWaitForm();
        }

        private void BtnProductoEscala_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "Lista Precios")
                {

                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                splashScreenManager1.ShowWaitForm();
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Ventas.frmListaPrecio
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "Lista Precios";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void BtnValidar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "Validacion de bonificacion")
                {

                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                splashScreenManager1.ShowWaitForm();
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Ventas.frmMaestroDetalle
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "Validacion de bonificacion";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void ListadoPorRuta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
            splashScreenManager1.ShowWaitForm();
            var pedidos = new XtraTabPage();
            entidad.index = 0;
            var rpt = new RptListadoPorRutas();
            var frmrpt = new Modulos.Reportes.Modulos.Distribucion.FrmMostrarReporte();
            frmrpt.TopLevel = false;
            frmrpt.FormBorderStyle = FormBorderStyle.None;
            frmrpt.Dock = DockStyle.Fill;
            frmrpt.documentViewer1.DocumentSource = rpt;
            xtraTabControl1.TabPages.Add(pedidos);
            xtraTabControl1.SelectedTabPage = pedidos;
            pedidos.Text = "Listado General Producto";
            entidad.index = xtraTabControl1.SelectedTabPageIndex;
            pedidos.Controls.Add(frmrpt);
            frmrpt.Show();
            splashScreenManager1.CloseWaitForm();
        }

        private void ListadoProductoClase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
            splashScreenManager1.ShowWaitForm();
            var pedidos = new XtraTabPage();
            entidad.index = 0;
            var rpt = new RptListadoSegunClase();
            var frmrpt = new Modulos.Reportes.Modulos.Distribucion.FrmMostrarReporte();
            frmrpt.TopLevel = false;
            frmrpt.FormBorderStyle = FormBorderStyle.None;
            frmrpt.Dock = DockStyle.Fill;
            frmrpt.documentViewer1.DocumentSource = rpt;
            xtraTabControl1.TabPages.Add(pedidos);
            xtraTabControl1.SelectedTabPage = pedidos;
            pedidos.Text = "Listado Clase Producto";
            entidad.index = xtraTabControl1.SelectedTabPageIndex;
            pedidos.Controls.Add(frmrpt);
            frmrpt.Show();
            splashScreenManager1.CloseWaitForm();
        }

        private void CONTROLGENERA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "Correlativos")
                {
                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                splashScreenManager1.ShowWaitForm();
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Ventas.frmControlGenera()
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill,
                    NModulo = e.Item.Name,
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "Correlativos";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void TIPOCP_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "Tipo De Documento")
                {
                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                splashScreenManager1.ShowWaitForm();
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Configuracion.frmTipoCp
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill,
                    NModulo = e.Item.Name,
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "Tipo De Documento";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void CBODMS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "Unilever Dms")
                {
                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                splashScreenManager1.ShowWaitForm();
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Reportes.Modulos.Ventas.Cubos.UnileverDms
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill,
                    //NModulo = e.Item.Name,
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "Unilever Dms";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void InformeDeReparto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
            splashScreenManager1.ShowWaitForm();
            var pedidos = new XtraTabPage();
            entidad.index = 0;
            var rpt = new RptInformeDeReparto();
            var frmrpt = new Modulos.Reportes.Modulos.Distribucion.FrmMostrarReporte();
            frmrpt.TopLevel = false;
            frmrpt.FormBorderStyle = FormBorderStyle.None;
            frmrpt.Dock = DockStyle.Fill;
            frmrpt.documentViewer1.DocumentSource = rpt;
            xtraTabControl1.TabPages.Add(pedidos);
            xtraTabControl1.SelectedTabPage = pedidos;
            pedidos.Text = "Informe De Reparto";
            entidad.index = xtraTabControl1.SelectedTabPageIndex;
            pedidos.Controls.Add(frmrpt);
            frmrpt.Show();
            splashScreenManager1.CloseWaitForm();
        }

        private void ListadoGeneralClase_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
            splashScreenManager1.ShowWaitForm();
            var pedidos = new XtraTabPage();
            entidad.index = 0;
            var rpt = new RptListadoGeneralSegunClase();
            var frmrpt = new Modulos.Reportes.Modulos.Distribucion.FrmMostrarReporte();
            frmrpt.TopLevel = false;
            frmrpt.FormBorderStyle = FormBorderStyle.None;
            frmrpt.Dock = DockStyle.Fill;
            frmrpt.documentViewer1.DocumentSource = rpt;
            xtraTabControl1.TabPages.Add(pedidos);
            xtraTabControl1.SelectedTabPage = pedidos;
            pedidos.Text = "Listado General Segun Clase";
            entidad.index = xtraTabControl1.SelectedTabPageIndex;
            pedidos.Controls.Add(frmrpt);
            frmrpt.Show();
            splashScreenManager1.CloseWaitForm();
        }

        private void CBOCOMPRAS_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "Compras")
                {
                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                splashScreenManager1.ShowWaitForm();
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Reportes.Modulos.Ventas.Cubos.frmCompras
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill,
                    //NModulo = e.Item.Name,
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "Compras";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void VENDEDORES_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "Vendedor")
                {
                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                splashScreenManager1.ShowWaitForm();
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Ventas.frmVendedor
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill,
                    NModulo = e.Item.Name,
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "Vendedor";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void AvanceCobertura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
                if (xtraTabControl1.TabPages[i].Text == "Avance Cobertura")
                {
                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            if (!existe)
            {
                splashScreenManager1.SplashFormStartPosition = SplashFormStartPosition.Default;
                splashScreenManager1.ShowWaitForm();
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Reportes.Modulos.Ventas.frmAvanceCliente
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill,
                    //NModulo = e.Item.Name,
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "Avance Cobertura";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
                splashScreenManager1.CloseWaitForm();
            }
        }
    }
}