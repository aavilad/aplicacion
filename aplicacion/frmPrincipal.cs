using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTab;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace xtraForm
{
    public partial class frmPrincipal : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        Form objeto;
        Libreria.Entidad entidad = new Libreria.Entidad();
        Libreria.Proceso proceso = new Libreria.Proceso();
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
            {
                if (xtraTabControl1.TabPages[i].Text == "Reglas Bonificacion")
                {

                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            }
            if (!existe)
            {
                XtraTabPage promocion = new XtraTabPage();
                objeto = new Modulos.Ventas.frmPromocion
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                xtraTabControl1.TabPages.Add(promocion);
                xtraTabControl1.SelectedTabPage = promocion;
                promocion.Text = "Reglas Bonificacion";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                promocion.Controls.Add(objeto);
                objeto.Show();
            }

        }

        private void xtraTabControl1_HeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.HeaderButtonEventArgs e)
        {
            if (e.Button == TabButtons.Close)
            {
                xtraTabControl1.TabPages.Remove(e.ActivePage as XtraTabPage);
            }
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
            {
                if (xtraTabControl1.TabPages[i].Text == "pedidos")
                {

                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            }
            if (!existe)
            {
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Ventas.frmPedido
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "pedidos";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
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
            //
            Libreria.Proceso proceso = new Libreria.Proceso();
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
            {
                if (xtraTabControl1.TabPages[i].Text == "Pesos SF")
                {

                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
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
            {
                if (xtraTabControl1.TabPages[i].Text == "Comprobantes")
                {

                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            }
            if (!existe)
            {
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Elementos.frmComprobantes
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                xtraTabControl1.TabPages.Add(pedidos);
                xtraTabControl1.SelectedTabPage = pedidos;
                pedidos.Text = "Comprobantes";
                entidad.index = xtraTabControl1.SelectedTabPageIndex;
                pedidos.Controls.Add(objeto);
                objeto.Show();
            }
        }

        private void btnNotasCredito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool existe = false;
            for (int i = 0; i < xtraTabControl1.TabPages.Count; i++)
            {
                if (xtraTabControl1.TabPages[i].Text == "Notas De Credito")
                {

                    xtraTabControl1.SelectedTabPage = xtraTabControl1.TabPages[i];
                    existe = true;
                }
            }
            if (!existe)
            {
                XtraTabPage pedidos = new XtraTabPage();
                entidad.index = 0;
                objeto = new Modulos.Ventas.frmNotasCredito
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
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
            Filtros.frmProcesar frmbonificar = new Filtros.frmProcesar();
            proceso.consultar("select [Fuerza Ventas], [Codigo Vendedor], [Nombre Vendedor] from Vva_Vendedor","vendedor");
            frmbonificar.gridControl1.DataSource = proceso.ds.Tables["vendedor"];
            frmbonificar.gridView1.OptionsView.ShowGroupPanel = false;
            frmbonificar.gridView1.Columns["Fuerza Ventas"].GroupIndex = 1;
            frmbonificar.gridView1.GroupRowHeight = 1;
            frmbonificar.gridView1.OptionsSelection.MultiSelect = true;
            frmbonificar.gridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            frmbonificar.gridView1.RowHeight = 1;
            frmbonificar.gridView1.Appearance.Row.FontSizeDelta = 0;
            frmbonificar.gridView1.BestFitColumns();
            frmbonificar.StartPosition = FormStartPosition.CenterScreen;
            frmbonificar.Show();
        }
    }
}