using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xtraForm.Model;

namespace xtraForm.Modulos.Ventas
{
    public partial class frmMaestroDetalle : DevExpress.XtraEditors.XtraForm
    {
        public string fecha;
        public frmMaestroDetalle()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                gridControl1.DataSource = null;
                gridControl3.DataSource = null;
                var frmprincipal = new frmPrincipal();
                frmprincipal.splashScreenManager1.SplashFormStartPosition = DevExpress.XtraSplashScreen.SplashFormStartPosition.Default;
                frmprincipal.splashScreenManager1.ShowWaitForm();
                try
                {
                    var proceso = new Libreria.Proceso();
                    var Cadena = new List<string>();
                    var PedidosComprometidos = (dynamic)null;
                    var PedidosBonificados = (dynamic)null;
                    string Fecha = Convert.ToDateTime(dateEdit1.EditValue).ToString("dd/MM/yyyy");
                    using (var Context = new LiderEntities())
                    {
                        int Tipo = Context.Bonificacions.Where(x => x.PKID == (int)lookUpEdit1.EditValue).Select(c => c.TipoMecanica).FirstOrDefault();
                        var Coleccion = Context.ItemBonificacions.Distinct().Where(x => x.IDBonificacion == (int)lookUpEdit1.EditValue).Select(c => new { Codigo = c.cdProductoColeccion.Trim() }).ToList();
                        var Minimo = Context.Bonificacions.Where(x => x.PKID == (int)lookUpEdit1.EditValue).Select(c => c.CantidadMinima).FirstOrDefault();
                        var Maximo = Context.Bonificacions.Where(x => x.PKID == (int)lookUpEdit1.EditValue).Select(c => c.CantidadMaxima).FirstOrDefault();
                        foreach (var i in Coleccion)
                        {
                            Cadena.Add("'" + i.Codigo + "'");
                        }
                        string Producto = string.Join(",", Cadena.ToArray());
                        //Pedidos compromeditos
                        switch (Tipo)
                        {
                            case 1:

                                string sql1 = @"
                                SELECT        
                                dbo.Vva_ItemPedido.NrPedido AS Pedido, dbo.CLIENTE.Cliente AS [Codigo], dbo.CLIENTE.Alias AS [Nombre], SUM(dbo.Vva_ItemPedido.Cantidad) AS [Venta]
                                FROM           
                                dbo.CLIENTE INNER JOIN
                                dbo.Vva_Pedido ON dbo.CLIENTE.Cliente = dbo.Vva_Pedido.IDClient INNER JOIN
                                dbo.Vva_ItemPedido ON dbo.Vva_Pedido.NrPedido = dbo.Vva_ItemPedido.NrPedido
                                WHERE        (dbo.Vva_ItemPedido.IDProducto IN (" + Producto + @")) AND (dbo.Vva_Pedido.FechaEmision = '" + Fecha + @"')
                                GROUP BY dbo.CLIENTE.Cliente, dbo.CLIENTE.Alias, dbo.Vva_ItemPedido.NrPedido
                                HAVING        (SUM(dbo.Vva_ItemPedido.Cantidad) >=" + Minimo + @")
                                ";
                                proceso.consultar(sql1, "pedidos");
                                PedidosComprometidos = proceso.ds.Tables["pedidos"];//Context.Database.SqlQuery<List<string>>(sql).ToList();

                                break;
                            case 2:
                                string sql2 = @"
                                SELECT        
                                dbo.Vva_ItemPedido.NrPedido AS Pedido, RTRIM(dbo.CLIENTE.Cliente) AS Codigo, Rtrim(dbo.CLIENTE.Alias) AS Nombre, SUM(dbo.Vva_ItemPedido.Cantidad) AS Venta
                                FROM           
                                dbo.CLIENTE INNER JOIN
                                dbo.Vva_Pedido ON dbo.CLIENTE.Cliente = dbo.Vva_Pedido.IDClient INNER JOIN
                                dbo.Vva_ItemPedido ON dbo.Vva_Pedido.NrPedido = dbo.Vva_ItemPedido.NrPedido
                                WHERE        (dbo.Vva_ItemPedido.IDProducto IN (" + Producto + @")) AND (dbo.Vva_Pedido.FechaEmision = '" + Fecha + @"')
                                GROUP BY dbo.CLIENTE.Cliente, dbo.CLIENTE.Alias, dbo.Vva_ItemPedido.NrPedido
                                HAVING        (SUM(dbo.Vva_ItemPedido.Cantidad) >= " + Minimo + @") AND ((SUM(dbo.Vva_ItemPedido.Cantidad)) < " + Maximo + @")
                                ";
                                proceso.consultar(sql2, "pedidos");
                                PedidosComprometidos = proceso.ds.Tables["pedidos"];//Context.Database.SqlQuery<List<string>>(sql).ToList();
                                break;
                            case 3:
                                string sql3 = @"
                                SELECT        
                                dbo.Vva_ItemPedido.NrPedido AS Pedido, RTRIM(dbo.CLIENTE.Cliente) AS Codigo, Rtrim(dbo.CLIENTE.Alias) AS Nombre, SUM(dbo.Vva_ItemPedido.Cantidad*dbo.Vva_ItemPedido.Precio) AS Venta
                                FROM           
                                dbo.CLIENTE INNER JOIN
                                dbo.Vva_Pedido ON dbo.CLIENTE.Cliente = dbo.Vva_Pedido.IDClient INNER JOIN
                                dbo.Vva_ItemPedido ON dbo.Vva_Pedido.NrPedido = dbo.Vva_ItemPedido.NrPedido
                                WHERE        (dbo.Vva_ItemPedido.IDProducto IN (" + Producto + @")) AND (dbo.Vva_Pedido.FechaEmision = '" + Fecha + @"')
                                GROUP BY dbo.CLIENTE.Cliente, dbo.CLIENTE.Alias, dbo.Vva_ItemPedido.NrPedido
                                HAVING        ((SUM(dbo.Vva_ItemPedido.Cantidad*dbo.Vva_ItemPedido.Precio)) >= " + Minimo + @")
                                ";
                                proceso.consultar(sql3, "pedidos");
                                PedidosComprometidos = proceso.ds.Tables["pedidos"];//Context.Database.SqlQuery<List<string>>(sql).ToList();
                                break;
                            case 4:
                                string sql4 = @"
                                SELECT        
                                dbo.Vva_ItemPedido.NrPedido AS Pedido, RTRIM(dbo.CLIENTE.Cliente) AS Codigo, Rtrim(dbo.CLIENTE.Alias) AS Nombre, SUM(dbo.Vva_ItemPedido.Cantidad*dbo.Vva_ItemPedido.Precio) AS Venta
                                FROM           
                                dbo.CLIENTE INNER JOIN
                                dbo.Vva_Pedido ON dbo.CLIENTE.Cliente = dbo.Vva_Pedido.IDClient INNER JOIN
                                dbo.Vva_ItemPedido ON dbo.Vva_Pedido.NrPedido = dbo.Vva_ItemPedido.NrPedido
                                WHERE        (dbo.Vva_ItemPedido.IDProducto IN (" + Producto + @")) AND (dbo.Vva_Pedido.FechaEmision = '" + Fecha + @"')
                                GROUP BY dbo.CLIENTE.Cliente, dbo.CLIENTE.Alias, dbo.Vva_ItemPedido.NrPedido
                                HAVING        ((SUM(dbo.Vva_ItemPedido.Cantidad*dbo.Vva_ItemPedido.Precio)) >= " + Minimo + @") AND ((SUM(dbo.Vva_ItemPedido.Cantidad*dbo.Vva_ItemPedido.Precio)) < " + Maximo + @")
                                ";
                                proceso.consultar(sql4, "pedidos");
                                PedidosComprometidos = proceso.ds.Tables["pedidos"];//Context.Database.SqlQuery<List<string>>(sql).ToList();
                                break;
                        }
                        gridView1.OptionsBehavior.ReadOnly = true;
                        gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                        gridView1.OptionsBehavior.Editable = false;
                        gridView1.OptionsView.ColumnAutoWidth = false;
                        gridView1.OptionsView.ShowGroupPanel = false;
                        gridControl1.DataSource = PedidosComprometidos;
                        gridView1.BestFitColumns();

                        //pedidos bonificados
                        string sql0 = @"
                        SELECT        dbo.Vva_Pedido.NrPedido AS Pedido, RTRIM(dbo.Vva_Cliente.Codigo) As Codigo, Rtrim(dbo.Vva_Cliente.Nombre) As Nombre, dbo.Vva_ItemPedido.Cantidad As Bonificacion
                        FROM            dbo.Vva_Pedido INNER JOIN
                                                 dbo.Vva_ItemPedido ON dbo.Vva_Pedido.NrPedido = dbo.Vva_ItemPedido.NrPedido INNER JOIN
                                                 dbo.Vva_Cliente ON dbo.Vva_Pedido.IDClient = dbo.Vva_Cliente.Codigo INNER JOIN
                                                 dbo.Bonificacion ON dbo.Vva_ItemPedido.IDBonif = dbo.Bonificacion.PKID
                        WHERE        (dbo.Vva_Pedido.FechaEmision = '" + Fecha + @"') AND (dbo.Vva_ItemPedido.IDBonif = " + (int)lookUpEdit1.EditValue + @")
                        GROUP BY dbo.Vva_Pedido.NrPedido, dbo.Vva_Cliente.Codigo, dbo.Vva_Cliente.Nombre, dbo.Vva_ItemPedido.Cantidad
                                ";
                        proceso.consultar(sql0, "pedidos");
                        gridControl3.DataSource = proceso.ds.Tables["pedidos"];
                        gridView3.OptionsBehavior.ReadOnly = true;
                        gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
                        gridView3.OptionsBehavior.Editable = false;
                        gridView3.OptionsView.ColumnAutoWidth = false;
                        gridView3.BestFitColumns();
                        gridView3.OptionsView.ShowGroupPanel = false;
                    }
                    frmprincipal.splashScreenManager1.CloseWaitForm();
                    ContarA.Text = "Filas: " + gridView1.RowCount;
                    ContarB.Text = "Filas: " + gridView3.RowCount;
                }
                catch (DbEntityValidationException t)
                {
                    foreach (var eve in t.EntityValidationErrors)
                    {
                        foreach (var ve in eve.ValidationErrors)
                        {
                            MessageBox.Show("- Propiedad: \"" + ve.PropertyName + "\", Error: \"" + ve.ErrorMessage + "\"");
                        }
                    }
                }
            }
        }

        private void frmMaestroDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                using (var Context = new LiderEntities())
                {
                    var Bonif = from a in (from b in Context.Bonificacions
                                           join ib in Context.ItemBonificacions on b.PKID equals ib.IDBonificacion
                                           join pv in Context.PROVEEDORs on b.IDProveedor equals pv.Proveedor1
                                           where b.Activo == true
                                           select new { ID = b.PKID, pv.RazonSocial, b.Mecanica }).Distinct()
                                orderby a.RazonSocial
                                select new
                                {
                                    ID = a.ID,
                                    Proveedor = a.RazonSocial.Trim(),
                                    Mecanica = a.Mecanica
                                };
                    lookUpEdit1.Properties.ShowHeader = false;
                    lookUpEdit1.Properties.DisplayMember = "Mecanica";
                    lookUpEdit1.Properties.ValueMember = "ID";
                    lookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("Proveedor", string.Empty, 10));
                    lookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("Mecanica", string.Empty, 10));
                    lookUpEdit1.Properties.DataSource = Bonif.ToList();
                }
            }
            catch (DbEntityValidationException t)
            {
                foreach (var eve in t.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        MessageBox.Show("- Propiedad: \"" + ve.PropertyName + "\", Error: \"" + ve.ErrorMessage + "\"");
                    }
                }
            }

        }
    }
}