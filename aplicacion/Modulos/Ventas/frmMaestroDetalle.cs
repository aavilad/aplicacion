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

namespace xtraForm.Modulos.Ventas
{
    public partial class frmMaestroDetalle : DevExpress.XtraEditors.XtraForm
    {
        public string fecha;
        Libreria.Proceso proceso = new Libreria.Proceso();
        public frmMaestroDetalle()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate())
            {
                var frmprincipal = new frmPrincipal();
                frmprincipal.splashScreenManager1.SplashFormStartPosition = DevExpress.XtraSplashScreen.SplashFormStartPosition.Default;
                frmprincipal.splashScreenManager1.ShowWaitForm();
                try
                {
                    var Cadena = new List<string>();
                    var PedidosComprometidos = (dynamic)null;
                    var PedidosBonificados = (dynamic)null;
                    string Fecha = Convert.ToDateTime(dateEdit1.EditValue).ToString("dd/MM/yyyy");
                    using (var Context = new Model.LiderAppEntities())
                    {
                        int Tipo = Context.Bonificacion.Where(x => x.PKID == (int)lookUpEdit1.EditValue).Select(c => c.TipoMecanica).FirstOrDefault();
                        var Coleccion = Context.ItemBonificacion.Distinct().Where(x => x.IDBonificacion == (int)lookUpEdit1.EditValue).Select(c => new { Codigo = c.cdProductoColeccion.Trim() }).ToList();
                        var Minimo = Context.Bonificacion.Where(x => x.PKID == (int)lookUpEdit1.EditValue).Select(c => c.CantidadMinima).FirstOrDefault();
                        var Maximo = Context.Bonificacion.Where(x => x.PKID == (int)lookUpEdit1.EditValue).Select(c => c.CantidadMaxima).FirstOrDefault();
                        foreach (var i in Coleccion)
                        {
                            Cadena.Add("'" + i.Codigo + "'");
                        }
                        string Producto = string.Join(",", Cadena.ToArray());
                        //Pedidos compromeditos
                        switch (Tipo)
                        {
                            case 1:
                                PedidosComprometidos = (from p in Context.Vva_Pedido.AsEnumerable()
                                                        join ip in Context.Vva_ItemPedido.AsEnumerable() on p.NrPedido equals ip.NrPedido
                                                        join cl in Context.CLIENTE.AsEnumerable() on p.IDClient equals cl.Cliente1
                                                        where p.FechaEmision == DateTime.Parse(Fecha) && Producto.Contains(ip.IDProducto)
                                                        && ip.Cantidad >= Convert.ToDecimal(Minimo)
                                                        select new
                                                        {
                                                            Pedido = p.NrPedido.Trim(),
                                                            Codigo_Cliente = cl.Cliente1.Trim(),
                                                            Nombre_Cliente = cl.Alias.Trim(),
                                                            Cantidad_vendida = Convert.ToDecimal(ip.Cantidad)
                                                        }).ToList();
                                break;
                            case 2:
                                PedidosComprometidos = (from p in Context.Vva_Pedido.AsEnumerable()
                                                        join ip in Context.Vva_ItemPedido.AsEnumerable() on p.NrPedido equals ip.NrPedido
                                                        join cl in Context.CLIENTE.AsEnumerable() on p.IDClient equals cl.Cliente1
                                                        where p.FechaEmision == DateTime.Parse(Fecha) && Producto.Contains(ip.IDProducto)
                                                        && ip.Cantidad >= Convert.ToDecimal(Minimo) && ip.Cantidad < Convert.ToInt32(Maximo)
                                                        select new
                                                        {
                                                            Pedido = p.NrPedido.Trim(),
                                                            Codigo_Cliente = cl.Cliente1.Trim(),
                                                            Nombre_Cliente = cl.Alias.Trim(),
                                                            Cantidad_vendida = Convert.ToDecimal(ip.Cantidad)
                                                        }).ToList();
                                break;
                            case 3:
                                PedidosComprometidos = (from p in Context.Vva_Pedido.AsEnumerable()
                                                        join ip in Context.Vva_ItemPedido.AsEnumerable() on p.NrPedido equals ip.NrPedido
                                                        join cl in Context.CLIENTE.AsEnumerable() on p.IDClient equals cl.Cliente1
                                                        where p.FechaEmision == DateTime.Parse(Fecha) && Producto.Contains(ip.IDProducto)
                                                        && ip.Cantidad * ip.Precio >= Convert.ToDecimal(Minimo)
                                                        select new
                                                        {
                                                            Pedido = p.NrPedido.Trim(),
                                                            Codigo_Cliente = cl.Cliente1.Trim(),
                                                            Nombre_Cliente = cl.Alias.Trim(),
                                                            Cantidad_vendida = Convert.ToDecimal(ip.Cantidad * ip.Precio)
                                                        }).ToList();
                                break;
                            case 4:
                                PedidosComprometidos = (from p in Context.Vva_Pedido.AsEnumerable()
                                                        join ip in Context.Vva_ItemPedido.AsEnumerable() on p.NrPedido equals ip.NrPedido
                                                        join cl in Context.CLIENTE.AsEnumerable() on p.IDClient equals cl.Cliente1
                                                        where p.FechaEmision == DateTime.Parse(Fecha) && Producto.Contains(ip.IDProducto)
                                                        && ip.Cantidad * ip.Precio >= Convert.ToDecimal(Minimo) && ip.Cantidad * ip.Precio < Convert.ToDecimal(Maximo)
                                                        select new
                                                        {
                                                            Pedido = p.NrPedido.Trim(),
                                                            Codigo_Cliente = cl.Cliente1.Trim(),
                                                            Nombre_Cliente = cl.Alias.Trim(),
                                                            Cantidad_vendida = Convert.ToDecimal(ip.Cantidad * ip.Precio)
                                                        }).ToList();
                                break;
                        }
                        gridControl1.DataSource = PedidosComprometidos;
                        gridView1.OptionsBehavior.ReadOnly = true;
                        gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
                        gridView1.OptionsBehavior.Editable = false;
                        gridView1.OptionsView.ColumnAutoWidth = false;
                        gridView1.BestFitColumns();
                        gridView1.OptionsView.ShowGroupPanel = false;
                        //pedidos bonificados
                        PedidosBonificados = (from p in Context.Vva_Pedido.AsEnumerable()
                                              join ip in Context.Vva_ItemPedido.AsEnumerable() on p.NrPedido equals ip.NrPedido
                                              join b in Context.Bonificacion.AsEnumerable() on ip.IDBonif equals b.PKID
                                              join cl in Context.CLIENTE.AsEnumerable() on p.IDClient equals cl.Cliente1
                                              where b.PKID == (int)lookUpEdit1.EditValue && p.FechaEmision == DateTime.Parse(Fecha)
                                              select new
                                              {
                                                  Pedido = p.NrPedido.Trim(),
                                                  Codigo_Cliente = cl.Cliente1.Trim(),
                                                  Nombre_Cliente = cl.Alias.Trim(),
                                                  Cantidad_Bonificada = ip.Cantidad
                                              }).ToList();
                        gridControl3.DataSource = PedidosBonificados;
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
                using (var Context = new Model.LiderAppEntities())
                {
                    var Bonif = from a in (from b in Context.Bonificacion
                                           join ib in Context.ItemBonificacion on b.PKID equals ib.IDBonificacion
                                           join pv in Context.PROVEEDOR on b.IDProveedor equals pv.Proveedor1
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
                    lookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("Proveedor", "", 10));
                    lookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("Mecanica", "", 10));
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